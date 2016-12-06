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

    public static Guid HIDGuid
    {
      get
      {
        Guid gHid;
        Win32Usb.HidD_GetHidGuid(out gHid);
        return gHid;
      }
    }

    [DllImport("hid.dll", SetLastError = true)]
    protected static extern void HidD_GetHidGuid(out Guid gHid);

    [DllImport("setupapi.dll", SetLastError = true)]
    protected static extern IntPtr SetupDiGetClassDevs(ref Guid gClass, [MarshalAs(UnmanagedType.LPStr)] string strEnumerator, IntPtr hParent, uint nFlags);

    [DllImport("setupapi.dll", SetLastError = true)]
    protected static extern int SetupDiDestroyDeviceInfoList(IntPtr lpInfoSet);

    [DllImport("setupapi.dll", SetLastError = true)]
    protected static extern bool SetupDiEnumDeviceInterfaces(IntPtr lpDeviceInfoSet, uint nDeviceInfoData, ref Guid gClass, uint nIndex, ref Win32Usb.DeviceInterfaceData oInterfaceData);

    [DllImport("setupapi.dll", SetLastError = true)]
    protected static extern bool SetupDiGetDeviceInterfaceDetail(IntPtr lpDeviceInfoSet, ref Win32Usb.DeviceInterfaceData oInterfaceData, IntPtr lpDeviceInterfaceDetailData, uint nDeviceInterfaceDetailDataSize, ref uint nRequiredSize, IntPtr lpDeviceInfoData);

    [DllImport("setupapi.dll", SetLastError = true)]
    protected static extern bool SetupDiGetDeviceInterfaceDetail(IntPtr lpDeviceInfoSet, ref Win32Usb.DeviceInterfaceData oInterfaceData, ref Win32Usb.DeviceInterfaceDetailData oDetailData, uint nDeviceInterfaceDetailDataSize, ref uint nRequiredSize, IntPtr lpDeviceInfoData);

    [DllImport("user32.dll", SetLastError = true)]
    protected static extern IntPtr RegisterDeviceNotification(IntPtr hwnd, Win32Usb.DeviceBroadcastInterface oInterface, uint nFlags);

    [DllImport("user32.dll", SetLastError = true)]
    protected static extern bool UnregisterDeviceNotification(IntPtr hHandle);

    [DllImport("hid.dll", SetLastError = true)]
    protected static extern bool HidD_GetPreparsedData(IntPtr hFile, out IntPtr lpData);

    [DllImport("hid.dll", SetLastError = true)]
    protected static extern bool HidD_FreePreparsedData(ref IntPtr pData);

    [DllImport("hid.dll", SetLastError = true)]
    protected static extern int HidP_GetCaps(IntPtr lpData, out Win32Usb.HidCaps oCaps);

    [DllImport("kernel32.dll", SetLastError = true)]
    protected static extern IntPtr CreateFile([MarshalAs(UnmanagedType.LPStr)] string strName, uint nAccess, uint nShareMode, IntPtr lpSecurity, uint nCreationFlags, uint nAttributes, IntPtr lpTemplate);

    [DllImport("kernel32.dll", SetLastError = true)]
    protected static extern int CloseHandle(IntPtr hFile);

    public static IntPtr RegisterForUsbEvents(IntPtr hWnd, Guid gClass)
    {
      Win32Usb.DeviceBroadcastInterface oInterface = new Win32Usb.DeviceBroadcastInterface();
      oInterface.Size = Marshal.SizeOf((object) oInterface);
      oInterface.ClassGuid = gClass;
      oInterface.DeviceType = 5;
      oInterface.Reserved = 0;
      return Win32Usb.RegisterDeviceNotification(hWnd, oInterface, 0U);
    }

    public static bool UnregisterForUsbEvents(IntPtr hHandle)
    {
      return Win32Usb.UnregisterDeviceNotification(hHandle);
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
