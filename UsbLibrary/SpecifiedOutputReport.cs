// Decompiled with JetBrains decompiler
// Type: UsbLibrary.SpecifiedOutputReport
// Assembly: UsbLibrary, Version=1.0.5855.29665, Culture=neutral, PublicKeyToken=null
// MVID: 5237C4C1-0487-434F-958F-85B41FDA0A3D
// Assembly location: C:\Program Files (x86)\Novatek-Electro\Configurator REV-302\UsbLibrary.dll

namespace UsbLibrary
{
  public class SpecifiedOutputReport : OutputReport
  {
    public SpecifiedOutputReport(HIDDevice oDev)
      : base(oDev)
    {
    }

    public bool SendData(byte[] data)
    {
      byte[] buffer = this.Buffer;
      for (int index = 1; index < buffer.Length; ++index)
        buffer[index] = data[index];
      return buffer.Length >= data.Length;
    }
  }
}
