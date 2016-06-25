using GalaSoft.MvvmLight;
using System.Collections.Generic;
using System;
using BencodeNET.Objects;
using BencodeNET;
using System.Text;
using System.Linq;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Command;
using TransmissionRemote.RPC.Arguments;
using System.IO;

namespace TransmissionFluid.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class AddTorrentViewModel : ViewModelBase
    {

        private ObservableCollection<Model.TorrentFileName> _TorrentFiles;
        public ObservableCollection<Model.TorrentFileName> TorrentFiles
        {
            get { return _TorrentFiles; }
            set { Set(ref _TorrentFiles, value); }
        }

        private TorrentFile _TorrentFile;
        public TorrentFile TorrentFile
        {
            get { return _TorrentFile; }
            set { Set(ref _TorrentFile, value); }
        }

        private string _MetaInfo;
        public string MetaInfo
        {
            get { return _MetaInfo; }
            set { Set(ref _MetaInfo, value); }
        }

        private string _DownloadDir;
        public string DownloadDir
        {
            get { return _DownloadDir; }
            set { Set(ref _DownloadDir, value); }
        }

        private List<string> _RecentDownloadDir;
        public List<string> RecentDownloadDir
        {
            get { return _RecentDownloadDir; }
            set { Set(ref _RecentDownloadDir, value); }
        }

        private int _PeerLimit;
        public int PeerLimit
        {
            get { return _PeerLimit; }
            set { Set(ref _PeerLimit, value); }
        }

        private bool _StartImmediate;
        public bool StartImmediate
        {
            get { return _StartImmediate; }
            set { Set(ref _StartImmediate, value); }
        }

        public long TotalSize
        {
            get
            {
                if (this.TorrentFiles != null)
                    return this.TorrentFiles.Sum(x => x.Size);
                return long.MinValue;
            }
        }

        public long SelectedSize
        {
            get
            {
                if (this.TorrentFiles != null)
                    return this.TorrentFiles.Where(x => x.IsWanted).Sum(x => x.Size);
                return long.MinValue;
            }
        }

        private string _TorrentComment;
        public string TorrentComment
        {
            get { return _TorrentComment; }
            set { Set(ref _TorrentComment, value); }
        }

        public DateTime _TorrentDate;
        public DateTime TorrentDate
        {
            get { return _TorrentDate; }
            set { Set(ref _TorrentDate, value); }
        }

        private string _TorrentName;
        public string TorrentName
        {
            get { return _TorrentName; }
            set { Set(ref _TorrentName, value); }
        }

        private string _TorrentCreatedBy;
        public string TorrentCreatedBy
        {
            get { return _TorrentCreatedBy; }
            set { Set(ref _TorrentCreatedBy, value); }
        }

        private RelayCommand _SelectAllCommand;
        /// <summary>
        /// Gets the SelectAllCommand.
        /// </summary>
        public RelayCommand SelectAllCommand
        {
            get
            {
                return _SelectAllCommand
                    ?? (_SelectAllCommand = new RelayCommand(
                    () =>
                    {
                        foreach (var item in this.TorrentFiles)
                        {
                            item.IsWanted = true;
                        }
                        RaisePropertyChanged("SelectedSize");
                    }));
            }
        }

        private RelayCommand _SelectNoneCommand;
        /// <summary>
        /// Gets the SelectNoneCommand.
        /// </summary>
        public RelayCommand SelectNoneCommand
        {
            get
            {
                return _SelectNoneCommand
                    ?? (_SelectNoneCommand = new RelayCommand(
                    () =>
                    {

                        foreach (var item in this.TorrentFiles)
                        {
                            item.IsWanted = false;
                        }
                        RaisePropertyChanged("SelectedSize");
                    }));
            }
        }


        private RelayCommand _WantedChangedCommand;

        /// <summary>
        /// Gets the WantedChangedCommand.
        /// </summary>
        public RelayCommand WantedChangedCommand
        {
            get
            {
                return _WantedChangedCommand
                    ?? (_WantedChangedCommand = new RelayCommand(
                    () =>
                    {
                        RaisePropertyChanged("SelectedSize");
                    }));
            }
        }

        
        private RelayCommand _ConfirmAddCommand;

        /// <summary>
        /// Gets the ConfirmAddCommand.
        /// </summary>
        public RelayCommand ConfirmAddCommand
        {
            get
            {
                return _ConfirmAddCommand
                    ?? (_ConfirmAddCommand = new RelayCommand(
                    () =>
                    {
                        if (!SettingsManager.Instance.Settings.RecentFolders.Contains(this.DownloadDir))
                            SettingsManager.Instance.Settings.RecentFolders.Add(this.DownloadDir);

                        var args = new AddTorrentArguments();
                        args.MetaInfo = this.MetaInfo;
                        args.DownloadDir = this.DownloadDir;
                        args.BandwidthPriority = 2;
                        args.PeerLimit = this.PeerLimit;

                        List<int> wanted = new List<int>();
                        List<int> unwanted = new List<int>();

                        for (int i = 0; i < this.TorrentFiles.Count; i++)
                        {
                            if (this.TorrentFiles[i].IsWanted)
                                wanted.Add(i);
                            else
                                unwanted.Add(i);
                        }

                        args.FilesWanted = wanted.ToArray();
                        args.FilesUnwanted = unwanted.ToArray();
                        args.Paused = this.StartImmediate;
                        
                    }));
            }
        }



        /// <summary>
        /// Initializes a new instance of the AddTorrentViewModel class.
        /// </summary>
        public AddTorrentViewModel()
        {
            this.TorrentFiles = new ObservableCollection<Model.TorrentFileName>();
            this.TorrentFiles.CollectionChanged += (s, e) =>
            {
                RaisePropertyChanged("SelectedSize");
                RaisePropertyChanged("TotalSize");
            };

            this.RecentDownloadDir = SettingsManager.Instance.Settings.RecentFolders;
        }

        public override void Cleanup()
        {

            base.Cleanup();
        }

        public void ReadTorrentFile(string localfile)
        {
            TorrentFile torrent = Bencode.DecodeTorrentFile(localfile);
            
            Byte[] bytes = File.ReadAllBytes(localfile);
            String base64string = Convert.ToBase64String(bytes);
            this.MetaInfo = base64string;

            if (torrent.Info.ContainsKey("name"))
                this.TorrentName = ((BString)torrent.Info["name"]).ToString(Encoding.UTF8);

            this.TorrentComment = torrent.Comment;
            this.TorrentCreatedBy = torrent.CreatedBy;
            this.TorrentDate = torrent.CreationDate;

            long piecelen = (BNumber)torrent.Info["piece length"];
            //var pieces = (BList)torrent.Info["pieces"];

            ObservableCollection<Model.TorrentFileName> filelist = new ObservableCollection<Model.TorrentFileName>();

            if (torrent.Info.ContainsKey("files"))
            {
                BList files = (BList)torrent.Info["files"];

                foreach (BDictionary file in files)
                {
                    GetTorrentFileList(filelist, file);
                }

            }
            else
            {
                GetTorrentFileList(filelist, torrent.Info);
            }

            this.TorrentFiles = filelist;
            RaisePropertyChanged("SelectedSize");
            RaisePropertyChanged("TotalSize");
        }

        private static void GetTorrentFileList(IList<Model.TorrentFileName> filelist, BDictionary file)
        {
            // File size in bytes (BNumber has implicit conversion to int and long)
            long size = (BNumber)file["length"];

            // List of all parts of the file path. 'dir1/dir2/file.ext' => dir1, dir2 and file.ext
            BList path = (BList)file["path"];

            string fullpath = String.Join("\\", path);

            // Last element is the file name
            BString fileName = (BString)path.Last();

            // Converts fileName (BString = bytes) to a string
            string fileNameString = fileName.ToString(Encoding.UTF8);

            var tf = new Model.TorrentFileName();
            tf.Name = fileNameString;
            tf.Size = size;
            tf.Path = fullpath;
            tf.IsWanted = true;

            filelist.Add(tf);
        }
    }
}