using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransmissionRemote.RPC.Arguments
{
    public class AddTorrentArguments
    {
        [JsonProperty("cookies")]
        public string Cookies { get; set; }

        [JsonProperty("download-dir")]
        public string DownloadDir { get; set; }

        [JsonProperty("filename")]
        public string FileName { get; set; }

        [JsonProperty("metainfo")]
        public string MetaInfo { get; set; }

        [JsonProperty("paused")]
        public bool Paused { get; set; }

        [JsonProperty("peer-limit")]
        public int PeerLimit { get; set; }

        [JsonProperty("bandwidthPriority")]
        public int BandwidthPriority { get; set; }

        [JsonProperty("files-wanted")]
        public int[] FilesWanted { get; set; }

        [JsonProperty("files-unwanted")]
        public int[] FilesUnwanted { get; set; }

        [JsonProperty("priority-high")]
        public int[] PriorityHigh { get; set; }

        [JsonProperty("priority-low")]
        public int[] PriorityLow { get; set; }

        [JsonProperty("priority-normal")]
        public int[] PriorityNormal { get; set; }

        public Dictionary<string, object> ToDictionary()
        {
            var dict = new Dictionary<string, object>();
            dict.Add("cookies", this.Cookies);
            dict.Add("download-dir", this.DownloadDir);
            //dict.Add("filename", this.FileName);
            dict.Add("metainfo", this.MetaInfo);
            dict.Add("paused", this.Paused);
            dict.Add("peer-limit", this.PeerLimit);
            dict.Add("bandwidthPriority", this.BandwidthPriority);
            dict.Add("files-wanted", this.FilesWanted);
            dict.Add("files-unwanted", this.FilesUnwanted);
            dict.Add("priority-high", this.PriorityHigh);
            dict.Add("priority-low", this.PriorityLow);
            dict.Add("priority-normal", this.PriorityNormal);

            return dict;
        }

        public void ReadMetaInfo(string fileName)
        {

            Byte[] bytes = System.IO.File.ReadAllBytes(fileName);
            String base64string = Convert.ToBase64String(bytes);
            this.MetaInfo = base64string;
        }
    }
}

