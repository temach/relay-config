// NoAuthor
// Type: MultiTimerWinForms.ConnectionClass
// Assembly: MultiTimer, Version=1.5.2.0, Culture=neutral, PublicKeyToken=null
// MVID: BCBF5A5D-507A-4FEA-8EFC-8CECD33998F9
// Assembly location: C:\Program Files (x86)\Novatek-Electro\Configurator REV-302\MultiTimer.exe

using System;
using System.Collections;

namespace MultiTimerWinForms
{
  public class ConnectionClass
  {
    private TimerClass[] ListsEvents = new TimerClass[6];
    public DeviceOptionsClass DevOpt = new DeviceOptionsClass();
    public CtrlProgramOptionsClass ProgsOpt = new CtrlProgramOptionsClass();
    private int BytesCount;
    public int ByteInSendBlock;
    public int ByteInReadBlock;
    public ModesSend TypeSendData;
    public ModesRead TypeReadData;
    public int NumProgOfData;
    public int CountLoops;
    private int MaxItemsList;
    private int CountItemsList;
    public int ProgressBarPercent;
    public int FullBytes;
    private int ByteInSendBlockAbs;
    private int ByteInReadBlockAbs;
    public int EnablePlacesInDevice;
    public int NeededPlaces;
    public int VersionOfDeviceProgram;
    public int SubVersionOfDeviceProgram;
    public DateTime DeviceTime;
    public DateTime SendTimeToDevice;
    public int ReadVoltage;
    public int ReadBright;
    public int WriteVoltage;
    public int WriteBright;
    public byte RTCCalibrValue;

    public ConnectionClass()
    {
      this.BytesCount = 0;
    }

    public void LetLinksOnOptions(DeviceOptionsClass Dev1, CtrlProgramOptionsClass Prog1)
    {
      this.ResetVars();
    }

    public void ResetVars()
    {
      DeviceOptionsClass deviceOptionsClass = new DeviceOptionsClass();
      CtrlProgramOptionsClass programOptionsClass = new CtrlProgramOptionsClass();
      for (int index = 0; index <= 9; ++index)
        programOptionsClass.Add(new CtrlProgramOptionsClass());
      this.DevOpt = deviceOptionsClass;
      this.ProgsOpt = programOptionsClass;
    }

    public void ErrorConnect()
    {
      this.TypeSendData = ModesSend.NO;
      this.TypeReadData = ModesRead.NO;
      this.ResetVars();
    }

    public bool NewTypeDataSend(ModesSend NewTypeSend)
    {
      bool flag = false;
      if (this.TypeSendData == ModesSend.NO)
      {
        this.TypeSendData = NewTypeSend;
        this.ByteInSendBlock = 0;
        this.ByteInSendBlockAbs = 0;
        flag = true;
      }
      return flag;
    }

    public bool NewTypeDataRead(ModesRead NewTypeRead)
    {
      bool flag = false;
      if (this.TypeReadData == ModesRead.NO)
      {
        this.TypeReadData = NewTypeRead;
        this.ByteInReadBlock = 0;
        this.ByteInReadBlockAbs = 0;
        flag = true;
      }
      return flag;
    }

    private byte BoolToByte(bool data)
    {
      return !data ? (byte) 0 : (byte) 1;
    }

