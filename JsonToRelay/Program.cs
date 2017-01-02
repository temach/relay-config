using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace JsonToRelay
{
  class Program
  {
    static void Main(string[] args)
    {
      string path_base = @"C:\Users\artem\Desktop\VS-2015-projects\timerelay-daemon-1\JsonToRelay";
      string input_path = @"\settings_sample_multi_timer.tmj";
      string output_path = @"\settings_sample_multi_timer_output.tmj";

      MainLogic logic = MainLogic.MakeMainLogic();

      // we get settings across the network as json
      logic.OpenFileJSON(path_base + input_path);

      // start heavy work in separate thread
      new System.Threading.Tasks.Task(() =>
      {
        Thread.Sleep(20);
        // ask for settings
        logic.GetSettingsClick(null, EventArgs.Empty);
        // save to file
        logic.SaveFileJSON(path_base + output_path);
      }).Start();

      // start heavy work in separate thread
      new System.Threading.Tasks.Task(() =>
      {
        // write settigns to device
        logic.SendSettingsClick();
      }).Start();

      Thread.Sleep(TimeSpan.FromMilliseconds(500));

      // read settings again to check if they are applied
      // ask for settings
      logic.GetSettingsClick(null, EventArgs.Empty);
      // show settings, check that they are new settings
      var prog_one_new_returned = logic.CtrlProgramsOpts[1];
      Console.WriteLine("HELLO STAGE 3");

      logic.Dispose();
      Console.ReadKey();
    }
  }
}
