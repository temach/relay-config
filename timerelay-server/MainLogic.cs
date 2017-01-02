using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsbLibrary;
using Newtonsoft.Json;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.Collections.Concurrent;
using System.Threading;
using Timer = System.Windows.Forms.Timer;

namespace timerelay_server
{
    enum USB_GetSequenceEnum
    {
        NO,
        GET_OPTIONS,
        SEND_OPTIONS,
    }

    class MainLogic : IDisposable
    {
        // public
        public CtrlProgramOptions InRelayCtrlProgramsOptions = new CtrlProgramOptions();
        public DeviceOptions InRelayDeviceOptions = new DeviceOptions();

        public DeviceOptions DeviceOpts = new DeviceOptions();
        public CtrlProgramOptions CtrlProgramsOpts = new CtrlProgramOptions();

        public ConnectionClass Connection = new ConnectionClass();
        public volatile bool USB_Connect = false;

        public volatile bool WaitingForRead;
        // from https://msdn.microsoft.com/en-us/library/dd997371.aspx
        // A bounded collection. It can hold no more 
        // than 1 items at once. This way everything is done orderly.
        private BlockingCollection<byte[]> UsbReceivedDataQueue = new BlockingCollection<byte[]>(1);

        // private
        private USB_GetSequenceEnum USB_GetSequence = USB_GetSequenceEnum.NO;
        private UsbHidPort usb;

        private JsonReadWrite jsonReadWrite = new JsonReadWrite();

        private int CtrlProgsMax = 8;

        private Timer timer1 = new Timer();
        private IContainer components = new Container();
        private object SyncLock = new object();

        static public MainLogic singletonMainLogic = null;

        static public MainLogic GetMainLogic()
        {
            if (singletonMainLogic != null)
            {
                return singletonMainLogic;
            }
            // else make the singleton
            singletonMainLogic = new MainLogic();
            // wait for device to be found
            while (singletonMainLogic.USB_Connect == false)
            {
                // in millisecs
                Thread.Sleep(100);
            }
            // read the time config, must be first action
            while (singletonMainLogic.WaitingForRead)
            {
                singletonMainLogic.usb_OnDataRecieved_WaitAndProcess();
            }
            return singletonMainLogic;
        }

        MainLogic()
        {
            timer1.Interval = 900000;
            timer1.Tick += new EventHandler(this.timer1_Tick);

            CreatCollectionForCtrlPrograms();
            this.Connection.LetLinksOnOptions(this.DeviceOpts, this.CtrlProgramsOpts);

            this.usb = new UsbHidPort(this.components);
            this.usb.ProductId = 23;
            this.usb.VendorId = 1982;
            this.usb.OnSpecifiedDeviceArrived += new EventHandler(this.usb_OnSpecifiedDeviceArrived);
            this.usb.OnSpecifiedDeviceRemoved += new EventHandler(this.usb_OnSpecifiedDeviceRemoved);
            this.usb.OnDataRecieved += new DataRecievedEventHandler(this.usb_OnDataReceivedAddToQueue);
            this.usb.OnDataSend += new EventHandler(this.usb_OnDataSend);
            this.usb.RegisterHandle(null);
        }

        private void usb_OnDataReceivedAddToQueue(object sender, DataRecievedEventArgs args)
        {
            // This is expected to be called from async read thread
            UsbReceivedDataQueue.Add((byte[])args.data.Clone());
        }

        private void CreatCollectionForCtrlPrograms()
        {
            for (int index = 0; index <= this.CtrlProgsMax + 1; ++index)
                this.CtrlProgramsOpts.Add(new CtrlProgramOptions());
        }

        private void usb_OnSpecifiedDeviceArrived(object sender, EventArgs e)
        {
            lock (this)
            {
                Console.WriteLine("My device was found");
                this.USB_Connect = true;
                this.GetDeviceTime();
            }
        }

        private void usb_OnSpecifiedDeviceRemoved(object sender, EventArgs e)
        {
            // only atomic operations
            Console.WriteLine("My device removed");
            this.USB_Connect = false;
        }

