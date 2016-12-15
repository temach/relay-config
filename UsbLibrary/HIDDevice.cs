// Decompiled with JetBrains decompiler
// Type: UsbLibrary.HIDDevice
// Assembly: UsbLibrary, Version=1.0.5855.29665, Culture=neutral, PublicKeyToken=null
// MVID: 5237C4C1-0487-434F-958F-85B41FDA0A3D
// Assembly location: C:\Program Files (x86)\Novatek-Electro\Configurator REV-302\UsbLibrary.dll

using Microsoft.Win32.SafeHandles;
using System;
using System.IO;
using System.Runtime.InteropServices;
using Minimod.PrettyPrint;
using USBInterface;

namespace UsbLibrary
{
  public abstract class HIDDevice : Win32Usb, IDisposable
  {
    private FileStream m_oFile;
    private int m_nInputReportLength = 32;
    private int m_nOutputReportLength = 32;
    private IntPtr m_hHandle;

    // public because we have to use it in one place
    public USBDevice hidapi_device;

    public int OutputReportLength
    {
      get
      {
        return this.m_nOutputReportLength;
      }
    }

    public int InputReportLength
    {
      get
      {
        return this.m_nInputReportLength;
      }
    }

    public event EventHandler OnDeviceRemoved;

    public void Dispose()
    {
      this.Dispose(true);
      GC.SuppressFinalize((object) this);
    }

    protected virtual void Dispose(bool bDisposing)
    {
      try
      {
        if (bDisposing && this.m_oFile != null)
        {
          this.m_oFile.Close();
          this.m_oFile = (FileStream) null;
        }
        if (!(this.m_hHandle != IntPtr.Zero))
          return;
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.ToString());
      }
    }


    private void Initialise(USBDevice dev)
    {
      try
      {
        hidapi_device = dev;
        hidapi_device.DeviceDisconnecedEvent += this.DeviceDisconnectedHandler;
        hidapi_device.InputReportArrivedEvent += this.ReportReceivedHandle;
        hidapi_device.StartAsyncRead();
      }
      catch (Exception ex)
      {
        throw HIDDeviceException.GenerateWithWinError("Failed to get the detailed data from the hid.");
      }
      this.m_hHandle = IntPtr.Zero;
    }

    private void ReportReceivedHandle(object o, ReportEventArgs args)
    {
      // since we dont use report IDs, that means we get 31 bytes instead of 32
      // but the logic expects 32 bytes, so add the first 0x00 byte here
      byte[] with_command = new byte[m_nInputReportLength];
      with_command[0] = 0;
      Array.Copy(args.Data, 0, with_command, 1, args.Data.Length);
      InputReport inputReport = this.CreateInputReport();
      inputReport.SetData(with_command);
      this.HandleDataReceived(inputReport);
    }

    private void DeviceDisconnectedHandler(object o, EventArgs a)
    {
        this.HandleDeviceRemoved();
        if (this.OnDeviceRemoved != null)
          this.OnDeviceRemoved((object) this, new EventArgs());
        this.Dispose();
    }

    protected void Write(OutputReport oOutRep)
    {
      try
      {
        hidapi_device.Write(oOutRep.Buffer);
      }
      catch (IOException ex)
      {
        throw new HIDDeviceException("Probbaly the device was removed");
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.ToString());
      }
    }

    protected virtual void HandleDataReceived(InputReport oInRep)
    {
    }

    protected virtual void HandleDeviceRemoved()
    {
    }


    // There is only one device that you would ever want to find.
    // The function is written with this assumption in mind.
    public static HIDDevice FindDevice(int nVid, int nPid, Type oType)
    {
      try
      {
        // We know all of this information before hand, so just use it!
        USBInterface.USBDevice d = new USBDevice((ushort)nVid, (ushort)nPid, null, false, 31);
        HIDDevice instance = (HIDDevice)Activator.CreateInstance(oType);
        instance.Initialise(d);
        return instance;
      }
      catch (Exception ex)
      {
        throw new Exception("Could not open device");
      }
    }

    public virtual InputReport CreateInputReport()
    {
      return (InputReport) null;
    }
  }
}
