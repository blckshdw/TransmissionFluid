using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransmissionRemote.RPC.Arguments
{
    public class TorrentAdded
    {
        [JsonProperty("hashString")]
        public string HashString { get; set; }
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class TorrentAddedArguments
    {
        [JsonProperty("torrent-added")]
        public TorrentAdded TorrentAdded { get; set; }
    }
}

