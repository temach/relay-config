using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoIt;

namespace ControlGUI
{

    enum RELAY_MODE
    {
        OFF,
        YEARLY,
        MONTHLY,
        WEEKLY,
        DAILY,
        PULSE,
        SIMPLE
    }

    enum PULSE_OPTION
    {
        SECONDS_ON,
        SECONDS_OFF
    }

    static class RelayAutoitNavigator
    {
        static RelaySettings setting = new RelaySettings();
        static string startPath = @"C:\Program Files (x86)\Novatek-Electro\Configurator REV-302\MultiTimer.exe";

        static string window = "Configurator relay REV-302";
        static string treeViewControl = "[NAME:treeView1; CLASS:WindowsForms10.SysTreeView32.app.0.378734a]";
        static string subTreeTimeRelayMode = "#0";
        static string subSubTreeTimeRelayGeneralSettings = "#0";
        static string subSubTreePulseModeOptions = "#6";

        static Dictionary<int, string> channel = new Dictionary<int, string>();
        static Dictionary<RELAY_MODE, string> relayModes = new Dictionary<RELAY_MODE, string>();
        static Dictionary<PULSE_OPTION, string> pulseOptions = new Dictionary<PULSE_OPTION, string>();

        static  RelayAutoitNavigator()
        {
            string buttonOff = "[NAME:radioButton15; TEXT:OFF]";
            string buttonProgram1 = "[NAME:radioButton1; TEXT:Program P1]";
            string buttonProgram2 = "[NAME:radioButton2; TEXT:Program P2]";
            channel.Add(0, buttonOff);
            channel.Add(1, buttonProgram1);
            channel.Add(2, buttonProgram2);

            string pulseTimer = "[NAME:radioButton13; TEXT:Pulse timer]";
            relayModes.Add(RELAY_MODE.PULSE, pulseTimer);

            string secondsOn = "[CLASS:WindowsForms10.EDIT.app.0.378734a; INSTANCE:3]";
            string secondsOff = "[CLASS:WindowsForms10.EDIT.app.0.378734a; INSTANCE:1]";
            pulseOptions.Add(PULSE_OPTION.SECONDS_ON, secondsOn);
            pulseOptions.Add(PULSE_OPTION.SECONDS_OFF, secondsOff);
        }

        static public void GetControlGUI()
        {
            if (AutoItX.WinActivate(window) == 0)
            {
                // then the windows does not exist, and we must create it
                int pid = AutoItX.Run(startPath, Environment.GetFolderPath(Environment.SpecialFolder.UserProfile));
                if (pid == 0)
                {
                    // Log error
                }
                AutoItX.WinWait(window, "", 10);
                AutoItX.WinActivate(window);
            }
        }

        public static string Plus(this string s, string other)
        {
            return s + "|" + other;
        }

        public static void ExpandTreeViewMenu(string name)
        {
            AutoItX.ControlTreeView(window, "", treeViewControl, "Expand", name, "");
        }

        public static void SetPulseMode(string program, RELAY_MODE mode)
        {
            // descend down the tree
            string path = program.Plus(subTreeTimeRelayMode).Plus(subSubTreeTimeRelayGeneralSettings);
            ExpandTreeViewMenu(path);
            AutoItX.ControlTreeView(window, "", treeViewControl, "Select", path, "");
            // click radio button
            AutoItX.ControlClick(window, "", relayModes[mode]);
        }

        public static void EraseAndWriteText(string control, string text)
        {
            AutoItX.ControlSetText(window, "", control, text);
        }

        public static void SetPulseModeOptions(string program, int secondsOn, int secondsOff)
        {
            // descend down the tree
            string path = program.Plus(subTreeTimeRelayMode).Plus(subSubTreePulseModeOptions);
            ExpandTreeViewMenu(path);
            AutoItX.ControlTreeView(window, "", treeViewControl, "Select", path, "");
            // on
            AutoItX.ControlClick(window, "", pulseOptions[PULSE_OPTION.SECONDS_ON]);
            EraseAndWriteText(pulseOptions[PULSE_OPTION.SECONDS_ON], secondsOn.ToString());
            // off 
            AutoItX.ControlClick(window, "", pulseOptions[PULSE_OPTION.SECONDS_OFF]);
            EraseAndWriteText(pulseOptions[PULSE_OPTION.SECONDS_OFF], secondsOff.ToString());
        }

        public static void ChannelSetProgram(string channelName, int programNumber)
        {
            //System.Drawing.Rectangle www = AutoItX.ControlGetPos(window, "", treeViewControl);
            //string name = AutoItX.ControlTreeView(window, "", treeViewControl, "Select", channelName, "");
            AutoItX.ControlTreeView(window, "", treeViewControl, "Select", channelName, "");
            AutoItX.ControlClick(window, "", channel[programNumber]);
        }

        public static RelaySettings CollectCurrentSettings()
        {
            return setting;
        }

        public static void ConfigChannels(ChannelSettings[] channels)
        {
            for (int i = 0; i < channels.Length; i++)
            {
                // channel number in treeView1, to get K1 or K2
                string channelName = "#" + i;
                ChannelSetProgram(channelName, channels[i].programNumber);
            }
        }

        public static void ConfigPrograms(ProgramSettings[] programs)
        {
            for (int i = 0; i < programs.Length; i++)
            {
                // the number to referer to the entry in treeView1
                string programName = "#" + (i + 2).ToString();
                ProgramSettings pset = programs[i];
                if (pset.impulceMode)
                {
                    SetPulseMode(programName, RELAY_MODE.PULSE);
                    SetPulseModeOptions(programName, pset.impulceTimeOn, pset.impulceTimeOff);
                }
            }
        }

        public static void FlushToHardware()
        {
            System.Drawing.Rectangle pos = AutoItX.WinGetPos(window);
            AutoItX.MouseClick("left", pos.X + 20, pos.Y + 35);
            AutoItX.ControlSend(window, "", "", "{RIGHT}{DOWN}{DOWN}{ENTER}{ENTER}");
        }

        public static bool PushNewSettings(RelaySettings settingsNew)
        {
            lock (setting)
            {
                GetControlGUI();
                // just reset all settings to sync them
                ConfigChannels(settingsNew.channels);
                ConfigPrograms(settingsNew.programs);
                // send to device
                FlushToHardware();
                return true;
            }
        }

    }
}
