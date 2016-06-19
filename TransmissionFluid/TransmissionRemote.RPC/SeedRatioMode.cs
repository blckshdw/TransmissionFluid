using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransmissionRemote.RPC
{
    public enum SeedRatioMode
    {
        /* follow the global settings */
        TR_RATIOLIMIT_GLOBAL = 0,

        /* override the global settings, seeding until a certain ratio */
        TR_RATIOLIMIT_SINGLE = 1,

        /* override the global settings, seeding regardless of ratio */
        TR_RATIOLIMIT_UNLIMITED = 2
    }
}
