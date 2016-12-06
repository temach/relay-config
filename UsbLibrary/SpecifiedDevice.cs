// Decompiled with JetBrains decompiler
// Type: UsbLibrary.SpecifiedDevice
// Assembly: UsbLibrary, Version=1.0.5855.29665, Culture=neutral, PublicKeyToken=null
// MVID: 5237C4C1-0487-434F-958F-85B41FDA0A3D
// Assembly location: C:\Program Files (x86)\Novatek-Electro\Configurator REV-302\UsbLibrary.dll

using System;

namespace UsbLibrary
{
  public class SpecifiedDevice : HIDDevice
  {
    public event DataRecievedEventHandler DataRecieved;

    public event DataSendEventHandler DataSend;

    public override InputReport CreateInputReport()
    {
      return (InputReport) new SpecifiedInputReport((HIDDevice) this);
    }

    public static SpecifiedDevice FindSpecifiedDevice(int vendor_id, int product_id)
    {
      return (SpecifiedDevice) HIDDevice.FindDevice(vendor_id, product_id, typeof (SpecifiedDevice));
    }

    protected override void HandleDataReceived(InputReport oInRep)
    {
      if (this.DataRecieved == null)
        return;
      this.DataRecieved((object) this, new DataRecievedEventArgs(((SpecifiedInputReport) oInRep).Data));
    }

    public void SendData(byte[] data)
    {
      SpecifiedOutputReport specifiedOutputReport = new SpecifiedOutputReport((HIDDevice) this);
      specifiedOutputReport.SendData(data);
      try
      {
        this.Write((OutputReport) specifiedOutputReport);
        if (this.DataSend == null)
          return;
        this.DataSend((object) this, new DataSendEventArgs(data));
      }
      catch (HIDDeviceException ex)
      {
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.ToString());
      }
    }

    protected override void Dispose(bool bDisposing)
    {
      int num = bDisposing ? 1 : 0;
      base.Dispose(bDisposing);
    }
  }
}
