using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransmissionRemote.RPC
{
    public class FileStat
    {

        [JsonProperty("bytesCompleted")]
        public ulong BytesCompleted { get; set; }

        [JsonProperty("priority")]
        public int Priority { get; set; }

        [JsonProperty("wanted")]
        public bool Wanted { get; set; }
    }

    public class File
    {

        [JsonProperty("bytesCompleted")]
        public ulong BytesCompleted { get; set; }

        [JsonProperty("length")]
        public ulong Length { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
    public class Peer
    {

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("clientIsChoked")]
        public bool ClientIsChoked { get; set; }

        [JsonProperty("clientIsInterested")]
        public bool ClientIsInterested { get; set; }

        [JsonProperty("clientName")]
        public string ClientName { get; set; }

        [JsonProperty("flagStr")]
        public string FlagStr { get; set; }

        [JsonProperty("isDownloadingFrom")]
        public bool IsDownloadingFrom { get; set; }

        [JsonProperty("isEncrypted")]
        public bool IsEncrypted { get; set; }

        [JsonProperty("isIncoming")]
        public bool IsIncoming { get; set; }

        [JsonProperty("isUploadingTo")]
        public bool IsUploadingTo { get; set; }

        [JsonProperty("peerIsChoked")]
        public bool PeerIsChoked { get; set; }

        [JsonProperty("peerIsInterested")]
        public bool PeerIsInterested { get; set; }

        [JsonProperty("port")]
        public int Port { get; set; }

        [JsonProperty("progress")]
        public double Progress { get; set; }

        /// <summary>
        /// (B/s)
        /// </summary>
        [JsonProperty("rateToClient")]
        public int RateToClient { get; set; }

        /// <summary>
        /// (B/s)
        /// </summary>
        [JsonProperty("rateToPeer")]
        public int RateToPeer { get; set; }
    }
    public class PeersFrom
    {

        [JsonProperty("fromCache")]
        public float FromCache { get; set; }

        [JsonProperty("fromDht")]
        public float FromDht { get; set; }

        [JsonProperty("fromIncoming")]
        public float FromIncoming { get; set; }

        [JsonProperty("fromLtep")]
        public float FromLtep { get; set; }

        [JsonProperty("fromPex")]
        public float FromPex { get; set; }

        [JsonProperty("fromTracker")]
        public float FromTracker { get; set; }
    }

    public class TrackerStat
    {

        [JsonProperty("announce")]
        public string Announce { get; set; }

        [JsonProperty("announceState")]
        public float AnnounceState { get; set; }

        [JsonProperty("downloadCount")]
        public float DownloadCount { get; set; }

        [JsonProperty("hasAnnounced")]
        public bool HasAnnounced { get; set; }

        [JsonProperty("hasScraped")]
        public bool HasScraped { get; set; }

        [JsonProperty("host")]
        public string Host { get; set; }

        [JsonProperty("id")]
        public float Id { get; set; }

        [JsonProperty("isBackup")]
        public bool IsBackup { get; set; }

        [JsonProperty("lastAnnouncePeerCount")]
        public float LastAnnouncePeerCount { get; set; }

        [JsonProperty("lastAnnounceResult")]
        public string LastAnnounceResult { get; set; }

        [JsonProperty("lastAnnounceStartTime")]
        public float LastAnnounceStartTime { get; set; }

        [JsonProperty("lastAnnounceSucceeded")]
        public bool LastAnnounceSucceeded { get; set; }

        [JsonProperty("lastAnnounceTime")]
        public float LastAnnounceTime { get; set; }

        [JsonProperty("lastAnnounceTimedOut")]
        public bool LastAnnounceTimedOut { get; set; }

        [JsonProperty("lastScrapeResult")]
        public string LastScrapeResult { get; set; }

        [JsonProperty("lastScrapeStartTime")]
        public float LastScrapeStartTime { get; set; }

        [JsonProperty("lastScrapeSucceeded")]
        public bool LastScrapeSucceeded { get; set; }

        [JsonProperty("lastScrapeTime")]
        public float LastScrapeTime { get; set; }

        [JsonProperty("leecherCount")]
        public float LeecherCount { get; set; }

        [JsonProperty("nextAnnounceTime")]
        public float NextAnnounceTime { get; set; }

        [JsonProperty("nextScrapeTime")]
        public float NextScrapeTime { get; set; }

        [JsonProperty("scrapeState")]
        public float ScrapeState { get; set; }

        [JsonProperty("seederCount")]
        public float SeederCount { get; set; }

        [JsonProperty("tier")]
        public float Tier { get; set; }
    }

    public class Tracker
    {

        [JsonProperty("announce")]
        public string Announce { get; set; }

        [JsonProperty("id")]
        public float Id { get; set; }

        [JsonProperty("scrape")]
        public string Scrape { get; set; }

        [JsonProperty("tier")]
        public float Tier { get; set; }
    }

    public class Torrent : NotifyBase
    {
        public event EventHandler TorrentCompleted;

        private long _UnixActivityDate;
        [JsonProperty("activityDate")]
        public long UnixActivityDate
        {
            get { return _UnixActivityDate; }
            set
            {
                SetProperty(ref _UnixActivityDate, value);
            }
        }

        [JsonIgnore]
        public DateTime? ActivityDate
        {
            get
            {
                if (this.UnixActivityDate > 0)
                {
                    DateTimeOffset dto = DateTimeOffset.FromUnixTimeSeconds(this.UnixActivityDate);
                    return dto.LocalDateTime;
                }
                return null;
            }
        }

        private long _UnixDateAdded;
        [JsonProperty("addedDate")]
        public long UnixDateAdded
        {
            get { return _UnixDateAdded; }
            set
            {
                SetProperty(ref _UnixDateAdded, value);
                OnPropertyChanged("DateAdded");
            }
        }

        [JsonIgnore]
        public DateTime? DateAdded
        {
            get
            {
                if (this.UnixDateAdded > 0)
                {
                    DateTimeOffset dto = DateTimeOffset.FromUnixTimeSeconds(this.UnixDateAdded);
                    return dto.LocalDateTime;
                }
                return null;
            }
        }

        private float _BandwidthPriority;
        [JsonProperty("bandwidthPriority")]
        public float BandwidthPriority
        {
            get { return _BandwidthPriority; }
            set
            {
                SetProperty(ref _BandwidthPriority, value);
            }
        }

        private string _Comment;
        [JsonProperty("comment")]
        public string Comment
        {
            get { return _Comment; }
            set
            {
                SetProperty(ref _Comment, value);
            }
        }

        private ulong _CorruptEver;
        [JsonProperty("corruptEver")]
        public ulong CorruptEver
        {
            get { return _CorruptEver; }
            set
            {
                SetProperty(ref _CorruptEver, value);
            }
        }

        private string _Creator;
        [JsonProperty("creator")]
        public string Creator
        {
            get { return _Creator; }
            set
            {
                SetProperty(ref _Creator, value);
            }
        }

        private long _UnixDateCreated;
        [JsonProperty("dateCreated")]
        public long UnixDateCreated
        {
            get { return _UnixDateCreated; }
            set
            {
                SetProperty(ref _UnixDateCreated, value);
                OnPropertyChanged("UnixDateCreated");
                OnPropertyChanged("DateCreated");
            }
        }

        [JsonIgnore]
        public DateTime? DateCreated
        {
            get
            {
                if (this.UnixDateCreated > 0)
                {
                    DateTimeOffset dto = DateTimeOffset.FromUnixTimeSeconds(this.UnixDateCreated);
                    return dto.LocalDateTime;
                }
                return null;
            }
        }

        private ulong _DesiredAvailable;
        [JsonProperty("desiredAvailable")]
        public ulong DesiredAvailable
        {
            get { return _DesiredAvailable; }
            set
            {
                SetProperty(ref _DesiredAvailable, value);
            }
        }

        private long _UnixDoneDate;
        [JsonProperty("doneDate")]
        public long UnixDoneDate
        {
            get { return _UnixDoneDate; }
            set
            {
                SetProperty(ref _UnixDoneDate, value);
                OnPropertyChanged("UnixDoneDate");
                OnPropertyChanged("DateDone");
            }
        }

        [JsonIgnore]
        public DateTime? DateDone
        {
            get
            {
                if (this.UnixDoneDate > 0)
                {
                    DateTimeOffset dto = DateTimeOffset.FromUnixTimeSeconds(this.UnixDoneDate);
                    return dto.LocalDateTime;
                }
                return null;
            }
        }

        private string _DownloadDir;
        [JsonProperty("downloadDir")]
        public string DownloadDir
        {
            get { return _DownloadDir; }
            set
            {
                SetProperty(ref _DownloadDir, value);
            }
        }

        private float _DownloadLimit;
        [JsonProperty("downloadLimit")]
        public float DownloadLimit
        {
            get { return _DownloadLimit; }
            set
            {
                SetProperty(ref _DownloadLimit, value);
            }
        }

        private bool _DownloadLimited;
        [JsonProperty("downloadLimited")]
        public bool DownloadLimited
        {
            get { return _DownloadLimited; }
            set
            {
                SetProperty(ref _DownloadLimited, value);
            }
        }

        private ulong _DownloadedEver;
        [JsonProperty("downloadedEver")]
        public ulong DownloadedEver
        {
            get { return _DownloadedEver; }
            set
            {
                SetProperty(ref _DownloadedEver , value);
            }
        }

        private float _ErrorCode;
        [JsonProperty("error")]
        public float ErrorCode
        {
            get { return _ErrorCode; }
            set
            {
                SetProperty(ref _ErrorCode , value);
                OnPropertyChanged("Error");
            }
        }

        public TorrentError Error
        {
            get { return (TorrentError)this.ErrorCode; }
        }

        private string _ErrorString;
        [JsonProperty("errorString")]
        public string ErrorString
        {
            get { return _ErrorString; }
            set
            {
                SetProperty(ref _ErrorString, value);
            }
        }

        public const int TR_ETA_NOT_AVAIL = -1;
        public const int TR_ETA_UNKNOWN = -2;
        private int _Eta;
        /// <summary>
        /// Estimated number of seconds left until the torrent is done.  
        /// -1 TR_ETA_NOT_AVAIL
        /// -2 TR_ETA_UNKNOWN.
        /// </summary>
        [JsonProperty("eta")]
        public int Eta
        {
            get { return _Eta; }
            set
            {
                SetProperty(ref _Eta, value);
                OnPropertyChanged("EtaTimeSpan");
            }
        }
        
        [JsonIgnore]
        public TimeSpan? EtaTimeSpan
        {
            get
            {
                if (this.Eta > 0)
                {
                    return TimeSpan.FromSeconds(this.Eta);
                }
                return null;
            }
        }

        private float _EtaIdle;
        [JsonProperty("etaIdle")]
        public float EtaIdle
        {
            get { return _EtaIdle; }
            set
            {
                SetProperty(ref _EtaIdle, value);
            }
        }

        private IList<FileStat> _FileStats;
        [JsonProperty("fileStats")]
        public IList<FileStat> FileStats
        {
            get { return _FileStats; }
            set
            {
                SetProperty(ref _FileStats, value);
            }
        }

        private IList<File> _Files;
        [JsonProperty("files")]
        public IList<File> Files
        {
            get { return _Files; }
            set
            {
                SetProperty(ref _Files, value);
            }
        }

        private string _HashString;
        [JsonProperty("hashString")]
        public string HashString
        {
            get { return _HashString; }
            set
            {
                SetProperty(ref _HashString, value);
            }
        }

        private float _HaveUnchecked;
        [JsonProperty("haveUnchecked")]
        public float HaveUnchecked
        {
            get { return _HaveUnchecked; }
            set
            {
                SetProperty(ref _HaveUnchecked, value);
            }
        }

        private ulong _HaveValid;
        [JsonProperty("haveValid")]
        public ulong HaveValid
        {
            get { return _HaveValid; }
            set
            {
                SetProperty(ref _HaveValid, value);
            }
        }

        private bool _HonorsSessionLimits;
        [JsonProperty("honorsSessionLimits")]
        public bool HonorsSessionLimits
        {
            get { return _HonorsSessionLimits; }
            set
            {
                SetProperty(ref _HonorsSessionLimits, value);
            }
        }

        private int _Id;
        [JsonProperty("id")]
        public int Id
        {
            get { return _Id; }
            set
            {
                SetProperty(ref _Id, value);
            }
        }

        private bool _IsFinished;
        [JsonProperty("isFinished")]
        public bool IsFinished
        {
            get { return _IsFinished; }
            set
            {
                if (SetProperty(ref _IsFinished, value) && _IsFinished)
                {
                    var handler = TorrentCompleted;
                    if (handler != null)
                        handler(this, new EventArgs());
                }
            }
        }

        private bool _IsPrivate;
        [JsonProperty("isPrivate")]
        public bool IsPrivate
        {
            get { return _IsPrivate; }
            set
            {
                SetProperty(ref _IsPrivate, value);
            }
        }

        private bool _IsStalled;
        [JsonProperty("isStalled")]
        public bool IsStalled
        {
            get { return _IsStalled; }
            set
            {
                SetProperty(ref _IsStalled, value);
            }
        }

        private ulong _LeftUntilDone;
        [JsonProperty("leftUntilDone")]
        public ulong LeftUntilDone
        {
            get { return _LeftUntilDone; }
            set
            {
                SetProperty(ref _LeftUntilDone, value);
            }
        }

        private string _MagnetLink;
        [JsonProperty("magnetLink")]
        public string MagnetLink
        {
            get { return _MagnetLink; }
            set
            {
                SetProperty(ref _MagnetLink, value);
            }
        }

        private float _ManualAnnounceTime;
        [JsonProperty("manualAnnounceTime")]
        public float ManualAnnounceTime
        {
            get { return _ManualAnnounceTime; }
            set
            {
                SetProperty(ref _ManualAnnounceTime, value);
            }
        }

        private float _MaxConnectedPeers;
        [JsonProperty("maxConnectedPeers")]
        public float MaxConnectedPeers
        {
            get { return _MaxConnectedPeers; }
            set
            {
                SetProperty(ref _MaxConnectedPeers, value);
            }
        }

        private float _MetadataPercentComplete;
        [JsonProperty("metadataPercentComplete")]
        public float MetadataPercentComplete
        {
            get { return _MetadataPercentComplete; }
            set
            {
                SetProperty(ref _MetadataPercentComplete, value);
            }
        }

        private string _Name;
        [JsonProperty("name")]
        public string Name
        {
            get { return _Name; }
            set
            {
                SetProperty(ref _Name, value);
            }
        }

        private float _PeerLimit;
        [JsonProperty("peer-limit")]
        public float PeerLimit
        {
            get { return _PeerLimit; }
            set
            {
                SetProperty(ref _PeerLimit, value);
            }
        }

        private IList<Peer> _Peers;
        [JsonProperty("peers")]
        public IList<Peer> Peers
        {
            get { return _Peers; }
            set
            {
                SetProperty(ref _Peers, value);
            }
        }

        private int _PeersConnected;
        [JsonProperty("peersConnected")]
        public int PeersConnected
        {
            get { return _PeersConnected; }
            set
            {
                SetProperty(ref _PeersConnected, value);
            }
        }

        private PeersFrom _PeersFrom;
        [JsonProperty("peersFrom")]
        public PeersFrom PeersFrom
        {
            get { return _PeersFrom; }
            set
            {
                SetProperty(ref _PeersFrom, value);
            }
        }

        private int _PeersGettingFromUs;
        [JsonProperty("peersGettingFromUs")]
        public int PeersGettingFromUs
        {
            get { return _PeersGettingFromUs; }
            set
            {
                SetProperty(ref _PeersGettingFromUs, value);
            }
        }

        public int _PeersSendingToUs;
        [JsonProperty("peersSendingToUs")]
        public int PeersSendingToUs
        {
            get { return _PeersSendingToUs; }
            set
            {
                SetProperty(ref _PeersSendingToUs, value);
            }
        }

        private float _PercentDone;
        [JsonProperty("percentDone")]
        public float PercentDone
        {
            get { return _PercentDone; }
            set
            {
                SetProperty(ref _PercentDone, value);
            }
        }

        private float _PieceCount;
        [JsonProperty("pieceCount")]
        public float PieceCount
        {
            get { return _PieceCount; }
            set
            {
                SetProperty(ref _PieceCount, value);
            }
        }

        private float _PieceSize;
        [JsonProperty("pieceSize")]
        public float PieceSize
        {
            get { return _PieceSize; }
            set
            {
                SetProperty(ref _PieceSize, value);
            }
        }

        private string _Pieces;
        [JsonProperty("pieces")]
        public string PiecesBase64String
        {
            get { return _Pieces; }
            set
            {
                if (SetProperty(ref _Pieces, value))
                    OnPropertyChanged("Pieces");
            }
        }


        [JsonIgnore]
        public byte[] Pieces
        {
            get
            {
                if (!String.IsNullOrEmpty(this.PiecesBase64String))
                {
                    var pieceString = this.PiecesBase64String.Replace("\\n", "");
                    var bytes = Convert.FromBase64String(pieceString);
                    return bytes;
                }
                return new byte[] { };
            }
        }

        private IList<float> _Priorities;
        [JsonProperty("priorities")]
        public IList<float> Priorities
        {
            get { return _Priorities; }
            set
            {
                SetProperty(ref _Priorities, value);
            }
        }

        private float _QueuePosition;
        [JsonProperty("queuePosition")]
        public float QueuePoisition
        {
            get { return _QueuePosition; }
            set
            {
                SetProperty(ref _QueuePosition, value);
            }
        }

        private float _RateDownload;
        [JsonProperty("rateDownload")]
        public float RateDownload
        {
            get { return _RateDownload; }
            set
            {
                SetProperty(ref _RateDownload, value);
            }
        }

        private float _RateUpload;
        [JsonProperty("rateUpload")]
        public float RateUpload
        {
            get { return _RateUpload; }
            set
            {
                SetProperty(ref _RateUpload, value);
            }
        }

        private float _RecheckProgress;
        /// <summary>
        /// When tr_stat.status is TR_STATUS_CHECK or TR_STATUS_CHECK_WAIT,
        ///this is the percentage of how much of the files has been
        ///verified.When it gets to 1, the verify process is done.
        ///Range is [0..1]
        ///@see tr_stat.status
        /// </summary>
        [JsonProperty("recheckProgress")]
        public float RecheckProgress
        {
            get { return _RecheckProgress; }
            set
            {
                SetProperty(ref _RecheckProgress, value);
            }
        }

        private float _SecondsDownloading;
        [JsonProperty("secondsDownloading")]
        public float SecondsDownloading
        {
            get { return _SecondsDownloading; }
            set
            {
                SetProperty(ref _SecondsDownloading, value);
            }
        }

        private float _SecondsSeeding;
        [JsonProperty("secondsSeeding")]
        public float SecondsSeeding
        {
            get { return _SecondsSeeding; }
            set
            {
                SetProperty(ref _SecondsSeeding , value);
            }
        }

        private float _SeedIdleLimit;
        [JsonProperty("seedIdleLimit")]
        public float SeedIdleLimit
        {
            get { return _SeedIdleLimit; }
            set
            {
                SetProperty(ref _SeedIdleLimit, value);
            }
        }

        private float _SeedIdleMode;
        [JsonProperty("seedIdleMode")]
        public float SeedIdleMode
        {
            get { return _SeedIdleMode; }
            set
            {
                SetProperty(ref _SeedIdleMode, value);
            }
        }

        private double _SeedRatioLimit;
        [JsonProperty("seedRatioLimit")]
        public double SeedRatioLimit
        {
            get { return _SeedRatioLimit; }
            set
            {
                SetProperty(ref _SeedRatioLimit, value);
            }
        }

        private float _SeedRatioModeCode;
        [JsonProperty("seedRatioMode")]
        public float SeedRatioModeCode
        {
            get { return _SeedRatioModeCode; }
            set
            {
                if (SetProperty(ref _SeedRatioModeCode , value))
                    OnPropertyChanged("SeedRatioMode");
            }
        }

        public SeedRatioMode SeedRatioMode
        {
            get { return (SeedRatioMode)this.SeedRatioModeCode; }
        }

        private ulong _SizeWhenDone;
        [JsonProperty("sizeWhenDone")]
        public ulong SizeWhenDone
        {
            get { return _SizeWhenDone; }
            set
            {
                SetProperty(ref _SizeWhenDone, value);
            }
        }

        private long _UnixStartDate;
        [JsonProperty("startDate")]
        public long UnixStartDate
        {
            get { return _UnixStartDate; }
            set
            {
                if (SetProperty(ref _UnixStartDate, value))
                    OnPropertyChanged("StartDate");
            }
        }

        public DateTime StartDate
        {
            get
            {
                DateTimeOffset dto = DateTimeOffset.FromUnixTimeSeconds(this.UnixStartDate);
                return dto.LocalDateTime;
            }
        }

        private float _StatusCode;
        [JsonProperty("status")]
        public float StatusCode
        {
            get { return _StatusCode; }
            set
            {
                if (SetProperty(ref _StatusCode, value))
                    OnPropertyChanged("Status");
            }
        }

        [JsonIgnore]
        public TorrentStatus Status
        {
            get
            {
                return (TorrentStatus)this.StatusCode;
            }
        }

        private string _TorrentFile;
        [JsonProperty("torrentFile")]
        public string TorrentFile
        {
            get { return _TorrentFile; }
            set
            {
                SetProperty(ref _TorrentFile, value);
            }
        }

        private float _TotalSize;
        [JsonProperty("totalSize")]
        public float TotalSize
        {
            get { return _TotalSize; }
            set
            {
                SetProperty(ref _TotalSize, value);
            }
        }

        private IList<TrackerStat> _TrackerStats;
        [JsonProperty("trackerStats")]
        public IList<TrackerStat> TrackerStats
        {
            get { return _TrackerStats; }
            set
            {
                SetProperty(ref _TrackerStats, value);
            }
        }

        private IList<Tracker> _Trackers;
        [JsonProperty("trackers")]
        public IList<Tracker> Trackers
        {
            get { return _Trackers; }
            set
            {
                SetProperty(ref _Trackers, value);
            }
        }

        private float _UploadLimit;
        [JsonProperty("uploadLimit")]
        public float UploadLimit
        {
            get { return _UploadLimit; }
            set
            {
                SetProperty(ref _UploadLimit, value);
            }
        }

        private bool _UploadLimited;
        [JsonProperty("uploadLimited")]
        public bool UploadLimited
        {
            get { return _UploadLimited; }
            set
            {
                SetProperty(ref _UploadLimited, value);
            }
        }

        private double _UploadRatio;
        [JsonProperty("uploadRatio")]
        public double UploadRatio
        {
            get { return _UploadRatio; }
            set
            {
                SetProperty(ref _UploadRatio, value);
            }
        }

        private ulong _UploadEver;
        [JsonProperty("uploadedEver")]
        public ulong UploadedEver
        {
            get { return _UploadEver; }
            set
            {
                SetProperty(ref _UploadEver, value);
            }
        }

        private IList<float> _Wanted;
        [JsonProperty("wanted")]
        public IList<float> Wanted
        {
            get { return _Wanted; }
            set
            {
                SetProperty(ref _Wanted, value);
            }
        }

        private IList<string> _Webseeds;
        [JsonProperty("webseeds")]
        public IList<string> Webseeds
        {
            get { return _Webseeds; }
            set
            {
                SetProperty(ref _Webseeds, value);
            }
        }

        private float _WebseedsSendingtoUs;
        [JsonProperty("webseedsSendingToUs")]
        public float WebseedsSendingToUs
        {
            get { return _WebseedsSendingtoUs; }
            set
            {
                SetProperty(ref _WebseedsSendingtoUs, value);
            }
        }

        
        public override string ToString()
        {
            return _Name;
        }
    }

    public class TorrentCollection
    {

        [JsonProperty("torrents")]
        public IList<Torrent> Torrents { get; set; }

        [JsonProperty("removed")]
        public IList<Torrent> Removed { get; set; }
    }
}
