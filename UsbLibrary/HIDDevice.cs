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

    private USBDevice hidapi_device = new USBDevice();

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
        Win32Usb.CloseHandle(this.m_hHandle);
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.ToString());
      }
    }

    private void Initialise(USBDevice dev)
    private void Initialise(string strPath)
    {
      




      this.m_hHandle = Win32Usb.CreateFile(strPath, 3221225472U, 0U, IntPtr.Zero, 3U, 1073741824U, IntPtr.Zero);
      if (this.m_hHandle != Win32Usb.InvalidHandleValue)
      {
        IntPtr lpData;
        if (!Win32Usb.HidD_GetPreparsedData(this.m_hHandle, out lpData))
          throw HIDDeviceException.GenerateWithWinError("GetPreparsedData failed");
        try
        {
          Win32Usb.HidCaps oCaps;
          Win32Usb.HidP_GetCaps(lpData, out oCaps);
          this.m_oFile = new FileStream(new SafeFileHandle(this.m_hHandle, false), FileAccess.ReadWrite, this.m_nInputReportLength, true);
          this.BeginAsyncRead();
        }
        catch (Exception ex)
        {
          throw HIDDeviceException.GenerateWithWinError("Failed to get the detailed data from the hid.");
        }
        finally
        {
          Win32Usb.HidD_FreePreparsedData(ref lpData);
        }
      }
      else
      {
        this.m_hHandle = IntPtr.Zero;
        throw HIDDeviceException.GenerateWithWinError("Failed to create device file");
      }
    }

    private void BeginAsyncRead()
    {
      byte[] buffer = new byte[this.m_nInputReportLength];
      this.m_oFile.BeginRead(buffer, 0, this.m_nInputReportLength, new AsyncCallback(this.ReadCompleted), (object) buffer);
    }

    protected void ReadCompleted(IAsyncResult iResult)
    {
      byte[] asyncState = (byte[]) iResult.AsyncState;
      try
      {
        this.m_oFile.EndRead(iResult);
        try
        {
          InputReport inputReport = this.CreateInputReport();
          inputReport.SetData(asyncState);
          this.HandleDataReceived(inputReport);
        }
        finally
        {
          this.BeginAsyncRead();
        }
      }
      catch (IOException ex)
      {
        this.HandleDeviceRemoved();
        if (this.OnDeviceRemoved != null)
          this.OnDeviceRemoved((object) this, new EventArgs());
        this.Dispose();
      }
    }

    protected void Write(OutputReport oOutRep)
    {
      try
      {
        this.m_oFile.Write(oOutRep.Buffer, 0, oOutRep.BufferLength);
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

    private static string GetDevicePath(IntPtr hInfoSet, ref Win32Usb.DeviceInterfaceData oInterface)
    {
      uint nRequiredSize = 0;
      if (!Win32Usb.SetupDiGetDeviceInterfaceDetail(hInfoSet, ref oInterface, IntPtr.Zero, 0U, ref nRequiredSize, IntPtr.Zero))
      {
        Win32Usb.DeviceInterfaceDetailData oDetailData = new Win32Usb.DeviceInterfaceDetailData();
        oDetailData.Size = Marshal.SizeOf(typeof (IntPtr)) != 8 ? 5 : 8;
        if (Win32Usb.SetupDiGetDeviceInterfaceDetail(hInfoSet, ref oInterface, ref oDetailData, nRequiredSize, ref nRequiredSize, IntPtr.Zero))
          return oDetailData.DevicePath;
      }
      return (string) null;
    }

    // There is only one device that you would ever want to find.
    // The function is written with this assumption in mind.
    public static HIDDevice FindDevice(int nVid, int nPid, Type oType)
    {
      USBInterface.USBDevice d = new USBDevice();
      try
      {
        d.Open((ushort)nVid, (ushort)nPid);
        if (! d.HIDisOpen)
        {
          throw HIDDeviceException.GenerateError(
            string.Format("Could not open device with vid={0}, pid={0}", nVid, nPid)
            );
        }
        HIDDevice instance = (HIDDevice)Activator.CreateInstance(oType);
        instance.Initialise(d);
        return instance;
      }
      catch (Exception ex)
      {
        throw HIDDeviceException.GenerateError(ex.ToString());
      }
      return (HIDDevice)null;
    }

    public virtual InputReport CreateInputReport()
    {
      return (InputReport) null;
    }
  }
}
