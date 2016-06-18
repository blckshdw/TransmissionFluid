using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransmissionRemote.RPC
{
    public class TransmissionResponse
    {
        [JsonProperty(PropertyName = "arguments")]
        public Dictionary<string, object> Arguments { get; set; }

        [JsonProperty(PropertyName = "result")]
        public string Result { get; set; }

        [JsonProperty(PropertyName = "tag")]
        public string Tag { get; set; }

        public T Deserialize<T>()
        {
            var arguments = JsonConvert.SerializeObject(this.Arguments);
            return JsonConvert.DeserializeObject<T>(arguments);
        }
    }
}
