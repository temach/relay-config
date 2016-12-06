// Decompiled with JetBrains decompiler
// Type: UsbLibrary.Report
// Assembly: UsbLibrary, Version=1.0.5855.29665, Culture=neutral, PublicKeyToken=null
// MVID: 5237C4C1-0487-434F-958F-85B41FDA0A3D
// Assembly location: C:\Program Files (x86)\Novatek-Electro\Configurator REV-302\UsbLibrary.dll

namespace UsbLibrary
{
  public abstract class Report
  {
    private byte[] m_arrBuffer;
    private int m_nLength;

    public byte[] Buffer
    {
      get
      {
        return this.m_arrBuffer;
      }
      set
      {
        this.m_arrBuffer = value;
      }
    }

    public int BufferLength
    {
      get
      {
        return this.m_nLength;
      }
    }

    public Report(HIDDevice oDev)
    {
    }

    protected void SetBuffer(byte[] arrBytes)
    {
      this.m_arrBuffer = arrBytes;
      this.m_nLength = this.m_arrBuffer.Length;
    }
  }
}