        private void usb_OnDataSend(object sender, EventArgs e)
        {
        }

        private void SaveDataInRelay()
        {
            lock (this)
            {
                this.InRelayCtrlProgramsOptions.Clear();
                foreach (CtrlProgramOptions ctrlProgramsOption in (CollectionBase)this.CtrlProgramsOpts)
                    this.InRelayCtrlProgramsOptions.Add((CtrlProgramOptions)ctrlProgramsOption.Clone());
                this.InRelayDeviceOptions = (DeviceOptions)this.DeviceOpts.Clone();
            }
        }

        private void MyUsbSendData()
        {
            lock(this)
            {
                WaitingForRead = true;
                try
                {
                    byte[] RefDataByte = new byte[32];
                    RefDataByte[0] = (byte)0;
                    if (!this.Connection.SendData(ref RefDataByte))
                        return;
                    if (this.usb.SpecifiedDevice != null)
                    {
                        this.usb.SpecifiedDevice.SendData(RefDataByte);
                    }
                    else
                    {
                        this.timer1.Enabled = false;
                        Console.WriteLine("Device not connect");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("While sending MyUsb:" + ex.Message);
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lock (this)
            {
                this.timer1.Enabled = false;
                this.Connection.ErrorConnect();
                if (this.Connection.TypeReadData != ModesRead.SEND_NEWTIME)
                {
                    Console.WriteLine("Connection error");
                }
                // add special token to signal error in input
                UsbReceivedDataQueue.Add(null);
            }
        }

        private void GetDeviceTime()
        {
            lock (this)
            {
                Console.WriteLine("Getting the time");
                if (this.timer1.Enabled || !this.Connection.NewTypeDataSend(ModesSend.REQUEST_DEVICETIME))
                    return;
                this.timer1.Enabled = true;
                this.MyUsbSendData();
            }
        }

        public void GetSettingsClick()
        {
            lock(this)
            {
                if (!this.Connection.NewTypeDataSend(ModesSend.REQUEST_NUM_VERSION))
                    return;
                this.timer1.Enabled = true;
                this.USB_GetSequence = USB_GetSequenceEnum.GET_OPTIONS;
                this.MyUsbSendData();
                // read settings
                while (this.WaitingForRead)
                {
                    this.usb_OnDataRecieved_WaitAndProcess();
                }
            }
        }

        public void SendSettingsClick()
        {
            lock (this)
            {
                if (!this.Connection.NewTypeDataSend(ModesSend.REQUEST_NUM_VERSION))
                    return;
                this.timer1.Enabled = true;
                this.USB_GetSequence = USB_GetSequenceEnum.SEND_OPTIONS;
                this.MyUsbSendData();
                // send settings
                while (this.WaitingForRead)
                {
                    this.usb_OnDataRecieved_WaitAndProcess();
                }
            }
        }

        public void OpenSettingsJSON(string json)
        {
            Tuple<DeviceOptions, CtrlProgramOptions> ret = jsonReadWrite.OpenFileJSON(json);
            lock(this)
            {
                this.DeviceOpts = ret.Item1;
                this.CtrlProgramsOpts = ret.Item2;
            }
        }

        public string SaveSettingsJSON()
        {
            DeviceOptions dev;
            CtrlProgramOptions progs;
            lock(this)
            {
                dev = (DeviceOptions)this.DeviceOpts.Clone();
                progs = (CtrlProgramOptions)this.CtrlProgramsOpts.Clone();
            }
            return jsonReadWrite.SaveFileJSON(dev, progs);
        }

        public void usb_OnDataRecieved_WaitAndProcess()
        {
            lock (this)
            {
                byte[] args_data = UsbReceivedDataQueue.Take();
                WaitingForRead = false; // read has just been accomplished!
                if (args_data == null)
                {
                    // this is a special token, symbolising that there was a read error
                    return;
                }
                Console.WriteLine("OnDataReceived");
                this.timer1.Enabled = true;
                switch (this.Connection.ReadData(args_data, ref this.DeviceOpts, ref this.CtrlProgramsOpts))
                {
                    case 1:
                        this.timer1.Enabled = false;
                        this.SaveDataInRelay();
                        Console.WriteLine("Settings read success.");
                        break;
                    case 2:
                        Console.WriteLine("USB: Receiving data");
                        if (this.Connection.NewTypeDataSend(ModesSend.CONTINUE))
                        {
                            this.MyUsbSendData();
                            break;
                        }
                        break;
                    case 3:
                        Console.WriteLine("USB: Sending data");
                        this.MyUsbSendData();
                        break;
                    case 4:
                        this.timer1.Enabled = false;
                        this.SaveDataInRelay();
                        Console.WriteLine("Settings send success");
                        break;
                    case 5:
                        Console.WriteLine("USB: Reading data");
                        this.MyUsbSendData();
                        break;
                    case 6:
                        this.timer1.Enabled = false;
                        Console.WriteLine("USB case 6");
                        break;
                    case 7:
                        if (this.USB_GetSequence == USB_GetSequenceEnum.GET_OPTIONS)
                        {
                            if (this.CompareVersions(this.Connection.VersionOfDeviceProgram, this.Connection.SubVersionOfDeviceProgram))
                            {
                                if (this.Connection.NewTypeDataSend(ModesSend.REQUEST_NUM_EVENTS))
                                {
                                    this.MyUsbSendData();
                                    break;
                                }
                                break;
                            }
                            this.timer1.Enabled = false;
                            this.USB_GetSequence = USB_GetSequenceEnum.NO;
                            Console.WriteLine("Bad verison in get_options");
                            break;
                        }
                        if (this.USB_GetSequence == USB_GetSequenceEnum.SEND_OPTIONS)
                        {
                            if (this.CompareVersions(this.Connection.VersionOfDeviceProgram, this.Connection.SubVersionOfDeviceProgram))
                            {
                                if (this.Connection.NewTypeDataSend(ModesSend.REQUEST_NUM_PLACES))
                                {
                                    this.timer1.Enabled = true;
                                    this.Connection.DevOpt = this.DeviceOpts;
                                    this.Connection.ProgsOpt = this.CtrlProgramsOpts;
                                    this.Connection.NeededPlaces = 0;
                                    for (int index = 1; index <= 8; ++index)
                                        this.Connection.NeededPlaces += this.CtrlProgramsOpts[index].ListHolidays.Count + this.CtrlProgramsOpts[index].ListEventsException.Count + this.CtrlProgramsOpts[index].ListEventsYear.Count + this.CtrlProgramsOpts[index].ListEventsMonth.Count + this.CtrlProgramsOpts[index].ListEventsWeek.Count + this.CtrlProgramsOpts[index].ListEventsDay.Count;
                                    this.MyUsbSendData();
                                    break;
                                }
                                break;
                            }
                            this.timer1.Enabled = false;
                            this.USB_GetSequence = USB_GetSequenceEnum.NO;
                            Console.WriteLine("Bad verison in general");
                            break;
                        }
                        this.timer1.Enabled = false;
                        Console.WriteLine("Check version");
                        break;
                    case 8:
                        this.timer1.Enabled = false;
                        Console.WriteLine("case 8");
                        break;
                    case 9:
                        this.timer1.Enabled = false;
                        Console.WriteLine("New time send, case 9");
                        break;
                    case 10:
                        this.timer1.Enabled = false;
                        Console.WriteLine(" Калибрование успешно завершено.\nПроконтролируйте точность скорректированных значений.");
                        break;
                    case 11:
                        this.timer1.Enabled = false;
                        Console.WriteLine(" Калибровочное значение времени успешно записано в устройство.\nПроконтролируйте точность хода времени.");
                        break;
                }

            }
        }

        private bool CompareVersions(int ver, int subver)
        {
            if (ver != 1)
                return false;
            switch (subver)
            {
                case 1:
                    return true;
                case 2:
                    return true;
                default:
                    return false;
            }
        }

        ~MainLogic()
        {
            Dispose(true);
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
                this.components.Dispose();
        }


    }
}
