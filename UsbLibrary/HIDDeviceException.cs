// Decompiled with JetBrains decompiler
// Type: UsbLibrary.HIDDeviceException
// Assembly: UsbLibrary, Version=1.0.5855.29665, Culture=neutral, PublicKeyToken=null
// MVID: 5237C4C1-0487-434F-958F-85B41FDA0A3D
// Assembly location: C:\Program Files (x86)\Novatek-Electro\Configurator REV-302\UsbLibrary.dll

using System;
using System.Runtime.InteropServices;

namespace UsbLibrary
{
  public class HIDDeviceException : ApplicationException
  {
    public HIDDeviceException(string strMessage)
      : base(strMessage)
    {
    }

    public static HIDDeviceException GenerateWithWinError(string strMessage)
    {
      return new HIDDeviceException(string.Format("Msg:{0} WinEr:{1:X8}", (object) strMessage, (object) Marshal.GetLastWin32Error()));
    }

    public static HIDDeviceException GenerateError(string strMessage)
    {
      return new HIDDeviceException(string.Format("Msg:{0}", (object) strMessage));
    }
  }
}
