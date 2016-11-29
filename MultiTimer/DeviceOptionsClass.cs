// NoAuthor
// Type: MultiTimerWinForms.DeviceOptionsClass
// Assembly: MultiTimer, Version=1.5.2.0, Culture=neutral, PublicKeyToken=null
// MVID: BCBF5A5D-507A-4FEA-8EFC-8CECD33998F9
// Assembly location: C:\Program Files (x86)\Novatek-Electro\Configurator REV-302\MultiTimer.exe

using System;

namespace MultiTimerWinForms
{
  [Serializable]
  public class DeviceOptionsClass : ICloneable
  {
    public byte ChannelsMax = 2;
    public byte ProgramsMax = 8;
    public byte[] Channel_CtrlProg = new byte[3];
    public bool DST_OnOff;
    public DeviceOptionsClass.AdjTime CommonDelay;

    public DeviceOptionsClass()
    {
      this.Init();
    }

    public void Reset()
    {
      this.Init();
    }

    private void Init()
    {
      this.Channel_CtrlProg[1] = (byte) 0;
      this.Channel_CtrlProg[2] = (byte) 0;
      this.CommonDelay.Minute = 0;
      this.CommonDelay.Second = 0;
      this.DST_OnOff = true;
    }

    public object Clone()
    {
      DeviceOptionsClass deviceOptionsClass = (DeviceOptionsClass) this.MemberwiseClone();
      byte[] numArray = new byte[3]
      {
        this.Channel_CtrlProg[0],
        this.Channel_CtrlProg[1],
        this.Channel_CtrlProg[2]
      };
      deviceOptionsClass.Channel_CtrlProg = numArray;
      return (object) deviceOptionsClass;
    }

    public bool Compare(DeviceOptionsClass DevOpt)
    {
      bool flag = true;
      if ((int) this.Channel_CtrlProg[1] != (int) DevOpt.Channel_CtrlProg[1] || (int) this.Channel_CtrlProg[2] != (int) DevOpt.Channel_CtrlProg[2] || (this.CommonDelay.Minute != DevOpt.CommonDelay.Minute || this.CommonDelay.Second != DevOpt.CommonDelay.Second) || this.DST_OnOff != DevOpt.DST_OnOff)
        flag = false;
      return flag;
    }

    [Serializable]
    public struct AdjTime
    {
      public int Minute;
      public int Second;
    }
  }
}
