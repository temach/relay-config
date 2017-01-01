using System;

namespace JsonToRelay
{
  public class DeviceOptions : ICloneable
  {
    public byte ChannelsMax = 2;
    public byte ProgramsMax = 8;
    public byte[] Channel_CtrlProg = new byte[3];
    public bool DST_OnOff;
    public DeviceOptions.AdjTime CommonDelay;

    public DeviceOptions()
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
      DeviceOptions deviceOptionsClass = (DeviceOptions) this.MemberwiseClone();
      byte[] numArray = new byte[3]
      {
        this.Channel_CtrlProg[0],
        this.Channel_CtrlProg[1],
        this.Channel_CtrlProg[2]
      };
      deviceOptionsClass.Channel_CtrlProg = numArray;
      return deviceOptionsClass;
    }

    public bool Compare(DeviceOptions DevOpt)
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
