using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TransmissionRemote.RPC;
using System.Diagnostics;
using System.Linq;

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
    }
}
