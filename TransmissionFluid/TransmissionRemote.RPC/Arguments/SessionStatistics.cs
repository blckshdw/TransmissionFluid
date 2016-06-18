using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransmissionRemote.RPC.Arguments
{
    public class CumulativeStats
    {
        [JsonProperty("downloadedBytes")]
        public long DownloadedBytes { get; set; }
        [JsonProperty("filesAdded ")]
        public int FilesAdded { get; set; }
        [JsonProperty("secondsActive")]
        public int SecondsActive { get; set; }
        [JsonProperty("sessionCount")]
        public int SessionCount { get; set; }
        [JsonProperty("uploadedBytes ")]
        public long UploadedBytes { get; set; }

        public TimeSpan TimeActive { get { return TimeSpan.FromSeconds(this.SecondsActive); } }
    }

    public class CurrentStats
    {
        [JsonProperty("downloadedBytes")]
        public ulong DownloadedBytes { get; set; }
        [JsonProperty("filesAdded ")]
        public int FilesAdded { get; set; }
        [JsonProperty("secondsActive ")]
        public int SecondsActive { get; set; }
        [JsonProperty("sessionCount")]
        public int SessionCount { get; set; }
        [JsonProperty("uploadedBytes")]
        public ulong UploadedBytes { get; set; }
    }

    public class SessionStatistics
    {
        [JsonProperty("activeTorrentCount")]
        public int ActiveTorrentCount { get; set; }

        [JsonProperty("cumulative-stats")]
        public CumulativeStats Cumulativestats { get; set; }

        [JsonProperty("current-stats")]
        public CurrentStats Currentstats { get; set; }
        [JsonProperty("downloadSpeed")]
        public long DownloadSpeed { get; set; }
        [JsonProperty("PausedTorrentCount")]
        public int PausedTorrentCount { get; set; }
        [JsonProperty("torrentCount")]
        public int TorrentCount { get; set; }
        [JsonProperty("uploadSpeed")]
        public long UploadSpeed { get; set; }
    }
}

