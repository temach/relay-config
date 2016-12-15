// Decompiled with JetBrains decompiler
// Type: UsbLibrary.Win32Usb
// Assembly: UsbLibrary, Version=1.0.5855.29665, Culture=neutral, PublicKeyToken=null
// MVID: 5237C4C1-0487-434F-958F-85B41FDA0A3D
// Assembly location: C:\Program Files (x86)\Novatek-Electro\Configurator REV-302\UsbLibrary.dll

using System;
using System.Runtime.InteropServices;

namespace UsbLibrary
{
  public class Win32Usb
  {
    public static IntPtr NullHandle = IntPtr.Zero;
    protected static IntPtr InvalidHandleValue = new IntPtr(-1);
    public const int WM_DEVICECHANGE = 537;
    public const int DEVICE_ARRIVAL = 32768;
    public const int DEVICE_REMOVECOMPLETE = 32772;
    protected const int DIGCF_PRESENT = 2;
    protected const int DIGCF_DEVICEINTERFACE = 16;
    protected const int DEVTYP_DEVICEINTERFACE = 5;
    protected const int DEVICE_NOTIFY_WINDOW_HANDLE = 0;
    protected const uint PURGE_TXABORT = 1;
    protected const uint PURGE_RXABORT = 2;
    protected const uint PURGE_TXCLEAR = 4;
    protected const uint PURGE_RXCLEAR = 8;
    protected const uint GENERIC_READ = 2147483648;
    protected const uint GENERIC_WRITE = 1073741824;
    protected const uint FILE_SHARE_WRITE = 2;
    protected const uint FILE_SHARE_READ = 1;
    protected const uint FILE_FLAG_OVERLAPPED = 1073741824;
    protected const uint OPEN_EXISTING = 3;
    protected const uint OPEN_ALWAYS = 4;
    protected const uint ERROR_IO_PENDING = 997;
    protected const uint INFINITE = 4294967295;


    public static void RegisterForUsbEvents()
    {
    }


    public static bool UnregisterForUsbEvents()
    {
      return true;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    protected struct Overlapped
    {
      public uint Internal;
      public uint InternalHigh;
      public uint Offset;
      public uint OffsetHigh;
      public IntPtr Event;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    protected struct DeviceInterfaceData
    {
      public int Size;
      public Guid InterfaceClassGuid;
      public int Flags;
      public IntPtr Reserved;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    protected struct HidCaps
    {
      public short Usage;
      public short UsagePage;
      public short InputReportByteLength;
      public short OutputReportByteLength;
      public short FeatureReportByteLength;
      [MarshalAs(UnmanagedType.ByValArray, SizeConst = 17)]
      public short[] Reserved;
      public short NumberLinkCollectionNodes;
      public short NumberInputButtonCaps;
      public short NumberInputValueCaps;
      public short NumberInputDataIndices;
      public short NumberOutputButtonCaps;
      public short NumberOutputValueCaps;
      public short NumberOutputDataIndices;
      public short NumberFeatureButtonCaps;
      public short NumberFeatureValueCaps;
      public short NumberFeatureDataIndices;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct DeviceInterfaceDetailData
    {
      public int Size;
      [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
      public string DevicePath;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Unicode)]
    public class DeviceBroadcastInterface
    {
      public int Size;
      public int DeviceType;
      public int Reserved;
      public Guid ClassGuid;
      [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
      public string Name;
    }
  }
}
