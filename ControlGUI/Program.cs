using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlGUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ChannelSettings ch1 = new ChannelSettings();
            ch1.programNumber = 1;

            ChannelSettings ch2 = new ChannelSettings();
            ch2.programNumber = 0;

            ProgramSettings pr1 = new ProgramSettings();
            pr1.impulceMode = true;
            pr1.impulceTimeOff = 4;
            pr1.impulceTimeOn = 2;

            ProgramSettings pr2 = new ProgramSettings();
            pr2.impulceMode = true;
            pr2.impulceTimeOff = 4;
            pr2.impulceTimeOn = 2;

            RelaySettings pushSet = new RelaySettings();
            pushSet.channels = new ChannelSettings[] { ch1, ch2 };
            pushSet.programs = new ProgramSettings[] { pr1, pr2 };

            RelayAutoitNavigator.PushNewSettings(pushSet);
        }
    }
}
