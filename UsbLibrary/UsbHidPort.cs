// Decompiled with JetBrains decompiler
// Type: UsbLibrary.UsbHidPort
// Assembly: UsbLibrary, Version=1.0.5855.29665, Culture=neutral, PublicKeyToken=null
// MVID: 5237C4C1-0487-434F-958F-85B41FDA0A3D
// Assembly location: C:\Program Files (x86)\Novatek-Electro\Configurator REV-302\UsbLibrary.dll

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace UsbLibrary
{
  [ToolboxBitmap(typeof (UsbHidPort), "UsbHidBmp.bmp")]
  public class UsbHidPort : Component
  {
    private int product_id;
    private int vendor_id;
    private Guid device_class;
    private IntPtr usb_event_handle;
    private SpecifiedDevice specified_device;
    private IntPtr handle;
    private IContainer components;

    [Category("Embedded Details")]
    [DefaultValue("(none)")]
    [Description("The product id from the USB device you want to use")]
    public int ProductId
    {
      get
      {
        return this.product_id;
      }
      set
      {
        this.product_id = value;
      }
    }

    [Category("Embedded Details")]
    [Description("The vendor id from the USB device you want to use")]
    [DefaultValue("(none)")]
    public int VendorId
    {
      get
      {
        return this.vendor_id;
      }
      set
      {
        this.vendor_id = value;
      }
    }

    [Category("Embedded Details")]
    [Description("The Device Class the USB device belongs to")]
    [DefaultValue("(none)")]
    public Guid DeviceClass
    {
      get
      {
        return this.device_class;
      }
    }

    [Description("The Device witch applies to the specifications you set")]
    [DefaultValue("(none)")]
    [Category("Embedded Details")]
    public SpecifiedDevice SpecifiedDevice
    {
      get
      {
        return this.specified_device;
      }
    }

    [DisplayName("OnSpecifiedDeviceArrived")]
    [Description("The event that occurs when a usb hid device with the specified vendor id and product id is found on the bus")]
    [Category("Embedded Event")]
    public event EventHandler OnSpecifiedDeviceArrived;

    [DisplayName("OnSpecifiedDeviceRemoved")]
    [Description("The event that occurs when a usb hid device with the specified vendor id and product id is removed from the bus")]
    [Category("Embedded Event")]
    public event EventHandler OnSpecifiedDeviceRemoved;

    [DisplayName("OnDeviceArrived")]
    [Description("The event that occurs when a usb hid device is found on the bus")]
    [Category("Embedded Event")]
    public event EventHandler OnDeviceArrived;

    [DisplayName("OnDeviceRemoved")]
    [Description("The event that occurs when a usb hid device is removed from the bus")]
    [Category("Embedded Event")]
    public event EventHandler OnDeviceRemoved;

    [Description("The event that occurs when data is recieved from the embedded system")]
    [DisplayName("OnDataRecieved")]
    [Category("Embedded Event")]
    public event DataRecievedEventHandler OnDataRecieved;

    [Description("The event that occurs when data is send from the host to the embedded system")]
    [DisplayName("OnDataSend")]
    [Category("Embedded Event")]
    public event EventHandler OnDataSend;

    public UsbHidPort()
    {
      this.product_id = 0;
      this.vendor_id = 0;
      this.specified_device = (SpecifiedDevice) null;
      this.device_class = Win32Usb.HIDGuid;
      this.InitializeComponent();
    }

    public UsbHidPort(IContainer container)
    {
      this.product_id = 0;
      this.vendor_id = 0;
      this.specified_device = (SpecifiedDevice) null;
      this.device_class = Win32Usb.HIDGuid;
      container.Add((IComponent) this);
      this.InitializeComponent();
    }

    public void RegisterHandle(IntPtr Handle)
    {
      this.usb_event_handle = Win32Usb.RegisterForUsbEvents(Handle, this.device_class);
      this.handle = Handle;
      this.CheckDevicePresent();
    }

    public bool UnregisterHandle()
    {
      return Win32Usb.UnregisterForUsbEvents(this.handle);
    }

    public void ParseMessages(ref Message m)
    {
      if (m.Msg != 537)
        return;
      switch (m.WParam.ToInt32())
      {
        case 32768:
          if (this.OnDeviceArrived == null)
            break;
          this.OnDeviceArrived((object) this, new EventArgs());
          this.CheckDevicePresent();
          break;
        case 32772:
          if (this.OnDeviceRemoved == null)
            break;
          this.OnDeviceRemoved((object) this, new EventArgs());
          this.CheckDevicePresent();
          break;
      }
    }

    public void CheckDevicePresent()
    {
      try
      {
        bool flag = false;
        if (this.specified_device != null)
          flag = true;
        this.specified_device = SpecifiedDevice.FindSpecifiedDevice(this.vendor_id, this.product_id);
        if (this.specified_device != null)
        {
          if (this.OnSpecifiedDeviceArrived == null)
            return;
          this.OnSpecifiedDeviceArrived((object) this, new EventArgs());
          this.specified_device.DataRecieved += new DataRecievedEventHandler(this.OnDataRecieved.Invoke);
          this.specified_device.DataSend += new DataSendEventHandler(this.OnDataSend.Invoke);
        }
        else
        {
          if (this.OnSpecifiedDeviceRemoved == null || !flag)
            return;
          this.OnSpecifiedDeviceRemoved((object) this, new EventArgs());
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.ToString());
      }
    }

    private void DataRecieved(object sender, DataRecievedEventArgs args)
    {
      if (this.OnDataRecieved == null)
        return;
      this.OnDataRecieved(sender, args);
    }

    private void DataSend(object sender, DataSendEventArgs args)
    {
      if (this.OnDataSend == null)
        return;
      this.OnDataSend(sender, (EventArgs) args);
    }

    protected override void Dispose(bool disposing)
    {
      this.UnregisterHandle();
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.components = (IContainer) new Container();
    }
  }
}
