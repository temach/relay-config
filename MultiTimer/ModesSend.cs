// NoAuthor
// Type: MultiTimerWinForms.ModesSend
// Assembly: MultiTimer, Version=1.5.2.0, Culture=neutral, PublicKeyToken=null
// MVID: BCBF5A5D-507A-4FEA-8EFC-8CECD33998F9
// Assembly location: C:\Program Files (x86)\Novatek-Electro\Configurator REV-302\MultiTimer.exe

namespace MultiTimerWinForms
{
  public enum ModesSend
  {
    NO = 0,
    REQUEST_OPTIONS = 10,
    PREP_GET_OPTIONS = 11,
    SEND_OPTIONS = 12,
    REQUEST_NUM_EVENTS = 14,
    REQUEST_NUM_PLACES = 15,
    REQUEST_NUM_VERSION = 16,
    REQUEST_DEVICETIME = 17,
    SEND_NEWTIME = 18,
    SEND_NEWVOLTBRIGHT = 19,
    SEND_FACTORYTIMECALIBR = 20,
    CONTINUE = 127,
  }
}
