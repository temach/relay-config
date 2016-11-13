using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoIt;
using AutoItX3Lib;

namespace timerelay_daemon_1
{
    static class RelayAutoitNavigator
    {
        static RelaySettings setting = new RelaySettings();

        static RelayAutoitNavigator()
        {
            // get settings from gui (from relay)
            setting.impulceMode = false;
            setting.impulceTimeOff = 99;
            setting.impulceTimeOn = 23;
        }

        public static RelaySettings CollectCurrentSettings()
        {
            return setting;
        }

        public static bool PushNewSettings(RelaySettings settingsNew)
        {
            lock (setting)
            {
                setting = settingsNew;
                return true;
            }
        }

    }
}
