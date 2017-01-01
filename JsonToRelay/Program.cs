using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

      // ask for settings
      logic.GetSettingsClick(null, EventArgs.Empty);
      // show settings
      var prog_one = logic.CtrlProgramsOpts[1];
      Console.WriteLine("HELLO STAGE 1");
      // save to file
      logic.SaveFileJSON(path_base + output_path);

      // we get settings across the network as json
      // get the settngs
      logic.OpenFileJSON(path_base + input_path);
      var prog_one_new = logic.CtrlProgramsOpts[1];
      // write settigns to device
      logic.SendSettingsClick();
      Console.WriteLine("HELLO STAGE 2");

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
