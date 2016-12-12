using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USBInterface;

namespace TestUSBInterface
{
  class Program
  {
    static void Main(string[] args)
    {
      USBDevice dev = new USBDevice();
      dev.Open(1982, 23);
      Console.WriteLine(dev.HIDisOpen);
      Console.WriteLine(dev.Description());
      dev.Close();
      Console.ReadKey();
    }
  }
}
