using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransmissionFluid.Model
{
    public class TorrentFileName : GalaSoft.MvvmLight.ViewModelBase
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public long Size { get; set; }
        public bool _Wanted = true;
        public bool IsWanted
        {
            get { return _Wanted; }
            set { Set(ref _Wanted, value); }
        }

        public string[] Paths { get; set; }
    }
}
