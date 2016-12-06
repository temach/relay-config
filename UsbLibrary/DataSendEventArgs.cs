// Decompiled with JetBrains decompiler
// Type: UsbLibrary.DataSendEventArgs
// Assembly: UsbLibrary, Version=1.0.5855.29665, Culture=neutral, PublicKeyToken=null
// MVID: 5237C4C1-0487-434F-958F-85B41FDA0A3D
// Assembly location: C:\Program Files (x86)\Novatek-Electro\Configurator REV-302\UsbLibrary.dll

using System;

namespace UsbLibrary
{
  public class DataSendEventArgs : EventArgs
  {
    public readonly byte[] data;

    public DataSendEventArgs(byte[] data)
    {
      this.data = data;
    }
  }
}
