using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransmissionRemote.RPC
{
    public class TransmissionRequest
    {
        [JsonProperty(PropertyName = "method")]

        public string Method { get; set; }
        [JsonProperty(PropertyName = "tag")]

        public int Tag { get; set; }
        [JsonProperty(PropertyName = "arguments")]
        public Dictionary<string, object> Arguments { get; set; }


        public TransmissionRequest() { }
        public TransmissionRequest(string method)
        {
            this.Method = method;
        }
        public TransmissionRequest(string method, Dictionary<string, object> args)
        {
            this.Method = method;
            this.Arguments = args;
        }
    }
}
