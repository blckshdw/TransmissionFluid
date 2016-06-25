using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TransmissionRemote.RPC;
using System.Diagnostics;
using System.Linq;
using BencodeNET;
using BencodeNET.Objects;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TransmissionRemote.RPC.Tests
{
    [TestClass]
    public class UnitTest1
    {
        public const string Host = "172.30.0.1";
        [TestMethod]
        public void GetSession()
        {
            var client = new Client(Host);
            var result = client.GetSession();

            Assert.IsTrue(result.RpcVersion >= 8);
        }

        [TestMethod]
        public void GetSessionStats()
        {
            var client = new Client(Host);
            var result = client.GetSessionStats();

            Assert.IsTrue(result.TorrentCount > 0);
        }

        [TestMethod]
        public void GetRecentTorrents()
        {
            var client = new Client(Host);
            var result = client.GetRecentTorrents();

            Assert.IsTrue(result.Count() > 0);

        }

        [TestMethod]
        public void GetTorrents()
        {
            int[] ids = { 1, 2, 3 };
            var client = new Client(Host);
            var result = client.GetTorrent(ids);

            Assert.IsTrue(result.Count() == 3);
        }

        [TestMethod]
        public void GetTorrent()
        {
            var client = new Client(Host);
            var torrent = client.GetTorrent(1);

            Assert.IsTrue(torrent.Id == 1);
        }

        [TestMethod]
        public void StartTorrent()
        {
            var client = new Client(Host);
            var result = client.StartTorrent(new int[] { 1 });

            Assert.IsTrue(result.Result == "success");
        }


        [TestMethod]
        public void StoptTorrent()
        {
            var client = new Client(Host);
            var result = client.StopTorrent(new int[] { 1 });
            
            Assert.IsTrue(result.Result == "success");
        }

        [TestMethod]
        public void ReAnnounceTorrent()
        {
            var client = new Client(Host);
            var result = client.ReannounceTorrent(new int[] { 1 });
            
            Assert.IsTrue(result.Result == "success");
        }

        [TestMethod]
        public void VerifyTorrent()
        {
            var client = new Client(Host);
            var result = client.VerifyTorrent(new int[] { 1 });
            
            Assert.IsTrue(result.Result == "success");
        }

        [TestMethod]
        public void ReadLocalTorrentFile()
        {
            bool isMultiFile;
            //string file = @"C:\Users\dan.PARADOX\Downloads\ubuntu-14.10-desktop-amd64.iso.torrent";
            string localfile = @"C:\Users\dan.PARADOX\Downloads\[kat.cr]deadpool.2016.1080p.bluray.x264.dts.jyk.torrent";
            TorrentFile torrent = Bencode.DecodeTorrentFile(localfile);

            List<string> filelist = new List<string>();

            if (torrent.Info.ContainsKey("files"))
            {
                BList files = (BList)torrent.Info["files"];

                foreach (BDictionary file in files)
                {
                    //http://stackoverflow.com/questions/32067409/decode-bencode-torrent-files                    

                    // File size in bytes (BNumber has implicit conversion to int and long)
                    int size = (BNumber)file["length"];

                    // List of all parts of the file path. 'dir1/dir2/file.ext' => dir1, dir2 and file.ext
                    BList path = (BList)file["path"];

                    string fullpath = String.Join("|",path);

                    // Last element is the file name
                    BString fileName = (BString)path.Last();

                    // Converts fileName (BString = bytes) to a string
                    string fileNameString = fileName.ToString(Encoding.UTF8);
                }

            } else 
            {
                filelist.Add(torrent.Info["name"].ToString());
            }

        }

        [TestMethod]
        public void AddTorrent()
        {
            string fileName = @"C:\Users\dan.PARADOX\Downloads\[kat.cr]deadpool.2016.1080p.bluray.x264.dts.jyk.torrent";
            Arguments.AddTorrentArguments args = new Arguments.AddTorrentArguments();
            args.ReadMetaInfo(fileName);
            args.Paused = true;
            args.FilesWanted = new int[] { 1,2 };
            args.FilesUnwanted = new int[] { 0, 3, 4, 5, 6 };
            args.PriorityHigh = new int[] { 1 };
            args.PriorityLow = new int[] { 2 };
            args.PeerLimit = 1;
            args.DownloadDir = "/tmp/";

            var client = new Client(Host);
            var result = client.AddTorrent(args);

            Assert.IsTrue(result.Id >= 0);
        }
    }
}
