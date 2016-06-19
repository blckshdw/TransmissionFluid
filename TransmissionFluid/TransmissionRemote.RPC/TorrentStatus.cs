using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransmissionRemote.RPC
{
    public enum TorrentStatus
    {
        [Description("Stopped")]
        TR_STATUS_STOPPED = 0, /* Torrent is stopped */

        [Description("Stopped")]
        TR_STATUS_OLD_STOPPED = 16, /* Old Status Code Stopped */
        
        [Description("Check - Queued")]
        TR_STATUS_CHECK_WAIT = 1, /* Queued to check files */

        [Description("Checking")]
        TR_STATUS_CHECK = 2, /* Checking files */

        [Description("Queued Download")]
        TR_STATUS_DOWNLOAD_WAIT = 3, /* Queued to download */

        [Description("Downloading")]
        TR_STATUS_DOWNLOAD = 4, /* Downloading */

        [Description("Queued Seed")]
        TR_STATUS_SEED_WAIT = 5, /* Queued to seed */

        [Description("Seeding")]
        TR_STATUS_SEED = 6,  /* Seeding */

        [Description("Seeding")]
        TR_STATUS_OLD_SEED = 8, /* Old Seeding */
    }
}
