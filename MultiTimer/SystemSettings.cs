// NoAuthor
// Type: MultiTimerWinForms.SystemSettings
// Assembly: MultiTimer, Version=1.5.2.0, Culture=neutral, PublicKeyToken=null
// MVID: BCBF5A5D-507A-4FEA-8EFC-8CECD33998F9
// Assembly location: C:\Program Files (x86)\Novatek-Electro\Configurator REV-302\MultiTimer.exe

using Microsoft.Win32;

namespace MultiTimerWinForms
{
  internal class SystemSettings
  {
    private string LangKey = "ConfiguratorRevLanguage";
    private string LangPath = "Software\\Novatek";
    public SystemSettings.TypeLanguage Lang;

    public SystemSettings()
    {
      this.Lang = SystemSettings.TypeLanguage.ENGLISH;
      this.Lang = this.GetRegistryLang();
    }

    public void SetRegistryLang(SystemSettings.TypeLanguage lang)
    {
      RegistryKey subKey = Registry.CurrentUser.CreateSubKey(this.LangPath);
      if (subKey == null)
        return;
      string str = "null";
      if (lang == SystemSettings.TypeLanguage.ENGLISH)
        str = "Eng";
      else if (lang == SystemSettings.TypeLanguage.POLISH)
        str = "Pol";
      else if (lang == SystemSettings.TypeLanguage.RUSSIAN)
        str = "Rus";
      subKey.SetValue(this.LangKey, (object) str);
      subKey.Close();
    }

    public SystemSettings.TypeLanguage GetRegistryLang()
    {
      SystemSettings.TypeLanguage typeLanguage = SystemSettings.TypeLanguage.ENGLISH;
      RegistryKey subKey = Registry.CurrentUser.CreateSubKey(this.LangPath);
      if (subKey != null)
      {
        string str = "null";
        object obj = subKey.GetValue(this.LangKey);
        if (obj != null)
          str = obj.ToString();
        if (str.Equals("Pol"))
          typeLanguage = SystemSettings.TypeLanguage.POLISH;
        else if (str.Equals("Eng"))
          typeLanguage = SystemSettings.TypeLanguage.ENGLISH;
        else if (str.Equals("Rus"))
          typeLanguage = SystemSettings.TypeLanguage.RUSSIAN;
        subKey.Close();
      }
      return typeLanguage;
    }

    public enum TypeLanguage
    {
      RUSSIAN,
      ENGLISH,
      POLISH,
    }
  }
}
