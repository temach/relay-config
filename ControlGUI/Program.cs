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
            ch1.impulceMode = true;
            ch1.impulceTimeOff = 4;
            ch1.impulceTimeOn = 2;

            ChannelSettings ch2 = new ChannelSettings();
            ch2.programNumber = 0;
            ch2.impulceMode = true;
            ch2.impulceTimeOff = 4;
            ch2.impulceTimeOn = 2;

            RelaySettings pushSet = new RelaySettings();
            pushSet.channelK1 = ch1;
            pushSet.channelK2 = ch2;

            ControllerTimeRelayGUI.PushNewSettings(pushSet);
        }
    }
}
