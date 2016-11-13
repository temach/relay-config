using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace timerelay_daemon_1
{
    public class ChannelSettings
    {
        public int programNumber { get; set; }
    }

    public class ProgramSettings
    {
        public bool impulceMode { get; set; }
        public int impulceTimeOn { get; set; }
        public int impulceTimeOff { get; set; }
    }

    public class RelaySettings
    {
        public ChannelSettings[] channels { get; set; }
        public ProgramSettings[] programs { get; set; }
    }
}