    public bool SendData(ref byte[] RefDataByte)
    {
      bool flag = false;
      RefDataByte[0] = (byte) 0;
      switch (this.TypeSendData)
      {
        case ModesSend.REQUEST_OPTIONS:
          RefDataByte[1] = (byte) 10;
          for (int index = 2; index <= 31; ++index)
            RefDataByte[index] = (byte) 0;
          this.TypeSendData = ModesSend.NO;
          this.NewTypeDataRead(ModesRead.OPTIONS);
          flag = true;
          break;
        case ModesSend.PREP_GET_OPTIONS:
          RefDataByte[1] = (byte) 11;
          for (int index = 2; index <= 31; ++index)
            RefDataByte[index] = (byte) 0;
          this.TypeSendData = ModesSend.SEND_OPTIONS;
          this.ByteInSendBlock = 0;
          flag = true;
          break;
        case ModesSend.SEND_OPTIONS:
          flag = true;
          for (int index1 = 1; index1 <= 31; ++index1)
          {
            ++this.ByteInSendBlock;
            ++this.ByteInSendBlockAbs;
            if (this.FullBytes != 0)
              this.ProgressBarPercent = this.ByteInSendBlockAbs * 100 / this.FullBytes;
            switch (this.ByteInSendBlock)
            {
              case 1:
                RefDataByte[index1] = this.DevOpt.Channel_CtrlProg[1];
                this.NumProgOfData = 1;
                this.CountLoops = 1;
                this.FullBytes = 500;
                for (int index2 = 1; index2 <= 8; ++index2)
                {
                  this.ListsEvents[0] = this.ProgsOpt[index2].ListHolidays;
                  this.ListsEvents[1] = this.ProgsOpt[index2].ListEventsException;
                  this.ListsEvents[2] = this.ProgsOpt[index2].ListEventsYear;
                  this.ListsEvents[3] = this.ProgsOpt[index2].ListEventsMonth;
                  this.ListsEvents[4] = this.ProgsOpt[index2].ListEventsWeek;
                  this.ListsEvents[5] = this.ProgsOpt[index2].ListEventsDay;
                  foreach (CollectionBase listsEvent in this.ListsEvents)
                    this.FullBytes += listsEvent.Count * 8;
                }
                break;
              case 2:
                RefDataByte[index1] = this.DevOpt.Channel_CtrlProg[2];
                break;
              case 3:
                RefDataByte[index1] = this.BoolToByte(this.DevOpt.DST_OnOff);
                break;
              case 4:
                RefDataByte[index1] = (byte) this.DevOpt.CommonDelay.Minute;
                break;
              case 5:
                RefDataByte[index1] = (byte) this.DevOpt.CommonDelay.Second;
                break;
              case 6:
                RefDataByte[index1] = (byte) this.ProgsOpt[this.NumProgOfData].RelayTimeMode;
                this.CountLoops = 1;
                break;
              case 7:
                RefDataByte[index1] = this.BoolToByte(this.ProgsOpt[this.NumProgOfData].ExceptDaysOfWeek[this.CountLoops]);
                if (this.CountLoops < 7)
                {
                  ++this.CountLoops;
                  this.ByteInSendBlock = 6;
                  break;
                }
                this.CountLoops = 0;
                break;
              case 8:
                RefDataByte[index1] = this.BoolToByte(this.ProgsOpt[this.NumProgOfData].AllowDaysoffs);
                break;
              case 9:
                RefDataByte[index1] = this.BoolToByte(this.ProgsOpt[this.NumProgOfData].AllowHolidays);
                break;
              case 10:
                RefDataByte[index1] = this.BoolToByte(this.ProgsOpt[this.NumProgOfData].AllowCyclicity);
                this.CountLoops = 0;
                break;
              case 11:
                switch (this.CountLoops)
                {
                  case 0:
                    RefDataByte[index1] = (byte) this.ProgsOpt[this.NumProgOfData].RI_BeforeDelay.Minute;
                    continue;
                  case 1:
                    RefDataByte[index1] = (byte) this.ProgsOpt[this.NumProgOfData].RI_OnDelay.Minute;
                    continue;
                  case 2:
                    RefDataByte[index1] = (byte) this.ProgsOpt[this.NumProgOfData].RI_OffDelay.Minute;
                    continue;
                  case 3:
                    RefDataByte[index1] = (byte) this.ProgsOpt[this.NumProgOfData].RS_Delay.Minute;
                    continue;
                  case 4:
                    RefDataByte[index1] = (byte) this.ProgsOpt[this.NumProgOfData].RV_DelayUmin.Minute;
                    continue;
                  case 5:
                    RefDataByte[index1] = (byte) this.ProgsOpt[this.NumProgOfData].RV_DelayUnorm.Minute;
                    continue;
                  case 6:
                    RefDataByte[index1] = (byte) this.ProgsOpt[this.NumProgOfData].RV_DelayUmax.Minute;
                    continue;
                  case 7:
                    RefDataByte[index1] = (byte) this.ProgsOpt[this.NumProgOfData].RF_DelayLmin.Minute;
                    continue;
                  case 8:
                    RefDataByte[index1] = (byte) this.ProgsOpt[this.NumProgOfData].RF_DelayLmax.Minute;
                    continue;
                  default:
                    continue;
                }
              case 12:
                switch (this.CountLoops)
                {
                  case 0:
                    RefDataByte[index1] = (byte) this.ProgsOpt[this.NumProgOfData].RI_BeforeDelay.Second;
                    break;
                  case 1:
                    RefDataByte[index1] = (byte) this.ProgsOpt[this.NumProgOfData].RI_OnDelay.Second;
                    break;
                  case 2:
                    RefDataByte[index1] = (byte) this.ProgsOpt[this.NumProgOfData].RI_OffDelay.Second;
                    break;
                  case 3:
                    RefDataByte[index1] = (byte) this.ProgsOpt[this.NumProgOfData].RS_Delay.Second;
                    break;
                  case 4:
                    RefDataByte[index1] = (byte) this.ProgsOpt[this.NumProgOfData].RV_DelayUmin.Second;
                    break;
                  case 5:
                    RefDataByte[index1] = (byte) this.ProgsOpt[this.NumProgOfData].RV_DelayUnorm.Second;
                    break;
                  case 6:
                    RefDataByte[index1] = (byte) this.ProgsOpt[this.NumProgOfData].RV_DelayUmax.Second;
                    break;
                  case 7:
                    RefDataByte[index1] = (byte) this.ProgsOpt[this.NumProgOfData].RF_DelayLmin.Second;
                    break;
                  case 8:
                    RefDataByte[index1] = (byte) this.ProgsOpt[this.NumProgOfData].RF_DelayLmax.Second;
                    break;
                }
                if (this.CountLoops < 8)
                {
                  ++this.CountLoops;
                  this.ByteInSendBlock = 10;
                  break;
                }
                this.CountLoops = 0;
                break;
              case 13:
                RefDataByte[index1] = this.BoolToByte(this.ProgsOpt[this.NumProgOfData].RV_OnOff);
                break;
              case 14:
                RefDataByte[index1] = (byte) (this.ProgsOpt[this.NumProgOfData].RV_Umin & (int) byte.MaxValue);
                break;
              case 15:
                RefDataByte[index1] = (byte) (this.ProgsOpt[this.NumProgOfData].RV_Umin >> 8 & (int) byte.MaxValue);
                break;
              case 16:
                RefDataByte[index1] = (byte) (this.ProgsOpt[this.NumProgOfData].RV_Umax & (int) byte.MaxValue);
                break;
              case 17:
                RefDataByte[index1] = (byte) (this.ProgsOpt[this.NumProgOfData].RV_Umax >> 8 & (int) byte.MaxValue);
                break;
              case 18:
                RefDataByte[index1] = (byte) this.ProgsOpt[this.NumProgOfData].RV_Uminhyst;
                break;
              case 19:
                RefDataByte[index1] = (byte) this.ProgsOpt[this.NumProgOfData].RV_Umaxhyst;
                break;
              case 20:
                RefDataByte[index1] = this.BoolToByte(this.ProgsOpt[this.NumProgOfData].RF_OnOff);
                break;
              case 21:
                RefDataByte[index1] = (byte) (this.ProgsOpt[this.NumProgOfData].RF_Lpor & (int) byte.MaxValue);
                break;
              case 22:
                RefDataByte[index1] = (byte) (this.ProgsOpt[this.NumProgOfData].RF_Lpor >> 8 & (int) byte.MaxValue);
                break;
              case 23:
                RefDataByte[index1] = (byte) (this.ProgsOpt[this.NumProgOfData].RF_Lporhyst & (int) byte.MaxValue);
                break;
              case 24:
                RefDataByte[index1] = (byte) (this.ProgsOpt[this.NumProgOfData].RF_Lporhyst >> 8 & (int) byte.MaxValue);
                break;
              case 25:
                RefDataByte[index1] = (byte) this.ProgsOpt[this.NumProgOfData].RF_Condition_Lmin;
                break;
              case 26:
                RefDataByte[index1] = (byte) this.ProgsOpt[this.NumProgOfData].RF_Condition_Lmax;
                this.CountLoops = 0;
                this.ListsEvents[0] = this.ProgsOpt[this.NumProgOfData].ListHolidays;
                this.ListsEvents[1] = this.ProgsOpt[this.NumProgOfData].ListEventsException;
                this.ListsEvents[2] = this.ProgsOpt[this.NumProgOfData].ListEventsYear;
                this.ListsEvents[3] = this.ProgsOpt[this.NumProgOfData].ListEventsMonth;
                this.ListsEvents[4] = this.ProgsOpt[this.NumProgOfData].ListEventsWeek;
                this.ListsEvents[5] = this.ProgsOpt[this.NumProgOfData].ListEventsDay;
                break;
              case 27:
                this.MaxItemsList = this.ListsEvents[this.CountLoops].Count;
                RefDataByte[index1] = (byte) (this.MaxItemsList & (int) byte.MaxValue);
                break;
              case 28:
                RefDataByte[index1] = (byte) (this.MaxItemsList >> 8 & (int) byte.MaxValue);
                if (this.MaxItemsList == 0)
                {
                  this.ByteInSendBlock = 35;
                  break;
                }
                this.CountItemsList = 1;
                break;
              case 29:
                RefDataByte[index1] = (byte) this.ListsEvents[this.CountLoops][this.CountItemsList - 1].DateAndTime.Month;
                break;
              case 30:
                RefDataByte[index1] = (byte) this.ListsEvents[this.CountLoops][this.CountItemsList - 1].DateAndTime.Day;
                break;
              case 31:
                RefDataByte[index1] = (byte) (this.ListsEvents[this.CountLoops][this.CountItemsList - 1].DateAndTime.Day - 1);
                break;
              case 32:
                RefDataByte[index1] = (byte) this.ListsEvents[this.CountLoops][this.CountItemsList - 1].DateAndTime.Hour;
                break;
              case 33:
                RefDataByte[index1] = (byte) this.ListsEvents[this.CountLoops][this.CountItemsList - 1].DateAndTime.Minute;
                break;
              case 34:
                RefDataByte[index1] = (byte) this.ListsEvents[this.CountLoops][this.CountItemsList - 1].DateAndTime.Second;
                break;
              case 35:
                RefDataByte[index1] = this.BoolToByte(this.ListsEvents[this.CountLoops][this.CountItemsList - 1].Condition);
                if (this.CountItemsList < this.MaxItemsList)
                {
                  ++this.CountItemsList;
                  this.ByteInSendBlock = 28;
                  break;
                }
                this.ByteInSendBlock = 35;
                break;
              case 36:
                if (this.CountLoops < 5)
                {
                  ++this.CountLoops;
                  this.ByteInSendBlock = 26;
                  break;
                }
                this.ByteInSendBlock = 36;
                this.CountLoops = 0;
                break;
              case 37:
                if (this.NumProgOfData < 8)
                {
                  ++this.NumProgOfData;
                  this.ByteInSendBlock = 5;
                  this.CountLoops = 1;
                  break;
                }
                break;
              case 38:
                this.TypeSendData = ModesSend.NO;
                break;
            }
          }
          break;
        case ModesSend.REQUEST_NUM_EVENTS:
          RefDataByte[1] = (byte) 14;
          for (int index = 2; index <= 31; ++index)
            RefDataByte[index] = (byte) 0;
          this.TypeSendData = ModesSend.NO;
          this.NewTypeDataRead(ModesRead.NUM_EVENTS);
          flag = true;
          break;
        case ModesSend.REQUEST_NUM_PLACES:
          RefDataByte[1] = (byte) 15;
          for (int index = 2; index <= 31; ++index)
            RefDataByte[index] = (byte) 0;
          this.TypeSendData = ModesSend.NO;
          this.NewTypeDataRead(ModesRead.NUM_PLACES);
          flag = true;
          break;
        case ModesSend.REQUEST_NUM_VERSION:
          RefDataByte[1] = (byte) 16;
          for (int index = 2; index <= 31; ++index)
            RefDataByte[index] = (byte) 0;
          this.TypeSendData = ModesSend.NO;
          this.NewTypeDataRead(ModesRead.NUM_VERSION);
          flag = true;
          break;
        case ModesSend.REQUEST_DEVICETIME:
          RefDataByte[1] = (byte) 17;
          for (int index = 2; index <= 31; ++index)
            RefDataByte[index] = (byte) 0;
          this.TypeSendData = ModesSend.NO;
          this.NewTypeDataRead(ModesRead.DEVICETIME);
          flag = true;
          break;
        case ModesSend.SEND_NEWTIME:
          RefDataByte[1] = (byte) 18;
          RefDataByte[2] = (byte) (this.SendTimeToDevice.Year & (int) byte.MaxValue);
          RefDataByte[3] = (byte) (this.SendTimeToDevice.Year >> 8 & (int) byte.MaxValue);
          RefDataByte[4] = (byte) this.SendTimeToDevice.Month;
          RefDataByte[5] = (byte) this.SendTimeToDevice.Day;
          RefDataByte[6] = (byte) this.SendTimeToDevice.Hour;
          RefDataByte[7] = (byte) this.SendTimeToDevice.Minute;
          RefDataByte[8] = (byte) this.SendTimeToDevice.Second;
          for (int index = 9; index <= 31; ++index)
            RefDataByte[index] = (byte) 0;
          this.TypeSendData = ModesSend.NO;
          this.TypeReadData = ModesRead.SEND_NEWTIME;
          flag = true;
          break;
        case ModesSend.SEND_NEWVOLTBRIGHT:
          RefDataByte[1] = (byte) 19;
          RefDataByte[2] = (byte) (this.WriteVoltage & (int) byte.MaxValue);
          RefDataByte[3] = (byte) (this.WriteVoltage >> 8 & (int) byte.MaxValue);
          RefDataByte[4] = (byte) (this.WriteBright & (int) byte.MaxValue);
          RefDataByte[5] = (byte) (this.WriteBright >> 8 & (int) byte.MaxValue);
          for (int index = 6; index <= 31; ++index)
            RefDataByte[index] = (byte) 0;
          this.TypeSendData = ModesSend.NO;
          this.TypeReadData = ModesRead.SEND_NEWVOLTBRIGHT;
          flag = true;
          break;
        case ModesSend.SEND_FACTORYTIMECALIBR:
          RefDataByte[1] = (byte) 20;
          RefDataByte[2] = this.RTCCalibrValue;
          for (int index = 3; index <= 31; ++index)
            RefDataByte[index] = (byte) 0;
          this.TypeSendData = ModesSend.NO;
          this.TypeReadData = ModesRead.SEND_FACTORYTIMECALIBR;
          flag = true;
          break;
        case ModesSend.CONTINUE:
          RefDataByte[1] = (byte) 127;
          for (int index = 2; index <= 31; ++index)
            RefDataByte[index] = (byte) 0;
          this.TypeSendData = ModesSend.NO;
          flag = true;
          break;
      }
      return flag;
    }

