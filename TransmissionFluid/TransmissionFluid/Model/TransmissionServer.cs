using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransmissionFluid.Model
{
    public class TransmissionServer
    {
        public string Host { get; set; }
        public int Port { get; set; } = 9091;
        public string Path { get; set; } = "/transmission/rpc";

    }
}
