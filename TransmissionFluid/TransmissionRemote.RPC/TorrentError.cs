using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransmissionRemote.RPC
{
    //See transmission.h
    //https://trac.transmissionbt.com/browser/trunk/libtransmission/transmission.h?rev=5922
    public enum TorrentError
    {
        TR_OK = 0,

        /* general errors */
        TR_ERROR = -100,
        TR_ERROR_ASSERT,

        /* io errors */
        TR_ERROR_IO_PARENT = -200,
        TR_ERROR_IO_PERMISSIONS,
        TR_ERROR_IO_SPACE,
        TR_ERROR_IO_FILE_TOO_BIG,
        TR_ERROR_IO_OPEN_FILES,
        TR_ERROR_IO_DUP_DOWNLOAD,
        TR_ERROR_IO_CHECKSUM,
        TR_ERROR_IO_OTHER,

        /* tracker errors */
        TR_ERROR_TC_ERROR = -300,
        TR_ERROR_TC_WARNING,

        /* peer errors */
        TR_ERROR_PEER_MESSAGE = -400
    }
}