    public int ReadData(byte[] newDataByte, ref DeviceOptionsClass DeviceOptions, ref CtrlProgramOptionsClass CtrlProgramsOptions)
    {
      int num = 0;
      this.BytesCount = 0;
      switch (this.TypeReadData)
      {
        case ModesRead.NO:
          if ((int) newDataByte[1] == (int) sbyte.MaxValue)
          {
            num = this.TypeSendData == ModesSend.NO ? 4 : 3;
            break;
          }
          break;
        case ModesRead.OPTIONS:
          num = 2;
          for (int index = 1; index <= 31; ++index)
          {
            ++this.ByteInReadBlock;
            ++this.ByteInReadBlockAbs;
            this.ProgressBarPercent = 0;
            if (this.FullBytes != 0)
              this.ProgressBarPercent = this.ByteInReadBlockAbs * 100 / this.FullBytes;
            DateTime dateAndTime;
            switch (this.ByteInReadBlock)
            {
              case 1:
                this.ResetVars();
                this.DevOpt.Channel_CtrlProg[1] = newDataByte[index];
                this.NumProgOfData = 1;
                this.CountLoops = 1;
                break;
              case 2:
                this.DevOpt.Channel_CtrlProg[2] = newDataByte[index];
                break;
              case 3:
                this.DevOpt.DST_OnOff = (int) newDataByte[index] != 0;
                break;
              case 4:
                this.DevOpt.CommonDelay.Minute = (int) newDataByte[index];
                break;
              case 5:
                this.DevOpt.CommonDelay.Second = (int) newDataByte[index];
                break;
              case 6:
                this.ProgsOpt[this.NumProgOfData].RelayTimeMode = (CtrlProgramOptionsClass.RelayTimeModeType) newDataByte[index];
                this.CountLoops = 1;
                break;
              case 7:
                this.ProgsOpt[this.NumProgOfData].ExceptDaysOfWeek[this.CountLoops] = (int) newDataByte[index] != 0;
                if (this.CountLoops < 7)
                {
                  ++this.CountLoops;
                  this.ByteInReadBlock = 6;
                  break;
                }
                this.CountLoops = 0;
                break;
              case 8:
                this.ProgsOpt[this.NumProgOfData].AllowDaysoffs = (int) newDataByte[index] != 0;
                break;
              case 9:
                this.ProgsOpt[this.NumProgOfData].AllowHolidays = (int) newDataByte[index] != 0;
                break;
              case 10:
                this.ProgsOpt[this.NumProgOfData].AllowCyclicity = (int) newDataByte[index] != 0;
                this.CountLoops = 0;
                break;
              case 11:
                switch (this.CountLoops)
                {
                  case 0:
                    this.ProgsOpt[this.NumProgOfData].RI_BeforeDelay.Minute = (int) newDataByte[index];
                    continue;
                  case 1:
                    this.ProgsOpt[this.NumProgOfData].RI_OnDelay.Minute = (int) newDataByte[index];
                    continue;
                  case 2:
                    this.ProgsOpt[this.NumProgOfData].RI_OffDelay.Minute = (int) newDataByte[index];
                    continue;
                  case 3:
                    this.ProgsOpt[this.NumProgOfData].RS_Delay.Minute = (int) newDataByte[index];
                    continue;
                  case 4:
                    this.ProgsOpt[this.NumProgOfData].RV_DelayUmin.Minute = (int) newDataByte[index];
                    continue;
                  case 5:
                    this.ProgsOpt[this.NumProgOfData].RV_DelayUnorm.Minute = (int) newDataByte[index];
                    continue;
                  case 6:
                    this.ProgsOpt[this.NumProgOfData].RV_DelayUmax.Minute = (int) newDataByte[index];
                    continue;
                  case 7:
                    this.ProgsOpt[this.NumProgOfData].RF_DelayLmin.Minute = (int) newDataByte[index];
                    continue;
                  case 8:
                    this.ProgsOpt[this.NumProgOfData].RF_DelayLmax.Minute = (int) newDataByte[index];
                    continue;
                  default:
                    continue;
                }
              case 12:
                switch (this.CountLoops)
                {
                  case 0:
                    this.ProgsOpt[this.NumProgOfData].RI_BeforeDelay.Second = (int) newDataByte[index];
                    break;
                  case 1:
                    this.ProgsOpt[this.NumProgOfData].RI_OnDelay.Second = (int) newDataByte[index];
                    break;
                  case 2:
                    this.ProgsOpt[this.NumProgOfData].RI_OffDelay.Second = (int) newDataByte[index];
                    break;
                  case 3:
                    this.ProgsOpt[this.NumProgOfData].RS_Delay.Second = (int) newDataByte[index];
                    break;
                  case 4:
                    this.ProgsOpt[this.NumProgOfData].RV_DelayUmin.Second = (int) newDataByte[index];
                    break;
                  case 5:
                    this.ProgsOpt[this.NumProgOfData].RV_DelayUnorm.Second = (int) newDataByte[index];
                    break;
                  case 6:
                    this.ProgsOpt[this.NumProgOfData].RV_DelayUmax.Second = (int) newDataByte[index];
                    break;
                  case 7:
                    this.ProgsOpt[this.NumProgOfData].RF_DelayLmin.Second = (int) newDataByte[index];
                    break;
                  case 8:
                    this.ProgsOpt[this.NumProgOfData].RF_DelayLmax.Second = (int) newDataByte[index];
                    break;
                }
                if (this.CountLoops < 8)
                {
                  ++this.CountLoops;
                  this.ByteInReadBlock = 10;
                  break;
                }
                this.CountLoops = 0;
                break;
              case 13:
                this.ProgsOpt[this.NumProgOfData].RV_OnOff = (int) newDataByte[index] != 0;
                break;
              case 14:
                this.ProgsOpt[this.NumProgOfData].RV_Umin = (int) newDataByte[index];
                break;
              case 15:
                this.ProgsOpt[this.NumProgOfData].RV_Umin |= (int) newDataByte[index] << 8;
                break;
              case 16:
                this.ProgsOpt[this.NumProgOfData].RV_Umax = (int) newDataByte[index];
                break;
              case 17:
                this.ProgsOpt[this.NumProgOfData].RV_Umax |= (int) newDataByte[index] << 8;
                break;
              case 18:
                this.ProgsOpt[this.NumProgOfData].RV_Uminhyst = (int) newDataByte[index];
                break;
              case 19:
                this.ProgsOpt[this.NumProgOfData].RV_Umaxhyst = (int) newDataByte[index];
                break;
              case 20:
                this.ProgsOpt[this.NumProgOfData].RF_OnOff = (int) newDataByte[index] != 0;
                break;
              case 21:
                this.ProgsOpt[this.NumProgOfData].RF_Lpor = (int) newDataByte[index];
                break;
              case 22:
                this.ProgsOpt[this.NumProgOfData].RF_Lpor |= (int) newDataByte[index] << 8;
                break;
              case 23:
                this.ProgsOpt[this.NumProgOfData].RF_Lporhyst = (int) newDataByte[index];
                break;
              case 24:
                this.ProgsOpt[this.NumProgOfData].RF_Lporhyst |= (int) newDataByte[index] << 8;
                break;
              case 25:
                this.ProgsOpt[this.NumProgOfData].RF_Condition_Lmin = (int) newDataByte[index];
                break;
              case 26:
                this.ProgsOpt[this.NumProgOfData].RF_Condition_Lmax = (int) newDataByte[index];
                this.CountLoops = 0;
                break;
              case 27:
                this.MaxItemsList = (int) newDataByte[index];
                break;
              case 28:
                this.MaxItemsList |= (int) newDataByte[index] << 8;
                if (this.MaxItemsList == 0)
                {
                  this.ByteInReadBlock = 35;
                  break;
                }
                this.CountItemsList = 1;
                break;
              case 29:
                switch (this.CountLoops)
                {
                  case 0:
                    this.ProgsOpt[this.NumProgOfData].ListHolidays.Add(new TimerClass());
                    this.ProgsOpt[this.NumProgOfData].ListHolidays[this.CountItemsList - 1].DateAndTime = new DateTime(1996, (int) newDataByte[index], 1, 0, 0, 0);
                    continue;
                  case 1:
                    this.ProgsOpt[this.NumProgOfData].ListEventsException.Add(new TimerClass());
                    this.ProgsOpt[this.NumProgOfData].ListEventsException[this.CountItemsList - 1].DateAndTime = new DateTime(1996, 1, 1, 0, 0, 0);
                    continue;
                  case 2:
                    this.ProgsOpt[this.NumProgOfData].ListEventsYear.Add(new TimerClass());
                    this.ProgsOpt[this.NumProgOfData].ListEventsYear[this.CountItemsList - 1].DateAndTime = new DateTime(1996, (int) newDataByte[index], 1, 0, 0, 0);
                    continue;
                  case 3:
                    this.ProgsOpt[this.NumProgOfData].ListEventsMonth.Add(new TimerClass());
                    this.ProgsOpt[this.NumProgOfData].ListEventsMonth[this.CountItemsList - 1].DateAndTime = new DateTime(1996, (int) newDataByte[index], 1, 0, 0, 0);
                    continue;
                  case 4:
                    this.ProgsOpt[this.NumProgOfData].ListEventsWeek.Add(new TimerClass());
                    this.ProgsOpt[this.NumProgOfData].ListEventsWeek[this.CountItemsList - 1].DateAndTime = new DateTime(1996, 1, 1, 0, 0, 0);
                    continue;
                  case 5:
                    this.ProgsOpt[this.NumProgOfData].ListEventsDay.Add(new TimerClass());
                    this.ProgsOpt[this.NumProgOfData].ListEventsDay[this.CountItemsList - 1].DateAndTime = new DateTime(1996, 1, 1, 0, 0, 0);
                    continue;
                  default:
                    continue;
                }
              case 30:
                switch (this.CountLoops)
                {
                  case 0:
                    dateAndTime = this.ProgsOpt[this.NumProgOfData].ListHolidays[this.CountItemsList - 1].DateAndTime;
                    this.ProgsOpt[this.NumProgOfData].ListHolidays[this.CountItemsList - 1].DateAndTime = new DateTime(1996, dateAndTime.Month, (int) newDataByte[index], dateAndTime.Hour, dateAndTime.Minute, dateAndTime.Second);
                    continue;
                  case 2:
                    dateAndTime = this.ProgsOpt[this.NumProgOfData].ListEventsYear[this.CountItemsList - 1].DateAndTime;
                    this.ProgsOpt[this.NumProgOfData].ListEventsYear[this.CountItemsList - 1].DateAndTime = new DateTime(1996, dateAndTime.Month, (int) newDataByte[index], dateAndTime.Hour, dateAndTime.Minute, dateAndTime.Second);
                    continue;
                  case 3:
                    dateAndTime = this.ProgsOpt[this.NumProgOfData].ListEventsMonth[this.CountItemsList - 1].DateAndTime;
                    this.ProgsOpt[this.NumProgOfData].ListEventsMonth[this.CountItemsList - 1].DateAndTime = new DateTime(1996, dateAndTime.Month, (int) newDataByte[index], dateAndTime.Hour, dateAndTime.Minute, dateAndTime.Second);
                    continue;
                  default:
                    continue;
                }
              case 31:
                switch (this.CountLoops)
                {
                  case 4:
                    dateAndTime = this.ProgsOpt[this.NumProgOfData].ListEventsWeek[this.CountItemsList - 1].DateAndTime;
                    this.ProgsOpt[this.NumProgOfData].ListEventsWeek[this.CountItemsList - 1].DateAndTime = new DateTime(1996, 1, (int) newDataByte[index] + 1, dateAndTime.Hour, dateAndTime.Minute, dateAndTime.Second);
                    continue;
                  default:
                    continue;
                }
              case 32:
                switch (this.CountLoops)
                {
                  case 1:
                    dateAndTime = this.ProgsOpt[this.NumProgOfData].ListEventsException[this.CountItemsList - 1].DateAndTime;
                    this.ProgsOpt[this.NumProgOfData].ListEventsException[this.CountItemsList - 1].DateAndTime = new DateTime(1996, dateAndTime.Month, dateAndTime.Day, (int) newDataByte[index], dateAndTime.Minute, dateAndTime.Second);
                    continue;
                  case 2:
                    dateAndTime = this.ProgsOpt[this.NumProgOfData].ListEventsYear[this.CountItemsList - 1].DateAndTime;
                    this.ProgsOpt[this.NumProgOfData].ListEventsYear[this.CountItemsList - 1].DateAndTime = new DateTime(1996, dateAndTime.Month, dateAndTime.Day, (int) newDataByte[index], dateAndTime.Minute, dateAndTime.Second);
                    continue;
                  case 3:
                    dateAndTime = this.ProgsOpt[this.NumProgOfData].ListEventsMonth[this.CountItemsList - 1].DateAndTime;
                    this.ProgsOpt[this.NumProgOfData].ListEventsMonth[this.CountItemsList - 1].DateAndTime = new DateTime(1996, dateAndTime.Month, dateAndTime.Day, (int) newDataByte[index], dateAndTime.Minute, dateAndTime.Second);
                    continue;
                  case 4:
                    dateAndTime = this.ProgsOpt[this.NumProgOfData].ListEventsWeek[this.CountItemsList - 1].DateAndTime;
                    this.ProgsOpt[this.NumProgOfData].ListEventsWeek[this.CountItemsList - 1].DateAndTime = new DateTime(1996, dateAndTime.Month, dateAndTime.Day, (int) newDataByte[index], dateAndTime.Minute, dateAndTime.Second);
                    continue;
                  case 5:
                    dateAndTime = this.ProgsOpt[this.NumProgOfData].ListEventsDay[this.CountItemsList - 1].DateAndTime;
                    this.ProgsOpt[this.NumProgOfData].ListEventsDay[this.CountItemsList - 1].DateAndTime = new DateTime(1996, dateAndTime.Month, dateAndTime.Day, (int) newDataByte[index], dateAndTime.Minute, dateAndTime.Second);
                    continue;
                  default:
                    continue;
                }
              case 33:
                switch (this.CountLoops)
                {
                  case 1:
                    dateAndTime = this.ProgsOpt[this.NumProgOfData].ListEventsException[this.CountItemsList - 1].DateAndTime;
                    this.ProgsOpt[this.NumProgOfData].ListEventsException[this.CountItemsList - 1].DateAndTime = new DateTime(1996, dateAndTime.Month, dateAndTime.Day, dateAndTime.Hour, (int) newDataByte[index], dateAndTime.Second);
                    continue;
                  case 2:
                    dateAndTime = this.ProgsOpt[this.NumProgOfData].ListEventsYear[this.CountItemsList - 1].DateAndTime;
                    this.ProgsOpt[this.NumProgOfData].ListEventsYear[this.CountItemsList - 1].DateAndTime = new DateTime(1996, dateAndTime.Month, dateAndTime.Day, dateAndTime.Hour, (int) newDataByte[index], dateAndTime.Second);
                    continue;
                  case 3:
                    dateAndTime = this.ProgsOpt[this.NumProgOfData].ListEventsMonth[this.CountItemsList - 1].DateAndTime;
                    this.ProgsOpt[this.NumProgOfData].ListEventsMonth[this.CountItemsList - 1].DateAndTime = new DateTime(1996, dateAndTime.Month, dateAndTime.Day, dateAndTime.Hour, (int) newDataByte[index], dateAndTime.Second);
                    continue;
                  case 4:
                    dateAndTime = this.ProgsOpt[this.NumProgOfData].ListEventsWeek[this.CountItemsList - 1].DateAndTime;
                    this.ProgsOpt[this.NumProgOfData].ListEventsWeek[this.CountItemsList - 1].DateAndTime = new DateTime(1996, dateAndTime.Month, dateAndTime.Day, dateAndTime.Hour, (int) newDataByte[index], dateAndTime.Second);
                    continue;
                  case 5:
                    dateAndTime = this.ProgsOpt[this.NumProgOfData].ListEventsDay[this.CountItemsList - 1].DateAndTime;
                    this.ProgsOpt[this.NumProgOfData].ListEventsDay[this.CountItemsList - 1].DateAndTime = new DateTime(1996, dateAndTime.Month, dateAndTime.Day, dateAndTime.Hour, (int) newDataByte[index], dateAndTime.Second);
                    continue;
                  default:
                    continue;
                }
              case 34:
                switch (this.CountLoops)
                {
                  case 0:
                    dateAndTime = this.ProgsOpt[this.NumProgOfData].ListHolidays[this.CountItemsList - 1].DateAndTime;
                    this.ProgsOpt[this.NumProgOfData].ListHolidays[this.CountItemsList - 1].DateAndTime = new DateTime(1996, dateAndTime.Month, dateAndTime.Day, dateAndTime.Hour, dateAndTime.Minute, (int) newDataByte[index]);
                    continue;
                  case 1:
                    dateAndTime = this.ProgsOpt[this.NumProgOfData].ListEventsException[this.CountItemsList - 1].DateAndTime;
                    this.ProgsOpt[this.NumProgOfData].ListEventsException[this.CountItemsList - 1].DateAndTime = new DateTime(1996, dateAndTime.Month, dateAndTime.Day, dateAndTime.Hour, dateAndTime.Minute, (int) newDataByte[index]);
                    continue;
                  case 2:
                    dateAndTime = this.ProgsOpt[this.NumProgOfData].ListEventsYear[this.CountItemsList - 1].DateAndTime;
                    this.ProgsOpt[this.NumProgOfData].ListEventsYear[this.CountItemsList - 1].DateAndTime = new DateTime(1996, dateAndTime.Month, dateAndTime.Day, dateAndTime.Hour, dateAndTime.Minute, (int) newDataByte[index]);
                    continue;
                  case 3:
                    dateAndTime = this.ProgsOpt[this.NumProgOfData].ListEventsMonth[this.CountItemsList - 1].DateAndTime;
                    this.ProgsOpt[this.NumProgOfData].ListEventsMonth[this.CountItemsList - 1].DateAndTime = new DateTime(1996, dateAndTime.Month, dateAndTime.Day, dateAndTime.Hour, dateAndTime.Minute, (int) newDataByte[index]);
                    continue;
                  case 4:
                    dateAndTime = this.ProgsOpt[this.NumProgOfData].ListEventsWeek[this.CountItemsList - 1].DateAndTime;
                    this.ProgsOpt[this.NumProgOfData].ListEventsWeek[this.CountItemsList - 1].DateAndTime = new DateTime(1996, dateAndTime.Month, dateAndTime.Day, dateAndTime.Hour, dateAndTime.Minute, (int) newDataByte[index]);
                    continue;
                  case 5:
                    dateAndTime = this.ProgsOpt[this.NumProgOfData].ListEventsDay[this.CountItemsList - 1].DateAndTime;
                    this.ProgsOpt[this.NumProgOfData].ListEventsDay[this.CountItemsList - 1].DateAndTime = new DateTime(1996, dateAndTime.Month, dateAndTime.Day, dateAndTime.Hour, dateAndTime.Minute, (int) newDataByte[index]);
                    continue;
                  default:
                    continue;
                }
              case 35:
                switch (this.CountLoops)
                {
                  case 0:
                    this.ProgsOpt[this.NumProgOfData].ListHolidays[this.CountItemsList - 1].Condition = (int) newDataByte[index] != 0;
                    break;
                  case 1:
                    this.ProgsOpt[this.NumProgOfData].ListEventsException[this.CountItemsList - 1].Condition = (int) newDataByte[index] != 0;
                    break;
                  case 2:
                    this.ProgsOpt[this.NumProgOfData].ListEventsYear[this.CountItemsList - 1].Condition = (int) newDataByte[index] != 0;
                    break;
                  case 3:
                    this.ProgsOpt[this.NumProgOfData].ListEventsMonth[this.CountItemsList - 1].Condition = (int) newDataByte[index] != 0;
                    break;
                  case 4:
                    this.ProgsOpt[this.NumProgOfData].ListEventsWeek[this.CountItemsList - 1].Condition = (int) newDataByte[index] != 0;
                    break;
                  case 5:
                    this.ProgsOpt[this.NumProgOfData].ListEventsDay[this.CountItemsList - 1].Condition = (int) newDataByte[index] != 0;
                    break;
                }
                if (this.CountItemsList < this.MaxItemsList)
                {
                  ++this.CountItemsList;
                  this.ByteInReadBlock = 28;
                  break;
                }
                this.ByteInReadBlock = 35;
                break;
              case 36:
                if (this.CountLoops < 5)
                {
                  ++this.CountLoops;
                  this.ByteInReadBlock = 26;
                  break;
                }
                this.ByteInReadBlock = 36;
                this.CountLoops = 0;
                break;
              case 37:
                if (this.NumProgOfData < 8)
                {
                  ++this.NumProgOfData;
                  this.ByteInReadBlock = 5;
                  this.CountLoops = 1;
                  break;
                }
                break;
              case 38:
                DeviceOptions = this.DevOpt;
                CtrlProgramsOptions = this.ProgsOpt;
                this.TypeReadData = ModesRead.NO;
                num = 1;
                break;
            }
          }
          break;
        case ModesRead.NUM_EVENTS:
          this.ProgressBarPercent = 0;
          this.FullBytes = (int) newDataByte[1];
          this.FullBytes |= (int) newDataByte[2] << 8;
          this.FullBytes = this.FullBytes * 8 + 500;
          this.TypeReadData = ModesRead.NO;
          this.NewTypeDataSend(ModesSend.REQUEST_OPTIONS);
          num = 5;
          break;
        case ModesRead.NUM_PLACES:
          this.ProgressBarPercent = 0;
          this.EnablePlacesInDevice = (int) newDataByte[1];
          this.EnablePlacesInDevice |= (int) newDataByte[2] << 8;
          if (this.EnablePlacesInDevice > 5000)
            this.EnablePlacesInDevice = 5000;
          if (this.NeededPlaces > this.EnablePlacesInDevice)
          {
            this.TypeReadData = ModesRead.NO;
            num = 6;
            break;
          }
          this.TypeReadData = ModesRead.NO;
          this.NewTypeDataSend(ModesSend.PREP_GET_OPTIONS);
          num = 5;
          break;
        case ModesRead.NUM_VERSION:
          this.VersionOfDeviceProgram = (int) newDataByte[1];
          this.SubVersionOfDeviceProgram = (int) newDataByte[2];
          this.TypeReadData = ModesRead.NO;
          num = 7;
          break;
        case ModesRead.DEVICETIME:
          this.DeviceTime = new DateTime((this.EnablePlacesInDevice = (int) newDataByte[1]) | (int) newDataByte[2] << 8, (int) newDataByte[3], (int) newDataByte[4], (int) newDataByte[5], (int) newDataByte[6], (int) newDataByte[7]);
          this.ReadVoltage = (int) newDataByte[8];
          this.ReadVoltage |= (int) newDataByte[9] << 8;
          this.ReadBright = (int) newDataByte[10];
          this.ReadBright |= (int) newDataByte[11] << 8;
          this.TypeReadData = ModesRead.NO;
          num = 8;
          break;
        case ModesRead.SEND_NEWTIME:
          this.TypeReadData = ModesRead.NO;
          num = 9;
          break;
        case ModesRead.SEND_NEWVOLTBRIGHT:
          this.TypeReadData = ModesRead.NO;
          num = 10;
          break;
        case ModesRead.SEND_FACTORYTIMECALIBR:
          this.TypeReadData = ModesRead.NO;
          num = 11;
          break;
      }
      return num;
    }
  }
}
