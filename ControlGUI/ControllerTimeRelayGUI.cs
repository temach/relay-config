using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoIt;

namespace ControlGUI
{

    public class ChannelSettings
    {
        public int programNumber { get; set; }
        public bool impulceMode { get; set; }
        public int impulceTimeOn { get; set; }
        public int impulceTimeOff { get; set; }
    }

    public class RelaySettings
    {
        public ChannelSettings channelK1 { get; set; }
        public ChannelSettings channelK2 { get; set; }
    }

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

    static class ControllerTimeRelayGUI
    {
        static RelaySettings setting = new RelaySettings();
        static string startPath = @"C:\Program Files (x86)\Novatek-Electro\Configurator REV-302\MultiTimer.exe";

        static string window = "Configurator relay REV-302";
        static string treeViewControl = "[NAME:treeView1; CLASS:WindowsForms10.SysTreeView32.app.0.378734a]";
        //static string treeViewControl = "[NAME:treeView1]";
        static string subTreeTimeRelayMode = "#0";
        static string subSubTreeTimeRelayGeneralSettings = "#0";
        static string subSubTreePulseModeOptions = "#6";
        static string channelK1 = "#0";
        static string channelK2 = "#1";

        static Dictionary<int, string> channel = new Dictionary<int, string>();
        static Dictionary<RELAY_MODE, string> relayModes = new Dictionary<RELAY_MODE, string>();
        static Dictionary<PULSE_OPTION, string> pulseOptions = new Dictionary<PULSE_OPTION, string>();

        static  ControllerTimeRelayGUI()
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

        public static void ConfigureParameters(RelaySettings settingsNew)
        {
            // just reset all settings to sync them
            ChannelSettings chOne = settingsNew.channelK1;
            ChannelSetProgram(channelK1, chOne.programNumber);
            if (chOne.programNumber > 0)
            {
                if (chOne.impulceMode)
                {
                    string program = "#" + (chOne.programNumber + 2).ToString();
                    SetPulseMode(program, RELAY_MODE.PULSE);
                    SetPulseModeOptions(program, chOne.impulceTimeOn, chOne.impulceTimeOff);
                }
            }

            ChannelSettings chTwo = settingsNew.channelK2;
            ChannelSetProgram(channelK2, chTwo.programNumber);
            if (chTwo.programNumber > 0)
            {
                if (chTwo.impulceMode)
                {
                    string program = "#" + (chTwo.programNumber + 2).ToString();
                    SetPulseMode(program, RELAY_MODE.PULSE);
                    SetPulseModeOptions(program, chTwo.impulceTimeOn, chTwo.impulceTimeOff);
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

                //ConfigureParameters(settingsNew);
                FlushToHardware();


                return true;
            }
        }

    }
}
