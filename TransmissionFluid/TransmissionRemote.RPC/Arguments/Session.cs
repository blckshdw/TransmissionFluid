using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransmissionRemote.RPC.Arguments
{
    public class Session
    {
        [JsonProperty("alt-speed-down")]
        public int AltSpeedDown { get; set; }

        [JsonProperty("alt-speed-enabled")]
        public bool AltSpeedEnabled { get; set; }

        [JsonProperty("alt-speed-time-begin")]
        public int AltSpeedTimeBegin { get; set; }

        [JsonProperty("alt-speed-time-day")]
        public int AltSpeedTimeDay { get; set; }

        [JsonProperty("alt-speed-time-enabled")]
        public bool AltSpeedTimeEnabled { get; set; }

        [JsonProperty("alt-speed-time-end")]
        public int AltSpeedTimeEnd { get; set; }

        [JsonProperty("alt-speed-up")]
        public int AltSpeedUp { get; set; }

        [JsonProperty("blocklist-enabled")]
        public bool BlocklistEnabled { get; set; }

        [JsonProperty("blocklist-size")]
        public int BlocklistSize { get; set; }

        [JsonProperty("config-dir")]
        public string ConfigDir { get; set; }

        [JsonProperty("dht-enabled")]
        public bool DhtEnabled { get; set; }

        [JsonProperty("download-dir")]
        public string DownloadDir { get; set; }

        [JsonProperty("encryption")]
        public string Encryption { get; set; }

        [JsonProperty("incomplete-dir")]
        public string IncompleteDir { get; set; }

        [JsonProperty("incomplete-dir-enabled")]
        public bool IncompleteDirEnabled { get; set; }

        [JsonProperty("peer-limit-global")]
        public int PeerLimitGlobal { get; set; }

        [JsonProperty("peer-limit-per-torrent")]
        public int PeerLimitPerTorrent { get; set; }

        [JsonProperty("peer-port")]
        public int PeerPort { get; set; }

        [JsonProperty("peer-port-random-on-start")]
        public int PeerPortRandomOnStart { get; set; }

        [JsonProperty("pex-enabled")]
        public bool PexEnabled { get; set; }

        [JsonProperty("port-forwarding-enabled")]
        public bool PortForwardingEnabled { get; set; }

        [JsonProperty("rename-partial-files")]
        public bool RenamePartialFiles { get; set; }

        [JsonProperty("rpc-version")]
        public int RpcVersion { get; set; }

        [JsonProperty("rpc-version-minimum")]
        public int RpcVersionMinimum { get; set; }

        [JsonProperty("seedRatioLimit")]
        public int SeedRatioLimit { get; set; }

        [JsonProperty("seedRatioLimited")]
        public bool SeedRatioLimited { get; set; }

        [JsonProperty("speed-limit-down")]
        public int SpeedLimitDown { get; set; }

        [JsonProperty("speed-limit-down-enabled")]
        public bool SpeedLimitDownEnabled { get; set; }

        [JsonProperty("speed-limit-up")]
        public int SpeedLimitUp { get; set; }

        [JsonProperty("speed-limit-up-enabled")]
        public bool SpeedLimitUpEnabled { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }
    }
}
