// NoAuthor
// Type: MultiTimerWinForms.Form1
// Assembly: MultiTimer, Version=1.5.2.0, Culture=neutral, PublicKeyToken=null
// MVID: BCBF5A5D-507A-4FEA-8EFC-8CECD33998F9
// Assembly location: C:\Program Files (x86)\Novatek-Electro\Configurator REV-302\MultiTimer.exe

using Newtonsoft.Json;
using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using UsbLibrary;

namespace MultiTimerWinForms
{
  public class Form1 : Form
  {
    public int LangGlobal = 1;
    private int CtrlProgsMax = 8;
    private string StRelVrem = "Реле времени ";
    private string StRelVremOptions = "Общие настройки реле времени ";
    private string StExceptions = "Исключения ";
    private string StHolidays = "Праздники ";
    private string StWeekEnds = "Выходные дни";
    private string StListEventExceptions = "Список исключительных событий ";
    private string StListEventYear = "События годового реле ";
    private string StListEventMonth = "События месячного реле ";
    private string StListEventWeek = "События недельного реле ";
    private string StListEventDay = "События суточного реле ";
    private string StImpulseOptions = "Настройки импульсного реле";
    private string StSimpleOptions = "Настройки простого реле";
    private string StVoltRelayOptions = "Реле напряжения ";
    private string StPhotoRelayOptions = "Фотореле ";
    private string StDeviceOptions = "Общие настройки устройства";
    private string StTimeCorrect = "Установка времени";
    private string StVoltBrightCorrect = "Коррекция напряжения и освещенности";
    private string[] StDaysOfWeek = new string[7]
    {
      "Понедельник",
      "Вторник",
      "Среда",
      "Четверг",
      "Пятница",
      "Суббота",
      "Воскресенье"
    };
    private string stMon = "Monday";
    private string stTue = "Tuesday";
    private string stWed = "Wednesday";
    private string stThu = "Thursday";
    private string stFri = "Friday";
    private string stSat = "Saturday";
    private string stSun = "Sunday";
    private string[] stInfo = new string[3]
    {
      "Информация",
      "Information",
      "Brak"
    };
    private string[] stAbsent = new string[3]
    {
      "отсутствует",
      "is absent",
      "informacji"
    };
    private string[] stChannel1 = new string[3]
    {
      "Kaнал К1",
      "Channel К1",
      "Kanał K1"
    };
    private string[] stChannel2 = new string[3]
    {
      "Канал К2",
      "Channel K2",
      "Kanał K2"
    };
    private string[] stProgram = new string[3]
    {
      "Программа П",
      "Program P",
      "Program P"
    };
    private string[] stUSBnoCon = new string[3]
    {
      "USB: Связь с реле отсутствует",
      "USB: No connection",
      "USB: Brak komunikacji z przekaźnikiem"
    };
    private string[] stEvents_t1 = new string[3]
    {
      " событий)",
      " events)",
      " zdarzeń)"
    };
    private string[] stInTreeOff = new string[3]
    {
      "(откл)",
      "(OFF)",
      "(odłączony)"
    };
    private string[] stInTreeYear = new string[3]
    {
      "(год)",
      "(year)",
      "(rok)"
    };
    private string[] stInTreeMonth = new string[3]
    {
      "(мес)",
      "(month)",
      "(mies.)"
    };
    private string[] stInTreeWeek = new string[3]
    {
      "(нед)",
      "(week)",
      "(tydz.)"
    };
    private string[] stInTreeDay = new string[3]
    {
      "(сут)",
      "(day)",
      "(dni)"
    };
    private string[] stInTreePulse = new string[3]
    {
      "(имп)",
      "(pulse)",
      "(impuls.)"
    };
    private string[] stInTreeSimple = new string[3]
    {
      "(простое)",
      "(simple)",
      "(zwykły)"
    };
    private string[] stInTreeON = new string[3]
    {
      "(вкл)",
      "(ON)",
      "(załączony)"
    };
    private string[] stInTreeChannelN = new string[3]
    {
      "Канал К",
      "Channel K",
      "Kanał K"
    };
    private string[] stInTreeOffFull = new string[3]
    {
      " (отключить)",
      " (OFF)",
      "(odłączony)"
    };
    private string[] stInTreeP = new string[3]{ "П", "P", "P" };
    private string[] stVoltAndPhoto = new string[3]
    {
      "Напряжение и освещенность",
      "Voltage and Illumination",
      "Napięcie i natężenie oświetlenia"
    };
    private string[] stTimeSetting = new string[3]
    {
      "Установка времени",
      "Time Setting",
      "Ustawienia czasu"
    };
    private string[] stGeneralSettings = new string[3]
    {
      "Общие настройки устройства",
      "General Settings",
      "Ogólne ustawienia urządzenia"
    };
    private string[] stPhotoRelay = new string[3]
    {
      "Фото реле",
      "Photorelay",
      "Fotoprzekaźnik"
    };
    private string[] stRV = new string[3]
    {
      "Реле напряжения",
      "Voltage Relay",
      "Przekaźnik napięciowy"
    };
    private string[] stSimpleRT = new string[3]
    {
      "Простое реле времени",
      "Simple Time Relay",
      "Zegar impulsowy"
    };
    private string[] stPulseRT = new string[3]
    {
      "Импульсное реле времени",
      "Pulse Time Relay",
      "Zwykły zegar"
    };
    private string[] stEventsDailyRT = new string[3]
    {
      "События суточного реле времени",
      "Daily Time Relay Events",
      "Zdarzenia zegara dziennego"
    };
    private string[] stEventsWeeklyRT = new string[3]
    {
      "События недельного реле времени",
      "Weekly Time Relay Events",
      "Zdarzenia zegara tygodniowego"
    };
    private string[] stEventsMonthlyRT = new string[3]
    {
      "События месячного реле времени",
      "Monthly Time Relay Events",
      "Zdarzenia zegara miesięcznego"
    };
    private string[] stEventsYearlyRT = new string[3]
    {
      "События годового реле времени",
      "Yearly Time Relay Events",
      "Zdarzenia zegara rocznego"
    };
    private string[] stExceptionEventsRT = new string[3]
    {
      "Исключительные события",
      "Exception Events",
      "Wyłączenia"
    };
    private string[] stDaysOffRT = new string[3]
    {
      "Выходные дни",
      "Days Off",
      "Dni wolne"
    };
    private string[] stHolidaysRT = new string[3]
    {
      "Праздники",
      "Holidays",
      "Święta"
    };
    private string[] stExceptionsRT = new string[3]
    {
      "Исключения",
      "Exceptions",
      "Wyłączenia"
    };
    private string[] stRT = new string[3]
    {
      "Реле времени",
      "Time Relay",
      "Przekaźnik czasowy"
    };
    private string[] stGeneralOptionsRT = new string[3]
    {
      "Общие настройки реле времени",
      "Time Relay General Settings",
      "Ogólne ustawienia przekaźnika czas."
    };
    private string[] stChooseModeRT = new string[3]
    {
      "Выберите режим работы реле времени программы П",
      "Choose operation mode of time relay P",
      "Wybierz tryb pracy przekaźnika czasowego programu P"
    };
    private string[] stChooseProgram = new string[3]
    {
      "Выберите программу для управления контактами канала К",
      "Choose program for managment contacts of channel K",
      "Wybierz program do sterowania stykami kanału K"
    };
    private string[] stClose = new string[3]
    {
      "Включить",
      "Close",
      "Załącz"
    };
    private string[] stOpen = new string[3]
    {
      "Отключить",
      "Open",
      "Wyłącz"
    };
    private string[] stNovatek = new string[3]
    {
      "Конфигуратор реле РЭВ-302",
      "Configurator relay REV-302",
      "Konfigurator przekaźnika REV-302"
    };
    private string[] stNoAccessToDisk = new string[3]
    {
      "Нет доступа к диску. Файл не сохранен.",
      "Not access to disk. The file has not saved",
      "Brak dostępu do dysku. Plik nie został zapisany."
    };
    private string[] stAttention = new string[3]
    {
      "Внимание!",
      "Attention!",
      "Uwaga!"
    };
    private string[] stNotGoogFile = new string[3]
    {
      "Файл не содежит информацию\nо настройках или устарел.",
      "The file does not have information\nabout setting or obsolete.",
      "Plik nie zawiera informacji о ustawieniach lub jest przestarzały."
    };
    private string[] stFileNotFind = new string[3]
    {
      "Файл не найден",
      "The file has not found.",
      "Plik nie został znaleziony"
    };
    private string[] stFileReset = new string[3]
    {
      "Все текущие настройки будут сброшены.",
      "All setting will be reset!",
      "Wszystkie bieżące ustawienia zostaną skasowane."
    };
    private string[] stSettingSuccessRead = new string[3]
    {
      "Настройки РЭВ-302 успешно считаны.",
      "Settings has been read successfully",
      "Odczyt ustawień REV-302 jest zakończony sukcesem."
    };
    private string[] stReceivingData = new string[3]
    {
      "Прием данных",
      "Receiving data",
      "Odbiór danych"
    };
    private string[] stTransferData = new string[3]
    {
      "Передача данных",
      "Transfer data",
      "Transmisja danych"
    };
    private string[] stSettingSuccessTransfer = new string[3]
    {
      "Настройки успешно записаны в РЭВ-302.\n\nДля выхода из меню настроек\nи перевода реле в рабочее\nсостояние нажмите кнопку \"Влево\"\nна лицевой панели РЭВ-302.",
      "Settings has been transfer successfully into REV-302.\n\nFor exit from Setting Menu\nand conversion relay in operation\nstate press button \"Left\"\n on REV-302 face panel.",
      "Zapis ustawień do REV-302 został zakończony sukcesem.\n\nDo wyjścia z menu\ni przejścia przekaźnika\ndo stanu roboczego służy przycisk \"W lewo\"\nna panelu przednim REV-302."
    };
    private string[] stOverMemory1 = new string[3]
    {
      "  В памяти подключенного реле \nможно сохранить не больше",
      "In the memory of connected relay may be saved only",
      "  W pamięci podłączonego przekaźnika \nmożna zapisać nie więcej niż"
    };
    private string[] stOverMemory2 = new string[3]
    {
      " событий.\nПрограмма содержит ",
      " events.\nProgram contain ",
      " zdarzeń.\nProgram zawiera "
    };
    private string[] stOverMemory3 = new string[3]
    {
      " событий.\nПопробуйте отредактировать \nсписки и повторить запись.",
      " events.\nTry to reduct lists and repeat settings transfer",
      " zdarzeń.\nSpróbuj edytować listę i powtórzyć zapis."
    };
    private string[] stSaveSettings = new string[3]
    {
      "Сохранение настроек в памяти реле",
      "Save settings in relay memory",
      "Zapis ustawień do pamięci przekaźnika"
    };
    private string[] stVersionDeviceNotSupport_1 = new string[3]
    {
      " Версия программы устройства v",
      " Program version of device v",
      " Wersja programu urządzenia: v"
    };
    private string[] stVersionDeviceNotSupport_2 = new string[3]
    {
      " не поддеживается. \nУстановите последнюю версию программного обеспечения.",
      " does not suppoted. \nInstall last version of software.",
      " nie jest obsługiwana. \nZainstaluj najnowszą wersje oprogramowania"
    };
    private string[] stVersionDevice = new string[3]
    {
      " Версия программы устройства: v",
      " Program version of device: v",
      " Wersja programu urządzenia: v"
    };
    private string[] stREV302 = new string[3]
    {
      "РЭВ-302",
      "REV-302",
      "REV-302"
    };
    private string[] stNewTimeSend = new string[3]
    {
      " В реле успешно записаны новые \nзначения времени и даты.",
      "New time and date have been written\nin relay successfully.",
      " Zapis wartości czasu i daty \ndo przekaźnika został zakończony sukcesem."
    };
    private string[] stSetTime = new string[3]
    {
      "Установка времени",
      "Time setting",
      "Ustawienia czasu"
    };
    private string[] stUSBconnectIs = new string[3]
    {
      "USB: Установлена связь с реле",
      "USB: Connection with relay established",
      "USB: Komunikacja z przekaźnikiem została nawiązana"
    };
    private string[] stDeviceNotConnect = new string[3]
    {
      "Устройство не подключено. \n Проверь питание и целостность кабеля USB. \n Затем повторите попытку считать данные.",
      "Connection with device is not existing.\n Check power and cable integrity USB. \n Аfter try read data again.",
      "Urządzenie nie jest podłączone. Sprawdź zasilanie i czy kabel USB nie jest uszkodzony. Następnie spróbuj ponownie odczytać dane."
    };
    private string[] stUSBconnectionNotIs = new string[3]
    {
      "USB: Связь с реле отсутствует",
      "USB: Connection is not existing",
      "USB: Brak komunikacji z przekaźnikiem"
    };
    private string[] stConnectError = new string[3]
    {
      "Произошел сбой связи с реле. \n Проверьте надежность подключения и \n повторите попытку.",
      "Connection has malfunctioned. \n Check cable solidity and try attempt again.",
      "Komunikacja z przekaźnikiem została przerwana. Sprawdź jakość połączenia i spróbuj ponownie."
    };
    private string[] stCopy1 = new string[3]
    {
      "   Внимание! Настройки программы П{0} будут \nзаменены настройками программы П{1}.",
      "   Attention! Settings of program P{0} will be replaced by settings of program P{1}",
      "   Uwaga! Ustawienia programu P{0} zostaną zmienione na ustawienia programu P{1}"
    };
    private string[] stCopy2 = new string[3]
    {
      "Копирование настроек управляющих программ",
      "Copy settings of programs control",
      "Kopiowanie ustawień programów sterujących"
    };
    private string[] stCopy3 = new string[3]
    {
      "   Все настройки программы П{0} были успешно \nскопированы в программу П{1}.",
      "   All settings of program P{0} have been copied successfully in program P{1}.",
      "   Kopiowanie wszystkich ustawień programu P{0} do programu P{1} zostało zakończone sukcesem."
    };
    private string[] stClearLists1 = new string[3]
    {
      " Вы действительно хотите очистить все списки Программы П{0}?",
      " Do you really wich to clear all program P{0} lists?",
      " Czy na pewno chcesz wyczyścić wszystkie listy Programu P{0}?"
    };
    private string[] stClearLists2 = new string[3]
    {
      "Очистка списков",
      "Clearing lists",
      "Czyszczenie list"
    };
    private string[] stSaveSettingsInFile = new string[3]
    {
      "Сохранить настройки в файл?",
      "Save settings in file?",
      "Czy zapisać ustawienia do pliku?"
    };
    private string[] stExitProgram = new string[3]
    {
      "Выход из программы",
      "Exit",
      "Wyjście z programu"
    };
    private string[] stResetProgramSettings1 = new string[3]
    {
      " Вы действительно хотите сбросить все настройки Программы П{0}?",
      " Do you really wish to reset all settings of program P{0}?",
      " Czy na pewno chcesz skasować wszystkie ustawienia Programu P{0}?"
    };
    private string[] stResetProgramSettings2 = new string[3]
    {
      "Сброс настроек",
      "Reset settings",
      "Kasowanie ustawień"
    };
    private string[] stChangeLanguageMessage = new string[3]
    {
      "Язык интерфейса изменится после следующего запуска программы!",
      "Reload application for change language!",
      "Zmiana języka po następnym uruchomieniu programu!"
    };
    private string[] stWarning = new string[3]
    {
      "Предупреждение",
      "Warning",
      "Ostrzeżenie"
    };
    private SystemSettings SysSet = new SystemSettings();
    private DeviceOptionsClass DeviceOptions = new DeviceOptionsClass();
    private CtrlProgramOptionsClass CtrlProgramsOptions = new CtrlProgramOptionsClass();
    private ConnectionClass Connection = new ConnectionClass();
    private ConnectionDialog1 dlgConnect = new ConnectionDialog1();
    private SunRises dlgSunRise = new SunRises();
    private ArrayEvents dlgArEv = new ArrayEvents();
    private CtrlProgramOptionsClass BackCtrlProgramsOptions = new CtrlProgramOptionsClass();
    private CtrlProgramOptionsClass InRelayCtrlProgramsOptions = new CtrlProgramOptionsClass();
    private DeviceOptionsClass InRelayDeviceOptions = new DeviceOptionsClass();
    public bool FactoryProgramType;
    private int ProgSelected;
    private int ChannelSelected;
    private string PathOfFile;
    private string StMessageUSB;
    private Form1.USB_GetSequenceEnum USB_GetSequence;
    private int USB_GetSeqStep;
    private bool USB_Connect;
    private DateTime DeviceTimeMonitor;
    private bool DeviceTimeMonitorExist;
    private DateTime SychTime;
    private bool WriteNewTimeInDevice;
    private bool SychShowTime;
    private IContainer components;
    private MenuStrip menuStrip1;
    private ToolStrip toolStrip1;
    private TreeView treeView1;
    private StatusStrip statusStrip1;
    private Label label1;
    private Label label2;
    private Label label3;
    private Button button1;
    private ListBox listBox1;
    private UsbHidPort usb;
    private Panel panel1;
    private Label label4;
    private GroupBox groupBox1;
    private RadioButton radioButton5;
    private RadioButton radioButton6;
    private RadioButton radioButton7;
    private RadioButton radioButton8;
    private RadioButton radioButton4;
    private RadioButton radioButton3;
    private RadioButton radioButton2;
    private RadioButton radioButton1;
    private GroupBox groupBox2;
    private GroupBox groupBox3;
    private RadioButton radioButton14;
    private RadioButton radioButton13;
    private RadioButton radioButton12;
    private RadioButton radioButton11;
    private RadioButton radioButton10;
    private RadioButton radioButton9;
    private CheckBox checkBox3;
    private CheckBox checkBox2;
    private CheckBox checkBox1;
    private TabControl tabControl1;
    private TabPage tabPage1_ChannelMode;
    private TabPage tabPage2_RtOptions;
    private TabPage tabPage3_Empty;
    private RadioButton radioButton15;
    private RadioButton radioButton16;
    private TabPage tabPage4_DayOffs;
    private GroupBox groupBox4;
    private CheckBox checkBox10;
    private CheckBox checkBox9;
    private CheckBox checkBox8;
    private CheckBox checkBox7;
    private CheckBox checkBox6;
    private CheckBox checkBox5;
    private CheckBox checkBox4;
    private TabPage tabPage5_Holidays;
    private GroupBox groupBox5;
    private MonthCalendar monthCalendar1;
    private Button button4;
    private Button button3;
    private Button button2;
    private Label label5;
    private ListView listView1;
    private ColumnHeader columnHeader1;
    private ColumnHeader columnHeader2;
    private ColumnHeader columnHeader3;
    private TabPage tabPage6_ExceptEvents;
    private GroupBox groupBox6;
    private NumericUpDown numericUpDown1;
    private ListView listView2;
    private ColumnHeader columnHeader4;
    private ColumnHeader columnHeader5;
    private ColumnHeader columnHeader6;
    private Button button5;
    private Button button6;
    private Button button7;
    private Label label10;
    private Label label9;
    private Label label8;
    private Label label7;
    private Label label6;
    private NumericUpDown numericUpDown3;
    private NumericUpDown numericUpDown2;
    private GroupBox groupBox7;
    private RadioButton radioButton18;
    private RadioButton radioButton17;
    private TabPage tabPage7_Year;
    private GroupBox groupBox8;
    private MonthCalendar monthCalendar2;
    private GroupBox groupBox9;
    private RadioButton radioButton19;
    private RadioButton radioButton20;
    private Label label11;
    private Label label12;
    private Label label13;
    private Label label14;
    private Label label15;
    private NumericUpDown numericUpDown4;
    private NumericUpDown numericUpDown5;
    private NumericUpDown numericUpDown6;
    private ListView listView3;
    private ColumnHeader columnHeader7;
    private ColumnHeader columnHeader8;
    private ColumnHeader columnHeader9;
    private Button button8;
    private Button button9;
    private Button button10;
    private ColumnHeader columnHeader10;
    private ColumnHeader columnHeader11;
    private TabPage tabPage8_Month;
    private GroupBox groupBox10;
    private GroupBox groupBox11;
    private RadioButton radioButton21;
    private RadioButton radioButton22;
    private Label label16;
    private Label label17;
    private Label label18;
    private Label label19;
    private Label label20;
    private NumericUpDown numericUpDown7;
    private NumericUpDown numericUpDown8;
    private NumericUpDown numericUpDown9;
    private ListView listView4;
    private ColumnHeader columnHeader12;
    private ColumnHeader columnHeader13;
    private ColumnHeader columnHeader15;
    private ColumnHeader columnHeader16;
    private Button button11;
    private Button button12;
    private Button button13;
    private TabPage tabPage9_Week;
    private TabPage tabPage10_Day;
    private Label label21;
    private GroupBox groupBox12;
    private ComboBox comboBox1;
    private Label label22;
    private GroupBox groupBox13;
    private RadioButton radioButton23;
    private RadioButton radioButton24;
    private Label label23;
    private Label label24;
    private Label label25;
    private Label label26;
    private Label label27;
    private NumericUpDown numericUpDown12;
    private NumericUpDown numericUpDown13;
    private NumericUpDown numericUpDown14;
    private ListView listView5;
    private ColumnHeader columnHeader14;
    private ColumnHeader columnHeader17;
    private ColumnHeader columnHeader18;
    private ColumnHeader columnHeader19;
    private Button button14;
    private Button button15;
    private Button button16;
    private GroupBox groupBox14;
    private GroupBox groupBox15;
    private RadioButton radioButton25;
    private RadioButton radioButton26;
    private Label label28;
    private Label label29;
    private Label label30;
    private Label label31;
    private Label label32;
    private NumericUpDown numericUpDown10;
    private NumericUpDown numericUpDown11;
    private NumericUpDown numericUpDown15;
    private ListView listView6;
    private ColumnHeader columnHeader20;
    private ColumnHeader columnHeader21;
    private ColumnHeader columnHeader22;
    private Button button17;
    private Button button18;
    private Button button19;
    private NumericUpDown numericUpDown16;
    private TabPage tabPage11_ImpulseRelay;
    private TabPage tabPage12_SimpleRelay;
    private GroupBox groupBox16;
    private GroupBox groupBox17;
    private GroupBox groupBox19;
    private Label label39;
    private NumericUpDown numericUpDown21;
    private Label label40;
    private Label label41;
    private NumericUpDown numericUpDown22;
    private GroupBox groupBox18;
    private Label label36;
    private NumericUpDown numericUpDown19;
    private Label label37;
    private Label label38;
    private NumericUpDown numericUpDown20;
    private Label label35;
    private NumericUpDown numericUpDown18;
    private Label label34;
    private Label label33;
    private NumericUpDown numericUpDown17;
    private GroupBox groupBox20;
    private GroupBox groupBox23;
    private Label label48;
    private NumericUpDown numericUpDown27;
    private Label label49;
    private Label label50;
    private NumericUpDown numericUpDown28;
    private TabPage tabPage14_RV;
    private TabPage tabPage15_RF;
    private GroupBox groupBox21;
    private RadioButton radioButton27;
    private RadioButton radioButton33;
    private GroupBox groupBox22;
    private GroupBox groupBox25;
    private NumericUpDown numericUpDown25;
    private Label label44;
    private NumericUpDown numericUpDown26;
    private Label label45;
    private GroupBox groupBox26;
    private GroupBox groupBox28;
    private Label label55;
    private NumericUpDown numericUpDown33;
    private Label label56;
    private Label label57;
    private NumericUpDown numericUpDown34;
    private GroupBox groupBox27;
    private Label label52;
    private NumericUpDown numericUpDown31;
    private Label label53;
    private Label label54;
    private NumericUpDown numericUpDown32;
    private Label label46;
    private NumericUpDown numericUpDown29;
    private Label label47;
    private Label label51;
    private NumericUpDown numericUpDown30;
    private GroupBox groupBox29;
    private GroupBox groupBox30;
    private GroupBox groupBox31;
    private Label label61;
    private NumericUpDown numericUpDown37;
    private Label label62;
    private Label label63;
    private NumericUpDown numericUpDown38;
    private GroupBox groupBox32;
    private Label label64;
    private NumericUpDown numericUpDown39;
    private Label label65;
    private Label label66;
    private NumericUpDown numericUpDown40;
    private GroupBox groupBox33;
    private GroupBox groupBox35;
    private RadioButton radioButton28;
    private RadioButton radioButton29;
    private GroupBox groupBox36;
    private NumericUpDown numericUpDown45;
    private Label label71;
    private NumericUpDown numericUpDown46;
    private Label label72;
    private GroupBox groupBox24;
    private NumericUpDown numericUpDown24;
    private Label label43;
    private NumericUpDown numericUpDown23;
    private Label label42;
    private RadioButton radioButton36;
    private RadioButton radioButton39;
    private RadioButton radioButton37;
    private RadioButton radioButton40;
    private RadioButton radioButton38;
    private RadioButton radioButton30;
    private RadioButton radioButton35;
    private RadioButton radioButton31;
    private RadioButton radioButton34;
    private RadioButton radioButton32;
    private TabPage tabPage1;
    private TabPage tabPage16_Options;
    private GroupBox groupBox42;
    private CheckBox checkBox12;
    private GroupBox groupBox43;
    private Label label76;
    private NumericUpDown numericUpDown41;
    private Label label77;
    private Label label78;
    private NumericUpDown numericUpDown42;
    private TabPage tabPage2_Time;
    private GroupBox groupBox34;
    private GroupBox groupBox39;
    private Label label59;
    private DateTimePicker dateTimePicker5;
    private Button button21;
    private DateTimePicker dateTimePicker6;
    private GroupBox groupBox38;
    private GroupBox groupBox37;
    private Label label58;
    private Button button20;
    private ToolStripMenuItem FileToolStripMenuItem;
    private ToolStripMenuItem createToolStripMenuItem;
    private ToolStripMenuItem openToolStripMenuItem;
    private ToolStripSeparator toolStripSeparator;
    private ToolStripMenuItem saveToolStripMenuItem;
    private ToolStripMenuItem saveAsToolStripMenuItem;
    private ToolStripMenuItem печатьToolStripMenuItem;
    private ToolStripMenuItem предварительныйпросмотрToolStripMenuItem;
    private ToolStripSeparator toolStripSeparator2;
    private ToolStripMenuItem exitToolStripMenuItem;
    private ToolStripMenuItem relayToolStripMenuItem;
    private ToolStripMenuItem readSettingsToolStripMenuItem;
    private ToolStripMenuItem sendSettingsToolStripMenuItem;
    private ToolStripMenuItem HelpToolStripMenuItem;
    private ToolStripMenuItem contentsHelpToolStripMenuItem;
    private ToolStripMenuItem aboutProgramToolStripMenuItem;
    private ToolStripSeparator toolStripSeparator1;
    private ToolStripButton createToolStripButton;
    private ToolStripButton openToolStripButton;
    private ToolStripButton saveToolStripButton;
    private ToolStripButton печатьToolStripButton;
    private ToolStripSeparator toolStripSeparator6;
    private ToolStripButton вырезатьToolStripButton;
    private ToolStripButton копироватьToolStripButton;
    private ToolStripButton вставкаToolStripButton;
    private ToolStripSeparator toolStripSeparator7;
    private ToolStripButton helpToolStripButton;
    private Button button27;
    private Button button26;
    private OpenFileDialog openFileDialog1;
    private SaveFileDialog saveFileDialog1;
    private Label label79;
    private Button button28;
    private Label label80;
    public ProgressBar progressBar1;
    private Button button29;
    private Button button30;
    private Button button31;
    private Label label81;
    private Timer timer1;
    private Label label82;
    private Button button32;
    private ToolStripMenuItem versionProgToolStripMenuItem;
    private TabPage tabPage3_VoltBright;
    private GroupBox groupBox44;
    private GroupBox groupBox45;
    private Label label83;
    private Label label84;
    private Button button33;
    private Label label85;
    private Label label86;
    private NumericUpDown numericUpDown43;
    private GroupBox groupBox46;
    private Label label87;
    private Label label88;
    private Button button35;
    private Label label89;
    private Label label90;
    private NumericUpDown numericUpDown44;
    private Label label60;
    private Label label67;
    private Label label68;
    private Label label69;
    private Timer timer2;
    private Button button22;
    private Timer timer3;
    private Timer timer4;
    private Label label70;
    private Label label73;
    private Button button23;
    private Button button24;
    private Button button25;
    private Button button34;
    private Button button36;
    private Button button37;
    private Button button38;
    private RichTextBox richTextBox1;
    private GroupBox groupBox40;
    private Button button39;
    private ComboBox comboBox2;
    private TabPage tabPage2_RTcom;
    private RichTextBox richTextBox2;
    private TabPage tabPage2_Except;
    private RichTextBox richTextBox3;
    private GroupBox groupBox41;
    private Label label74;
    private Label label75;
    private Label label91;
    private Button button40;
    private Label label92;
    private Label label93;
    private Button button41;
    private TextBox textBox1;
    private Label label94;
    private Label label96;
    private Label label98;
    private Label label97;
    private NumericUpDown numericUpDown35;
    private Button button42;
    private Button button43;
    private Button button44;
    private Button button45;
    private Button button46;
    private Button button47;
    private Button button48;
    private Button button49;
    private Label label95;
    private Timer timer5_compDataInRelay;
    private ToolStripMenuItem languageToolStripMenuItem;
    private ToolStripMenuItem englishToolStripMenuItem;
    private ToolStripMenuItem polishToolStripMenuItem;
    private ToolStripMenuItem russianToolStripMenuItem;

    public Form1()
    {
      this.InitializeComponent();
      this.Init();
    }

    private void LanguageInit()
    {
      switch (this.SysSet.Lang)
      {
        case SystemSettings.TypeLanguage.RUSSIAN:
          this.LangGlobal = 0;
          break;
        case SystemSettings.TypeLanguage.ENGLISH:
          this.LangGlobal = 1;
          break;
        case SystemSettings.TypeLanguage.POLISH:
          this.LangGlobal = 2;
          break;
      }
      if (this.LangGlobal == 0)
      {
        this.languageToolStripMenuItem.Text = "Язык";
        this.englishToolStripMenuItem.Checked = false;
        this.polishToolStripMenuItem.Checked = false;
        this.russianToolStripMenuItem.Checked = true;
      }
      else if (this.LangGlobal == 1)
      {
        this.languageToolStripMenuItem.Text = "Language";
        this.englishToolStripMenuItem.Checked = true;
        this.polishToolStripMenuItem.Checked = false;
        this.russianToolStripMenuItem.Checked = false;
        this.stMon = "Monday";
        this.stTue = "Tuesday";
        this.stWed = "Wednesday";
        this.stThu = "Thursday";
        this.stFri = "Friday";
        this.stSat = "Saturday";
        this.stSun = "Sunday";
        this.Text = this.stNovatek[this.LangGlobal];
        this.radioButton15.Text = "OFF";
        this.radioButton1.Text = "Program P1";
        this.radioButton2.Text = "Program P2";
        this.radioButton3.Text = "Program P3";
        this.radioButton4.Text = "Program P4";
        this.radioButton5.Text = "Program P5";
        this.radioButton6.Text = "Program P6";
        this.radioButton7.Text = "Program P7";
        this.radioButton8.Text = "Program P8";
        this.groupBox2.Text = "Choose operation mode of time relay";
        this.radioButton16.Text = "OFF";
        this.radioButton9.Text = "Yearly timer";
        this.radioButton10.Text = "Monthly timer";
        this.radioButton11.Text = "Weekly timer";
        this.radioButton12.Text = "Daily timer";
        this.radioButton13.Text = "Pulse timer";
        this.radioButton14.Text = "Simple timer";
        this.groupBox3.Text = "Additional settings";
        this.checkBox1.Text = "Recognize days off";
        this.checkBox2.Text = "Recognize holidays";
        this.checkBox3.Text = "Repeat cycle";
        this.richTextBox1.Text = "    To control channel contacts, in the channel K1 or K2 setup menu select one of 8 programs according to which the contacts will be switched. Then go to settings of the program selected and activate the time relay, voltage relay and/or photo relay.\n\n    Use this window to copy other programs settings into current program.";
        this.groupBox40.Text = "Choose program for copy it settings:";
        this.button39.Text = "Copy into current program";
        this.button42.Text = "Clear lists";
        this.button49.Text = "Reset settings";
        this.groupBox4.Text = "Choose days off in week:";
        this.checkBox4.Text = this.stMon;
        this.checkBox5.Text = this.stTue;
        this.checkBox6.Text = this.stWed;
        this.checkBox7.Text = this.stThu;
        this.checkBox8.Text = this.stFri;
        this.checkBox9.Text = this.stSat;
        this.checkBox10.Text = this.stSun;
        this.groupBox5.Text = "List of holidays:";
        this.listView1.Columns[1].Text = "Day";
        this.listView1.Columns[2].Text = "Month";
        this.button2.Text = "Add";
        this.button3.Text = "Delete selected";
        this.button4.Text = "Clear list";
        this.button34.Text = "Array wizard";
        this.button43.Text = "Undo last action";
        this.groupBox6.Text = "List of exception events:";
        this.listView2.Columns[1].Text = "Time";
        this.listView2.Columns[2].Text = "Contacts";
        this.label6.Text = "Hours";
        this.label7.Text = "Minutes";
        this.label8.Text = "Seconds";
        this.groupBox7.Text = "Condition channel contacts:";
        this.radioButton17.Text = "Open";
        this.radioButton18.Text = "Close";
        this.button7.Text = "Add";
        this.button6.Text = "Delete selected";
        this.button5.Text = "Clear list";
        this.button36.Text = "Array wizard";
        this.button44.Text = "Undo last action";
        this.groupBox8.Text = "Events list of yearly time relay:";
        this.listView3.Columns[1].Text = "Day";
        this.listView3.Columns[2].Text = "Month";
        this.listView3.Columns[3].Text = "Time";
        this.listView3.Columns[4].Text = "Contacts";
        this.label15.Text = "Hours";
        this.label14.Text = "Minutes";
        this.label13.Text = "Seconds";
        this.groupBox9.Text = "Condition channel contacts:";
        this.radioButton20.Text = "Open";
        this.radioButton19.Text = "Close";
        this.button10.Text = "Add";
        this.button9.Text = "Delete selected";
        this.button8.Text = "Clear list";
        this.button24.Text = "Array wizard";
        this.button45.Text = "Undo last action";
        this.button23.Text = "List of Sunrise/Sunset wizard";
        this.groupBox10.Text = "Events list of monthly time relay:";
        this.listView4.Columns[1].Text = "Day of Month";
        this.listView4.Columns[2].Text = "Time";
        this.listView4.Columns[3].Text = "Contacts";
        this.label21.Text = "Day of month:";
        this.label20.Text = "Hours";
        this.label19.Text = "Minutes";
        this.label18.Text = "Seconds";
        this.groupBox11.Text = "Condition channel contacts:";
        this.radioButton22.Text = "Open";
        this.radioButton21.Text = "Close";
        this.button13.Text = "Add";
        this.button12.Text = "Delete selected";
        this.button11.Text = "Clear list";
        this.button25.Text = "Array wizard";
        this.button46.Text = "Undo last action";
        this.groupBox12.Text = "Events list of weekly time relay:";
        this.listView5.Columns[1].Text = "Day of week";
        this.listView5.Columns[2].Text = "Time";
        this.listView5.Columns[3].Text = "Contacts";
        this.label22.Text = "Day of week:";
        this.comboBox1.Items[0] = (object) this.stMon;
        this.comboBox1.Items[1] = (object) this.stTue;
        this.comboBox1.Items[2] = (object) this.stWed;
        this.comboBox1.Items[3] = (object) this.stThu;
        this.comboBox1.Items[4] = (object) this.stFri;
        this.comboBox1.Items[5] = (object) this.stSat;
        this.comboBox1.Items[6] = (object) this.stSun;
        this.label27.Text = "Hours";
        this.label26.Text = "Minutes";
        this.label25.Text = "Seconds";
        this.groupBox13.Text = "Condition channel contacts:";
        this.radioButton24.Text = "Open";
        this.radioButton23.Text = "Close";
        this.button16.Text = "Add";
        this.button15.Text = "Delete selected";
        this.button14.Text = "Clear list";
        this.button37.Text = "Array wizard";
        this.button47.Text = "Undo last action";
        this.groupBox14.Text = "Events list of daily time relay:";
        this.listView6.Columns[1].Text = "Time";
        this.listView6.Columns[2].Text = "Contacts";
        this.label32.Text = "Hours";
        this.label31.Text = "Minutes";
        this.label30.Text = "Seconds";
        this.groupBox15.Text = "Condition channel contacts:";
        this.radioButton26.Text = "Open";
        this.radioButton25.Text = "Close";
        this.button19.Text = "Add";
        this.button18.Text = "Delete selected";
        this.button17.Text = "Clear list";
        this.button38.Text = "Array wizard";
        this.button48.Text = "Undo last action";
        this.groupBox16.Text = "Pulse time relay settings:";
        this.groupBox17.Text = "Preliminary Delay:";
        this.groupBox18.Text = "Contacts close duration:";
        this.groupBox19.Text = "Contacts open duration:";
        this.label33.Text = "Minutes";
        this.label38.Text = "Minutes";
        this.label41.Text = "Minutes";
        this.label35.Text = "Seconds";
        this.label36.Text = "Seconds";
        this.label39.Text = "Seconds";
        this.groupBox20.Text = "Simple time relay settings:";
        this.groupBox23.Text = "Delay before contacts close:";
        this.label50.Text = "Minutes";
        this.label48.Text = "Seconds";
        this.groupBox21.Text = "Voltage relay settings:";
        this.groupBox22.Text = "Operation Mode:";
        this.groupBox26.Text = "Bottom Threshold Open Delay\n(U < Umin):";
        this.groupBox36.Text = "Operating range bottom threshold:";
        this.groupBox27.Text = "Reclosing Delay\n(Umin < U < Umax):";
        this.groupBox25.Text = "Operating range upper threshold:";
        this.groupBox28.Text = "Upper Threshold Open Delay\n(U > Umax):";
        this.radioButton27.Text = "OFF";
        this.radioButton33.Text = "ON";
        this.label51.Text = "Minutes";
        this.label46.Text = "Seconds";
        this.label72.Text = "Umin, V:";
        this.label71.Text = "Positive\nhysteresis, V:";
        this.label54.Text = "Minutes";
        this.label52.Text = "Seconds";
        this.label45.Text = "Umax, V:";
        this.label44.Text = "Negative\nhysteresis, V:";
        this.label57.Text = "Minutes";
        this.label55.Text = "Seconds";
        this.groupBox29.Text = "Photorelay settings:";
        this.groupBox35.Text = "Operation mode:";
        this.groupBox24.Text = "Illumination threshold:";
        this.groupBox32.Text = "Delay if L < Lthr:";
        this.groupBox31.Text = "Delay if L > Lthr:";
        this.groupBox33.Text = "Contacts Position if L < Lthr:";
        this.groupBox30.Text = "Contacts Position if L > Lthr:";
        this.radioButton28.Text = "OFF";
        this.radioButton29.Text = "ON";
        this.label42.Text = "Lthr, lux:";
        this.label43.Text = "Positive\nhysteresis, lux:";
        this.label66.Text = "Minutes";
        this.label64.Text = "Seconds";
        this.label63.Text = "Minutes";
        this.label61.Text = "Seconds";
        this.radioButton34.Text = "Open";
        this.radioButton31.Text = "Close";
        this.radioButton35.Text = "Time relay repeat";
        this.radioButton32.Text = "Open till\nnext event";
        this.radioButton30.Text = "Close till\nnext event";
        this.radioButton40.Text = "Open";
        this.radioButton39.Text = "Close";
        this.radioButton38.Text = "Time relay repeat";
        this.radioButton37.Text = "Open till\nnext event";
        this.radioButton36.Text = "Close till\nnext event";
        this.groupBox42.Text = "Device general settings:";
        this.groupBox43.Text = "Common time delay between\nthe moment of device energizing\nand channel operation start:";
        this.label78.Text = "Minutes";
        this.label76.Text = "Seconds";
        this.checkBox12.Text = "Recognize summer time conversion";
        this.groupBox34.Text = "Time setting:";
        this.groupBox38.Text = "REV-302 current time:";
        this.groupBox37.Text = "System time:";
        this.groupBox39.Text = "Manual time setup:";
        this.button22.Text = "Reload";
        this.button20.Text = "Apply";
        this.button21.Text = "Apply";
        this.label58.Text = "Synchronize REV-302\ntime with system:";
        this.label59.Text = "Load in REV-302:";
        this.richTextBox2.Text = "    To close time relay, select one of the relay operation modes from the \"General time menu settings\". For fine setting of each mode, move to the corresponding menu items where the event lists are edited in case of calendar modes or time parameters for the pulse or common relay are set.\n\n    Days-off and holidays with special event lists are set up within the \"Exceptions\" group.\n\n    Use \"create array\" buttons to edit event lists.\n    For the yearly events list there is a possibility to calculate the moments of Sunrise and Sunset for a set time range with a time shift before or after the event and the required contacts position.";
        this.richTextBox3.Text = "    Certain days selected from the weekly (days-off) or the yearly (holidays) lists can be marked as exceptional. For such days a separate list of events is made up. To allow executing a separate event list on days-off and holidays, check corresponding checkboxes in the \"Time Relay General Settings\" item.";
        this.label95.Text = "Attention! Last changes are not kept in REV-302";
        this.FileToolStripMenuItem.Text = "File";
        this.FileToolStripMenuItem.Text = "File";
        this.relayToolStripMenuItem.Text = "Relay";
        this.HelpToolStripMenuItem.Text = "Help";
        this.createToolStripMenuItem.Text = "New";
        this.openToolStripMenuItem.Text = "Open";
        this.saveToolStripMenuItem.Text = "Save";
        this.saveAsToolStripMenuItem.Text = "Save as...";
        this.exitToolStripMenuItem.Text = "Exit";
        this.readSettingsToolStripMenuItem.Text = "Read settings";
        this.sendSettingsToolStripMenuItem.Text = "Write settings";
        this.versionProgToolStripMenuItem.Text = "Relay program version";
        this.contentsHelpToolStripMenuItem.Text = "Content";
        this.aboutProgramToolStripMenuItem.Text = "About program";
        this.createToolStripButton.Text = "New";
        this.openToolStripButton.Text = "Open";
        this.saveToolStripButton.Text = "Save";
        this.helpToolStripButton.Text = "Help";
        this.StRelVrem = "Time Relay ";
        this.StRelVremOptions = "Time relay general settings";
        this.StExceptions = "Exceptions ";
        this.StHolidays = "Holidays ";
        this.StWeekEnds = "Days off";
        this.StListEventExceptions = "List of exceptional events ";
        this.StListEventYear = "Yearly relay events ";
        this.StListEventMonth = "Monthly relay events ";
        this.StListEventWeek = "Weekly relay events ";
        this.StListEventDay = "Daily relay events ";
        this.StImpulseOptions = "Pulse relay options";
        this.StSimpleOptions = "Simple relay options";
        this.StVoltRelayOptions = "Voltage relay ";
        this.StPhotoRelayOptions = "Photorelay ";
        this.StDeviceOptions = "Device general settings";
        this.StTimeCorrect = "Time setting";
        this.StVoltBrightCorrect = "Voltage and illuminate correction";
        this.StDaysOfWeek[0] = this.stMon;
        this.StDaysOfWeek[1] = this.stTue;
        this.StDaysOfWeek[2] = this.stWed;
        this.StDaysOfWeek[3] = this.stThu;
        this.StDaysOfWeek[4] = this.stFri;
        this.StDaysOfWeek[5] = this.stSat;
        this.StDaysOfWeek[6] = this.stSun;
      }
      else
      {
        if (this.LangGlobal != 2)
          return;
        this.languageToolStripMenuItem.Text = "Język";
        this.englishToolStripMenuItem.Checked = false;
        this.polishToolStripMenuItem.Checked = true;
        this.russianToolStripMenuItem.Checked = false;
        this.stMon = "Poniedziałek";
        this.stTue = "Wtorek";
        this.stWed = "Środa";
        this.stThu = "Czwartek";
        this.stFri = "Piątek";
        this.stSat = "Sobota";
        this.stSun = "Niedziela";
        string str1 = "Wyłącz";
        string str2 = "Załącz";
        this.Text = this.stNovatek[this.LangGlobal];
        this.radioButton15.Text = "Odłączony";
        this.radioButton1.Text = "Program P1";
        this.radioButton2.Text = "Program P2";
        this.radioButton3.Text = "Program P3";
        this.radioButton4.Text = "Program P4";
        this.radioButton5.Text = "Program P5";
        this.radioButton6.Text = "Program P6";
        this.radioButton7.Text = "Program P7";
        this.radioButton8.Text = "Program P8";
        this.groupBox2.Text = "Wybierz tryb pracy przekaźnika czasowego programu P1";
        this.radioButton16.Text = "Odłączony";
        this.radioButton9.Text = "Zegar roczny";
        this.radioButton10.Text = "Zegar miesięczny";
        this.radioButton11.Text = "Zegar tygodniowy";
        this.radioButton12.Text = "Zegar dzienny";
        this.radioButton13.Text = "Zegar impulsowy";
        this.radioButton14.Text = "Zegar zwykły";
        this.groupBox3.Text = "Ustawienia dodatkowe";
        this.checkBox1.Text = "Uwzględnij dni wolne";
        this.checkBox2.Text = "Uwzględnij święta";
        this.checkBox3.Text = "Powtarzaj cyklicznie";
        this.richTextBox1.Text = "Do sterowania stykami kanałów w menu ustawień kanału K1 lub K2 należy wybrać jeden z 8 programów, zgodnie z którym będą przełączane styki. Następnie należy przejść do ustawień wybranego programu i aktywować przekaźnik czasowy i/lub napięciowy i/lub fotoprzekaźnik.\n\nZa pomocą tego okna można do bieżącego programu skopiować ustawienia z innych programów.";
        this.groupBox40.Text = "Wybierz program do kopiowania jego ustawień";
        this.button39.Text = "Kopiuj do programu bieżącego";
        this.button42.Text = "Wyczyść listy";
        this.button49.Text = "Skasuj ustawienia";
        this.groupBox4.Text = "Wybierz dni wolne:";
        this.checkBox4.Text = this.stMon;
        this.checkBox5.Text = this.stTue;
        this.checkBox6.Text = this.stWed;
        this.checkBox7.Text = this.stThu;
        this.checkBox8.Text = this.stFri;
        this.checkBox9.Text = this.stSat;
        this.checkBox10.Text = this.stSun;
        this.groupBox5.Text = "Lista świąt:";
        this.listView1.Columns[1].Text = "Dzień";
        this.listView1.Columns[2].Text = "Miesiąc";
        this.button2.Text = "Dodaj";
        this.button3.Text = "Usuń zaznaczone";
        this.button4.Text = "Wyczyść listę";
        this.button34.Text = "Utwórz listę świąt";
        this.button43.Text = "Anuluj ostatnie czynności";
        this.groupBox6.Text = "Lista wyłączeń:";
        this.listView2.Columns[1].Text = "Czas";
        this.listView2.Columns[2].Text = "Styki";
        this.label6.Text = "Godziny";
        this.label7.Text = "Minuty";
        this.label8.Text = "Sekundy";
        this.groupBox7.Text = "Stan styków kanału:";
        this.radioButton17.Text = str1;
        this.radioButton18.Text = str2;
        this.button7.Text = "Dodaj";
        this.button6.Text = "Usuń zaznaczone";
        this.button5.Text = "Wyczyść listę";
        this.button36.Text = "Utwórz listę zdarzeń";
        this.button44.Text = "Anuluj ostatnie czynności";
        this.groupBox8.Text = "Lista zdarzeń zegara rocznego:";
        this.listView3.Columns[1].Text = "Dzień";
        this.listView3.Columns[2].Text = "Miesiąc";
        this.listView3.Columns[3].Text = "Czas";
        this.listView3.Columns[4].Text = "Styki";
        this.label15.Text = "Godziny";
        this.label14.Text = "Minuty";
        this.label13.Text = "Sekundy";
        this.groupBox9.Text = "Stan styków kanału:";
        this.radioButton20.Text = str1;
        this.radioButton19.Text = str2;
        this.button10.Text = "Dodaj";
        this.button9.Text = "Usuń zaznaczone";
        this.button8.Text = "Wyczyść listę";
        this.button24.Text = "Utwórz listę zdarzeń";
        this.button45.Text = "Anuluj ostatnie czynności";
        this.button23.Text = "Utwórz listę wschodów/zachodów Słońca";
        this.groupBox10.Text = "Lista zdarzeń zegara miesięcznego:";
        this.listView4.Columns[1].Text = "Dzień miesiąca";
        this.listView4.Columns[2].Text = "Czas";
        this.listView4.Columns[3].Text = "Styki";
        this.label21.Text = "Dzień miesiąca:";
        this.label20.Text = "Godziny";
        this.label19.Text = "Minuty";
        this.label18.Text = "Sekundy";
        this.groupBox11.Text = "Stan styków kanału:";
        this.radioButton22.Text = str1;
        this.radioButton21.Text = str2;
        this.button13.Text = "Dodaj";
        this.button12.Text = "Usuń zaznaczone";
        this.button11.Text = "Wyczyść listę";
        this.button25.Text = "Utwórz listę zdarzeń";
        this.button46.Text = "Anuluj ostatnie czynności";
        this.groupBox12.Text = "Lista zdarzeń zegara tygodniowego:";
        this.listView5.Columns[1].Text = "Dzień tygodnia";
        this.listView5.Columns[2].Text = "Czas";
        this.listView5.Columns[3].Text = "Styki";
        this.label22.Text = "Dzień tygodnia:";
        this.comboBox1.Items[0] = (object) this.stMon;
        this.comboBox1.Items[1] = (object) this.stTue;
        this.comboBox1.Items[2] = (object) this.stWed;
        this.comboBox1.Items[3] = (object) this.stThu;
        this.comboBox1.Items[4] = (object) this.stFri;
        this.comboBox1.Items[5] = (object) this.stSat;
        this.comboBox1.Items[6] = (object) this.stSun;
        this.label27.Text = "Godziny";
        this.label26.Text = "Minuty";
        this.label25.Text = "Sekundy";
        this.groupBox13.Text = "Stan styków kanału:";
        this.radioButton24.Text = str1;
        this.radioButton23.Text = "Włącz";
        this.button16.Text = "Dodaj";
        this.button15.Text = "Usuń zaznaczone";
        this.button14.Text = "Wyczyść listę";
        this.button37.Text = "Utwórz listę zdarzeń";
        this.button47.Text = "Anuluj ostatnie czynności";
        this.groupBox14.Text = "Lista zdarzeń zegara dziennego:";
        this.listView6.Columns[1].Text = "Czas";
        this.listView6.Columns[2].Text = "Styki";
        this.label32.Text = "Godziny";
        this.label31.Text = "Minuty";
        this.label30.Text = "Sekundy";
        this.groupBox15.Text = "Stan styków kanału:";
        this.radioButton26.Text = str1;
        this.radioButton25.Text = str2;
        this.button19.Text = "Dodaj";
        this.button18.Text = "Usuń zaznaczone";
        this.button17.Text = "Wyczyść listę";
        this.button38.Text = "Utwórz listę zdarzeń";
        this.button48.Text = "Anuluj ostatnie czynności";
        this.groupBox16.Text = "Ustawienia zegara impulsowego:";
        this.groupBox17.Text = "Opóźnienie wstępne:";
        this.groupBox18.Text = "Czas trwania załączenia styków:";
        this.groupBox19.Text = "Czas trwania wyłączenia styków:";
        this.label33.Text = "Minuty";
        this.label38.Text = "Minuty";
        this.label41.Text = "Minuty";
        this.label35.Text = "Sekundy";
        this.label36.Text = "Sekundy";
        this.label39.Text = "Sekundy";
        this.groupBox20.Text = "Ustawienia zegara zwykłego:";
        this.groupBox23.Text = "Opóźnienie przed załączeniem styków:";
        this.label50.Text = "Minuty";
        this.label48.Text = "Sekundy";
        this.groupBox21.Text = "Ustawienia przekaźnika napięciowego:";
        this.groupBox22.Text = "Tryby pracy:";
        this.groupBox26.Text = "Opóźnienie wyłączenia dla dolnego progu\n(U < Umin):";
        this.groupBox36.Text = "Dolny próg zakresu pracy:";
        this.groupBox27.Text = "Opóźnienie ponownego załączenia\n(Umin < U < Umax):";
        this.groupBox25.Text = "Górny próg zakresu pracy:";
        this.groupBox28.Text = "Opóźnienie wyłączenia dla górnego progu\n(U > Umax):";
        this.radioButton27.Text = "Odłączony";
        this.radioButton33.Text = "Załączony";
        this.label51.Text = "Minuty";
        this.label46.Text = "Sekundy";
        this.label72.Text = "Umin, V:";
        this.label71.Text = "Histereza\ndodatnia, V:";
        this.label54.Text = "Minuty";
        this.label52.Text = "Sekundy";
        this.label45.Text = "Umax, V:";
        this.label44.Text = "Histereza\nujemna, V:";
        this.label57.Text = "Minuty";
        this.label55.Text = "Sekundy";
        this.groupBox29.Text = "Ustawienia fotoprzekaźnika:";
        this.groupBox35.Text = "Tryby pracy:";
        this.groupBox24.Text = "Próg natężenia oświetlenia:";
        this.groupBox32.Text = "Opóźnienie w przypadku L < Lthr:";
        this.groupBox31.Text = "Opóźnienie w przypadku L > Lthr:";
        this.groupBox33.Text = "Położenie styków w przypadku             L < Lthr:";
        this.groupBox30.Text = "Położenie styków w przypadku             L > Lthr:";
        this.radioButton28.Text = "Odłączony";
        this.radioButton29.Text = "Załączony";
        this.label42.Text = "Lthr, lux:";
        this.label43.Text = "Histereza\ndodatnia, lux:";
        this.label66.Text = "Minuty";
        this.label64.Text = "Sekundy";
        this.label63.Text = "Minuty";
        this.label61.Text = "Sekundy";
        this.radioButton34.Text = "Otwarte";
        this.radioButton31.Text = "Zamknięte";
        this.radioButton35.Text = "Powtórz przekaźnik czasowy";
        this.radioButton32.Text = "Otwarte do\nnastępnego zdarzenia";
        this.radioButton30.Text = "Zamknięte do\nnastępnego zdarzenia";
        this.radioButton40.Text = "Otwarte";
        this.radioButton39.Text = "Zamknięte";
        this.radioButton38.Text = "Powtórz przekaźnik czasowy";
        this.radioButton37.Text = "Otwarte do\nnastępnego zdarzenia";
        this.radioButton36.Text = "Zamknięte do\nnastępnego zdarzenia";
        this.groupBox42.Text = "Ogólne ustawienia urządzenia:";
        this.groupBox43.Text = "Ogólne opóźnienie czasu pomiędzy\nchwilą podania zasilania\ni rozpoczęciem pracy urządzenia:";
        this.label78.Text = "Minuty";
        this.label76.Text = "Sekundy";
        this.checkBox12.Text = "Uwzględnij przejście na czas letni";
        this.groupBox34.Text = "Ustawienie czasu:";
        this.groupBox38.Text = "Bieżący czas REV-302:";
        this.groupBox37.Text = "Czas systemowy:";
        this.groupBox39.Text = "Ręczne ustawienie czasu:";
        this.button22.Text = "Odśwież";
        this.button20.Text = "Zastosuj";
        this.button21.Text = "Zastosuj";
        this.label58.Text = "Synchronizuj czas REV-302\nz czasem systemowym:";
        this.label59.Text = "Pobierz do REV-302:";
        this.richTextBox2.Text = "Aby włączyć przekaźnik czasowy należy wybrać jeden z trybów pracy przekaźnika w menu \"Ogólne ustawienia przekaźnika czasowego\". W celu dokonania dokładnych ustawień każdego trybu należy przejść do odpowiednich pozycji menu, w których są edytowane listy zdarzeń (w przypadku trybów związanych z kalendarzem) lub określane parametry czasowe (dla przekaźnika impulsowego lub zwykłego).\n\nDni wolne i świąteczne z poszczególnymi listami zdarzeń są ustawiane w grupie \"Wyłączenia\".\n\nDo edycji list zdarzeń służą przyciski tworzenia tabel. W przypadku rocznej listy zdarzeń jest możliwość ustalenia astronomicznych chwil wschodów i zachodów Słońca dla ustawionego zakresu czasu z przesunięciem czasu przed i po zdarzeniu i odpowiednim położeniem styków.";
        this.richTextBox3.Text = "Niektóre dni, które są wybierane z listy tygodniowej (dni wolne) lub rocznej (święta), mogą zostać zaznaczone jako wyłączenia. Dla takich dni sporządza się własną listę zdarzeń. Aby zezwolić na wykonanie listy wyłączeń dla dni wolnych i świątecznych należy zaznaczyć odpowiednie pola w pozycji \"Ogólne ustawienia przekaźnika czasowego\".";
        this.label95.Text = "Uwaga! Ostatnie zmiany nie zostały zapisane do REV-302";
        this.FileToolStripMenuItem.Text = "Plik";
        this.FileToolStripMenuItem.Text = "Plik";
        this.relayToolStripMenuItem.Text = "Przekaźnik";
        this.HelpToolStripMenuItem.Text = "Pomoc";
        this.createToolStripMenuItem.Text = "Nowy";
        this.openToolStripMenuItem.Text = "Otwórz";
        this.saveToolStripMenuItem.Text = "Zapisz";
        this.saveAsToolStripMenuItem.Text = "Zapisz jako...";
        this.exitToolStripMenuItem.Text = "Zakończ";
        this.readSettingsToolStripMenuItem.Text = "Odczytaj ustawienia";
        this.sendSettingsToolStripMenuItem.Text = "Zapisz ustawienia";
        this.versionProgToolStripMenuItem.Text = "Wersja programu";
        this.contentsHelpToolStripMenuItem.Text = "Spis treści";
        this.aboutProgramToolStripMenuItem.Text = "O programie...";
        this.createToolStripButton.Text = "Nowy";
        this.openToolStripButton.Text = "Otwórz";
        this.saveToolStripButton.Text = "Zapisz";
        this.helpToolStripButton.Text = "Pomoc";
        this.StRelVrem = "Przekaźnik czasowy ";
        this.StRelVremOptions = "Ogólne ustawienia przekaźnika czasowego";
        this.StExceptions = "Wyłączenia ";
        this.StHolidays = "Święta ";
        this.StWeekEnds = "Dni wolne";
        this.StListEventExceptions = "Lista wyłączeń ";
        this.StListEventYear = "Zdarzenia zegara rocznego ";
        this.StListEventMonth = "Zdarzenia zegara miesięcznego ";
        this.StListEventWeek = "Zdarzenia zegara tygodniowego ";
        this.StListEventDay = "Zdarzenia zegara dziennego ";
        this.StImpulseOptions = "Ustawienia zegara impulsowego";
        this.StSimpleOptions = "Ustawienia zegara zwykłego";
        this.StVoltRelayOptions = "Przekaźnik napięciowy ";
        this.StPhotoRelayOptions = "Fotoprzekaźnik ";
        this.StDeviceOptions = "Ogólne ustawienia urządzenia";
        this.StTimeCorrect = "Ustawienie czasu";
        this.StVoltBrightCorrect = "Kalibracja napięcia i natężenia oświetlenia";
        this.StDaysOfWeek[0] = this.stMon;
        this.StDaysOfWeek[1] = this.stTue;
        this.StDaysOfWeek[2] = this.stWed;
        this.StDaysOfWeek[3] = this.stThu;
        this.StDaysOfWeek[4] = this.stFri;
        this.StDaysOfWeek[5] = this.stSat;
        this.StDaysOfWeek[6] = this.stSun;
      }
    }

    private void Init()
    {
      int num1 = 0;
      this.LanguageInit();
      this.label60.Text = this.stInfo[this.LangGlobal];
      this.label67.Text = this.stAbsent[this.LangGlobal];
      this.label68.Text = " ";
      this.label69.Text = " ";
      this.SychShowTime = true;
      this.SychTime = DateTime.Now;
      this.timer3.Enabled = true;
      this.treeView1.Nodes.Clear();
      this.treeView1.BeginUpdate();
      this.treeView1.Nodes.Add(this.stChannel1[this.LangGlobal]);
      int num2 = num1 + 1;
      this.treeView1.Nodes.Add(this.stChannel2[this.LangGlobal]);
      int num3 = num2 + 1;
      for (int index = num3; index < num3 + this.CtrlProgsMax; ++index)
      {
        this.treeView1.Nodes.Add(this.stProgram[this.LangGlobal] + (index - num3 + 1).ToString());
        this.treeView1.Nodes[index].Nodes.Add(this.StRelVrem);
        this.treeView1.Nodes[index].Nodes[0].Nodes.Add(this.StRelVremOptions);
        this.treeView1.Nodes[index].Nodes[0].Nodes.Add(this.StExceptions);
        this.treeView1.Nodes[index].Nodes[0].Nodes[1].Nodes.Add(this.StWeekEnds);
        this.treeView1.Nodes[index].Nodes[0].Nodes[1].Nodes.Add(this.StHolidays);
        this.treeView1.Nodes[index].Nodes[0].Nodes[1].Nodes.Add(this.StListEventExceptions);
        this.treeView1.Nodes[index].Nodes[0].Nodes.Add(this.StListEventYear);
        this.treeView1.Nodes[index].Nodes[0].Nodes.Add(this.StListEventMonth);
        this.treeView1.Nodes[index].Nodes[0].Nodes.Add(this.StListEventWeek);
        this.treeView1.Nodes[index].Nodes[0].Nodes.Add(this.StListEventDay);
        this.treeView1.Nodes[index].Nodes[0].Nodes.Add(this.StImpulseOptions);
        this.treeView1.Nodes[index].Nodes[0].Nodes.Add(this.StSimpleOptions);
        this.treeView1.Nodes[index].Nodes.Add(this.StVoltRelayOptions);
        this.treeView1.Nodes[index].Nodes.Add(this.StPhotoRelayOptions);
      }
      this.treeView1.Nodes.Add(this.StDeviceOptions);
      this.treeView1.Nodes.Add(this.StTimeCorrect);
      if (this.FactoryProgramType)
        this.treeView1.Nodes.Add(this.StVoltBrightCorrect);
      this.treeView1.SelectedNode = this.treeView1.Nodes[0];
      this.treeView1.EndUpdate();
      this.CreatCollectionForCtrlPrograms();
      this.BackCtrlProgramsOptions.Add(new CtrlProgramOptionsClass());
      this.Connection.LetLinksOnOptions(this.DeviceOptions, this.CtrlProgramsOptions);
      this.StMessageUSB = this.stUSBnoCon[this.LangGlobal];
      this.label81.Text = this.StMessageUSB;
      this.ReCalculateEventsInLists();
      this.ReDrawCorrespondenceProgAndChannel();
    }

    private void ReCalculateEventsInLists()
    {
      for (int pr = 1; pr <= 8; ++pr)
        this.ReCalculateEventsInLists(pr);
    }

    private void ReCalculateEventsInLists(int pr)
    {
      if (pr == 0)
        pr = 1;
      int index = pr + 1;
      int num = this.CtrlProgramsOptions[pr].ListHolidays.Count + this.CtrlProgramsOptions[pr].ListEventsException.Count + this.CtrlProgramsOptions[pr].ListEventsYear.Count + this.CtrlProgramsOptions[pr].ListEventsMonth.Count + this.CtrlProgramsOptions[pr].ListEventsWeek.Count + this.CtrlProgramsOptions[pr].ListEventsDay.Count;
      this.treeView1.Nodes[index].Text = this.stProgram[this.LangGlobal] + pr.ToString() + " (" + num.ToString() + this.stEvents_t1[this.LangGlobal];
      string str1;
      switch (this.CtrlProgramsOptions[pr].RelayTimeMode)
      {
        case CtrlProgramOptionsClass.RelayTimeModeType.R_T_M_OFF:
          str1 = this.stInTreeOff[this.LangGlobal];
          break;
        case CtrlProgramOptionsClass.RelayTimeModeType.R_T_M_YEAR:
          str1 = this.stInTreeYear[this.LangGlobal];
          break;
        case CtrlProgramOptionsClass.RelayTimeModeType.R_T_M_MONTH:
          str1 = this.stInTreeMonth[this.LangGlobal];
          break;
        case CtrlProgramOptionsClass.RelayTimeModeType.R_T_M_WEEK:
          str1 = this.stInTreeWeek[this.LangGlobal];
          break;
        case CtrlProgramOptionsClass.RelayTimeModeType.R_T_M_DAY:
          str1 = this.stInTreeDay[this.LangGlobal];
          break;
        case CtrlProgramOptionsClass.RelayTimeModeType.R_T_M_PULSE:
          str1 = this.stInTreePulse[this.LangGlobal];
          break;
        case CtrlProgramOptionsClass.RelayTimeModeType.R_T_M_SIMPLE:
          str1 = this.stInTreeSimple[this.LangGlobal];
          break;
        default:
          str1 = "";
          break;
      }
      this.treeView1.Nodes[index].Nodes[0].Text = this.StRelVrem + str1;
      this.treeView1.Nodes[index].Nodes[0].Nodes[1].Text = this.StExceptions + this.PlaceInScobe(this.CtrlProgramsOptions[pr].ListHolidays.Count + this.CtrlProgramsOptions[pr].ListEventsException.Count);
      this.treeView1.Nodes[index].Nodes[0].Nodes[1].Nodes[1].Text = this.StHolidays + this.PlaceInScobe(this.CtrlProgramsOptions[pr].ListHolidays.Count);
      this.treeView1.Nodes[index].Nodes[0].Nodes[1].Nodes[2].Text = this.StListEventExceptions + this.PlaceInScobe(this.CtrlProgramsOptions[pr].ListEventsException.Count);
      this.treeView1.Nodes[index].Nodes[0].Nodes[2].Text = this.StListEventYear + this.PlaceInScobe(this.CtrlProgramsOptions[pr].ListEventsYear.Count);
      this.treeView1.Nodes[index].Nodes[0].Nodes[3].Text = this.StListEventMonth + this.PlaceInScobe(this.CtrlProgramsOptions[pr].ListEventsMonth.Count);
      this.treeView1.Nodes[index].Nodes[0].Nodes[4].Text = this.StListEventWeek + this.PlaceInScobe(this.CtrlProgramsOptions[pr].ListEventsWeek.Count);
      this.treeView1.Nodes[index].Nodes[0].Nodes[5].Text = this.StListEventDay + this.PlaceInScobe(this.CtrlProgramsOptions[pr].ListEventsDay.Count);
      string str2 = !this.CtrlProgramsOptions[pr].RV_OnOff ? this.stInTreeOff[this.LangGlobal] : this.stInTreeON[this.LangGlobal];
      this.treeView1.Nodes[index].Nodes[1].Text = this.StVoltRelayOptions + str2;
      string str3 = !this.CtrlProgramsOptions[pr].RF_OnOff ? this.stInTreeOff[this.LangGlobal] : this.stInTreeON[this.LangGlobal];
      this.treeView1.Nodes[index].Nodes[2].Text = this.StPhotoRelayOptions + str3;
    }

    private void ReDrawCorrespondenceProgAndChannel()
    {
      for (int index = 0; index <= 1; ++index)
      {
        string str;
        if ((int) this.DeviceOptions.Channel_CtrlProg[index + 1] == 0)
          str = this.stInTreeChannelN[this.LangGlobal] + (index + 1).ToString() + this.stInTreeOffFull[this.LangGlobal];
        else
          str = this.stInTreeChannelN[this.LangGlobal] + (index + 1).ToString() + " (" + this.stInTreeP[this.LangGlobal] + this.DeviceOptions.Channel_CtrlProg[index + 1].ToString() + ")";
        this.treeView1.Nodes[index].Text = str;
      }
    }

    private string PlaceInScobe(int In)
    {
      return "(" + In.ToString() + ")";
    }

    private void CreatCollectionForCtrlPrograms()
    {
      for (int index = 0; index <= this.CtrlProgsMax + 1; ++index)
        this.CtrlProgramsOptions.Add(new CtrlProgramOptionsClass());
    }

    private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
    {
      TreeNode node = e.Node;
      if (e.Node.GetType() == typeof (TreeNode))
      {
        if (e.Node.Parent != null)
        {
          TreeNode treeNode = e.Node;
          while (treeNode.Parent != null)
            treeNode = treeNode.Parent;
          this.ProgSelected = treeNode.Index - 1;
          if (this.ProgSelected > 8)
            this.ProgSelected = 0;
          this.InVisibleAllPanels();
          string str = e.Node.Text.Split('(')[0];
          if (str == this.StRelVrem)
            this.ShowWin_RT();
          else if (str == this.StRelVremOptions)
            this.ShowWin_RTOptions();
          else if (str == this.StExceptions)
            this.ShowWin_Exceptions();
          else if (str == this.StHolidays)
            this.ShowWin_Holidays();
          else if (str == this.StWeekEnds)
            this.ShowWin_WeekEnds();
          else if (str == this.StListEventExceptions)
            this.ShowWin_ListOfExcept();
          else if (str == this.StListEventYear)
            this.ShowWin_ListOfYearEvents();
          else if (str == this.StListEventMonth)
            this.ShowWin_ListOfMonthEvents();
          else if (str == this.StListEventWeek)
            this.ShowWin_ListOfWeekEvents();
          else if (str == this.StListEventDay)
            this.ShowWin_ListOfDayEvents();
          else if (str == this.StImpulseOptions)
            this.ShowWin_ImpulseOptions();
          else if (str == this.StSimpleOptions)
            this.ShowWin_SimpleOptions();
          else if (str == this.StVoltRelayOptions)
            this.ShowWin_RVOptions();
          else if (str == this.StPhotoRelayOptions)
            this.ShowWin_RFOptions();
        }
        else if (e.Node.Parent == null)
        {
          this.InVisibleAllPanels();
          if (e.Node.Index == 0)
          {
            this.ChannelSelected = 1;
            this.ShowWin_Channel();
          }
          else if (e.Node.Index == 1)
          {
            this.ChannelSelected = 2;
            this.ShowWin_Channel();
          }
          else if (e.Node.Index >= 2 && e.Node.Index < 2 + this.CtrlProgsMax)
          {
            this.ProgSelected = e.Node.Index - 1;
            this.ShowWin_Empty();
          }
          else if (e.Node.Index == 2 + this.CtrlProgsMax)
            this.ShowWin_CommonDeviceOptions();
          else if (e.Node.Index == 3 + this.CtrlProgsMax)
            this.ShowWin_TimeCorrect();
          else if (e.Node.Index == 4 + this.CtrlProgsMax)
            this.ShowWin_VoltBrightCorrect();
        }
        this.label1.Text = e.Node.Text;
        this.label2.Text = string.Format("Номер корневого узла: {0}.", (object) e.Node.Index);
        this.label3.Text = string.Format("Номер программы №{0}", (object) this.ProgSelected);
      }
      this.treeView1.Focus();
      this.UnVisibledBackButtons();
    }

    private void ShowWin_VoltBrightCorrect()
    {
      this.label4.Text = this.stVoltAndPhoto[this.LangGlobal];
      this.tabControl1.SelectedTab = this.tabPage3_VoltBright;
    }

    private void ShowWin_TimeCorrect()
    {
      this.label4.Text = this.stTimeSetting[this.LangGlobal];
      this.tabControl1.SelectedTab = this.tabPage2_Time;
    }

    private void ShowWin_CommonDeviceOptions()
    {
      this.label4.Text = this.stGeneralSettings[this.LangGlobal];
      this.numericUpDown42.Value = (Decimal) this.DeviceOptions.CommonDelay.Minute;
      this.numericUpDown41.Value = (Decimal) this.DeviceOptions.CommonDelay.Second;
      this.checkBox12.Checked = this.DeviceOptions.DST_OnOff;
      this.tabControl1.SelectedTab = this.tabPage16_Options;
    }

    private void ShowWin_Empty()
    {
      this.comboBox2.Items.Clear();
      for (int index = 1; index <= 8; ++index)
      {
        if (index != this.ProgSelected)
          this.comboBox2.Items.Add((object) (this.stProgram[this.LangGlobal] + index.ToString()));
      }
      this.comboBox2.SelectedIndex = 0;
      this.label4.Text = string.Format(this.stProgram[this.LangGlobal] + this.ProgSelected.ToString());
      this.tabControl1.SelectedTab = this.tabPage3_Empty;
    }

    private void ShowWin_RFOptions()
    {
      this.tabControl1.SelectedTab = this.tabPage15_RF;
      this.label4.Text = this.stInTreeP[this.LangGlobal] + this.ProgSelected.ToString() + ":  " + this.stPhotoRelay[this.LangGlobal];
      this.radioButton28.Checked = !this.CtrlProgramsOptions[this.ProgSelected].RF_OnOff;
      this.radioButton29.Checked = this.CtrlProgramsOptions[this.ProgSelected].RF_OnOff;
      this.numericUpDown23.Value = (Decimal) this.CtrlProgramsOptions[this.ProgSelected].RF_Lpor;
      this.numericUpDown24.Value = (Decimal) this.CtrlProgramsOptions[this.ProgSelected].RF_Lporhyst;
      this.numericUpDown40.Value = (Decimal) this.CtrlProgramsOptions[this.ProgSelected].RF_DelayLmin.Minute;
      this.numericUpDown39.Value = (Decimal) this.CtrlProgramsOptions[this.ProgSelected].RF_DelayLmin.Second;
      this.numericUpDown38.Value = (Decimal) this.CtrlProgramsOptions[this.ProgSelected].RF_DelayLmax.Minute;
      this.numericUpDown37.Value = (Decimal) this.CtrlProgramsOptions[this.ProgSelected].RF_DelayLmax.Second;
      switch (this.CtrlProgramsOptions[this.ProgSelected].RF_Condition_Lmin)
      {
        case 0:
          this.radioButton34.Checked = true;
          break;
        case 1:
          this.radioButton31.Checked = true;
          break;
        case 2:
          this.radioButton35.Checked = true;
          break;
        case 3:
          this.radioButton32.Checked = true;
          break;
        case 4:
          this.radioButton30.Checked = true;
          break;
      }
      switch (this.CtrlProgramsOptions[this.ProgSelected].RF_Condition_Lmax)
      {
        case 0:
          this.radioButton40.Checked = true;
          break;
        case 1:
          this.radioButton39.Checked = true;
          break;
        case 2:
          this.radioButton38.Checked = true;
          break;
        case 3:
          this.radioButton37.Checked = true;
          break;
        case 4:
          this.radioButton36.Checked = true;
          break;
      }
    }

    private void ShowWin_RVOptions()
    {
      this.label4.Text = this.stInTreeP[this.LangGlobal] + this.ProgSelected.ToString() + ":  " + this.stRV[this.LangGlobal];
      this.tabControl1.SelectedTab = this.tabPage14_RV;
      this.radioButton27.Checked = !this.CtrlProgramsOptions[this.ProgSelected].RV_OnOff;
      this.radioButton33.Checked = this.CtrlProgramsOptions[this.ProgSelected].RV_OnOff;
      this.numericUpDown46.Value = (Decimal) this.CtrlProgramsOptions[this.ProgSelected].RV_Umin;
      this.numericUpDown45.Value = (Decimal) this.CtrlProgramsOptions[this.ProgSelected].RV_Uminhyst;
      this.numericUpDown26.Value = (Decimal) this.CtrlProgramsOptions[this.ProgSelected].RV_Umax;
      this.numericUpDown25.Value = (Decimal) this.CtrlProgramsOptions[this.ProgSelected].RV_Umaxhyst;
      this.numericUpDown30.Value = (Decimal) this.CtrlProgramsOptions[this.ProgSelected].RV_DelayUmin.Minute;
      this.numericUpDown29.Value = (Decimal) this.CtrlProgramsOptions[this.ProgSelected].RV_DelayUmin.Second;
      this.numericUpDown32.Value = (Decimal) this.CtrlProgramsOptions[this.ProgSelected].RV_DelayUnorm.Minute;
      this.numericUpDown31.Value = (Decimal) this.CtrlProgramsOptions[this.ProgSelected].RV_DelayUnorm.Second;
      this.numericUpDown34.Value = (Decimal) this.CtrlProgramsOptions[this.ProgSelected].RV_DelayUmax.Minute;
      this.numericUpDown33.Value = (Decimal) this.CtrlProgramsOptions[this.ProgSelected].RV_DelayUmax.Second;
    }

    private void ShowWin_SimpleOptions()
    {
      this.label4.Text = this.stInTreeP[this.LangGlobal] + this.ProgSelected.ToString() + ":  " + this.stSimpleRT[this.LangGlobal];
      this.numericUpDown28.Value = (Decimal) this.CtrlProgramsOptions[this.ProgSelected].RS_Delay.Minute;
      this.numericUpDown27.Value = (Decimal) this.CtrlProgramsOptions[this.ProgSelected].RS_Delay.Second;
      this.tabControl1.SelectedTab = this.tabPage12_SimpleRelay;
    }

    private void ShowWin_ImpulseOptions()
    {
      this.label4.Text = this.stInTreeP[this.LangGlobal] + this.ProgSelected.ToString() + ":  " + this.stPulseRT[this.LangGlobal];
      this.numericUpDown17.Value = (Decimal) this.CtrlProgramsOptions[this.ProgSelected].RI_BeforeDelay.Minute;
      this.numericUpDown18.Value = (Decimal) this.CtrlProgramsOptions[this.ProgSelected].RI_BeforeDelay.Second;
      this.numericUpDown20.Value = (Decimal) this.CtrlProgramsOptions[this.ProgSelected].RI_OnDelay.Minute;
      this.numericUpDown19.Value = (Decimal) this.CtrlProgramsOptions[this.ProgSelected].RI_OnDelay.Second;
      this.numericUpDown22.Value = (Decimal) this.CtrlProgramsOptions[this.ProgSelected].RI_OffDelay.Minute;
      this.numericUpDown21.Value = (Decimal) this.CtrlProgramsOptions[this.ProgSelected].RI_OffDelay.Second;
      this.tabControl1.SelectedTab = this.tabPage11_ImpulseRelay;
    }

    private void ShowWin_ListOfDayEvents()
    {
      this.label4.Text = this.stInTreeP[this.LangGlobal] + this.ProgSelected.ToString() + ":  " + this.stEventsDailyRT[this.LangGlobal];
      this.radioButton26.Checked = true;
      this.ReDrawListOfEventsDay();
      this.tabControl1.SelectedTab = this.tabPage10_Day;
    }

    private void ShowWin_ListOfWeekEvents()
    {
      this.label4.Text = this.stInTreeP[this.LangGlobal] + this.ProgSelected.ToString() + ":  " + this.stEventsWeeklyRT[this.LangGlobal];
      this.comboBox1.SelectedIndex = 0;
      this.radioButton24.Checked = true;
      this.ReDrawListOfEventsWeek();
      this.tabControl1.SelectedTab = this.tabPage9_Week;
    }

    private void ShowWin_ListOfMonthEvents()
    {
      this.label4.Text = this.stInTreeP[this.LangGlobal] + this.ProgSelected.ToString() + ":  " + this.stEventsMonthlyRT[this.LangGlobal];
      this.radioButton22.Checked = true;
      this.ReDrawListOfEventsMonth();
      this.tabControl1.SelectedTab = this.tabPage8_Month;
    }

    private void ShowWin_ListOfYearEvents()
    {
      this.label4.Text = this.stInTreeP[this.LangGlobal] + this.ProgSelected.ToString() + ":  " + this.stEventsYearlyRT[this.LangGlobal];
      this.radioButton20.Checked = true;
      this.ReDrawListOfEventsYear();
      this.tabControl1.SelectedTab = this.tabPage7_Year;
    }

    private void ShowWin_ListOfExcept()
    {
      this.label4.Text = this.stInTreeP[this.LangGlobal] + this.ProgSelected.ToString() + ":  " + this.stExceptionEventsRT[this.LangGlobal];
      this.radioButton17.Checked = true;
      this.ReDrawListOfEventsExceptions();
      this.tabControl1.SelectedTab = this.tabPage6_ExceptEvents;
    }

    private void ShowWin_WeekEnds()
    {
      this.label4.Text = this.stInTreeP[this.LangGlobal] + this.ProgSelected.ToString() + ":  " + this.stDaysOffRT[this.LangGlobal];
      int num1 = 1;
      CheckBox checkBox4 = this.checkBox4;
      bool[] exceptDaysOfWeek1 = this.CtrlProgramsOptions[this.ProgSelected].ExceptDaysOfWeek;
      int index1 = num1;
      int num2 = 1;
      int num3 = index1 + num2;
      int num4 = exceptDaysOfWeek1[index1] ? 1 : 0;
      checkBox4.Checked = num4 != 0;
      CheckBox checkBox5 = this.checkBox5;
      bool[] exceptDaysOfWeek2 = this.CtrlProgramsOptions[this.ProgSelected].ExceptDaysOfWeek;
      int index2 = num3;
      int num5 = 1;
      int num6 = index2 + num5;
      int num7 = exceptDaysOfWeek2[index2] ? 1 : 0;
      checkBox5.Checked = num7 != 0;
      CheckBox checkBox6 = this.checkBox6;
      bool[] exceptDaysOfWeek3 = this.CtrlProgramsOptions[this.ProgSelected].ExceptDaysOfWeek;
      int index3 = num6;
      int num8 = 1;
      int num9 = index3 + num8;
      int num10 = exceptDaysOfWeek3[index3] ? 1 : 0;
      checkBox6.Checked = num10 != 0;
      CheckBox checkBox7 = this.checkBox7;
      bool[] exceptDaysOfWeek4 = this.CtrlProgramsOptions[this.ProgSelected].ExceptDaysOfWeek;
      int index4 = num9;
      int num11 = 1;
      int num12 = index4 + num11;
      int num13 = exceptDaysOfWeek4[index4] ? 1 : 0;
      checkBox7.Checked = num13 != 0;
      CheckBox checkBox8 = this.checkBox8;
      bool[] exceptDaysOfWeek5 = this.CtrlProgramsOptions[this.ProgSelected].ExceptDaysOfWeek;
      int index5 = num12;
      int num14 = 1;
      int num15 = index5 + num14;
      int num16 = exceptDaysOfWeek5[index5] ? 1 : 0;
      checkBox8.Checked = num16 != 0;
      CheckBox checkBox9 = this.checkBox9;
      bool[] exceptDaysOfWeek6 = this.CtrlProgramsOptions[this.ProgSelected].ExceptDaysOfWeek;
      int index6 = num15;
      int num17 = 1;
      int num18 = index6 + num17;
      int num19 = exceptDaysOfWeek6[index6] ? 1 : 0;
      checkBox9.Checked = num19 != 0;
      CheckBox checkBox10 = this.checkBox10;
      bool[] exceptDaysOfWeek7 = this.CtrlProgramsOptions[this.ProgSelected].ExceptDaysOfWeek;
      int index7 = num18;
      int num20 = 1;
      int num21 = index7 + num20;
      int num22 = exceptDaysOfWeek7[index7] ? 1 : 0;
      checkBox10.Checked = num22 != 0;
      this.tabControl1.SelectedTab = this.tabPage4_DayOffs;
    }

    private void ShowWin_Holidays()
    {
      this.label4.Text = this.stInTreeP[this.LangGlobal] + this.ProgSelected.ToString() + ":  " + this.stHolidaysRT[this.LangGlobal];
      this.ReDrawListOfHolidays();
      this.tabControl1.SelectedTab = this.tabPage5_Holidays;
    }

    private void ShowWin_Exceptions()
    {
      this.label4.Text = this.stInTreeP[this.LangGlobal] + this.ProgSelected.ToString() + ":  " + this.stExceptionsRT[this.LangGlobal];
      this.tabControl1.SelectedTab = this.tabPage2_Except;
    }

    private void ShowWin_RT()
    {
      this.label4.Text = this.stInTreeP[this.LangGlobal] + this.ProgSelected.ToString() + ":  " + this.stRT[this.LangGlobal];
      this.tabControl1.SelectedTab = this.tabPage2_RTcom;
    }

    private void ShowWin_RTOptions()
    {
      this.label4.Text = this.stInTreeP[this.LangGlobal] + this.ProgSelected.ToString() + ":  " + this.stGeneralOptionsRT[this.LangGlobal];
      this.groupBox2.Text = this.stChooseModeRT[this.LangGlobal] + this.ProgSelected.ToString() + ":";
      switch (this.CtrlProgramsOptions[this.ProgSelected].RelayTimeMode)
      {
        case CtrlProgramOptionsClass.RelayTimeModeType.R_T_M_OFF:
          this.radioButton16.Checked = true;
          break;
        case CtrlProgramOptionsClass.RelayTimeModeType.R_T_M_YEAR:
          this.radioButton9.Checked = true;
          break;
        case CtrlProgramOptionsClass.RelayTimeModeType.R_T_M_MONTH:
          this.radioButton10.Checked = true;
          break;
        case CtrlProgramOptionsClass.RelayTimeModeType.R_T_M_WEEK:
          this.radioButton11.Checked = true;
          break;
        case CtrlProgramOptionsClass.RelayTimeModeType.R_T_M_DAY:
          this.radioButton12.Checked = true;
          break;
        case CtrlProgramOptionsClass.RelayTimeModeType.R_T_M_PULSE:
          this.radioButton13.Checked = true;
          break;
        case CtrlProgramOptionsClass.RelayTimeModeType.R_T_M_SIMPLE:
          this.radioButton14.Checked = true;
          break;
      }
      this.checkBox1.Checked = this.CtrlProgramsOptions[this.ProgSelected].AllowDaysoffs;
      this.checkBox2.Checked = this.CtrlProgramsOptions[this.ProgSelected].AllowHolidays;
      this.checkBox3.Checked = this.CtrlProgramsOptions[this.ProgSelected].AllowCyclicity;
      this.tabControl1.SelectedTab = this.tabPage2_RtOptions;
    }

    private void ShowWin_Channel()
    {
      this.label4.Text = this.stInTreeChannelN[this.LangGlobal] + this.ChannelSelected.ToString();
      this.groupBox1.Text = this.stChooseProgram[this.LangGlobal] + this.ChannelSelected.ToString() + ":";
      switch (this.DeviceOptions.Channel_CtrlProg[this.ChannelSelected])
      {
        case 0:
          this.radioButton15.Checked = true;
          break;
        case 1:
          this.radioButton1.Checked = true;
          break;
        case 2:
          this.radioButton2.Checked = true;
          break;
        case 3:
          this.radioButton3.Checked = true;
          break;
        case 4:
          this.radioButton4.Checked = true;
          break;
        case 5:
          this.radioButton5.Checked = true;
          break;
        case 6:
          this.radioButton6.Checked = true;
          break;
        case 7:
          this.radioButton7.Checked = true;
          break;
        case 8:
          this.radioButton8.Checked = true;
          break;
      }
      this.tabControl1.SelectedTab = this.tabPage1_ChannelMode;
    }

    private void UpdateAllFormElements()
    {
      this.numericUpDown42.Value = (Decimal) this.DeviceOptions.CommonDelay.Minute;
      this.numericUpDown41.Value = (Decimal) this.DeviceOptions.CommonDelay.Second;
      this.checkBox12.Checked = this.DeviceOptions.DST_OnOff;
      this.radioButton28.Checked = !this.CtrlProgramsOptions[this.ProgSelected].RF_OnOff;
      this.radioButton29.Checked = this.CtrlProgramsOptions[this.ProgSelected].RF_OnOff;
      this.numericUpDown23.Value = (Decimal) this.CtrlProgramsOptions[this.ProgSelected].RF_Lpor;
      this.numericUpDown24.Value = (Decimal) this.CtrlProgramsOptions[this.ProgSelected].RF_Lporhyst;
      this.numericUpDown40.Value = (Decimal) this.CtrlProgramsOptions[this.ProgSelected].RF_DelayLmin.Minute;
      this.numericUpDown39.Value = (Decimal) this.CtrlProgramsOptions[this.ProgSelected].RF_DelayLmin.Second;
      this.numericUpDown38.Value = (Decimal) this.CtrlProgramsOptions[this.ProgSelected].RF_DelayLmax.Minute;
      this.numericUpDown37.Value = (Decimal) this.CtrlProgramsOptions[this.ProgSelected].RF_DelayLmax.Second;
      switch (this.CtrlProgramsOptions[this.ProgSelected].RF_Condition_Lmin)
      {
        case 0:
          this.radioButton34.Checked = true;
          break;
        case 1:
          this.radioButton31.Checked = true;
          break;
        case 2:
          this.radioButton35.Checked = true;
          break;
        case 3:
          this.radioButton32.Checked = true;
          break;
        case 4:
          this.radioButton30.Checked = true;
          break;
      }
      switch (this.CtrlProgramsOptions[this.ProgSelected].RF_Condition_Lmax)
      {
        case 0:
          this.radioButton40.Checked = true;
          break;
        case 1:
          this.radioButton39.Checked = true;
          break;
        case 2:
          this.radioButton38.Checked = true;
          break;
        case 3:
          this.radioButton37.Checked = true;
          break;
        case 4:
          this.radioButton36.Checked = true;
          break;
      }
      this.radioButton27.Checked = !this.CtrlProgramsOptions[this.ProgSelected].RV_OnOff;
      this.radioButton33.Checked = this.CtrlProgramsOptions[this.ProgSelected].RV_OnOff;
      this.numericUpDown46.Value = (Decimal) this.CtrlProgramsOptions[this.ProgSelected].RV_Umin;
      this.numericUpDown45.Value = (Decimal) this.CtrlProgramsOptions[this.ProgSelected].RV_Uminhyst;
      this.numericUpDown26.Value = (Decimal) this.CtrlProgramsOptions[this.ProgSelected].RV_Umax;
      this.numericUpDown25.Value = (Decimal) this.CtrlProgramsOptions[this.ProgSelected].RV_Umaxhyst;
      this.numericUpDown30.Value = (Decimal) this.CtrlProgramsOptions[this.ProgSelected].RV_DelayUmin.Minute;
      this.numericUpDown29.Value = (Decimal) this.CtrlProgramsOptions[this.ProgSelected].RV_DelayUmin.Second;
      this.numericUpDown32.Value = (Decimal) this.CtrlProgramsOptions[this.ProgSelected].RV_DelayUnorm.Minute;
      this.numericUpDown31.Value = (Decimal) this.CtrlProgramsOptions[this.ProgSelected].RV_DelayUnorm.Second;
      this.numericUpDown34.Value = (Decimal) this.CtrlProgramsOptions[this.ProgSelected].RV_DelayUmax.Minute;
      this.numericUpDown33.Value = (Decimal) this.CtrlProgramsOptions[this.ProgSelected].RV_DelayUmax.Second;
      this.numericUpDown28.Value = (Decimal) this.CtrlProgramsOptions[this.ProgSelected].RS_Delay.Minute;
      this.numericUpDown27.Value = (Decimal) this.CtrlProgramsOptions[this.ProgSelected].RS_Delay.Second;
      this.numericUpDown17.Value = (Decimal) this.CtrlProgramsOptions[this.ProgSelected].RI_BeforeDelay.Minute;
      this.numericUpDown18.Value = (Decimal) this.CtrlProgramsOptions[this.ProgSelected].RI_BeforeDelay.Second;
      this.numericUpDown20.Value = (Decimal) this.CtrlProgramsOptions[this.ProgSelected].RI_OnDelay.Minute;
      this.numericUpDown19.Value = (Decimal) this.CtrlProgramsOptions[this.ProgSelected].RI_OnDelay.Second;
      this.numericUpDown22.Value = (Decimal) this.CtrlProgramsOptions[this.ProgSelected].RI_OffDelay.Minute;
      this.numericUpDown21.Value = (Decimal) this.CtrlProgramsOptions[this.ProgSelected].RI_OffDelay.Second;
      this.radioButton26.Checked = true;
      this.ReDrawListOfEventsDay();
      this.comboBox1.SelectedIndex = 0;
      this.radioButton24.Checked = true;
      this.ReDrawListOfEventsWeek();
      this.radioButton22.Checked = true;
      this.ReDrawListOfEventsMonth();
      this.radioButton20.Checked = true;
      this.ReDrawListOfEventsYear();
      this.radioButton17.Checked = true;
      this.ReDrawListOfEventsExceptions();
      this.ReDrawListOfHolidays();
      int num1 = 1;
      CheckBox checkBox4 = this.checkBox4;
      bool[] exceptDaysOfWeek1 = this.CtrlProgramsOptions[this.ProgSelected].ExceptDaysOfWeek;
      int index1 = num1;
      int num2 = 1;
      int num3 = index1 + num2;
      int num4 = exceptDaysOfWeek1[index1] ? 1 : 0;
      checkBox4.Checked = num4 != 0;
      CheckBox checkBox5 = this.checkBox5;
      bool[] exceptDaysOfWeek2 = this.CtrlProgramsOptions[this.ProgSelected].ExceptDaysOfWeek;
      int index2 = num3;
      int num5 = 1;
      int num6 = index2 + num5;
      int num7 = exceptDaysOfWeek2[index2] ? 1 : 0;
      checkBox5.Checked = num7 != 0;
      CheckBox checkBox6 = this.checkBox6;
      bool[] exceptDaysOfWeek3 = this.CtrlProgramsOptions[this.ProgSelected].ExceptDaysOfWeek;
      int index3 = num6;
      int num8 = 1;
      int num9 = index3 + num8;
      int num10 = exceptDaysOfWeek3[index3] ? 1 : 0;
      checkBox6.Checked = num10 != 0;
      CheckBox checkBox7 = this.checkBox7;
      bool[] exceptDaysOfWeek4 = this.CtrlProgramsOptions[this.ProgSelected].ExceptDaysOfWeek;
      int index4 = num9;
      int num11 = 1;
      int num12 = index4 + num11;
      int num13 = exceptDaysOfWeek4[index4] ? 1 : 0;
      checkBox7.Checked = num13 != 0;
      CheckBox checkBox8 = this.checkBox8;
      bool[] exceptDaysOfWeek5 = this.CtrlProgramsOptions[this.ProgSelected].ExceptDaysOfWeek;
      int index5 = num12;
      int num14 = 1;
      int num15 = index5 + num14;
      int num16 = exceptDaysOfWeek5[index5] ? 1 : 0;
      checkBox8.Checked = num16 != 0;
      CheckBox checkBox9 = this.checkBox9;
      bool[] exceptDaysOfWeek6 = this.CtrlProgramsOptions[this.ProgSelected].ExceptDaysOfWeek;
      int index6 = num15;
      int num17 = 1;
      int num18 = index6 + num17;
      int num19 = exceptDaysOfWeek6[index6] ? 1 : 0;
      checkBox9.Checked = num19 != 0;
      CheckBox checkBox10 = this.checkBox10;
      bool[] exceptDaysOfWeek7 = this.CtrlProgramsOptions[this.ProgSelected].ExceptDaysOfWeek;
      int index7 = num18;
      int num20 = 1;
      int num21 = index7 + num20;
      int num22 = exceptDaysOfWeek7[index7] ? 1 : 0;
      checkBox10.Checked = num22 != 0;
      this.groupBox2.Text = this.stChooseModeRT[this.LangGlobal] + this.ProgSelected.ToString() + ":";
      switch (this.CtrlProgramsOptions[this.ProgSelected].RelayTimeMode)
      {
        case CtrlProgramOptionsClass.RelayTimeModeType.R_T_M_OFF:
          this.radioButton16.Checked = true;
          break;
        case CtrlProgramOptionsClass.RelayTimeModeType.R_T_M_YEAR:
          this.radioButton9.Checked = true;
          break;
        case CtrlProgramOptionsClass.RelayTimeModeType.R_T_M_MONTH:
          this.radioButton10.Checked = true;
          break;
        case CtrlProgramOptionsClass.RelayTimeModeType.R_T_M_WEEK:
          this.radioButton11.Checked = true;
          break;
        case CtrlProgramOptionsClass.RelayTimeModeType.R_T_M_DAY:
          this.radioButton12.Checked = true;
          break;
        case CtrlProgramOptionsClass.RelayTimeModeType.R_T_M_PULSE:
          this.radioButton13.Checked = true;
          break;
        case CtrlProgramOptionsClass.RelayTimeModeType.R_T_M_SIMPLE:
          this.radioButton14.Checked = true;
          break;
      }
      this.checkBox1.Checked = this.CtrlProgramsOptions[this.ProgSelected].AllowDaysoffs;
      this.checkBox2.Checked = this.CtrlProgramsOptions[this.ProgSelected].AllowHolidays;
      this.checkBox3.Checked = this.CtrlProgramsOptions[this.ProgSelected].AllowCyclicity;
      this.groupBox1.Text = this.stChooseProgram[this.LangGlobal] + this.ChannelSelected.ToString() + ":";
      switch (this.DeviceOptions.Channel_CtrlProg[this.ChannelSelected])
      {
        case 0:
          this.radioButton15.Checked = true;
          break;
        case 1:
          this.radioButton1.Checked = true;
          break;
        case 2:
          this.radioButton2.Checked = true;
          break;
        case 3:
          this.radioButton3.Checked = true;
          break;
        case 4:
          this.radioButton4.Checked = true;
          break;
        case 5:
          this.radioButton5.Checked = true;
          break;
        case 6:
          this.radioButton6.Checked = true;
          break;
        case 7:
          this.radioButton7.Checked = true;
          break;
        case 8:
          this.radioButton8.Checked = true;
          break;
      }
      this.ReCalculateEventsInLists();
      this.ReDrawCorrespondenceProgAndChannel();
    }

    private void InVisibleAllPanels()
    {
    }

    private void radioButton15_Click(object sender, EventArgs e)
    {
      this.SetChannelMode((byte) 0);
    }

    private void radioButton1_Click(object sender, EventArgs e)
    {
      this.SetChannelMode((byte) 1);
    }

    private void radioButton2_Click(object sender, EventArgs e)
    {
      this.SetChannelMode((byte) 2);
    }

    private void radioButton3_Click(object sender, EventArgs e)
    {
      this.SetChannelMode((byte) 3);
    }

    private void radioButton4_Click(object sender, EventArgs e)
    {
      this.SetChannelMode((byte) 4);
    }

    private void radioButton5_Click(object sender, EventArgs e)
    {
      this.SetChannelMode((byte) 5);
    }

    private void radioButton6_Click(object sender, EventArgs e)
    {
      this.SetChannelMode((byte) 6);
    }

    private void radioButton7_Click(object sender, EventArgs e)
    {
      this.SetChannelMode((byte) 7);
    }

    private void radioButton8_Click(object sender, EventArgs e)
    {
      this.SetChannelMode((byte) 8);
    }

    private void SetChannelMode(byte SelProg)
    {
      if (this.ChannelSelected == 1)
        this.DeviceOptions.Channel_CtrlProg[1] = SelProg;
      else if (this.ChannelSelected == 2)
        this.DeviceOptions.Channel_CtrlProg[2] = SelProg;
      this.ReDrawCorrespondenceProgAndChannel();
    }

    private void radioButton16_Click(object sender, EventArgs e)
    {
      this.SetRTMode(CtrlProgramOptionsClass.RelayTimeModeType.R_T_M_OFF);
      this.ReCalculateEventsInLists(this.ProgSelected);
    }

    private void radioButton9_Click(object sender, EventArgs e)
    {
      this.SetRTMode(CtrlProgramOptionsClass.RelayTimeModeType.R_T_M_YEAR);
      this.ReCalculateEventsInLists(this.ProgSelected);
    }

    private void radioButton10_Click(object sender, EventArgs e)
    {
      this.SetRTMode(CtrlProgramOptionsClass.RelayTimeModeType.R_T_M_MONTH);
      this.ReCalculateEventsInLists(this.ProgSelected);
    }

    private void radioButton11_Click(object sender, EventArgs e)
    {
      this.SetRTMode(CtrlProgramOptionsClass.RelayTimeModeType.R_T_M_WEEK);
      this.ReCalculateEventsInLists(this.ProgSelected);
    }

    private void radioButton12_Click(object sender, EventArgs e)
    {
      this.SetRTMode(CtrlProgramOptionsClass.RelayTimeModeType.R_T_M_DAY);
      this.ReCalculateEventsInLists(this.ProgSelected);
    }

    private void radioButton13_Click(object sender, EventArgs e)
    {
      this.SetRTMode(CtrlProgramOptionsClass.RelayTimeModeType.R_T_M_PULSE);
      this.ReCalculateEventsInLists(this.ProgSelected);
    }

    private void radioButton14_Click(object sender, EventArgs e)
    {
      this.SetRTMode(CtrlProgramOptionsClass.RelayTimeModeType.R_T_M_SIMPLE);
      this.ReCalculateEventsInLists(this.ProgSelected);
    }

    private void SetRTMode(CtrlProgramOptionsClass.RelayTimeModeType Mode)
    {
      this.CtrlProgramsOptions[this.ProgSelected].RelayTimeMode = Mode;
      this.ReCalculateEventsInLists(this.ProgSelected);
    }

    private void checkBox1_Click(object sender, EventArgs e)
    {
      this.CtrlProgramsOptions[this.ProgSelected].AllowDaysoffs = this.checkBox1.Checked;
    }

    private void checkBox2_Click(object sender, EventArgs e)
    {
      this.CtrlProgramsOptions[this.ProgSelected].AllowHolidays = this.checkBox2.Checked;
    }

    private void checkBox3_Click(object sender, EventArgs e)
    {
      this.CtrlProgramsOptions[this.ProgSelected].AllowCyclicity = this.checkBox3.Checked;
    }

    private void checkBox4_Click(object sender, EventArgs e)
    {
      this.CtrlProgramsOptions[this.ProgSelected].ExceptDaysOfWeek[1] = this.checkBox4.Checked;
    }

    private void checkBox5_Click(object sender, EventArgs e)
    {
      this.CtrlProgramsOptions[this.ProgSelected].ExceptDaysOfWeek[2] = this.checkBox5.Checked;
    }

    private void checkBox6_Click(object sender, EventArgs e)
    {
      this.CtrlProgramsOptions[this.ProgSelected].ExceptDaysOfWeek[3] = this.checkBox6.Checked;
    }

    private void checkBox7_Click(object sender, EventArgs e)
    {
      this.CtrlProgramsOptions[this.ProgSelected].ExceptDaysOfWeek[4] = this.checkBox7.Checked;
    }

    private void checkBox8_Click(object sender, EventArgs e)
    {
      this.CtrlProgramsOptions[this.ProgSelected].ExceptDaysOfWeek[5] = this.checkBox8.Checked;
    }

    private void checkBox9_Click(object sender, EventArgs e)
    {
      this.CtrlProgramsOptions[this.ProgSelected].ExceptDaysOfWeek[6] = this.checkBox9.Checked;
    }

    private void checkBox10_Click(object sender, EventArgs e)
    {
      this.CtrlProgramsOptions[this.ProgSelected].ExceptDaysOfWeek[7] = this.checkBox10.Checked;
    }

    private void button2_Click(object sender, EventArgs e)
    {
      this.SaveDataForBack();
      this.CtrlProgramsOptions[this.ProgSelected].ListHolidays.AddSmart(new TimerClass(new DateTime(1996, this.monthCalendar1.SelectionStart.Month, this.monthCalendar1.SelectionStart.Day), false), 0);
      this.ReDrawListOfHolidays();
    }

    private void ReDrawListOfHolidays()
    {
      this.listView1.Items.Clear();
      int index = 0;
      foreach (TimerClass listHoliday in (CollectionBase) this.CtrlProgramsOptions[this.ProgSelected].ListHolidays)
      {
        this.listView1.Items.Add(string.Format("{0}", (object) (index + 1)));
        this.listView1.Items[index].SubItems.Add(listHoliday.DateAndTime.Day.ToString());
        this.listView1.Items[index].SubItems.Add(listHoliday.DateAndTime.ToString("MMMM"));
        ++index;
      }
      this.ReCalculateEventsInLists(this.ProgSelected);
    }

    private void ReDrawListOfEventsExceptions()
    {
      this.listView2.Items.Clear();
      int index = 0;
      foreach (TimerClass timerClass in (CollectionBase) this.CtrlProgramsOptions[this.ProgSelected].ListEventsException)
      {
        this.listView2.Items.Add(string.Format("{0}", (object) (index + 1)));
        this.listView2.Items[index].SubItems.Add(timerClass.DateAndTime.ToString("HH:mm:ss"));
        if (timerClass.Condition)
          this.listView2.Items[index].SubItems.Add(this.stClose[this.LangGlobal]);
        else
          this.listView2.Items[index].SubItems.Add(this.stOpen[this.LangGlobal]);
        ++index;
      }
      this.ReCalculateEventsInLists(this.ProgSelected);
    }

    private void ReDrawListOfEventsYear()
    {
      this.listView3.Items.Clear();
      int index = 0;
      foreach (TimerClass timerClass in (CollectionBase) this.CtrlProgramsOptions[this.ProgSelected].ListEventsYear)
      {
        this.listView3.Items.Add(string.Format("{0}", (object) (index + 1)));
        this.listView3.Items[index].SubItems.Add(timerClass.DateAndTime.Day.ToString());
        this.listView3.Items[index].SubItems.Add(timerClass.DateAndTime.ToString("MMMM"));
        this.listView3.Items[index].SubItems.Add(timerClass.DateAndTime.ToString("HH:mm:ss"));
        if (timerClass.Condition)
          this.listView3.Items[index].SubItems.Add(this.stClose[this.LangGlobal]);
        else
          this.listView3.Items[index].SubItems.Add(this.stOpen[this.LangGlobal]);
        ++index;
      }
      this.ReCalculateEventsInLists(this.ProgSelected);
    }

    private void ReDrawListOfEventsMonth()
    {
      this.listView4.Items.Clear();
      int index = 0;
      foreach (TimerClass timerClass in (CollectionBase) this.CtrlProgramsOptions[this.ProgSelected].ListEventsMonth)
      {
        this.listView4.Items.Add(string.Format("{0}", (object) (index + 1)));
        this.listView4.Items[index].SubItems.Add(timerClass.DateAndTime.Day.ToString());
        this.listView4.Items[index].SubItems.Add(timerClass.DateAndTime.ToString("HH:mm:ss"));
        if (timerClass.Condition)
          this.listView4.Items[index].SubItems.Add(this.stClose[this.LangGlobal]);
        else
          this.listView4.Items[index].SubItems.Add(this.stOpen[this.LangGlobal]);
        ++index;
      }
      this.ReCalculateEventsInLists(this.ProgSelected);
    }

    private void ReDrawListOfEventsWeek()
    {
      this.listView5.Items.Clear();
      int index = 0;
      foreach (TimerClass timerClass in (CollectionBase) this.CtrlProgramsOptions[this.ProgSelected].ListEventsWeek)
      {
        this.listView5.Items.Add(string.Format("{0}", (object) (index + 1)));
        this.listView5.Items[index].SubItems.Add(this.StDaysOfWeek[timerClass.DateAndTime.Day - 1]);
        this.listView5.Items[index].SubItems.Add(timerClass.DateAndTime.ToString("HH:mm:ss"));
        if (timerClass.Condition)
          this.listView5.Items[index].SubItems.Add(this.stClose[this.LangGlobal]);
        else
          this.listView5.Items[index].SubItems.Add(this.stOpen[this.LangGlobal]);
        ++index;
      }
      this.ReCalculateEventsInLists(this.ProgSelected);
    }

    private void ReDrawListOfEventsDay()
    {
      this.listView6.Items.Clear();
      int index = 0;
      foreach (TimerClass timerClass in (CollectionBase) this.CtrlProgramsOptions[this.ProgSelected].ListEventsDay)
      {
        this.listView6.Items.Add(string.Format("{0}", (object) (index + 1)));
        this.listView6.Items[index].SubItems.Add(timerClass.DateAndTime.ToString("HH:mm:ss"));
        if (timerClass.Condition)
          this.listView6.Items[index].SubItems.Add(this.stClose[this.LangGlobal]);
        else
          this.listView6.Items[index].SubItems.Add(this.stOpen[this.LangGlobal]);
        ++index;
      }
      this.ReCalculateEventsInLists(this.ProgSelected);
    }

    private void button4_Click(object sender, EventArgs e)
    {
      this.SaveDataForBack();
      this.CtrlProgramsOptions[this.ProgSelected].ListHolidays.Clear();
      this.ReDrawListOfHolidays();
    }

    private void button3_Click(object sender, EventArgs e)
    {
      this.SaveDataForBack();
      ListView.SelectedIndexCollection selectedIndices = this.listView1.SelectedIndices;
      int num1 = 0;
      foreach (int num2 in selectedIndices)
      {
        this.CtrlProgramsOptions[this.ProgSelected].ListHolidays.RemoveAt(num2 - num1);
        ++num1;
      }
      this.ReDrawListOfHolidays();
    }

    private void button7_Click(object sender, EventArgs e)
    {
      this.SaveDataForBack();
      this.CtrlProgramsOptions[this.ProgSelected].ListEventsException.AddSmart(new TimerClass(new DateTime(1996, 1, 1, (int) this.numericUpDown1.Value, (int) this.numericUpDown2.Value, (int) this.numericUpDown3.Value), this.radioButton18.Checked), 1);
      this.ReDrawListOfEventsExceptions();
    }

    private void button5_Click(object sender, EventArgs e)
    {
      this.SaveDataForBack();
      this.CtrlProgramsOptions[this.ProgSelected].ListEventsException.Clear();
      this.ReDrawListOfEventsExceptions();
    }

    private void button6_Click(object sender, EventArgs e)
    {
      this.SaveDataForBack();
      ListView.SelectedIndexCollection selectedIndices = this.listView2.SelectedIndices;
      int num1 = 0;
      foreach (int num2 in selectedIndices)
      {
        this.CtrlProgramsOptions[this.ProgSelected].ListEventsException.RemoveAt(num2 - num1);
        ++num1;
      }
      this.ReDrawListOfEventsExceptions();
    }

    private void button10_Click(object sender, EventArgs e)
    {
      this.SaveDataForBack();
      this.CtrlProgramsOptions[this.ProgSelected].ListEventsYear.AddSmart(new TimerClass(new DateTime(1996, this.monthCalendar2.SelectionStart.Month, this.monthCalendar2.SelectionStart.Day, (int) this.numericUpDown6.Value, (int) this.numericUpDown5.Value, (int) this.numericUpDown4.Value), this.radioButton19.Checked), 2);
      this.ReDrawListOfEventsYear();
    }

    private void button8_Click(object sender, EventArgs e)
    {
      this.SaveDataForBack();
      this.CtrlProgramsOptions[this.ProgSelected].ListEventsYear.Clear();
      this.ReDrawListOfEventsYear();
    }

    private void button9_Click(object sender, EventArgs e)
    {
      this.SaveDataForBack();
      ListView.SelectedIndexCollection selectedIndices = this.listView3.SelectedIndices;
      int num1 = 0;
      foreach (int num2 in selectedIndices)
      {
        this.CtrlProgramsOptions[this.ProgSelected].ListEventsYear.RemoveAt(num2 - num1);
        ++num1;
      }
      this.ReDrawListOfEventsYear();
    }

    private void button11_Click(object sender, EventArgs e)
    {
      this.SaveDataForBack();
      this.CtrlProgramsOptions[this.ProgSelected].ListEventsMonth.Clear();
      this.ReDrawListOfEventsMonth();
    }

    private void button14_Click(object sender, EventArgs e)
    {
      this.SaveDataForBack();
      this.CtrlProgramsOptions[this.ProgSelected].ListEventsWeek.Clear();
      this.ReDrawListOfEventsWeek();
    }

    private void button17_Click(object sender, EventArgs e)
    {
      this.SaveDataForBack();
      this.CtrlProgramsOptions[this.ProgSelected].ListEventsDay.Clear();
      this.ReDrawListOfEventsDay();
    }

    private void button12_Click(object sender, EventArgs e)
    {
      this.SaveDataForBack();
      ListView.SelectedIndexCollection selectedIndices = this.listView4.SelectedIndices;
      int num1 = 0;
      foreach (int num2 in selectedIndices)
      {
        this.CtrlProgramsOptions[this.ProgSelected].ListEventsMonth.RemoveAt(num2 - num1);
        ++num1;
      }
      this.ReDrawListOfEventsMonth();
    }

    private void button15_Click(object sender, EventArgs e)
    {
      this.SaveDataForBack();
      ListView.SelectedIndexCollection selectedIndices = this.listView5.SelectedIndices;
      int num1 = 0;
      foreach (int num2 in selectedIndices)
      {
        this.CtrlProgramsOptions[this.ProgSelected].ListEventsWeek.RemoveAt(num2 - num1);
        ++num1;
      }
      this.ReDrawListOfEventsWeek();
    }

    private void button18_Click(object sender, EventArgs e)
    {
      this.SaveDataForBack();
      ListView.SelectedIndexCollection selectedIndices = this.listView6.SelectedIndices;
      int num1 = 0;
      foreach (int num2 in selectedIndices)
      {
        this.CtrlProgramsOptions[this.ProgSelected].ListEventsDay.RemoveAt(num2 - num1);
        ++num1;
      }
      this.ReDrawListOfEventsDay();
    }

    private void button13_Click(object sender, EventArgs e)
    {
      this.SaveDataForBack();
      this.CtrlProgramsOptions[this.ProgSelected].ListEventsMonth.AddSmart(new TimerClass(new DateTime(1996, 1, (int) this.numericUpDown16.Value, (int) this.numericUpDown9.Value, (int) this.numericUpDown8.Value, (int) this.numericUpDown7.Value), this.radioButton21.Checked), 3);
      this.ReDrawListOfEventsMonth();
    }

    private void button16_Click(object sender, EventArgs e)
    {
      this.SaveDataForBack();
      this.CtrlProgramsOptions[this.ProgSelected].ListEventsWeek.AddSmart(new TimerClass(new DateTime(1996, 1, this.comboBox1.SelectedIndex + 1, (int) this.numericUpDown14.Value, (int) this.numericUpDown13.Value, (int) this.numericUpDown12.Value), this.radioButton23.Checked), 4);
      this.ReDrawListOfEventsWeek();
    }

    private void button19_Click(object sender, EventArgs e)
    {
      this.SaveDataForBack();
      this.CtrlProgramsOptions[this.ProgSelected].ListEventsDay.AddSmart(new TimerClass(new DateTime(1996, 1, 1, (int) this.numericUpDown15.Value, (int) this.numericUpDown11.Value, (int) this.numericUpDown10.Value), this.radioButton25.Checked), 5);
      this.ReDrawListOfEventsDay();
    }

    private void numericUpDown17_ValueChanged(object sender, EventArgs e)
    {
      this.CtrlProgramsOptions[this.ProgSelected].RI_BeforeDelay.Minute = (int) this.numericUpDown17.Value;
    }

    private void numericUpDown18_ValueChanged(object sender, EventArgs e)
    {
      this.CtrlProgramsOptions[this.ProgSelected].RI_BeforeDelay.Second = (int) this.numericUpDown18.Value;
    }

    private void numericUpDown20_ValueChanged(object sender, EventArgs e)
    {
      this.CtrlProgramsOptions[this.ProgSelected].RI_OnDelay.Minute = (int) this.numericUpDown20.Value;
    }

    private void numericUpDown19_ValueChanged(object sender, EventArgs e)
    {
      this.CtrlProgramsOptions[this.ProgSelected].RI_OnDelay.Second = (int) this.numericUpDown19.Value;
    }

    private void numericUpDown22_ValueChanged(object sender, EventArgs e)
    {
      this.CtrlProgramsOptions[this.ProgSelected].RI_OffDelay.Minute = (int) this.numericUpDown22.Value;
    }

    private void numericUpDown21_ValueChanged(object sender, EventArgs e)
    {
      this.CtrlProgramsOptions[this.ProgSelected].RI_OffDelay.Second = (int) this.numericUpDown21.Value;
    }

    private void numericUpDown28_ValueChanged(object sender, EventArgs e)
    {
      this.CtrlProgramsOptions[this.ProgSelected].RS_Delay.Minute = (int) this.numericUpDown28.Value;
    }

    private void numericUpDown27_ValueChanged(object sender, EventArgs e)
    {
      this.CtrlProgramsOptions[this.ProgSelected].RS_Delay.Second = (int) this.numericUpDown27.Value;
    }

    private void radioButton27_CheckedChanged(object sender, EventArgs e)
    {
      this.CtrlProgramsOptions[this.ProgSelected].RV_OnOff = !this.radioButton27.Checked;
      this.ReCalculateEventsInLists(this.ProgSelected);
    }

    private void radioButton33_CheckedChanged(object sender, EventArgs e)
    {
      this.CtrlProgramsOptions[this.ProgSelected].RV_OnOff = this.radioButton33.Checked;
      this.ReCalculateEventsInLists(this.ProgSelected);
    }

    private void numericUpDown46_ValueChanged(object sender, EventArgs e)
    {
      if ((int) this.numericUpDown46.Value + this.CtrlProgramsOptions[this.ProgSelected].RV_Uminhyst < this.CtrlProgramsOptions[this.ProgSelected].RV_Umax - this.CtrlProgramsOptions[this.ProgSelected].RV_Umaxhyst)
        this.CtrlProgramsOptions[this.ProgSelected].RV_Umin = (int) this.numericUpDown46.Value;
      else
        this.numericUpDown46.Value--;
    }

    private void numericUpDown45_ValueChanged(object sender, EventArgs e)
    {
      if ((int) this.numericUpDown45.Value + this.CtrlProgramsOptions[this.ProgSelected].RV_Umin < this.CtrlProgramsOptions[this.ProgSelected].RV_Umax - this.CtrlProgramsOptions[this.ProgSelected].RV_Umaxhyst)
        this.CtrlProgramsOptions[this.ProgSelected].RV_Uminhyst = (int) this.numericUpDown45.Value;
      else
        this.numericUpDown45.Value--;
    }

    private void numericUpDown30_ValueChanged(object sender, EventArgs e)
    {
      this.CtrlProgramsOptions[this.ProgSelected].RV_DelayUmin.Minute = (int) this.numericUpDown30.Value;
    }

    private void numericUpDown29_ValueChanged(object sender, EventArgs e)
    {
      this.CtrlProgramsOptions[this.ProgSelected].RV_DelayUmin.Second = (int) this.numericUpDown29.Value;
    }

    private void numericUpDown32_ValueChanged(object sender, EventArgs e)
    {
      this.CtrlProgramsOptions[this.ProgSelected].RV_DelayUnorm.Minute = (int) this.numericUpDown32.Value;
    }

    private void numericUpDown31_ValueChanged(object sender, EventArgs e)
    {
      this.CtrlProgramsOptions[this.ProgSelected].RV_DelayUnorm.Second = (int) this.numericUpDown31.Value;
    }

    private void numericUpDown34_ValueChanged(object sender, EventArgs e)
    {
      this.CtrlProgramsOptions[this.ProgSelected].RV_DelayUmax.Minute = (int) this.numericUpDown34.Value;
    }

    private void numericUpDown33_ValueChanged(object sender, EventArgs e)
    {
      this.CtrlProgramsOptions[this.ProgSelected].RV_DelayUmax.Second = (int) this.numericUpDown33.Value;
    }

    private void numericUpDown26_ValueChanged(object sender, EventArgs e)
    {
      if (this.CtrlProgramsOptions[this.ProgSelected].RV_Umin + this.CtrlProgramsOptions[this.ProgSelected].RV_Uminhyst < (int) this.numericUpDown26.Value - this.CtrlProgramsOptions[this.ProgSelected].RV_Umaxhyst)
        this.CtrlProgramsOptions[this.ProgSelected].RV_Umax = (int) this.numericUpDown26.Value;
      else
        this.numericUpDown26.Value++;
    }

    private void numericUpDown25_ValueChanged(object sender, EventArgs e)
    {
      if (this.CtrlProgramsOptions[this.ProgSelected].RV_Umin + this.CtrlProgramsOptions[this.ProgSelected].RV_Uminhyst < this.CtrlProgramsOptions[this.ProgSelected].RV_Umax - (int) this.numericUpDown25.Value)
        this.CtrlProgramsOptions[this.ProgSelected].RV_Umaxhyst = (int) this.numericUpDown25.Value;
      else
        this.numericUpDown25.Value++;
    }

    private void radioButton28_CheckedChanged(object sender, EventArgs e)
    {
      this.CtrlProgramsOptions[this.ProgSelected].RF_OnOff = !this.radioButton28.Checked;
      this.ReCalculateEventsInLists(this.ProgSelected);
    }

    private void radioButton29_CheckedChanged(object sender, EventArgs e)
    {
      this.CtrlProgramsOptions[this.ProgSelected].RF_OnOff = this.radioButton29.Checked;
      this.ReCalculateEventsInLists(this.ProgSelected);
    }

    private void numericUpDown23_ValueChanged(object sender, EventArgs e)
    {
      this.CtrlProgramsOptions[this.ProgSelected].RF_Lpor = (int) this.numericUpDown23.Value;
    }

    private void numericUpDown24_ValueChanged(object sender, EventArgs e)
    {
      this.CtrlProgramsOptions[this.ProgSelected].RF_Lporhyst = (int) this.numericUpDown24.Value;
    }

    private void numericUpDown40_ValueChanged(object sender, EventArgs e)
    {
      this.CtrlProgramsOptions[this.ProgSelected].RF_DelayLmin.Minute = (int) this.numericUpDown40.Value;
    }

    private void numericUpDown39_ValueChanged(object sender, EventArgs e)
    {
      this.CtrlProgramsOptions[this.ProgSelected].RF_DelayLmin.Second = (int) this.numericUpDown39.Value;
    }

    private void numericUpDown38_ValueChanged(object sender, EventArgs e)
    {
      this.CtrlProgramsOptions[this.ProgSelected].RF_DelayLmax.Minute = (int) this.numericUpDown38.Value;
    }

    private void numericUpDown37_ValueChanged(object sender, EventArgs e)
    {
      this.CtrlProgramsOptions[this.ProgSelected].RF_DelayLmax.Second = (int) this.numericUpDown37.Value;
    }

    private void radioButton34_CheckedChanged(object sender, EventArgs e)
    {
      this.CtrlProgramsOptions[this.ProgSelected].RF_Condition_Lmin = 0;
    }

    private void radioButton31_CheckedChanged(object sender, EventArgs e)
    {
      this.CtrlProgramsOptions[this.ProgSelected].RF_Condition_Lmin = 1;
    }

    private void radioButton35_CheckedChanged(object sender, EventArgs e)
    {
      this.CtrlProgramsOptions[this.ProgSelected].RF_Condition_Lmin = 2;
    }

    private void radioButton32_CheckedChanged(object sender, EventArgs e)
    {
      this.CtrlProgramsOptions[this.ProgSelected].RF_Condition_Lmin = 3;
    }

    private void radioButton30_CheckedChanged(object sender, EventArgs e)
    {
      this.CtrlProgramsOptions[this.ProgSelected].RF_Condition_Lmin = 4;
    }

    private void radioButton40_CheckedChanged(object sender, EventArgs e)
    {
      this.CtrlProgramsOptions[this.ProgSelected].RF_Condition_Lmax = 0;
    }

    private void radioButton39_CheckedChanged(object sender, EventArgs e)
    {
      this.CtrlProgramsOptions[this.ProgSelected].RF_Condition_Lmax = 1;
    }

    private void radioButton38_CheckedChanged(object sender, EventArgs e)
    {
      this.CtrlProgramsOptions[this.ProgSelected].RF_Condition_Lmax = 2;
    }

    private void radioButton37_CheckedChanged(object sender, EventArgs e)
    {
      this.CtrlProgramsOptions[this.ProgSelected].RF_Condition_Lmax = 3;
    }

    private void radioButton36_CheckedChanged(object sender, EventArgs e)
    {
      this.CtrlProgramsOptions[this.ProgSelected].RF_Condition_Lmax = 4;
    }

    private void numericUpDown42_ValueChanged(object sender, EventArgs e)
    {
      this.DeviceOptions.CommonDelay.Minute = (int) this.numericUpDown42.Value;
    }

    private void numericUpDown41_ValueChanged(object sender, EventArgs e)
    {
      this.DeviceOptions.CommonDelay.Second = (int) this.numericUpDown41.Value;
    }

    private void checkBox12_CheckedChanged(object sender, EventArgs e)
    {
      this.DeviceOptions.DST_OnOff = this.checkBox12.Checked;
    }

    private void выходToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Application.Exit();
    }

    private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.SaveNewFile();
    }

    private void SaveNewFile()
    {
      if (this.saveFileDialog1.ShowDialog() != DialogResult.OK)
        return;
      this.PathOfFile = this.saveFileDialog1.FileName;
      char ch1 = '\\';
      char ch2 = '.';
      this.Text = this.stNovatek[this.LangGlobal] + ": " + this.PathOfFile.Split(ch1)[this.PathOfFile.Split(ch1).Length - 1].Split(ch2)[0];
      this.SaveFile();
    }

    private void SaveFile()
    {
      try
      {
        if (this.PathOfFile.Split('.')[this.PathOfFile.Split('.').Length - 1].Equals("tmj"))
        {
          this.SaveFileJSON();
        }
        else
        {
          DataInFileClass2 dataInFileClass2 = new DataInFileClass2();
          dataInFileClass2.DeviceOptions = this.DeviceOptions;
          dataInFileClass2.CtrlProgramsOptions = this.CtrlProgramsOptions;
          IFormatter formatter = (IFormatter) new BinaryFormatter();
          FileStream fileStream = new FileStream(this.PathOfFile, FileMode.Create, FileAccess.Write);
          formatter.Serialize((Stream) fileStream, (object) dataInFileClass2);
          fileStream.Close();
        }
      }
      catch
      {
        int num = (int) MessageBox.Show(this.stNoAccessToDisk[this.LangGlobal], this.stAttention[this.LangGlobal], MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
    }

    private void SaveFileJSON()
    {
      TimerClass[] timerClassArray = new TimerClass[6];
      using (FileStream fileStream = File.Open(this.PathOfFile, FileMode.Create, FileAccess.Write))
      {
        using (StreamWriter streamWriter = new StreamWriter((Stream) fileStream))
        {
          using (JsonWriter jsonWriter = (JsonWriter) new JsonTextWriter((TextWriter) streamWriter))
          {
            jsonWriter.Formatting = Formatting.Indented;
            jsonWriter.WriteStartObject();
            jsonWriter.WritePropertyName("format");
            jsonWriter.WriteValue(1);
            jsonWriter.WritePropertyName("channel1");
            jsonWriter.WriteValue(this.DeviceOptions.Channel_CtrlProg[1]);
            jsonWriter.WritePropertyName("channel2");
            jsonWriter.WriteValue(this.DeviceOptions.Channel_CtrlProg[2]);
            jsonWriter.WritePropertyName("dstonoff");
            if (this.DeviceOptions.DST_OnOff)
              jsonWriter.WriteValue(1);
            else
              jsonWriter.WriteValue(0);
            jsonWriter.WritePropertyName("delaystart");
            jsonWriter.WriteStartArray();
            jsonWriter.WriteValue(this.DeviceOptions.CommonDelay.Minute);
            jsonWriter.WriteValue(this.DeviceOptions.CommonDelay.Second);
            jsonWriter.WriteEndArray();
            for (int index1 = 1; index1 <= 8; ++index1)
            {
              jsonWriter.WritePropertyName("program");
              jsonWriter.WriteStartObject();
              jsonWriter.WritePropertyName("number");
              jsonWriter.WriteValue(index1);
              jsonWriter.WritePropertyName("timermode");
              jsonWriter.WriteValue((object) this.CtrlProgramsOptions[index1].RelayTimeMode);
              jsonWriter.WritePropertyName("excweekdays");
              jsonWriter.WriteStartArray();
              for (int index2 = 1; index2 <= 7; ++index2)
              {
                if (this.CtrlProgramsOptions[index1].ExceptDaysOfWeek[index2])
                  jsonWriter.WriteValue(1);
                else
                  jsonWriter.WriteValue(0);
              }
              jsonWriter.WriteEndArray();
              jsonWriter.WritePropertyName("allowdayoffs");
              if (this.CtrlProgramsOptions[index1].AllowDaysoffs)
                jsonWriter.WriteValue(1);
              else
                jsonWriter.WriteValue(0);
              jsonWriter.WritePropertyName("allowholidays");
              if (this.CtrlProgramsOptions[index1].AllowHolidays)
                jsonWriter.WriteValue(1);
              else
                jsonWriter.WriteValue(0);
              jsonWriter.WritePropertyName("allowciclicity");
              if (this.CtrlProgramsOptions[index1].AllowCyclicity)
                jsonWriter.WriteValue(1);
              else
                jsonWriter.WriteValue(0);
              jsonWriter.WritePropertyName("ribeforedelay");
              jsonWriter.WriteStartArray();
              jsonWriter.WriteValue(this.CtrlProgramsOptions[index1].RI_BeforeDelay.Minute);
              jsonWriter.WriteValue(this.CtrlProgramsOptions[index1].RI_BeforeDelay.Second);
              jsonWriter.WriteEndArray();
              jsonWriter.WritePropertyName("riondelay");
              jsonWriter.WriteStartArray();
              jsonWriter.WriteValue(this.CtrlProgramsOptions[index1].RI_OnDelay.Minute);
              jsonWriter.WriteValue(this.CtrlProgramsOptions[index1].RI_OnDelay.Second);
              jsonWriter.WriteEndArray();
              jsonWriter.WritePropertyName("rioffdelay");
              jsonWriter.WriteStartArray();
              jsonWriter.WriteValue(this.CtrlProgramsOptions[index1].RI_OffDelay.Minute);
              jsonWriter.WriteValue(this.CtrlProgramsOptions[index1].RI_OffDelay.Second);
              jsonWriter.WriteEndArray();
              jsonWriter.WritePropertyName("rsdelay");
              jsonWriter.WriteStartArray();
              jsonWriter.WriteValue(this.CtrlProgramsOptions[index1].RS_Delay.Minute);
              jsonWriter.WriteValue(this.CtrlProgramsOptions[index1].RS_Delay.Second);
              jsonWriter.WriteEndArray();
              jsonWriter.WritePropertyName("rvdelayumin");
              jsonWriter.WriteStartArray();
              jsonWriter.WriteValue(this.CtrlProgramsOptions[index1].RV_DelayUmin.Minute);
              jsonWriter.WriteValue(this.CtrlProgramsOptions[index1].RV_DelayUmin.Second);
              jsonWriter.WriteEndArray();
              jsonWriter.WritePropertyName("rvdelayunorm");
              jsonWriter.WriteStartArray();
              jsonWriter.WriteValue(this.CtrlProgramsOptions[index1].RV_DelayUnorm.Minute);
              jsonWriter.WriteValue(this.CtrlProgramsOptions[index1].RV_DelayUnorm.Second);
              jsonWriter.WriteEndArray();
              jsonWriter.WritePropertyName("rvdelayumax");
              jsonWriter.WriteStartArray();
              jsonWriter.WriteValue(this.CtrlProgramsOptions[index1].RV_DelayUmax.Minute);
              jsonWriter.WriteValue(this.CtrlProgramsOptions[index1].RV_DelayUmax.Second);
              jsonWriter.WriteEndArray();
              jsonWriter.WritePropertyName("rfdelaylmin");
              jsonWriter.WriteStartArray();
              jsonWriter.WriteValue(this.CtrlProgramsOptions[index1].RF_DelayLmin.Minute);
              jsonWriter.WriteValue(this.CtrlProgramsOptions[index1].RF_DelayLmin.Second);
              jsonWriter.WriteEndArray();
              jsonWriter.WritePropertyName("rfdelaylmax");
              jsonWriter.WriteStartArray();
              jsonWriter.WriteValue(this.CtrlProgramsOptions[index1].RF_DelayLmax.Minute);
              jsonWriter.WriteValue(this.CtrlProgramsOptions[index1].RF_DelayLmax.Second);
              jsonWriter.WriteEndArray();
              jsonWriter.WritePropertyName("rvonoff");
              if (this.CtrlProgramsOptions[index1].RV_OnOff)
                jsonWriter.WriteValue(1);
              else
                jsonWriter.WriteValue(0);
              jsonWriter.WritePropertyName("rvumin");
              jsonWriter.WriteValue(this.CtrlProgramsOptions[index1].RV_Umin);
              jsonWriter.WritePropertyName("rvumax");
              jsonWriter.WriteValue(this.CtrlProgramsOptions[index1].RV_Umax);
              jsonWriter.WritePropertyName("rvuminhyst");
              jsonWriter.WriteValue(this.CtrlProgramsOptions[index1].RV_Uminhyst);
              jsonWriter.WritePropertyName("rvumaxhyst");
              jsonWriter.WriteValue(this.CtrlProgramsOptions[index1].RV_Umaxhyst);
              jsonWriter.WritePropertyName("rfonoff");
              if (this.CtrlProgramsOptions[index1].RF_OnOff)
                jsonWriter.WriteValue(1);
              else
                jsonWriter.WriteValue(0);
              jsonWriter.WritePropertyName("rflpor");
              jsonWriter.WriteValue(this.CtrlProgramsOptions[index1].RF_Lpor);
              jsonWriter.WritePropertyName("rflporhyst");
              jsonWriter.WriteValue(this.CtrlProgramsOptions[index1].RF_Lporhyst);
              jsonWriter.WritePropertyName("rfcontlmin");
              jsonWriter.WriteValue(this.CtrlProgramsOptions[index1].RF_Condition_Lmin);
              jsonWriter.WritePropertyName("rfcontlmax");
              jsonWriter.WriteValue(this.CtrlProgramsOptions[index1].RF_Condition_Lmax);
              timerClassArray[0] = this.CtrlProgramsOptions[index1].ListHolidays;
              timerClassArray[1] = this.CtrlProgramsOptions[index1].ListEventsException;
              timerClassArray[2] = this.CtrlProgramsOptions[index1].ListEventsYear;
              timerClassArray[3] = this.CtrlProgramsOptions[index1].ListEventsMonth;
              timerClassArray[4] = this.CtrlProgramsOptions[index1].ListEventsWeek;
              timerClassArray[5] = this.CtrlProgramsOptions[index1].ListEventsDay;
              for (int index2 = 0; index2 < 6; ++index2)
              {
                jsonWriter.WritePropertyName("lists");
                jsonWriter.WriteStartObject();
                jsonWriter.WritePropertyName("listnum");
                jsonWriter.WriteValue(index2);
                int count = timerClassArray[index2].Count;
                jsonWriter.WritePropertyName("eventsmax");
                jsonWriter.WriteValue(count);
                for (int index3 = 0; index3 < count; ++index3)
                {
                  jsonWriter.WritePropertyName("event");
                  jsonWriter.WriteStartObject();
                  jsonWriter.WritePropertyName("eventnum");
                  jsonWriter.WriteValue(index3);
                  jsonWriter.WritePropertyName("sec");
                  jsonWriter.WriteValue(timerClassArray[index2][index3].DateAndTime.Second);
                  jsonWriter.WritePropertyName("min");
                  jsonWriter.WriteValue(timerClassArray[index2][index3].DateAndTime.Minute);
                  jsonWriter.WritePropertyName("hour");
                  jsonWriter.WriteValue(timerClassArray[index2][index3].DateAndTime.Hour);
                  jsonWriter.WritePropertyName("weekday");
                  jsonWriter.WriteValue(timerClassArray[index2][index3].DateAndTime.Day - 1);
                  jsonWriter.WritePropertyName("monthday");
                  jsonWriter.WriteValue(timerClassArray[index2][index3].DateAndTime.Day);
                  jsonWriter.WritePropertyName("month");
                  jsonWriter.WriteValue(timerClassArray[index2][index3].DateAndTime.Month);
                  jsonWriter.WritePropertyName("condition");
                  if (timerClassArray[index2][index3].Condition)
                    jsonWriter.WriteValue(1);
                  else
                    jsonWriter.WriteValue(0);
                  jsonWriter.WriteEndObject();
                }
                jsonWriter.WriteEndObject();
              }
              jsonWriter.WriteEndObject();
            }
            jsonWriter.WriteEndObject();
            jsonWriter.Close();
          }
        }
      }
    }

    private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.OpenFile();
    }

    private void OpenFile()
    {
      switch (this.openFileDialog1.ShowDialog())
      {
        case DialogResult.OK:
          try
          {
            string fileName = this.openFileDialog1.FileName;
            if (fileName.Split('.')[fileName.Split('.').Length - 1].Equals("tmj"))
            {
              this.OpenFileJSON(fileName);
            }
            else
            {
              DataInFileClass2 dataInFileClass2_1 = new DataInFileClass2();
              IFormatter formatter = (IFormatter) new BinaryFormatter();
              FileStream fileStream = new FileStream(this.openFileDialog1.FileName, FileMode.Open, FileAccess.Read);
              DataInFileClass2 dataInFileClass2_2 = formatter.Deserialize((Stream) fileStream) as DataInFileClass2;
              fileStream.Close();
              this.DeviceOptions = dataInFileClass2_2.DeviceOptions;
              this.CtrlProgramsOptions = dataInFileClass2_2.CtrlProgramsOptions;
            }
            this.UpdateAllFormElements();
            this.PathOfFile = this.openFileDialog1.FileName;
            char ch1 = '\\';
            char ch2 = '.';
            this.Text = this.stNovatek[this.LangGlobal] + ": " + this.PathOfFile.Split(ch1)[this.PathOfFile.Split(ch1).Length - 1].Split(ch2)[0];
            break;
          }
          catch
          {
            int num = (int) MessageBox.Show(this.stNotGoogFile[this.LangGlobal], this.stAttention[this.LangGlobal], MessageBoxButtons.OK, MessageBoxIcon.Hand);
            break;
          }
        case DialogResult.Cancel:
          break;
        default:
          int num1 = (int) MessageBox.Show(this.stFileNotFind[this.LangGlobal], this.stAttention[this.LangGlobal], MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
          break;
      }
    }

    private void OpenFileJSON(string path)
    {
      DeviceOptionsClass deviceOptionsClass = new DeviceOptionsClass();
      CtrlProgramOptionsClass programOptionsClass = new CtrlProgramOptionsClass();
      for (int index = 0; index <= 9; ++index)
        programOptionsClass.Add(new CtrlProgramOptionsClass());
      using (FileStream fileStream = File.Open(path, FileMode.Open, FileAccess.Read))
      {
        using (StreamReader streamReader = new StreamReader((Stream) fileStream))
        {
          using (JsonReader jsonReader = (JsonReader) new JsonTextReader((TextReader) streamReader))
          {
            while (jsonReader.Read())
            {
              if (jsonReader.Value != null)
              {
                if (jsonReader.Value.Equals((object) "format"))
                {
                  if (jsonReader.Read() && jsonReader.Value != null && Convert.ToInt32(jsonReader.Value) != 1)
                    throw new ArgumentException("Fault File Format!");
                }
                else if (jsonReader.Value.Equals((object) "channel1"))
                {
                  if (jsonReader.Read() && jsonReader.Value != null)
                    deviceOptionsClass.Channel_CtrlProg[1] = Convert.ToByte(jsonReader.Value);
                }
                else if (jsonReader.Value.Equals((object) "channel2"))
                {
                  if (jsonReader.Read() && jsonReader.Value != null)
                    deviceOptionsClass.Channel_CtrlProg[2] = Convert.ToByte(jsonReader.Value);
                }
                else if (jsonReader.Value.Equals((object) "dstonoff"))
                {
                  if (jsonReader.Read() && jsonReader.Value != null)
                    deviceOptionsClass.DST_OnOff = Convert.ToBoolean(jsonReader.Value);
                }
                else if (jsonReader.Value.Equals((object) "dstonoff"))
                {
                  if (jsonReader.Read() && jsonReader.Value != null)
                    deviceOptionsClass.DST_OnOff = Convert.ToBoolean(jsonReader.Value);
                }
                else if (jsonReader.Value.Equals((object) "delaystart"))
                {
                  if (jsonReader.Read() && jsonReader.Value == null)
                  {
                    if (jsonReader.Read() && jsonReader.Value != null)
                      deviceOptionsClass.CommonDelay.Minute = Convert.ToInt32(jsonReader.Value);
                    if (jsonReader.Read() && jsonReader.Value != null)
                      deviceOptionsClass.CommonDelay.Second = Convert.ToInt32(jsonReader.Value);
                    jsonReader.Read();
                  }
                }
                else if (jsonReader.Value.Equals((object) "program"))
                {
                  int index1 = 0;
                  if (jsonReader.Read() && jsonReader.Value == null)
                  {
                    while (jsonReader.Read() && jsonReader.Value != null)
                    {
                      if (jsonReader.Value.Equals((object) "number"))
                      {
                        if (jsonReader.Read() && jsonReader.Value != null)
                          index1 = Convert.ToInt32(jsonReader.Value);
                      }
                      else if (jsonReader.Value.Equals((object) "timermode"))
                      {
                        if (jsonReader.Read() && jsonReader.Value != null)
                          programOptionsClass[index1].RelayTimeMode = (CtrlProgramOptionsClass.RelayTimeModeType) Convert.ToInt32(jsonReader.Value);
                      }
                      else if (jsonReader.Value.Equals((object) "excweekdays"))
                      {
                        if (jsonReader.Read() && jsonReader.Value == null)
                        {
                          for (int index2 = 0; index2 < 7; ++index2)
                          {
                            if (jsonReader.Read() && jsonReader.Value != null)
                              programOptionsClass[index1].ExceptDaysOfWeek[index2 + 1] = Convert.ToBoolean(jsonReader.Value);
                          }
                          jsonReader.Read();
                        }
                      }
                      else if (jsonReader.Value.Equals((object) "allowdayoffs"))
                      {
                        if (jsonReader.Read() && jsonReader.Value != null)
                          programOptionsClass[index1].AllowDaysoffs = Convert.ToBoolean(jsonReader.Value);
                      }
                      else if (jsonReader.Value.Equals((object) "allowholidays"))
                      {
                        if (jsonReader.Read() && jsonReader.Value != null)
                          programOptionsClass[index1].AllowHolidays = Convert.ToBoolean(jsonReader.Value);
                      }
                      else if (jsonReader.Value.Equals((object) "allowciclicity"))
                      {
                        if (jsonReader.Read() && jsonReader.Value != null)
                          programOptionsClass[index1].AllowCyclicity = Convert.ToBoolean(jsonReader.Value);
                      }
                      else if (jsonReader.Value.Equals((object) "ribeforedelay"))
                      {
                        if (jsonReader.Read() && jsonReader.Value == null)
                        {
                          if (jsonReader.Read() && jsonReader.Value != null)
                            programOptionsClass[index1].RI_BeforeDelay.Minute = Convert.ToInt32(jsonReader.Value);
                          if (jsonReader.Read() && jsonReader.Value != null)
                            programOptionsClass[index1].RI_BeforeDelay.Second = Convert.ToInt32(jsonReader.Value);
                          jsonReader.Read();
                        }
                      }
                      else if (jsonReader.Value.Equals((object) "riondelay"))
                      {
                        if (jsonReader.Read() && jsonReader.Value == null)
                        {
                          if (jsonReader.Read() && jsonReader.Value != null)
                            programOptionsClass[index1].RI_OnDelay.Minute = Convert.ToInt32(jsonReader.Value);
                          if (jsonReader.Read() && jsonReader.Value != null)
                            programOptionsClass[index1].RI_OnDelay.Second = Convert.ToInt32(jsonReader.Value);
                          jsonReader.Read();
                        }
                      }
                      else if (jsonReader.Value.Equals((object) "rioffdelay"))
                      {
                        if (jsonReader.Read() && jsonReader.Value == null)
                        {
                          if (jsonReader.Read() && jsonReader.Value != null)
                            programOptionsClass[index1].RI_OffDelay.Minute = Convert.ToInt32(jsonReader.Value);
                          if (jsonReader.Read() && jsonReader.Value != null)
                            programOptionsClass[index1].RI_OffDelay.Second = Convert.ToInt32(jsonReader.Value);
                          jsonReader.Read();
                        }
                      }
                      else if (jsonReader.Value.Equals((object) "rsdelay"))
                      {
                        if (jsonReader.Read() && jsonReader.Value == null)
                        {
                          if (jsonReader.Read() && jsonReader.Value != null)
                            programOptionsClass[index1].RS_Delay.Minute = Convert.ToInt32(jsonReader.Value);
                          if (jsonReader.Read() && jsonReader.Value != null)
                            programOptionsClass[index1].RS_Delay.Second = Convert.ToInt32(jsonReader.Value);
                          jsonReader.Read();
                        }
                      }
                      else if (jsonReader.Value.Equals((object) "rvdelayumin"))
                      {
                        if (jsonReader.Read() && jsonReader.Value == null)
                        {
                          if (jsonReader.Read() && jsonReader.Value != null)
                            programOptionsClass[index1].RV_DelayUmin.Minute = Convert.ToInt32(jsonReader.Value);
                          if (jsonReader.Read() && jsonReader.Value != null)
                            programOptionsClass[index1].RV_DelayUmin.Second = Convert.ToInt32(jsonReader.Value);
                          jsonReader.Read();
                        }
                      }
                      else if (jsonReader.Value.Equals((object) "rvdelayunorm"))
                      {
                        if (jsonReader.Read() && jsonReader.Value == null)
                        {
                          if (jsonReader.Read() && jsonReader.Value != null)
                            programOptionsClass[index1].RV_DelayUnorm.Minute = Convert.ToInt32(jsonReader.Value);
                          if (jsonReader.Read() && jsonReader.Value != null)
                            programOptionsClass[index1].RV_DelayUnorm.Second = Convert.ToInt32(jsonReader.Value);
                          jsonReader.Read();
                        }
                      }
                      else if (jsonReader.Value.Equals((object) "rvdelayumax"))
                      {
                        if (jsonReader.Read() && jsonReader.Value == null)
                        {
                          if (jsonReader.Read() && jsonReader.Value != null)
                            programOptionsClass[index1].RV_DelayUmax.Minute = Convert.ToInt32(jsonReader.Value);
                          if (jsonReader.Read() && jsonReader.Value != null)
                            programOptionsClass[index1].RV_DelayUmax.Second = Convert.ToInt32(jsonReader.Value);
                          jsonReader.Read();
                        }
                      }
                      else if (jsonReader.Value.Equals((object) "rfdelaylmin"))
                      {
                        if (jsonReader.Read() && jsonReader.Value == null)
                        {
                          if (jsonReader.Read() && jsonReader.Value != null)
                            programOptionsClass[index1].RF_DelayLmin.Minute = Convert.ToInt32(jsonReader.Value);
                          if (jsonReader.Read() && jsonReader.Value != null)
                            programOptionsClass[index1].RF_DelayLmin.Second = Convert.ToInt32(jsonReader.Value);
                          jsonReader.Read();
                        }
                      }
                      else if (jsonReader.Value.Equals((object) "rfdelaylmax"))
                      {
                        if (jsonReader.Read() && jsonReader.Value == null)
                        {
                          if (jsonReader.Read() && jsonReader.Value != null)
                            programOptionsClass[index1].RF_DelayLmax.Minute = Convert.ToInt32(jsonReader.Value);
                          if (jsonReader.Read() && jsonReader.Value != null)
                            programOptionsClass[index1].RF_DelayLmax.Second = Convert.ToInt32(jsonReader.Value);
                          jsonReader.Read();
                        }
                      }
                      else if (jsonReader.Value.Equals((object) "rvonoff"))
                      {
                        if (jsonReader.Read() && jsonReader.Value != null)
                          programOptionsClass[index1].RV_OnOff = Convert.ToBoolean(jsonReader.Value);
                      }
                      else if (jsonReader.Value.Equals((object) "rvumin"))
                      {
                        if (jsonReader.Read() && jsonReader.Value != null)
                          programOptionsClass[index1].RV_Umin = Convert.ToInt32(jsonReader.Value);
                      }
                      else if (jsonReader.Value.Equals((object) "rvumax"))
                      {
                        if (jsonReader.Read() && jsonReader.Value != null)
                          programOptionsClass[index1].RV_Umax = Convert.ToInt32(jsonReader.Value);
                      }
                      else if (jsonReader.Value.Equals((object) "rvuminhyst"))
                      {
                        if (jsonReader.Read() && jsonReader.Value != null)
                          programOptionsClass[index1].RV_Uminhyst = Convert.ToInt32(jsonReader.Value);
                      }
                      else if (jsonReader.Value.Equals((object) "rvumaxhyst"))
                      {
                        if (jsonReader.Read() && jsonReader.Value != null)
                          programOptionsClass[index1].RV_Umaxhyst = Convert.ToInt32(jsonReader.Value);
                      }
                      else if (jsonReader.Value.Equals((object) "rfonoff"))
                      {
                        if (jsonReader.Read() && jsonReader.Value != null)
                          programOptionsClass[index1].RF_OnOff = Convert.ToBoolean(jsonReader.Value);
                      }
                      else if (jsonReader.Value.Equals((object) "rflpor"))
                      {
                        if (jsonReader.Read() && jsonReader.Value != null)
                          programOptionsClass[index1].RF_Lpor = Convert.ToInt32(jsonReader.Value);
                      }
                      else if (jsonReader.Value.Equals((object) "rflporhyst"))
                      {
                        if (jsonReader.Read() && jsonReader.Value != null)
                          programOptionsClass[index1].RF_Lporhyst = Convert.ToInt32(jsonReader.Value);
                      }
                      else if (jsonReader.Value.Equals((object) "rfcontlmin"))
                      {
                        if (jsonReader.Read() && jsonReader.Value != null)
                          programOptionsClass[index1].RF_Condition_Lmin = Convert.ToInt32(jsonReader.Value);
                      }
                      else if (jsonReader.Value.Equals((object) "rfcontlmax"))
                      {
                        if (jsonReader.Read() && jsonReader.Value != null)
                          programOptionsClass[index1].RF_Condition_Lmax = Convert.ToInt32(jsonReader.Value);
                      }
                      else if (jsonReader.Value.Equals((object) "lists"))
                      {
                        int num1 = 0;
                        int num2 = 0;
                        TimerClass timerClass = new TimerClass();
                        if (jsonReader.Read() && jsonReader.Value == null)
                        {
                          while (jsonReader.Read() && jsonReader.Value != null)
                          {
                            if (jsonReader.Value.Equals((object) "listnum"))
                            {
                              if (jsonReader.Read() && jsonReader.Value != null)
                                num1 = Convert.ToInt32(jsonReader.Value);
                            }
                            else if (jsonReader.Value.Equals((object) "eventsmax"))
                            {
                              if (jsonReader.Read() && jsonReader.Value != null)
                              {
                                num2 = Convert.ToInt32(jsonReader.Value);
                                if (num2 == 0)
                                  break;
                              }
                            }
                            else if (jsonReader.Value.Equals((object) "event"))
                            {
                              int index2 = 0;
                              int second = 0;
                              int minute = 0;
                              int hour = 0;
                              int day1 = 1;
                              int day2 = 1;
                              int month = 1;
                              if (jsonReader.Read() && jsonReader.Value == null)
                              {
                                while (jsonReader.Read() && jsonReader.Value != null)
                                {
                                  if (jsonReader.Value.Equals((object) "eventnum"))
                                  {
                                    if (jsonReader.Read() && jsonReader.Value != null)
                                      index2 = Convert.ToInt32(jsonReader.Value);
                                  }
                                  else if (jsonReader.Value.Equals((object) "sec"))
                                  {
                                    if (jsonReader.Read() && jsonReader.Value != null)
                                      second = Convert.ToInt32(jsonReader.Value);
                                  }
                                  else if (jsonReader.Value.Equals((object) "min"))
                                  {
                                    if (jsonReader.Read() && jsonReader.Value != null)
                                      minute = Convert.ToInt32(jsonReader.Value);
                                  }
                                  else if (jsonReader.Value.Equals((object) "hour"))
                                  {
                                    if (jsonReader.Read() && jsonReader.Value != null)
                                      hour = Convert.ToInt32(jsonReader.Value);
                                  }
                                  else if (jsonReader.Value.Equals((object) "weekday"))
                                  {
                                    if (jsonReader.Read() && jsonReader.Value != null)
                                      day1 = Convert.ToInt32(jsonReader.Value) + 1;
                                  }
                                  else if (jsonReader.Value.Equals((object) "monthday"))
                                  {
                                    if (jsonReader.Read() && jsonReader.Value != null)
                                      day2 = Convert.ToInt32(jsonReader.Value);
                                  }
                                  else if (jsonReader.Value.Equals((object) "month"))
                                  {
                                    if (jsonReader.Read() && jsonReader.Value != null)
                                      month = Convert.ToInt32(jsonReader.Value);
                                  }
                                  else if (jsonReader.Value.Equals((object) "condition"))
                                  {
                                    if (jsonReader.Read() && jsonReader.Value != null)
                                    {
                                      int int32 = Convert.ToInt32(jsonReader.Value);
                                      timerClass.Add(new TimerClass());
                                      timerClass[index2].DateAndTime = num1 == 4 ? new DateTime(1996, month, day1, hour, minute, second) : new DateTime(1996, month, day2, hour, minute, second);
                                      timerClass[index2].Condition = Convert.ToBoolean(int32);
                                      break;
                                    }
                                    break;
                                  }
                                }
                                jsonReader.Read();
                              }
                              if (index2 == num2 - 1)
                                break;
                            }
                          }
                          jsonReader.Read();
                        }
                        switch (num1)
                        {
                          case 0:
                            programOptionsClass[index1].ListHolidays = timerClass;
                            break;
                          case 1:
                            programOptionsClass[index1].ListEventsException = timerClass;
                            break;
                          case 2:
                            programOptionsClass[index1].ListEventsYear = timerClass;
                            break;
                          case 3:
                            programOptionsClass[index1].ListEventsMonth = timerClass;
                            break;
                          case 4:
                            programOptionsClass[index1].ListEventsWeek = timerClass;
                            break;
                          case 5:
                            programOptionsClass[index1].ListEventsDay = timerClass;
                            break;
                        }
                        if (num1 == 5)
                          break;
                      }
                    }
                    jsonReader.Read();
                  }
                }
              }
            }
            jsonReader.Close();
          }
        }
      }
      this.DeviceOptions = deviceOptionsClass;
      this.CtrlProgramsOptions = programOptionsClass;
    }

    private void OpenToolStripButton_Click(object sender, EventArgs e)
    {
      this.OpenFile();
    }

    private void SaveToolStripButton_Click(object sender, EventArgs e)
    {
      if (this.PathOfFile == null)
        this.SaveNewFile();
      else
        this.SaveFile();
    }

    private void создатьToolStripButton_Click(object sender, EventArgs e)
    {
      if (MessageBox.Show(this.stFileReset[this.LangGlobal], this.stAttention[this.LangGlobal], MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) != DialogResult.OK)
        return;
      this.DeviceOptions.Reset();
      foreach (CtrlProgramOptionsClass ctrlProgramsOption in (CollectionBase) this.CtrlProgramsOptions)
        ctrlProgramsOption.Reset();
      this.UpdateAllFormElements();
      this.Text = this.stNovatek[this.LangGlobal];
      this.PathOfFile = (string) null;
    }

    private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (this.PathOfFile == null)
        this.SaveNewFile();
      else
        this.SaveFile();
    }

    private void button26_Click(object sender, EventArgs e)
    {
    }

    protected override void OnHandleCreated(EventArgs e)
    {
      base.OnHandleCreated(e);
      this.usb.RegisterHandle(this);
    }

    private void button1_Click(object sender, EventArgs e)
    {
      try
      {
        this.usb.CheckDevicePresent();
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.ToString());
      }
    }

    private void usb_OnDeviceArrived(object sender, EventArgs e)
    {
      this.listBox1.Items.Add((object) "Found a Device");
    }

    private void usb_OnDataRecieved(object sender, DataRecievedEventArgs args)
    {
      if (this.InvokeRequired)
      {
        try
        {
          this.Invoke((Delegate) new DataRecievedEventHandler(this.usb_OnDataRecieved), sender, (object) args);
        }
        catch (Exception ex)
        {
          Console.WriteLine(ex.ToString());
        }
      }
      else
      {
        this.timer1.Enabled = false;
        this.timer1.Enabled = true;
        this.timer2.Enabled = false;
        switch (this.Connection.ReadData(args.data, ref this.DeviceOptions, ref this.CtrlProgramsOptions))
        {
          case 1:
            this.timer1.Enabled = false;
            this.progressBar1.Visible = false;
            this.progressBar1.Value = 0;
            this.label81.Text = this.StMessageUSB;
            this.UpdateAllFormElements();
            this.SaveDataInRelay();
            this.tabControl1.Enabled = true;
            int num1 = (int) MessageBox.Show(this.stSettingSuccessRead[this.LangGlobal], this.stReceivingData[this.LangGlobal], MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            break;
          case 2:
            this.label81.Text = "USB: " + this.stReceivingData[this.LangGlobal];
            this.progressBar1.Value = this.Connection.ProgressBarPercent;
            this.progressBar1.Visible = true;
            if (this.Connection.NewTypeDataSend(ModesSend.CONTINUE))
            {
              this.MyUsbSendData();
              break;
            }
            break;
          case 3:
            this.label81.Text = "USB: " + this.stTransferData[this.LangGlobal];
            this.progressBar1.Value = this.Connection.ProgressBarPercent;
            this.progressBar1.Visible = true;
            this.MyUsbSendData();
            break;
          case 4:
            this.timer1.Enabled = false;
            this.progressBar1.Visible = false;
            this.progressBar1.Value = 0;
            this.label81.Text = this.StMessageUSB;
            this.SaveDataInRelay();
            this.tabControl1.Enabled = true;
            int num2 = (int) MessageBox.Show(this.stSettingSuccessTransfer[this.LangGlobal], this.stTransferData[this.LangGlobal], MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            break;
          case 5:
            this.label81.Text = "USB: " + this.stReceivingData[this.LangGlobal];
            this.MyUsbSendData();
            this.label82.Text = this.Connection.FullBytes.ToString();
            break;
          case 6:
            this.timer1.Enabled = false;
            this.label81.Text = this.StMessageUSB;
            this.tabControl1.Enabled = true;
            int num3 = (int) MessageBox.Show(this.stOverMemory1[this.LangGlobal] + this.Connection.EnablePlacesInDevice.ToString() + this.stOverMemory2[this.LangGlobal] + this.Connection.NeededPlaces.ToString() + this.stOverMemory3[this.LangGlobal], this.stSaveSettings[this.LangGlobal], MessageBoxButtons.OK, MessageBoxIcon.Hand);
            break;
          case 7:
            if (this.USB_GetSequence == Form1.USB_GetSequenceEnum.GET_OPTIONS)
            {
              if (this.CompareVersions(this.Connection.VersionOfDeviceProgram, this.Connection.SubVersionOfDeviceProgram))
              {
                if (this.Connection.NewTypeDataSend(ModesSend.REQUEST_NUM_EVENTS))
                {
                  this.MyUsbSendData();
                  break;
                }
                break;
              }
              this.timer1.Enabled = false;
              this.label81.Text = this.StMessageUSB;
              this.USB_GetSequence = Form1.USB_GetSequenceEnum.NO;
              int num4 = (int) MessageBox.Show(this.stVersionDeviceNotSupport_1[this.LangGlobal] + this.Connection.VersionOfDeviceProgram.ToString() + (object) '.' + this.Connection.SubVersionOfDeviceProgram.ToString() + this.stVersionDeviceNotSupport_2[this.LangGlobal], this.stReceivingData[this.LangGlobal], MessageBoxButtons.OK, MessageBoxIcon.Hand);
              break;
            }
            if (this.USB_GetSequence == Form1.USB_GetSequenceEnum.SEND_OPTIONS)
            {
              if (this.CompareVersions(this.Connection.VersionOfDeviceProgram, this.Connection.SubVersionOfDeviceProgram))
              {
                if (this.Connection.NewTypeDataSend(ModesSend.REQUEST_NUM_PLACES))
                {
                  this.timer1.Enabled = true;
                  this.Connection.DevOpt = this.DeviceOptions;
                  this.Connection.ProgsOpt = this.CtrlProgramsOptions;
                  this.Connection.NeededPlaces = 0;
                  for (int index = 1; index <= 8; ++index)
                    this.Connection.NeededPlaces += this.CtrlProgramsOptions[index].ListHolidays.Count + this.CtrlProgramsOptions[index].ListEventsException.Count + this.CtrlProgramsOptions[index].ListEventsYear.Count + this.CtrlProgramsOptions[index].ListEventsMonth.Count + this.CtrlProgramsOptions[index].ListEventsWeek.Count + this.CtrlProgramsOptions[index].ListEventsDay.Count;
                  this.MyUsbSendData();
                  break;
                }
                break;
              }
              this.timer1.Enabled = false;
              this.label81.Text = this.StMessageUSB;
              this.USB_GetSequence = Form1.USB_GetSequenceEnum.NO;
              this.tabControl1.Enabled = true;
              int num4 = (int) MessageBox.Show(this.stVersionDeviceNotSupport_1[this.LangGlobal] + this.Connection.VersionOfDeviceProgram.ToString() + (object) '.' + this.Connection.SubVersionOfDeviceProgram.ToString() + this.stVersionDeviceNotSupport_2[this.LangGlobal], this.stTransferData[this.LangGlobal], MessageBoxButtons.OK, MessageBoxIcon.Hand);
              break;
            }
            this.timer1.Enabled = false;
            this.label81.Text = this.StMessageUSB;
            int num5 = (int) MessageBox.Show(this.stVersionDevice[this.LangGlobal] + this.Connection.VersionOfDeviceProgram.ToString() + (object) '.' + this.Connection.SubVersionOfDeviceProgram.ToString(), this.stREV302[this.LangGlobal], MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            break;
          case 8:
            this.timer1.Enabled = false;
            this.label81.Text = this.StMessageUSB;
            this.DeviceTimeMonitor = this.Connection.DeviceTime;
            this.label60.Text = this.DeviceTimeMonitor.ToString("dd MMMM yyyy");
            this.label67.Text = this.DeviceTimeMonitor.ToString("HH:mm:ss");
            this.DeviceTimeMonitorExist = true;
            this.label70.Text = this.Connection.ReadVoltage.ToString();
            this.label73.Text = this.Connection.ReadBright.ToString();
            break;
          case 9:
            this.timer1.Enabled = false;
            this.label81.Text = this.StMessageUSB;
            int num6 = (int) MessageBox.Show(this.stNewTimeSend[this.LangGlobal], this.stSetTime[this.LangGlobal], MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            break;
          case 10:
            this.timer1.Enabled = false;
            this.label81.Text = this.StMessageUSB;
            int num7 = (int) MessageBox.Show(" Калибрование успешно завершено.\nПроконтролируйте точность скорректированных значений.", "Передача данных", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            break;
          case 11:
            this.timer1.Enabled = false;
            this.label81.Text = this.StMessageUSB;
            int num8 = (int) MessageBox.Show(" Калибровочное значение времени успешно записано в устройство.\nПроконтролируйте точность хода времени.", "Передача данных", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            break;
        }
        this.timer2.Enabled = true;
      }
    }

    private bool CompareVersions(int ver, int subver)
    {
      if (ver != 1)
        return false;
      switch (subver)
      {
        case 1:
          return true;
        case 2:
          return true;
        default:
          return false;
      }
    }

    private void usb_OnSpecifiedDeviceArrived(object sender, EventArgs e)
    {
      this.listBox1.Items.Add((object) "My device was found");
      this.StMessageUSB = this.stUSBconnectIs[this.LangGlobal];
      this.label81.Text = this.StMessageUSB;
      this.USB_Connect = true;
      this.GetDeviceTime();
    }

    private void GetDeviceTime()
    {
      if (this.timer1.Enabled || !this.Connection.NewTypeDataSend(ModesSend.REQUEST_DEVICETIME))
        return;
      this.timer1.Enabled = true;
      this.MyUsbSendData();
    }

    private void button27_Click(object sender, EventArgs e)
    {
      try
      {
        byte[] data = new byte[32];
        data[0] = (byte) 0;
        for (byte index = 1; (int) index < 31; ++index)
          data[(int) index] = index;
        data[1] = (byte) 100;
        if (this.usb.SpecifiedDevice != null)
        {
          this.usb.SpecifiedDevice.SendData(data);
        }
        else
        {
          int num = (int) MessageBox.Show(this.stDeviceNotConnect[this.LangGlobal], this.stAttention[this.LangGlobal], MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.ToString());
      }
    }

    private void MyUsbSendData()
    {
      try
      {
        byte[] RefDataByte = new byte[32];
        RefDataByte[0] = (byte) 0;
        if (!this.Connection.SendData(ref RefDataByte))
          return;
        if (this.usb.SpecifiedDevice != null)
        {
          this.usb.SpecifiedDevice.SendData(RefDataByte);
        }
        else
        {
          this.tabControl1.Enabled = true;
          this.timer1.Enabled = false;
          int num = (int) MessageBox.Show(this.stDeviceNotConnect[this.LangGlobal], this.stAttention[this.LangGlobal], MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.ToString());
      }
    }

    private void usb_OnDataSend(object sender, EventArgs e)
    {
    }

    private void настройкиToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (!this.Connection.NewTypeDataSend(ModesSend.REQUEST_NUM_VERSION))
        return;
      this.tabControl1.Enabled = false;
      this.timer1.Enabled = true;
      this.USB_GetSequence = Form1.USB_GetSequenceEnum.GET_OPTIONS;
      this.USB_GetSeqStep = 1;
      this.MyUsbSendData();
    }

    private void button28_Click(object sender, EventArgs e)
    {
      this.tabControl1.Enabled = false;
    }

    private void button29_Click(object sender, EventArgs e)
    {
      this.listBox1.Items.Clear();
      this.dlgConnect.Close();
    }

    private void button30_Click(object sender, EventArgs e)
    {
      if (!this.Connection.NewTypeDataSend(ModesSend.CONTINUE))
        return;
      this.MyUsbSendData();
    }

    private void button31_Click(object sender, EventArgs e)
    {
      if (this.dlgConnect.ProcBar1 == 90)
        this.dlgConnect.ProcBar1 = 45;
      else
        this.dlgConnect.ProcBar1 = 90;
    }

    private void SendToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.treeView1.Focus();
      if (!this.Connection.NewTypeDataSend(ModesSend.REQUEST_NUM_VERSION))
        return;
      this.tabControl1.Enabled = false;
      this.timer1.Enabled = true;
      this.USB_GetSequence = Form1.USB_GetSequenceEnum.SEND_OPTIONS;
      this.USB_GetSeqStep = 1;
      this.MyUsbSendData();
    }

    private void usb_OnSpecifiedDeviceRemoved(object sender, EventArgs e)
    {
      this.listBox1.Items.Add((object) "My device removed");
      this.StMessageUSB = this.stUSBconnectionNotIs[this.LangGlobal];
      this.label81.Text = this.StMessageUSB;
      this.USB_Connect = false;
    }

    private void usb_OnDeviceRemoved(object sender, EventArgs e)
    {
      this.listBox1.Items.Add((object) "Device removed");
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
      this.tabControl1.Enabled = true;
      this.timer1.Enabled = false;
      this.Connection.ErrorConnect();
      if (this.Connection.TypeReadData != ModesRead.SEND_NEWTIME)
      {
        int num = (int) MessageBox.Show(this.stConnectError[this.LangGlobal], this.stAttention[this.LangGlobal], MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
      this.progressBar1.Visible = false;
      this.progressBar1.Value = 0;
      this.label81.Text = this.StMessageUSB;
    }

    private void опрограммеToolStripMenuItem_Click(object sender, EventArgs e)
    {
      int num = (int) new About().ShowDialog();
    }

    private void button32_Click(object sender, EventArgs e)
    {
      new TimerClass().DateAndTime = new DateTime(1996, 1, 1, 0, 0, 0);
      DateTime dateTime = new DateTime(1996, 1, 1, 0, 0, 0);
      for (int index = 0; index < 5000; ++index)
      {
        dateTime = dateTime.AddSeconds(5.0);
        this.CtrlProgramsOptions[1].ListEventsYear.Add(new TimerClass());
        this.CtrlProgramsOptions[1].ListEventsYear[index].DateAndTime = new DateTime(1996, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute, dateTime.Second);
      }
      this.UpdateAllFormElements();
    }

    private void VersionProgToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.USB_GetSequence = Form1.USB_GetSequenceEnum.NO;
      if (!this.Connection.NewTypeDataSend(ModesSend.REQUEST_NUM_VERSION))
        return;
      this.timer1.Enabled = true;
      this.MyUsbSendData();
    }

    private void timer2_Tick(object sender, EventArgs e)
    {
      DateTime now = DateTime.Now;
      if (this.USB_Connect && (this.tabControl1.SelectedTab == this.tabPage2_Time || this.tabControl1.SelectedTab == this.tabPage3_VoltBright))
      {
        this.GetDeviceTime();
      }
      else
      {
        this.label60.Text = this.stInfo[this.LangGlobal];
        this.label67.Text = this.stAbsent[this.LangGlobal];
        this.DeviceTimeMonitorExist = false;
      }
      this.label68.Text = now.ToString("dd MMMM yyyy");
      this.label69.Text = now.ToString("HH:mm:ss");
    }

    private void button22_Click(object sender, EventArgs e)
    {
      if (this.USB_Connect && (this.tabControl1.SelectedTab == this.tabPage2_Time || this.tabControl1.SelectedTab == this.tabPage3_VoltBright))
      {
        this.GetDeviceTime();
      }
      else
      {
        this.label60.Text = this.stInfo[this.LangGlobal];
        this.label67.Text = this.stAbsent[this.LangGlobal];
        this.DeviceTimeMonitorExist = false;
      }
    }

    private void button20_Click(object sender, EventArgs e)
    {
      this.SychTime = DateTime.Now;
      this.WriteNewTimeInDevice = true;
      this.timer3.Enabled = true;
    }

    private void button21_Click(object sender, EventArgs e)
    {
      if (!this.Connection.NewTypeDataSend(ModesSend.SEND_NEWTIME))
        return;
      this.timer1.Enabled = true;
      this.Connection.SendTimeToDevice = new DateTime(this.dateTimePicker6.Value.Year, this.dateTimePicker6.Value.Month, this.dateTimePicker6.Value.Day, this.dateTimePicker5.Value.Hour, this.dateTimePicker5.Value.Minute, this.dateTimePicker5.Value.Second);
      this.MyUsbSendData();
    }

    private void timer3_Tick(object sender, EventArgs e)
    {
      if (this.SychTime.Second == DateTime.Now.Second)
        return;
      this.timer3.Enabled = false;
      if (this.SychShowTime)
      {
        this.SychShowTime = false;
        this.timer2.Enabled = true;
      }
      if (!this.WriteNewTimeInDevice)
        return;
      this.WriteNewTimeInDevice = false;
      this.timer4.Enabled = true;
    }

    private void timer4_Tick(object sender, EventArgs e)
    {
      this.timer4.Enabled = false;
      this.Connection.SendTimeToDevice = DateTime.Now.AddSeconds(1.0);
      if (!this.Connection.NewTypeDataSend(ModesSend.SEND_NEWTIME))
        return;
      this.timer1.Enabled = true;
      this.MyUsbSendData();
    }

    private void button35_Click(object sender, EventArgs e)
    {
      if (!this.Connection.NewTypeDataSend(ModesSend.SEND_NEWVOLTBRIGHT))
        return;
      this.Connection.WriteBright = 0;
      this.Connection.WriteVoltage = (int) this.numericUpDown44.Value;
      this.timer1.Enabled = true;
      this.MyUsbSendData();
    }

    private void button33_Click(object sender, EventArgs e)
    {
      if (!this.Connection.NewTypeDataSend(ModesSend.SEND_NEWVOLTBRIGHT))
        return;
      this.Connection.WriteBright = (int) this.numericUpDown43.Value;
      this.Connection.WriteVoltage = 0;
      this.timer1.Enabled = true;
      this.MyUsbSendData();
    }

    private void SunRiseToolStripMenuItem_Click(object sender, EventArgs e)
    {
      CtrlProgramOptionsClass programOptionsClass = new CtrlProgramOptionsClass();
      programOptionsClass.Add(new CtrlProgramOptionsClass());
      programOptionsClass[0] = (CtrlProgramOptionsClass) this.CtrlProgramsOptions[this.ProgSelected].Clone();
      this.dlgSunRise.ListEvents = this.CtrlProgramsOptions[this.ProgSelected].ListEventsYear;
      if (this.dlgSunRise.ShowDialog() != DialogResult.OK)
        return;
      this.BackCtrlProgramsOptions[0] = (CtrlProgramOptionsClass) programOptionsClass[0].Clone();
      this.VisibledBackButtons();
      this.CtrlProgramsOptions[this.ProgSelected].ListEventsYear = this.dlgSunRise.ListEvents;
      this.ReDrawListOfEventsYear();
    }

    private void button24_Click(object sender, EventArgs e)
    {
      CtrlProgramOptionsClass programOptionsClass = new CtrlProgramOptionsClass();
      programOptionsClass.Add(new CtrlProgramOptionsClass());
      programOptionsClass[0] = (CtrlProgramOptionsClass) this.CtrlProgramsOptions[this.ProgSelected].Clone();
      this.dlgArEv.ChangeShowElements(2);
      this.dlgArEv.ListEvents = this.CtrlProgramsOptions[this.ProgSelected].ListEventsYear;
      if (this.dlgArEv.ShowDialog() != DialogResult.OK)
        return;
      this.BackCtrlProgramsOptions[0] = (CtrlProgramOptionsClass) programOptionsClass[0].Clone();
      this.VisibledBackButtons();
      this.CtrlProgramsOptions[this.ProgSelected].ListEventsYear = this.dlgArEv.ListEvents;
      this.ReDrawListOfEventsYear();
    }

    private void button25_Click(object sender, EventArgs e)
    {
      CtrlProgramOptionsClass programOptionsClass = new CtrlProgramOptionsClass();
      programOptionsClass.Add(new CtrlProgramOptionsClass());
      programOptionsClass[0] = (CtrlProgramOptionsClass) this.CtrlProgramsOptions[this.ProgSelected].Clone();
      this.dlgArEv.ChangeShowElements(3);
      this.dlgArEv.ListEvents = this.CtrlProgramsOptions[this.ProgSelected].ListEventsMonth;
      if (this.dlgArEv.ShowDialog() != DialogResult.OK)
        return;
      this.BackCtrlProgramsOptions[0] = (CtrlProgramOptionsClass) programOptionsClass[0].Clone();
      this.VisibledBackButtons();
      this.CtrlProgramsOptions[this.ProgSelected].ListEventsMonth = this.dlgArEv.ListEvents;
      this.ReDrawListOfEventsMonth();
    }

    private void button34_Click(object sender, EventArgs e)
    {
      CtrlProgramOptionsClass programOptionsClass = new CtrlProgramOptionsClass();
      programOptionsClass.Add(new CtrlProgramOptionsClass());
      programOptionsClass[0] = (CtrlProgramOptionsClass) this.CtrlProgramsOptions[this.ProgSelected].Clone();
      this.dlgArEv.ChangeShowElements(0);
      this.dlgArEv.ListEvents = this.CtrlProgramsOptions[this.ProgSelected].ListHolidays;
      if (this.dlgArEv.ShowDialog() != DialogResult.OK)
        return;
      this.BackCtrlProgramsOptions[0] = (CtrlProgramOptionsClass) programOptionsClass[0].Clone();
      this.VisibledBackButtons();
      this.CtrlProgramsOptions[this.ProgSelected].ListHolidays = this.dlgArEv.ListEvents;
      this.ReDrawListOfHolidays();
    }

    private void button36_Click(object sender, EventArgs e)
    {
      CtrlProgramOptionsClass programOptionsClass = new CtrlProgramOptionsClass();
      programOptionsClass.Add(new CtrlProgramOptionsClass());
      programOptionsClass[0] = (CtrlProgramOptionsClass) this.CtrlProgramsOptions[this.ProgSelected].Clone();
      this.dlgArEv.ChangeShowElements(1);
      this.dlgArEv.ListEvents = this.CtrlProgramsOptions[this.ProgSelected].ListEventsException;
      if (this.dlgArEv.ShowDialog() != DialogResult.OK)
        return;
      this.BackCtrlProgramsOptions[0] = (CtrlProgramOptionsClass) programOptionsClass[0].Clone();
      this.VisibledBackButtons();
      this.CtrlProgramsOptions[this.ProgSelected].ListEventsException = this.dlgArEv.ListEvents;
      this.ReDrawListOfEventsExceptions();
    }

    private void button37_Click(object sender, EventArgs e)
    {
      CtrlProgramOptionsClass programOptionsClass = new CtrlProgramOptionsClass();
      programOptionsClass.Add(new CtrlProgramOptionsClass());
      programOptionsClass[0] = (CtrlProgramOptionsClass) this.CtrlProgramsOptions[this.ProgSelected].Clone();
      this.dlgArEv.ChangeShowElements(4);
      this.dlgArEv.ListEvents = this.CtrlProgramsOptions[this.ProgSelected].ListEventsWeek;
      if (this.dlgArEv.ShowDialog() != DialogResult.OK)
        return;
      this.BackCtrlProgramsOptions[0] = (CtrlProgramOptionsClass) programOptionsClass[0].Clone();
      this.VisibledBackButtons();
      this.CtrlProgramsOptions[this.ProgSelected].ListEventsWeek = this.dlgArEv.ListEvents;
      this.ReDrawListOfEventsWeek();
    }

    private void button38_Click(object sender, EventArgs e)
    {
      CtrlProgramOptionsClass programOptionsClass = new CtrlProgramOptionsClass();
      programOptionsClass.Add(new CtrlProgramOptionsClass());
      programOptionsClass[0] = (CtrlProgramOptionsClass) this.CtrlProgramsOptions[this.ProgSelected].Clone();
      this.dlgArEv.ChangeShowElements(5);
      this.dlgArEv.ListEvents = this.CtrlProgramsOptions[this.ProgSelected].ListEventsDay;
      if (this.dlgArEv.ShowDialog() != DialogResult.OK)
        return;
      this.BackCtrlProgramsOptions[0] = (CtrlProgramOptionsClass) programOptionsClass[0].Clone();
      this.VisibledBackButtons();
      this.CtrlProgramsOptions[this.ProgSelected].ListEventsDay = this.dlgArEv.ListEvents;
      this.ReDrawListOfEventsDay();
    }

    private void button39_Click(object sender, EventArgs e)
    {
      int selectedIndex = this.comboBox2.SelectedIndex;
      int index1 = 0;
      for (int index2 = 0; index2 <= this.comboBox2.SelectedIndex; ++index2)
      {
        ++index1;
        if (index1 == this.ProgSelected)
          ++index1;
      }
      if (MessageBox.Show(string.Format(this.stCopy1[this.LangGlobal], (object) this.ProgSelected, (object) index1), this.stCopy2[this.LangGlobal], MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) != DialogResult.OK)
        return;
      this.CtrlProgramsOptions[this.ProgSelected] = (CtrlProgramOptionsClass) this.CtrlProgramsOptions[index1].Clone();
      this.ReCalculateEventsInLists(this.ProgSelected);
      int num = (int) MessageBox.Show(string.Format(this.stCopy3[this.LangGlobal], (object) index1, (object) this.ProgSelected), this.stCopy2[this.LangGlobal], MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
    }

    private void button41_Click(object sender, EventArgs e)
    {
      byte[] numArray = new byte[128]
      {
        (byte) 0,
        (byte) 1,
        (byte) 2,
        (byte) 3,
        (byte) 4,
        (byte) 5,
        (byte) 6,
        (byte) 7,
        (byte) 8,
        (byte) 9,
        (byte) 10,
        (byte) 10,
        (byte) 11,
        (byte) 12,
        (byte) 13,
        (byte) 14,
        (byte) 15,
        (byte) 16,
        (byte) 17,
        (byte) 18,
        (byte) 19,
        (byte) 20,
        (byte) 21,
        (byte) 22,
        (byte) 23,
        (byte) 24,
        (byte) 25,
        (byte) 26,
        (byte) 27,
        (byte) 28,
        (byte) 29,
        (byte) 30,
        (byte) 31,
        (byte) 31,
        (byte) 32,
        (byte) 33,
        (byte) 34,
        (byte) 35,
        (byte) 36,
        (byte) 37,
        (byte) 38,
        (byte) 39,
        (byte) 40,
        (byte) 41,
        (byte) 42,
        (byte) 43,
        (byte) 44,
        (byte) 45,
        (byte) 46,
        (byte) 47,
        (byte) 48,
        (byte) 49,
        (byte) 50,
        (byte) 51,
        (byte) 51,
        (byte) 52,
        (byte) 53,
        (byte) 54,
        (byte) 55,
        (byte) 56,
        (byte) 57,
        (byte) 58,
        (byte) 59,
        (byte) 60,
        (byte) 61,
        (byte) 62,
        (byte) 63,
        (byte) 64,
        (byte) 65,
        (byte) 66,
        (byte) 67,
        (byte) 68,
        (byte) 69,
        (byte) 70,
        (byte) 71,
        (byte) 72,
        (byte) 72,
        (byte) 73,
        (byte) 74,
        (byte) 75,
        (byte) 76,
        (byte) 77,
        (byte) 78,
        (byte) 79,
        (byte) 80,
        (byte) 81,
        (byte) 82,
        (byte) 83,
        (byte) 84,
        (byte) 85,
        (byte) 86,
        (byte) 87,
        (byte) 88,
        (byte) 89,
        (byte) 90,
        (byte) 91,
        (byte) 92,
        (byte) 93,
        (byte) 93,
        (byte) 94,
        (byte) 95,
        (byte) 96,
        (byte) 97,
        (byte) 98,
        (byte) 99,
        (byte) 100,
        (byte) 101,
        (byte) 102,
        (byte) 103,
        (byte) 104,
        (byte) 105,
        (byte) 106,
        (byte) 107,
        (byte) 108,
        (byte) 109,
        (byte) 110,
        (byte) 111,
        (byte) 112,
        (byte) 113,
        (byte) 113,
        (byte) 114,
        (byte) 115,
        (byte) 116,
        (byte) 117,
        (byte) 118,
        (byte) 119,
        (byte) 120,
        (byte) 121
      };
      byte num1 = 0;
      string[] strArray = this.textBox1.Text.Split('.');
      int length = strArray[1].Length;
      int int32 = Convert.ToInt32(strArray[0]);
      double num2 = ((double) Convert.ToInt32(strArray[1]) / Math.Pow(10.0, (double) length) + (double) int32) * 1E-06;
      double num3 = 511.96875;
      double num4 = 1.0 / num2;
      this.label74.Text = string.Format("{0:#.#####}", (object) num4);
      double num5 = (num4 - num3) / num3 * 1000000.0;
      this.label94.Text = string.Format("{0:#.#####}", (object) num5);
      int num6 = (int) num5;
      if (num6 <= 121)
      {
        while ((int) num1 < (int) sbyte.MaxValue && (int) numArray[(int) num1] != num6)
          ++num1;
      }
      else
        num1 = (byte) 127;
      this.numericUpDown35.Value = (Decimal) num1;
    }

    private void button40_Click(object sender, EventArgs e)
    {
      if (this.timer1.Enabled || !this.Connection.NewTypeDataSend(ModesSend.SEND_FACTORYTIMECALIBR))
        return;
      this.Connection.RTCCalibrValue = (byte) this.numericUpDown35.Value;
      this.timer1.Enabled = true;
      this.MyUsbSendData();
    }

    private void содержаниеToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.CallHelp();
    }

    private void button42_Click(object sender, EventArgs e)
    {
      if (MessageBox.Show(string.Format(this.stClearLists1[this.LangGlobal], (object) this.ProgSelected), this.stClearLists2[this.LangGlobal], MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
        return;
      this.CtrlProgramsOptions[this.ProgSelected].ResetCollections();
      this.ReCalculateEventsInLists();
    }

    private void справкаToolStripButton_Click(object sender, EventArgs e)
    {
      this.CallHelp();
    }

    private void CallHelp()
    {
      try
      {
        Process process = new Process();
        process.StartInfo.ErrorDialog = true;
        if (this.LangGlobal == 0)
          process.StartInfo.FileName = "MultiTimer.chm";
        else if (this.LangGlobal == 1)
          process.StartInfo.FileName = "MultiTimerEng.chm";
        else if (this.LangGlobal == 2)
          process.StartInfo.FileName = "Tutorial_pl.pdf";
        process.Start();
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message);
      }
    }

    private void SaveDataForBack()
    {
      this.BackCtrlProgramsOptions[0] = (CtrlProgramOptionsClass) this.CtrlProgramsOptions[this.ProgSelected].Clone();
      this.VisibledBackButtons();
    }

    private void BackDataFromBack()
    {
      this.CtrlProgramsOptions[this.ProgSelected] = (CtrlProgramOptionsClass) this.BackCtrlProgramsOptions[0].Clone();
      this.UnVisibledBackButtons();
      this.ReDrawAllLists();
    }

    private void ReDrawAllLists()
    {
      this.ReDrawListOfHolidays();
      this.ReDrawListOfEventsExceptions();
      this.ReDrawListOfEventsYear();
      this.ReDrawListOfEventsMonth();
      this.ReDrawListOfEventsWeek();
      this.ReDrawListOfEventsDay();
    }

    private void UnVisibledBackButtons()
    {
      this.button43.Enabled = false;
      this.button44.Enabled = false;
      this.button45.Enabled = false;
      this.button46.Enabled = false;
      this.button47.Enabled = false;
      this.button48.Enabled = false;
    }

    private void VisibledBackButtons()
    {
      this.button43.Enabled = true;
      this.button44.Enabled = true;
      this.button45.Enabled = true;
      this.button46.Enabled = true;
      this.button47.Enabled = true;
      this.button48.Enabled = true;
    }

    private void button43_Click(object sender, EventArgs e)
    {
      this.BackDataFromBack();
    }

    private void button44_Click(object sender, EventArgs e)
    {
      this.BackDataFromBack();
    }

    private void button45_Click(object sender, EventArgs e)
    {
      this.BackDataFromBack();
    }

    private void button46_Click(object sender, EventArgs e)
    {
      this.BackDataFromBack();
    }

    private void button47_Click(object sender, EventArgs e)
    {
      this.BackDataFromBack();
    }

    private void button48_Click(object sender, EventArgs e)
    {
      this.BackDataFromBack();
    }

    private void Form1_MouseClick(object sender, MouseEventArgs e)
    {
      int num = (int) MessageBox.Show("Событие.", "Проверка!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
    }

    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
      switch (MessageBox.Show(this.stSaveSettingsInFile[this.LangGlobal], this.stExitProgram[this.LangGlobal], MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation))
      {
        case DialogResult.Cancel:
          e.Cancel = true;
          break;
        case DialogResult.Yes:
          if (this.PathOfFile == null)
          {
            this.SaveNewFile();
            break;
          }
          this.SaveFile();
          break;
        case DialogResult.No:
          e.Cancel = false;
          break;
      }
    }

    private void button49_Click(object sender, EventArgs e)
    {
      if (MessageBox.Show(string.Format(this.stResetProgramSettings1[this.LangGlobal], (object) this.ProgSelected), this.stResetProgramSettings2[this.LangGlobal], MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
        return;
      this.CtrlProgramsOptions[this.ProgSelected].ResetOptions();
      this.ReCalculateEventsInLists();
    }

    private void timer5_compDataInRelay_Tick(object sender, EventArgs e)
    {
      if (this.CtrlProgramsOptions.Compare(this.InRelayCtrlProgramsOptions) && this.DeviceOptions.Compare(this.InRelayDeviceOptions))
        this.label95.Visible = false;
      else
        this.label95.Visible = true;
    }

    private void SaveDataInRelay()
    {
      this.InRelayCtrlProgramsOptions.Clear();
      foreach (CtrlProgramOptionsClass ctrlProgramsOption in (CollectionBase) this.CtrlProgramsOptions)
        this.InRelayCtrlProgramsOptions.Add((CtrlProgramOptionsClass) ctrlProgramsOption.Clone());
      this.InRelayDeviceOptions = (DeviceOptionsClass) this.DeviceOptions.Clone();
      this.label95.Visible = false;
    }

    private void Form1_Load(object sender, EventArgs e)
    {
    }

    private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
    {
    }

    private void englishToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.SysSet.SetRegistryLang(SystemSettings.TypeLanguage.ENGLISH);
      this.englishToolStripMenuItem.Checked = true;
      this.polishToolStripMenuItem.Checked = false;
      this.russianToolStripMenuItem.Checked = false;
      if (this.SysSet.Lang == SystemSettings.TypeLanguage.ENGLISH)
        return;
      int num = (int) MessageBox.Show(this.stChangeLanguageMessage[this.LangGlobal], this.stWarning[this.LangGlobal], MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
    }

    private void polishToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.SysSet.SetRegistryLang(SystemSettings.TypeLanguage.POLISH);
      this.englishToolStripMenuItem.Checked = false;
      this.polishToolStripMenuItem.Checked = true;
      this.russianToolStripMenuItem.Checked = false;
      if (this.SysSet.Lang == SystemSettings.TypeLanguage.POLISH)
        return;
      int num = (int) MessageBox.Show(this.stChangeLanguageMessage[this.LangGlobal], this.stWarning[this.LangGlobal], MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
    }

    private void russianToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.SysSet.SetRegistryLang(SystemSettings.TypeLanguage.RUSSIAN);
      this.englishToolStripMenuItem.Checked = false;
      this.polishToolStripMenuItem.Checked = false;
      this.russianToolStripMenuItem.Checked = true;
      if (this.SysSet.Lang == SystemSettings.TypeLanguage.RUSSIAN)
        return;
      int num = (int) MessageBox.Show(this.stChangeLanguageMessage[this.LangGlobal], this.stWarning[this.LangGlobal], MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.components = (IContainer) new Container();
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (Form1));
      this.menuStrip1 = new MenuStrip();
      this.FileToolStripMenuItem = new ToolStripMenuItem();
      this.createToolStripMenuItem = new ToolStripMenuItem();
      this.openToolStripMenuItem = new ToolStripMenuItem();
      this.toolStripSeparator = new ToolStripSeparator();
      this.saveToolStripMenuItem = new ToolStripMenuItem();
      this.saveAsToolStripMenuItem = new ToolStripMenuItem();
      this.toolStripSeparator1 = new ToolStripSeparator();
      this.печатьToolStripMenuItem = new ToolStripMenuItem();
      this.предварительныйпросмотрToolStripMenuItem = new ToolStripMenuItem();
      this.toolStripSeparator2 = new ToolStripSeparator();
      this.exitToolStripMenuItem = new ToolStripMenuItem();
      this.relayToolStripMenuItem = new ToolStripMenuItem();
      this.readSettingsToolStripMenuItem = new ToolStripMenuItem();
      this.sendSettingsToolStripMenuItem = new ToolStripMenuItem();
      this.versionProgToolStripMenuItem = new ToolStripMenuItem();
      this.HelpToolStripMenuItem = new ToolStripMenuItem();
      this.contentsHelpToolStripMenuItem = new ToolStripMenuItem();
      this.aboutProgramToolStripMenuItem = new ToolStripMenuItem();
      this.toolStrip1 = new ToolStrip();
      this.createToolStripButton = new ToolStripButton();
      this.openToolStripButton = new ToolStripButton();
      this.saveToolStripButton = new ToolStripButton();
      this.печатьToolStripButton = new ToolStripButton();
      this.toolStripSeparator6 = new ToolStripSeparator();
      this.вырезатьToolStripButton = new ToolStripButton();
      this.копироватьToolStripButton = new ToolStripButton();
      this.вставкаToolStripButton = new ToolStripButton();
      this.toolStripSeparator7 = new ToolStripSeparator();
      this.helpToolStripButton = new ToolStripButton();
      this.treeView1 = new TreeView();
      this.statusStrip1 = new StatusStrip();
      this.tabControl1 = new TabControl();
      this.tabPage1 = new TabPage();
      this.button32 = new Button();
      this.label82 = new Label();
      this.button31 = new Button();
      this.button30 = new Button();
      this.button29 = new Button();
      this.label80 = new Label();
      this.button28 = new Button();
      this.label79 = new Label();
      this.button27 = new Button();
      this.button26 = new Button();
      this.label5 = new Label();
      this.label1 = new Label();
      this.label2 = new Label();
      this.label3 = new Label();
      this.listBox1 = new ListBox();
      this.button1 = new Button();
      this.tabPage1_ChannelMode = new TabPage();
      this.groupBox1 = new GroupBox();
      this.radioButton15 = new RadioButton();
      this.radioButton5 = new RadioButton();
      this.radioButton6 = new RadioButton();
      this.radioButton7 = new RadioButton();
      this.radioButton8 = new RadioButton();
      this.radioButton4 = new RadioButton();
      this.radioButton3 = new RadioButton();
      this.radioButton2 = new RadioButton();
      this.radioButton1 = new RadioButton();
      this.tabPage2_RtOptions = new TabPage();
      this.groupBox3 = new GroupBox();
      this.checkBox3 = new CheckBox();
      this.checkBox2 = new CheckBox();
      this.checkBox1 = new CheckBox();
      this.groupBox2 = new GroupBox();
      this.radioButton16 = new RadioButton();
      this.radioButton14 = new RadioButton();
      this.radioButton13 = new RadioButton();
      this.radioButton12 = new RadioButton();
      this.radioButton11 = new RadioButton();
      this.radioButton10 = new RadioButton();
      this.radioButton9 = new RadioButton();
      this.tabPage3_Empty = new TabPage();
      this.button49 = new Button();
      this.button42 = new Button();
      this.groupBox40 = new GroupBox();
      this.button39 = new Button();
      this.comboBox2 = new ComboBox();
      this.richTextBox1 = new RichTextBox();
      this.tabPage4_DayOffs = new TabPage();
      this.groupBox4 = new GroupBox();
      this.checkBox10 = new CheckBox();
      this.checkBox9 = new CheckBox();
      this.checkBox8 = new CheckBox();
      this.checkBox7 = new CheckBox();
      this.checkBox6 = new CheckBox();
      this.checkBox5 = new CheckBox();
      this.checkBox4 = new CheckBox();
      this.tabPage5_Holidays = new TabPage();
      this.groupBox5 = new GroupBox();
      this.button43 = new Button();
      this.button34 = new Button();
      this.listView1 = new ListView();
      this.columnHeader1 = new ColumnHeader();
      this.columnHeader2 = new ColumnHeader();
      this.columnHeader3 = new ColumnHeader();
      this.button4 = new Button();
      this.button3 = new Button();
      this.button2 = new Button();
      this.monthCalendar1 = new MonthCalendar();
      this.tabPage6_ExceptEvents = new TabPage();
      this.groupBox6 = new GroupBox();
      this.button44 = new Button();
      this.button36 = new Button();
      this.groupBox7 = new GroupBox();
      this.radioButton18 = new RadioButton();
      this.radioButton17 = new RadioButton();
      this.label10 = new Label();
      this.label9 = new Label();
      this.label8 = new Label();
      this.label7 = new Label();
      this.label6 = new Label();
      this.numericUpDown3 = new NumericUpDown();
      this.numericUpDown2 = new NumericUpDown();
      this.numericUpDown1 = new NumericUpDown();
      this.listView2 = new ListView();
      this.columnHeader4 = new ColumnHeader();
      this.columnHeader5 = new ColumnHeader();
      this.columnHeader6 = new ColumnHeader();
      this.button5 = new Button();
      this.button6 = new Button();
      this.button7 = new Button();
      this.tabPage7_Year = new TabPage();
      this.groupBox8 = new GroupBox();
      this.button45 = new Button();
      this.button24 = new Button();
      this.button23 = new Button();
      this.monthCalendar2 = new MonthCalendar();
      this.groupBox9 = new GroupBox();
      this.radioButton19 = new RadioButton();
      this.radioButton20 = new RadioButton();
      this.label11 = new Label();
      this.label12 = new Label();
      this.label13 = new Label();
      this.label14 = new Label();
      this.label15 = new Label();
      this.numericUpDown4 = new NumericUpDown();
      this.numericUpDown5 = new NumericUpDown();
      this.numericUpDown6 = new NumericUpDown();
      this.listView3 = new ListView();
      this.columnHeader7 = new ColumnHeader();
      this.columnHeader8 = new ColumnHeader();
      this.columnHeader9 = new ColumnHeader();
      this.columnHeader10 = new ColumnHeader();
      this.columnHeader11 = new ColumnHeader();
      this.button8 = new Button();
      this.button9 = new Button();
      this.button10 = new Button();
      this.tabPage8_Month = new TabPage();
      this.groupBox10 = new GroupBox();
      this.button46 = new Button();
      this.button25 = new Button();
      this.numericUpDown16 = new NumericUpDown();
      this.label21 = new Label();
      this.groupBox11 = new GroupBox();
      this.radioButton21 = new RadioButton();
      this.radioButton22 = new RadioButton();
      this.label16 = new Label();
      this.label17 = new Label();
      this.label18 = new Label();
      this.label19 = new Label();
      this.label20 = new Label();
      this.numericUpDown7 = new NumericUpDown();
      this.numericUpDown8 = new NumericUpDown();
      this.numericUpDown9 = new NumericUpDown();
      this.listView4 = new ListView();
      this.columnHeader12 = new ColumnHeader();
      this.columnHeader13 = new ColumnHeader();
      this.columnHeader15 = new ColumnHeader();
      this.columnHeader16 = new ColumnHeader();
      this.button11 = new Button();
      this.button12 = new Button();
      this.button13 = new Button();
      this.tabPage9_Week = new TabPage();
      this.groupBox12 = new GroupBox();
      this.button47 = new Button();
      this.button37 = new Button();
      this.comboBox1 = new ComboBox();
      this.label22 = new Label();
      this.listView5 = new ListView();
      this.columnHeader14 = new ColumnHeader();
      this.columnHeader17 = new ColumnHeader();
      this.columnHeader18 = new ColumnHeader();
      this.columnHeader19 = new ColumnHeader();
      this.groupBox13 = new GroupBox();
      this.radioButton23 = new RadioButton();
      this.radioButton24 = new RadioButton();
      this.label23 = new Label();
      this.label24 = new Label();
      this.label25 = new Label();
      this.label26 = new Label();
      this.label27 = new Label();
      this.numericUpDown12 = new NumericUpDown();
      this.numericUpDown13 = new NumericUpDown();
      this.numericUpDown14 = new NumericUpDown();
      this.button14 = new Button();
      this.button15 = new Button();
      this.button16 = new Button();
      this.tabPage10_Day = new TabPage();
      this.groupBox14 = new GroupBox();
      this.button48 = new Button();
      this.button38 = new Button();
      this.groupBox15 = new GroupBox();
      this.radioButton25 = new RadioButton();
      this.radioButton26 = new RadioButton();
      this.label28 = new Label();
      this.label29 = new Label();
      this.label30 = new Label();
      this.label31 = new Label();
      this.label32 = new Label();
      this.numericUpDown10 = new NumericUpDown();
      this.numericUpDown11 = new NumericUpDown();
      this.numericUpDown15 = new NumericUpDown();
      this.listView6 = new ListView();
      this.columnHeader20 = new ColumnHeader();
      this.columnHeader21 = new ColumnHeader();
      this.columnHeader22 = new ColumnHeader();
      this.button17 = new Button();
      this.button18 = new Button();
      this.button19 = new Button();
      this.tabPage11_ImpulseRelay = new TabPage();
      this.groupBox16 = new GroupBox();
      this.groupBox19 = new GroupBox();
      this.label39 = new Label();
      this.numericUpDown21 = new NumericUpDown();
      this.label40 = new Label();
      this.label41 = new Label();
      this.numericUpDown22 = new NumericUpDown();
      this.groupBox18 = new GroupBox();
      this.label36 = new Label();
      this.numericUpDown19 = new NumericUpDown();
      this.label37 = new Label();
      this.label38 = new Label();
      this.numericUpDown20 = new NumericUpDown();
      this.groupBox17 = new GroupBox();
      this.label35 = new Label();
      this.numericUpDown18 = new NumericUpDown();
      this.label34 = new Label();
      this.label33 = new Label();
      this.numericUpDown17 = new NumericUpDown();
      this.tabPage12_SimpleRelay = new TabPage();
      this.groupBox20 = new GroupBox();
      this.groupBox23 = new GroupBox();
      this.label48 = new Label();
      this.numericUpDown27 = new NumericUpDown();
      this.label49 = new Label();
      this.label50 = new Label();
      this.numericUpDown28 = new NumericUpDown();
      this.tabPage14_RV = new TabPage();
      this.groupBox21 = new GroupBox();
      this.groupBox36 = new GroupBox();
      this.numericUpDown45 = new NumericUpDown();
      this.label71 = new Label();
      this.numericUpDown46 = new NumericUpDown();
      this.label72 = new Label();
      this.groupBox28 = new GroupBox();
      this.label55 = new Label();
      this.numericUpDown33 = new NumericUpDown();
      this.label56 = new Label();
      this.label57 = new Label();
      this.numericUpDown34 = new NumericUpDown();
      this.groupBox27 = new GroupBox();
      this.label52 = new Label();
      this.numericUpDown31 = new NumericUpDown();
      this.label53 = new Label();
      this.label54 = new Label();
      this.numericUpDown32 = new NumericUpDown();
      this.groupBox26 = new GroupBox();
      this.label46 = new Label();
      this.numericUpDown29 = new NumericUpDown();
      this.label47 = new Label();
      this.label51 = new Label();
      this.numericUpDown30 = new NumericUpDown();
      this.groupBox25 = new GroupBox();
      this.numericUpDown25 = new NumericUpDown();
      this.label44 = new Label();
      this.numericUpDown26 = new NumericUpDown();
      this.label45 = new Label();
      this.groupBox22 = new GroupBox();
      this.radioButton27 = new RadioButton();
      this.radioButton33 = new RadioButton();
      this.tabPage15_RF = new TabPage();
      this.groupBox29 = new GroupBox();
      this.groupBox24 = new GroupBox();
      this.numericUpDown24 = new NumericUpDown();
      this.label43 = new Label();
      this.numericUpDown23 = new NumericUpDown();
      this.label42 = new Label();
      this.groupBox30 = new GroupBox();
      this.radioButton36 = new RadioButton();
      this.radioButton39 = new RadioButton();
      this.radioButton37 = new RadioButton();
      this.radioButton40 = new RadioButton();
      this.radioButton38 = new RadioButton();
      this.groupBox31 = new GroupBox();
      this.label61 = new Label();
      this.numericUpDown37 = new NumericUpDown();
      this.label62 = new Label();
      this.label63 = new Label();
      this.numericUpDown38 = new NumericUpDown();
      this.groupBox32 = new GroupBox();
      this.label64 = new Label();
      this.numericUpDown39 = new NumericUpDown();
      this.label65 = new Label();
      this.label66 = new Label();
      this.numericUpDown40 = new NumericUpDown();
      this.groupBox33 = new GroupBox();
      this.radioButton30 = new RadioButton();
      this.radioButton35 = new RadioButton();
      this.radioButton31 = new RadioButton();
      this.radioButton34 = new RadioButton();
      this.radioButton32 = new RadioButton();
      this.groupBox35 = new GroupBox();
      this.radioButton28 = new RadioButton();
      this.radioButton29 = new RadioButton();
      this.tabPage16_Options = new TabPage();
      this.groupBox42 = new GroupBox();
      this.checkBox12 = new CheckBox();
      this.groupBox43 = new GroupBox();
      this.label76 = new Label();
      this.numericUpDown41 = new NumericUpDown();
      this.label77 = new Label();
      this.label78 = new Label();
      this.numericUpDown42 = new NumericUpDown();
      this.tabPage2_Time = new TabPage();
      this.groupBox34 = new GroupBox();
      this.groupBox39 = new GroupBox();
      this.label59 = new Label();
      this.dateTimePicker5 = new DateTimePicker();
      this.button21 = new Button();
      this.dateTimePicker6 = new DateTimePicker();
      this.groupBox38 = new GroupBox();
      this.button22 = new Button();
      this.label67 = new Label();
      this.label60 = new Label();
      this.groupBox37 = new GroupBox();
      this.label68 = new Label();
      this.label58 = new Label();
      this.label69 = new Label();
      this.button20 = new Button();
      this.tabPage3_VoltBright = new TabPage();
      this.groupBox44 = new GroupBox();
      this.groupBox41 = new GroupBox();
      this.numericUpDown35 = new NumericUpDown();
      this.label98 = new Label();
      this.label97 = new Label();
      this.button41 = new Button();
      this.textBox1 = new TextBox();
      this.label94 = new Label();
      this.label96 = new Label();
      this.label74 = new Label();
      this.label75 = new Label();
      this.label91 = new Label();
      this.button40 = new Button();
      this.label92 = new Label();
      this.label93 = new Label();
      this.groupBox45 = new GroupBox();
      this.label73 = new Label();
      this.label83 = new Label();
      this.label84 = new Label();
      this.button33 = new Button();
      this.label85 = new Label();
      this.label86 = new Label();
      this.numericUpDown43 = new NumericUpDown();
      this.groupBox46 = new GroupBox();
      this.label70 = new Label();
      this.label87 = new Label();
      this.label88 = new Label();
      this.button35 = new Button();
      this.label89 = new Label();
      this.label90 = new Label();
      this.numericUpDown44 = new NumericUpDown();
      this.tabPage2_RTcom = new TabPage();
      this.richTextBox2 = new RichTextBox();
      this.tabPage2_Except = new TabPage();
      this.richTextBox3 = new RichTextBox();
      this.panel1 = new Panel();
      this.label4 = new Label();
      this.usb = new UsbHidPort(this.components);
      this.openFileDialog1 = new OpenFileDialog();
      this.saveFileDialog1 = new SaveFileDialog();
      this.progressBar1 = new ProgressBar();
      this.label81 = new Label();
      this.timer1 = new Timer(this.components);
      this.timer2 = new Timer(this.components);
      this.timer3 = new Timer(this.components);
      this.timer4 = new Timer(this.components);
      this.label95 = new Label();
      this.timer5_compDataInRelay = new Timer(this.components);
      this.languageToolStripMenuItem = new ToolStripMenuItem();
      this.englishToolStripMenuItem = new ToolStripMenuItem();
      this.polishToolStripMenuItem = new ToolStripMenuItem();
      this.russianToolStripMenuItem = new ToolStripMenuItem();
      this.menuStrip1.SuspendLayout();
      this.toolStrip1.SuspendLayout();
      this.tabControl1.SuspendLayout();
      this.tabPage1.SuspendLayout();
      this.tabPage1_ChannelMode.SuspendLayout();
      this.groupBox1.SuspendLayout();
      this.tabPage2_RtOptions.SuspendLayout();
      this.groupBox3.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.tabPage3_Empty.SuspendLayout();
      this.groupBox40.SuspendLayout();
      this.tabPage4_DayOffs.SuspendLayout();
      this.groupBox4.SuspendLayout();
      this.tabPage5_Holidays.SuspendLayout();
      this.groupBox5.SuspendLayout();
      this.tabPage6_ExceptEvents.SuspendLayout();
      this.groupBox6.SuspendLayout();
      this.groupBox7.SuspendLayout();
      this.numericUpDown3.BeginInit();
      this.numericUpDown2.BeginInit();
      this.numericUpDown1.BeginInit();
      this.tabPage7_Year.SuspendLayout();
      this.groupBox8.SuspendLayout();
      this.groupBox9.SuspendLayout();
      this.numericUpDown4.BeginInit();
      this.numericUpDown5.BeginInit();
      this.numericUpDown6.BeginInit();
      this.tabPage8_Month.SuspendLayout();
      this.groupBox10.SuspendLayout();
      this.numericUpDown16.BeginInit();
      this.groupBox11.SuspendLayout();
      this.numericUpDown7.BeginInit();
      this.numericUpDown8.BeginInit();
      this.numericUpDown9.BeginInit();
      this.tabPage9_Week.SuspendLayout();
      this.groupBox12.SuspendLayout();
      this.groupBox13.SuspendLayout();
      this.numericUpDown12.BeginInit();
      this.numericUpDown13.BeginInit();
      this.numericUpDown14.BeginInit();
      this.tabPage10_Day.SuspendLayout();
      this.groupBox14.SuspendLayout();
      this.groupBox15.SuspendLayout();
      this.numericUpDown10.BeginInit();
      this.numericUpDown11.BeginInit();
      this.numericUpDown15.BeginInit();
      this.tabPage11_ImpulseRelay.SuspendLayout();
      this.groupBox16.SuspendLayout();
      this.groupBox19.SuspendLayout();
      this.numericUpDown21.BeginInit();
      this.numericUpDown22.BeginInit();
      this.groupBox18.SuspendLayout();
      this.numericUpDown19.BeginInit();
      this.numericUpDown20.BeginInit();
      this.groupBox17.SuspendLayout();
      this.numericUpDown18.BeginInit();
      this.numericUpDown17.BeginInit();
      this.tabPage12_SimpleRelay.SuspendLayout();
      this.groupBox20.SuspendLayout();
      this.groupBox23.SuspendLayout();
      this.numericUpDown27.BeginInit();
      this.numericUpDown28.BeginInit();
      this.tabPage14_RV.SuspendLayout();
      this.groupBox21.SuspendLayout();
      this.groupBox36.SuspendLayout();
      this.numericUpDown45.BeginInit();
      this.numericUpDown46.BeginInit();
      this.groupBox28.SuspendLayout();
      this.numericUpDown33.BeginInit();
      this.numericUpDown34.BeginInit();
      this.groupBox27.SuspendLayout();
      this.numericUpDown31.BeginInit();
      this.numericUpDown32.BeginInit();
      this.groupBox26.SuspendLayout();
      this.numericUpDown29.BeginInit();
      this.numericUpDown30.BeginInit();
      this.groupBox25.SuspendLayout();
      this.numericUpDown25.BeginInit();
      this.numericUpDown26.BeginInit();
      this.groupBox22.SuspendLayout();
      this.tabPage15_RF.SuspendLayout();
      this.groupBox29.SuspendLayout();
      this.groupBox24.SuspendLayout();
      this.numericUpDown24.BeginInit();
      this.numericUpDown23.BeginInit();
      this.groupBox30.SuspendLayout();
      this.groupBox31.SuspendLayout();
      this.numericUpDown37.BeginInit();
      this.numericUpDown38.BeginInit();
      this.groupBox32.SuspendLayout();
      this.numericUpDown39.BeginInit();
      this.numericUpDown40.BeginInit();
      this.groupBox33.SuspendLayout();
      this.groupBox35.SuspendLayout();
      this.tabPage16_Options.SuspendLayout();
      this.groupBox42.SuspendLayout();
      this.groupBox43.SuspendLayout();
      this.numericUpDown41.BeginInit();
      this.numericUpDown42.BeginInit();
      this.tabPage2_Time.SuspendLayout();
      this.groupBox34.SuspendLayout();
      this.groupBox39.SuspendLayout();
      this.groupBox38.SuspendLayout();
      this.groupBox37.SuspendLayout();
      this.tabPage3_VoltBright.SuspendLayout();
      this.groupBox44.SuspendLayout();
      this.groupBox41.SuspendLayout();
      this.numericUpDown35.BeginInit();
      this.groupBox45.SuspendLayout();
      this.numericUpDown43.BeginInit();
      this.groupBox46.SuspendLayout();
      this.numericUpDown44.BeginInit();
      this.tabPage2_RTcom.SuspendLayout();
      this.tabPage2_Except.SuspendLayout();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      this.menuStrip1.BackColor = SystemColors.Control;
      this.menuStrip1.Items.AddRange(new ToolStripItem[4]
      {
        (ToolStripItem) this.FileToolStripMenuItem,
        (ToolStripItem) this.relayToolStripMenuItem,
        (ToolStripItem) this.languageToolStripMenuItem,
        (ToolStripItem) this.HelpToolStripMenuItem
      });
      this.menuStrip1.Location = new Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Size = new Size(835, 24);
      this.menuStrip1.TabIndex = 0;
      this.menuStrip1.Text = "menuStrip1";
      this.FileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[10]
      {
        (ToolStripItem) this.createToolStripMenuItem,
        (ToolStripItem) this.openToolStripMenuItem,
        (ToolStripItem) this.toolStripSeparator,
        (ToolStripItem) this.saveToolStripMenuItem,
        (ToolStripItem) this.saveAsToolStripMenuItem,
        (ToolStripItem) this.toolStripSeparator1,
        (ToolStripItem) this.печатьToolStripMenuItem,
        (ToolStripItem) this.предварительныйпросмотрToolStripMenuItem,
        (ToolStripItem) this.toolStripSeparator2,
        (ToolStripItem) this.exitToolStripMenuItem
      });
      this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
      this.FileToolStripMenuItem.Size = new Size(45, 20);
      this.FileToolStripMenuItem.Text = "&Файл";
      this.createToolStripMenuItem.Image = (Image) componentResourceManager.GetObject("createToolStripMenuItem.Image");
      this.createToolStripMenuItem.ImageTransparentColor = Color.Magenta;
      this.createToolStripMenuItem.Name = "createToolStripMenuItem";
      this.createToolStripMenuItem.ShortcutKeys = Keys.N | Keys.Control;
      this.createToolStripMenuItem.Size = new Size(218, 22);
      this.createToolStripMenuItem.Text = "&Новый";
      this.createToolStripMenuItem.Click += new EventHandler(this.создатьToolStripButton_Click);
      this.openToolStripMenuItem.Image = (Image) componentResourceManager.GetObject("openToolStripMenuItem.Image");
      this.openToolStripMenuItem.ImageTransparentColor = Color.Magenta;
      this.openToolStripMenuItem.Name = "openToolStripMenuItem";
      this.openToolStripMenuItem.ShortcutKeys = Keys.O | Keys.Control;
      this.openToolStripMenuItem.Size = new Size(218, 22);
      this.openToolStripMenuItem.Text = "&Открыть";
      this.openToolStripMenuItem.Click += new EventHandler(this.OpenToolStripMenuItem_Click);
      this.toolStripSeparator.Name = "toolStripSeparator";
      this.toolStripSeparator.Size = new Size(215, 6);
      this.saveToolStripMenuItem.Image = (Image) componentResourceManager.GetObject("saveToolStripMenuItem.Image");
      this.saveToolStripMenuItem.ImageTransparentColor = Color.Magenta;
      this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
      this.saveToolStripMenuItem.ShortcutKeys = Keys.S | Keys.Control;
      this.saveToolStripMenuItem.Size = new Size(218, 22);
      this.saveToolStripMenuItem.Text = "&Сохранить";
      this.saveToolStripMenuItem.Click += new EventHandler(this.сохранитьToolStripMenuItem_Click);
      this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
      this.saveAsToolStripMenuItem.Size = new Size(218, 22);
      this.saveAsToolStripMenuItem.Text = "Сохранить &как...";
      this.saveAsToolStripMenuItem.Click += new EventHandler(this.SaveAsToolStripMenuItem_Click);
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new Size(215, 6);
      this.toolStripSeparator1.Visible = false;
      this.печатьToolStripMenuItem.Image = (Image) componentResourceManager.GetObject("печатьToolStripMenuItem.Image");
      this.печатьToolStripMenuItem.ImageTransparentColor = Color.Magenta;
      this.печатьToolStripMenuItem.Name = "печатьToolStripMenuItem";
      this.печатьToolStripMenuItem.ShortcutKeys = Keys.P | Keys.Control;
      this.печатьToolStripMenuItem.Size = new Size(218, 22);
      this.печатьToolStripMenuItem.Text = "&Печать";
      this.печатьToolStripMenuItem.Visible = false;
      this.предварительныйпросмотрToolStripMenuItem.Image = (Image) componentResourceManager.GetObject("предварительныйпросмотрToolStripMenuItem.Image");
      this.предварительныйпросмотрToolStripMenuItem.ImageTransparentColor = Color.Magenta;
      this.предварительныйпросмотрToolStripMenuItem.Name = "предварительныйпросмотрToolStripMenuItem";
      this.предварительныйпросмотрToolStripMenuItem.Size = new Size(218, 22);
      this.предварительныйпросмотрToolStripMenuItem.Text = "Предварительный про&смотр";
      this.предварительныйпросмотрToolStripMenuItem.Visible = false;
      this.toolStripSeparator2.Name = "toolStripSeparator2";
      this.toolStripSeparator2.Size = new Size(215, 6);
      this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
      this.exitToolStripMenuItem.Size = new Size(218, 22);
      this.exitToolStripMenuItem.Text = "Вы&ход";
      this.exitToolStripMenuItem.Click += new EventHandler(this.выходToolStripMenuItem_Click);
      this.relayToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[3]
      {
        (ToolStripItem) this.readSettingsToolStripMenuItem,
        (ToolStripItem) this.sendSettingsToolStripMenuItem,
        (ToolStripItem) this.versionProgToolStripMenuItem
      });
      this.relayToolStripMenuItem.Name = "relayToolStripMenuItem";
      this.relayToolStripMenuItem.Size = new Size(43, 20);
      this.relayToolStripMenuItem.Text = "&Реле";
      this.readSettingsToolStripMenuItem.Name = "readSettingsToolStripMenuItem";
      this.readSettingsToolStripMenuItem.Size = new Size(177, 22);
      this.readSettingsToolStripMenuItem.Text = "Считать настройки";
      this.readSettingsToolStripMenuItem.Click += new EventHandler(this.настройкиToolStripMenuItem_Click);
      this.sendSettingsToolStripMenuItem.Name = "sendSettingsToolStripMenuItem";
      this.sendSettingsToolStripMenuItem.Size = new Size(177, 22);
      this.sendSettingsToolStripMenuItem.Text = "Записать настройки";
      this.sendSettingsToolStripMenuItem.Click += new EventHandler(this.SendToolStripMenuItem_Click);
      this.versionProgToolStripMenuItem.Name = "versionProgToolStripMenuItem";
      this.versionProgToolStripMenuItem.Size = new Size(177, 22);
      this.versionProgToolStripMenuItem.Text = "Версия программы";
      this.versionProgToolStripMenuItem.Click += new EventHandler(this.VersionProgToolStripMenuItem_Click);
      this.HelpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[2]
      {
        (ToolStripItem) this.contentsHelpToolStripMenuItem,
        (ToolStripItem) this.aboutProgramToolStripMenuItem
      });
      this.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem";
      this.HelpToolStripMenuItem.Size = new Size(62, 20);
      this.HelpToolStripMenuItem.Text = "Спра&вка";
      this.contentsHelpToolStripMenuItem.Name = "contentsHelpToolStripMenuItem";
      this.contentsHelpToolStripMenuItem.ShortcutKeys = Keys.F1;
      this.contentsHelpToolStripMenuItem.Size = new Size(157, 22);
      this.contentsHelpToolStripMenuItem.Text = "&Содержание";
      this.contentsHelpToolStripMenuItem.Click += new EventHandler(this.содержаниеToolStripMenuItem_Click);
      this.aboutProgramToolStripMenuItem.Name = "aboutProgramToolStripMenuItem";
      this.aboutProgramToolStripMenuItem.Size = new Size(157, 22);
      this.aboutProgramToolStripMenuItem.Text = "&О программе...";
      this.aboutProgramToolStripMenuItem.Click += new EventHandler(this.опрограммеToolStripMenuItem_Click);
      this.toolStrip1.BackColor = SystemColors.Control;
      this.toolStrip1.Items.AddRange(new ToolStripItem[10]
      {
        (ToolStripItem) this.createToolStripButton,
        (ToolStripItem) this.openToolStripButton,
        (ToolStripItem) this.saveToolStripButton,
        (ToolStripItem) this.печатьToolStripButton,
        (ToolStripItem) this.toolStripSeparator6,
        (ToolStripItem) this.вырезатьToolStripButton,
        (ToolStripItem) this.копироватьToolStripButton,
        (ToolStripItem) this.вставкаToolStripButton,
        (ToolStripItem) this.toolStripSeparator7,
        (ToolStripItem) this.helpToolStripButton
      });
      this.toolStrip1.Location = new Point(0, 24);
      this.toolStrip1.Name = "toolStrip1";
      this.toolStrip1.Size = new Size(835, 25);
      this.toolStrip1.TabIndex = 1;
      this.toolStrip1.Text = "toolStrip1";
      this.createToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.createToolStripButton.Image = (Image) componentResourceManager.GetObject("createToolStripButton.Image");
      this.createToolStripButton.ImageTransparentColor = Color.Magenta;
      this.createToolStripButton.Name = "createToolStripButton";
      this.createToolStripButton.Size = new Size(23, 22);
      this.createToolStripButton.Text = "&Создать";
      this.createToolStripButton.Click += new EventHandler(this.создатьToolStripButton_Click);
      this.openToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.openToolStripButton.Image = (Image) componentResourceManager.GetObject("openToolStripButton.Image");
      this.openToolStripButton.ImageTransparentColor = Color.Magenta;
      this.openToolStripButton.Name = "openToolStripButton";
      this.openToolStripButton.Size = new Size(23, 22);
      this.openToolStripButton.Text = "&Открыть";
      this.openToolStripButton.Click += new EventHandler(this.OpenToolStripButton_Click);
      this.saveToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.saveToolStripButton.Image = (Image) componentResourceManager.GetObject("saveToolStripButton.Image");
      this.saveToolStripButton.ImageTransparentColor = Color.Magenta;
      this.saveToolStripButton.Name = "saveToolStripButton";
      this.saveToolStripButton.Size = new Size(23, 22);
      this.saveToolStripButton.Text = "&Сохранить";
      this.saveToolStripButton.Click += new EventHandler(this.SaveToolStripButton_Click);
      this.печатьToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.печатьToolStripButton.Image = (Image) componentResourceManager.GetObject("печатьToolStripButton.Image");
      this.печатьToolStripButton.ImageTransparentColor = Color.Magenta;
      this.печатьToolStripButton.Name = "печатьToolStripButton";
      this.печатьToolStripButton.Size = new Size(23, 22);
      this.печатьToolStripButton.Text = "&Печать";
      this.печатьToolStripButton.Visible = false;
      this.toolStripSeparator6.Name = "toolStripSeparator6";
      this.toolStripSeparator6.Size = new Size(6, 25);
      this.вырезатьToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.вырезатьToolStripButton.Image = (Image) componentResourceManager.GetObject("вырезатьToolStripButton.Image");
      this.вырезатьToolStripButton.ImageTransparentColor = Color.Magenta;
      this.вырезатьToolStripButton.Name = "вырезатьToolStripButton";
      this.вырезатьToolStripButton.Size = new Size(23, 22);
      this.вырезатьToolStripButton.Text = "В&ырезать";
      this.вырезатьToolStripButton.Visible = false;
      this.копироватьToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.копироватьToolStripButton.Image = (Image) componentResourceManager.GetObject("копироватьToolStripButton.Image");
      this.копироватьToolStripButton.ImageTransparentColor = Color.Magenta;
      this.копироватьToolStripButton.Name = "копироватьToolStripButton";
      this.копироватьToolStripButton.Size = new Size(23, 22);
      this.копироватьToolStripButton.Text = "&Копировать";
      this.копироватьToolStripButton.Visible = false;
      this.вставкаToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.вставкаToolStripButton.Image = (Image) componentResourceManager.GetObject("вставкаToolStripButton.Image");
      this.вставкаToolStripButton.ImageTransparentColor = Color.Magenta;
      this.вставкаToolStripButton.Name = "вставкаToolStripButton";
      this.вставкаToolStripButton.Size = new Size(23, 22);
      this.вставкаToolStripButton.Text = "Вст&авка";
      this.вставкаToolStripButton.Visible = false;
      this.toolStripSeparator7.Name = "toolStripSeparator7";
      this.toolStripSeparator7.Size = new Size(6, 25);
      this.toolStripSeparator7.Visible = false;
      this.helpToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.helpToolStripButton.Image = (Image) componentResourceManager.GetObject("helpToolStripButton.Image");
      this.helpToolStripButton.ImageTransparentColor = Color.Magenta;
      this.helpToolStripButton.Name = "helpToolStripButton";
      this.helpToolStripButton.Size = new Size(23, 22);
      this.helpToolStripButton.Text = "Спр&авка";
      this.helpToolStripButton.Click += new EventHandler(this.справкаToolStripButton_Click);
      this.treeView1.BackColor = SystemColors.Control;
      this.treeView1.Font = new Font("Microsoft Sans Serif", 8f);
      this.treeView1.HideSelection = false;
      this.treeView1.Location = new Point(0, 49);
      this.treeView1.Name = "treeView1";
      this.treeView1.Size = new Size(283, 569);
      this.treeView1.TabIndex = 2;
      this.treeView1.AfterSelect += new TreeViewEventHandler(this.treeView1_AfterSelect);
      this.statusStrip1.BackColor = SystemColors.Control;
      this.statusStrip1.Location = new Point(0, 621);
      this.statusStrip1.Name = "statusStrip1";
      this.statusStrip1.Size = new Size(835, 22);
      this.statusStrip1.SizingGrip = false;
      this.statusStrip1.TabIndex = 7;
      this.statusStrip1.Text = "statusStrip1";
      this.tabControl1.Controls.Add((Control) this.tabPage1);
      this.tabControl1.Controls.Add((Control) this.tabPage1_ChannelMode);
      this.tabControl1.Controls.Add((Control) this.tabPage2_RtOptions);
      this.tabControl1.Controls.Add((Control) this.tabPage3_Empty);
      this.tabControl1.Controls.Add((Control) this.tabPage4_DayOffs);
      this.tabControl1.Controls.Add((Control) this.tabPage5_Holidays);
      this.tabControl1.Controls.Add((Control) this.tabPage6_ExceptEvents);
      this.tabControl1.Controls.Add((Control) this.tabPage7_Year);
      this.tabControl1.Controls.Add((Control) this.tabPage8_Month);
      this.tabControl1.Controls.Add((Control) this.tabPage9_Week);
      this.tabControl1.Controls.Add((Control) this.tabPage10_Day);
      this.tabControl1.Controls.Add((Control) this.tabPage11_ImpulseRelay);
      this.tabControl1.Controls.Add((Control) this.tabPage12_SimpleRelay);
      this.tabControl1.Controls.Add((Control) this.tabPage14_RV);
      this.tabControl1.Controls.Add((Control) this.tabPage15_RF);
      this.tabControl1.Controls.Add((Control) this.tabPage16_Options);
      this.tabControl1.Controls.Add((Control) this.tabPage2_Time);
      this.tabControl1.Controls.Add((Control) this.tabPage3_VoltBright);
      this.tabControl1.Controls.Add((Control) this.tabPage2_RTcom);
      this.tabControl1.Controls.Add((Control) this.tabPage2_Except);
      this.tabControl1.Location = new Point(285, 86);
      this.tabControl1.Name = "tabControl1";
      this.tabControl1.SelectedIndex = 0;
      this.tabControl1.Size = new Size(550, 532);
      this.tabControl1.TabIndex = 5;
      this.tabControl1.TabStop = false;
      this.tabPage1.BackColor = SystemColors.Control;
      this.tabPage1.Controls.Add((Control) this.button32);
      this.tabPage1.Controls.Add((Control) this.label82);
      this.tabPage1.Controls.Add((Control) this.button31);
      this.tabPage1.Controls.Add((Control) this.button30);
      this.tabPage1.Controls.Add((Control) this.button29);
      this.tabPage1.Controls.Add((Control) this.label80);
      this.tabPage1.Controls.Add((Control) this.button28);
      this.tabPage1.Controls.Add((Control) this.label79);
      this.tabPage1.Controls.Add((Control) this.button27);
      this.tabPage1.Controls.Add((Control) this.button26);
      this.tabPage1.Controls.Add((Control) this.label5);
      this.tabPage1.Controls.Add((Control) this.label1);
      this.tabPage1.Controls.Add((Control) this.label2);
      this.tabPage1.Controls.Add((Control) this.label3);
      this.tabPage1.Controls.Add((Control) this.listBox1);
      this.tabPage1.Controls.Add((Control) this.button1);
      this.tabPage1.Location = new Point(4, 22);
      this.tabPage1.Name = "tabPage1";
      this.tabPage1.Padding = new Padding(3);
      this.tabPage1.Size = new Size(542, 506);
      this.tabPage1.TabIndex = 14;
      this.tabPage1.Text = "tabPage1";
      this.button32.Location = new Point(350, 275);
      this.button32.Name = "button32";
      this.button32.Size = new Size(108, 27);
      this.button32.TabIndex = 16;
      this.button32.Text = "Add Items";
      this.button32.UseVisualStyleBackColor = true;
      this.button32.Click += new EventHandler(this.button32_Click);
      this.label82.AutoSize = true;
      this.label82.Location = new Point(373, 53);
      this.label82.Name = "label82";
      this.label82.Size = new Size(41, 13);
      this.label82.TabIndex = 15;
      this.label82.Text = "label82";
      this.button31.Location = new Point(348, 200);
      this.button31.Name = "button31";
      this.button31.Size = new Size(107, 26);
      this.button31.TabIndex = 14;
      this.button31.Text = "Test2";
      this.button31.UseVisualStyleBackColor = true;
      this.button31.Click += new EventHandler(this.button31_Click);
      this.button30.Location = new Point(348, 232);
      this.button30.Name = "button30";
      this.button30.Size = new Size(111, 23);
      this.button30.TabIndex = 13;
      this.button30.Text = "Send 127";
      this.button30.UseVisualStyleBackColor = true;
      this.button30.Click += new EventHandler(this.button30_Click);
      this.button29.Location = new Point(348, 168);
      this.button29.Name = "button29";
      this.button29.Size = new Size(111, 26);
      this.button29.TabIndex = 12;
      this.button29.Text = "Clear List";
      this.button29.UseVisualStyleBackColor = true;
      this.button29.Click += new EventHandler(this.button29_Click);
      this.label80.AutoSize = true;
      this.label80.Location = new Point(373, 25);
      this.label80.Name = "label80";
      this.label80.Size = new Size(41, 13);
      this.label80.TabIndex = 11;
      this.label80.Text = "label80";
      this.button28.Location = new Point(348, 134);
      this.button28.Name = "button28";
      this.button28.Size = new Size(102, 28);
      this.button28.TabIndex = 10;
      this.button28.Text = "Test";
      this.button28.UseVisualStyleBackColor = true;
      this.button28.Click += new EventHandler(this.button28_Click);
      this.label79.AutoSize = true;
      this.label79.Location = new Point(37, 112);
      this.label79.Name = "label79";
      this.label79.Size = new Size(41, 13);
      this.label79.TabIndex = 9;
      this.label79.Text = "label79";
      this.button27.Location = new Point(236, 90);
      this.button27.Name = "button27";
      this.button27.Size = new Size(95, 31);
      this.button27.TabIndex = 8;
      this.button27.Text = "Send";
      this.button27.UseVisualStyleBackColor = true;
      this.button27.Click += new EventHandler(this.button27_Click);
      this.button26.Location = new Point(236, 25);
      this.button26.Name = "button26";
      this.button26.Size = new Size(95, 31);
      this.button26.TabIndex = 7;
      this.button26.Text = "Get";
      this.button26.UseVisualStyleBackColor = true;
      this.button26.Click += new EventHandler(this.button26_Click);
      this.label5.AutoSize = true;
      this.label5.Location = new Point(37, 90);
      this.label5.Name = "label5";
      this.label5.Size = new Size(35, 13);
      this.label5.TabIndex = 6;
      this.label5.Text = "label5";
      this.label1.AutoSize = true;
      this.label1.Location = new Point(37, 14);
      this.label1.Name = "label1";
      this.label1.Size = new Size(35, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "label1";
      this.label2.AutoSize = true;
      this.label2.Location = new Point(37, 42);
      this.label2.Name = "label2";
      this.label2.Size = new Size(35, 13);
      this.label2.TabIndex = 1;
      this.label2.Text = "label2";
      this.label3.AutoSize = true;
      this.label3.Location = new Point(37, 70);
      this.label3.Name = "label3";
      this.label3.Size = new Size(35, 13);
      this.label3.TabIndex = 2;
      this.label3.Text = "label3";
      this.listBox1.FormattingEnabled = true;
      this.listBox1.Location = new Point(6, 141);
      this.listBox1.Name = "listBox1";
      this.listBox1.Size = new Size(210, 238);
      this.listBox1.TabIndex = 4;
      this.button1.Location = new Point(348, 97);
      this.button1.Name = "button1";
      this.button1.Size = new Size(111, 31);
      this.button1.TabIndex = 3;
      this.button1.Text = "Check Connection";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new EventHandler(this.button1_Click);
      this.tabPage1_ChannelMode.BackColor = SystemColors.Control;
      this.tabPage1_ChannelMode.Controls.Add((Control) this.groupBox1);
      this.tabPage1_ChannelMode.Location = new Point(4, 22);
      this.tabPage1_ChannelMode.Name = "tabPage1_ChannelMode";
      this.tabPage1_ChannelMode.Padding = new Padding(3);
      this.tabPage1_ChannelMode.Size = new Size(542, 506);
      this.tabPage1_ChannelMode.TabIndex = 0;
      this.tabPage1_ChannelMode.Text = "ChMode";
      this.groupBox1.Controls.Add((Control) this.radioButton15);
      this.groupBox1.Controls.Add((Control) this.radioButton5);
      this.groupBox1.Controls.Add((Control) this.radioButton6);
      this.groupBox1.Controls.Add((Control) this.radioButton7);
      this.groupBox1.Controls.Add((Control) this.radioButton8);
      this.groupBox1.Controls.Add((Control) this.radioButton4);
      this.groupBox1.Controls.Add((Control) this.radioButton3);
      this.groupBox1.Controls.Add((Control) this.radioButton2);
      this.groupBox1.Controls.Add((Control) this.radioButton1);
      this.groupBox1.Location = new Point(6, 8);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new Size(530, 489);
      this.groupBox1.TabIndex = 1;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Выберите программу для управления контактами канала К1:";
      this.radioButton15.AutoSize = true;
      this.radioButton15.Location = new Point(45, 61);
      this.radioButton15.Name = "radioButton15";
      this.radioButton15.Size = new Size(75, 17);
      this.radioButton15.TabIndex = 8;
      this.radioButton15.TabStop = true;
      this.radioButton15.Text = "Отключен";
      this.radioButton15.UseVisualStyleBackColor = true;
      this.radioButton15.Click += new EventHandler(this.radioButton15_Click);
      this.radioButton5.AutoSize = true;
      this.radioButton5.Location = new Point(45, 281);
      this.radioButton5.Name = "radioButton5";
      this.radioButton5.Size = new Size(101, 17);
      this.radioButton5.TabIndex = 7;
      this.radioButton5.TabStop = true;
      this.radioButton5.Text = "Программа П5";
      this.radioButton5.UseVisualStyleBackColor = true;
      this.radioButton5.Click += new EventHandler(this.radioButton5_Click);
      this.radioButton6.AutoSize = true;
      this.radioButton6.Location = new Point(45, 325);
      this.radioButton6.Name = "radioButton6";
      this.radioButton6.Size = new Size(101, 17);
      this.radioButton6.TabIndex = 6;
      this.radioButton6.TabStop = true;
      this.radioButton6.Text = "Программа П6";
      this.radioButton6.UseVisualStyleBackColor = true;
      this.radioButton6.Click += new EventHandler(this.radioButton6_Click);
      this.radioButton7.AutoSize = true;
      this.radioButton7.Location = new Point(45, 369);
      this.radioButton7.Name = "radioButton7";
      this.radioButton7.Size = new Size(101, 17);
      this.radioButton7.TabIndex = 5;
      this.radioButton7.TabStop = true;
      this.radioButton7.Text = "Программа П7";
      this.radioButton7.UseVisualStyleBackColor = true;
      this.radioButton7.Click += new EventHandler(this.radioButton7_Click);
      this.radioButton8.AutoSize = true;
      this.radioButton8.Location = new Point(45, 413);
      this.radioButton8.Name = "radioButton8";
      this.radioButton8.Size = new Size(101, 17);
      this.radioButton8.TabIndex = 4;
      this.radioButton8.TabStop = true;
      this.radioButton8.Text = "Программа П8";
      this.radioButton8.UseVisualStyleBackColor = true;
      this.radioButton8.Click += new EventHandler(this.radioButton8_Click);
      this.radioButton4.AutoSize = true;
      this.radioButton4.Location = new Point(45, 237);
      this.radioButton4.Name = "radioButton4";
      this.radioButton4.Size = new Size(101, 17);
      this.radioButton4.TabIndex = 3;
      this.radioButton4.TabStop = true;
      this.radioButton4.Text = "Программа П4";
      this.radioButton4.UseVisualStyleBackColor = true;
      this.radioButton4.Click += new EventHandler(this.radioButton4_Click);
      this.radioButton3.AutoSize = true;
      this.radioButton3.Location = new Point(45, 193);
      this.radioButton3.Name = "radioButton3";
      this.radioButton3.Size = new Size(101, 17);
      this.radioButton3.TabIndex = 2;
      this.radioButton3.TabStop = true;
      this.radioButton3.Text = "Программа П3";
      this.radioButton3.UseVisualStyleBackColor = true;
      this.radioButton3.Click += new EventHandler(this.radioButton3_Click);
      this.radioButton2.AutoSize = true;
      this.radioButton2.Location = new Point(45, 149);
      this.radioButton2.Name = "radioButton2";
      this.radioButton2.Size = new Size(101, 17);
      this.radioButton2.TabIndex = 1;
      this.radioButton2.TabStop = true;
      this.radioButton2.Text = "Программа П2";
      this.radioButton2.UseVisualStyleBackColor = true;
      this.radioButton2.Click += new EventHandler(this.radioButton2_Click);
      this.radioButton1.AutoSize = true;
      this.radioButton1.Location = new Point(45, 105);
      this.radioButton1.Name = "radioButton1";
      this.radioButton1.Size = new Size(101, 17);
      this.radioButton1.TabIndex = 0;
      this.radioButton1.TabStop = true;
      this.radioButton1.Text = "Программа П1";
      this.radioButton1.UseVisualStyleBackColor = true;
      this.radioButton1.Click += new EventHandler(this.radioButton1_Click);
      this.tabPage2_RtOptions.BackColor = SystemColors.Control;
      this.tabPage2_RtOptions.Controls.Add((Control) this.groupBox3);
      this.tabPage2_RtOptions.Controls.Add((Control) this.groupBox2);
      this.tabPage2_RtOptions.Location = new Point(4, 22);
      this.tabPage2_RtOptions.Name = "tabPage2_RtOptions";
      this.tabPage2_RtOptions.Padding = new Padding(3);
      this.tabPage2_RtOptions.Size = new Size(542, 506);
      this.tabPage2_RtOptions.TabIndex = 1;
      this.tabPage2_RtOptions.Text = "RtMode";
      this.groupBox3.Controls.Add((Control) this.checkBox3);
      this.groupBox3.Controls.Add((Control) this.checkBox2);
      this.groupBox3.Controls.Add((Control) this.checkBox1);
      this.groupBox3.Location = new Point(5, 256);
      this.groupBox3.Name = "groupBox3";
      this.groupBox3.Size = new Size(530, 86);
      this.groupBox3.TabIndex = 6;
      this.groupBox3.TabStop = false;
      this.groupBox3.Text = "Дополнительные настройки:";
      this.checkBox3.AutoSize = true;
      this.checkBox3.Location = new Point(207, 28);
      this.checkBox3.Name = "checkBox3";
      this.checkBox3.Size = new Size(142, 17);
      this.checkBox3.TabIndex = 2;
      this.checkBox3.Text = "Повторять циклически";
      this.checkBox3.UseVisualStyleBackColor = true;
      this.checkBox3.Click += new EventHandler(this.checkBox3_Click);
      this.checkBox2.AutoSize = true;
      this.checkBox2.Location = new Point(31, 56);
      this.checkBox2.Name = "checkBox2";
      this.checkBox2.Size = new Size(138, 17);
      this.checkBox2.TabIndex = 1;
      this.checkBox2.Text = "Учитывать праздники";
      this.checkBox2.UseVisualStyleBackColor = true;
      this.checkBox2.Click += new EventHandler(this.checkBox2_Click);
      this.checkBox1.AutoSize = true;
      this.checkBox1.Location = new Point(31, 28);
      this.checkBox1.Name = "checkBox1";
      this.checkBox1.Size = new Size(135, 17);
      this.checkBox1.TabIndex = 0;
      this.checkBox1.Text = "Учитывать выходные";
      this.checkBox1.UseVisualStyleBackColor = true;
      this.checkBox1.Click += new EventHandler(this.checkBox1_Click);
      this.groupBox2.Controls.Add((Control) this.radioButton16);
      this.groupBox2.Controls.Add((Control) this.radioButton14);
      this.groupBox2.Controls.Add((Control) this.radioButton13);
      this.groupBox2.Controls.Add((Control) this.radioButton12);
      this.groupBox2.Controls.Add((Control) this.radioButton11);
      this.groupBox2.Controls.Add((Control) this.radioButton10);
      this.groupBox2.Controls.Add((Control) this.radioButton9);
      this.groupBox2.Location = new Point(6, 8);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new Size(530, 242);
      this.groupBox2.TabIndex = 3;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Выберите режим работы реле времени:";
      this.radioButton16.AutoSize = true;
      this.radioButton16.Location = new Point(30, 30);
      this.radioButton16.Name = "radioButton16";
      this.radioButton16.Size = new Size(81, 17);
      this.radioButton16.TabIndex = 6;
      this.radioButton16.TabStop = true;
      this.radioButton16.Text = "Отключено";
      this.radioButton16.UseVisualStyleBackColor = true;
      this.radioButton16.Click += new EventHandler(this.radioButton16_Click);
      this.radioButton14.AutoSize = true;
      this.radioButton14.Location = new Point(30, 198);
      this.radioButton14.Name = "radioButton14";
      this.radioButton14.Size = new Size(95, 17);
      this.radioButton14.TabIndex = 5;
      this.radioButton14.TabStop = true;
      this.radioButton14.Text = "Простое реле";
      this.radioButton14.UseVisualStyleBackColor = true;
      this.radioButton14.Click += new EventHandler(this.radioButton14_Click);
      this.radioButton13.AutoSize = true;
      this.radioButton13.Location = new Point(30, 170);
      this.radioButton13.Name = "radioButton13";
      this.radioButton13.Size = new Size(115, 17);
      this.radioButton13.TabIndex = 4;
      this.radioButton13.TabStop = true;
      this.radioButton13.Text = "Импульсное реле";
      this.radioButton13.UseVisualStyleBackColor = true;
      this.radioButton13.Click += new EventHandler(this.radioButton13_Click);
      this.radioButton12.AutoSize = true;
      this.radioButton12.Location = new Point(30, 142);
      this.radioButton12.Name = "radioButton12";
      this.radioButton12.Size = new Size(98, 17);
      this.radioButton12.TabIndex = 3;
      this.radioButton12.TabStop = true;
      this.radioButton12.Text = "Суточное реле";
      this.radioButton12.UseVisualStyleBackColor = true;
      this.radioButton12.Click += new EventHandler(this.radioButton12_Click);
      this.radioButton11.AutoSize = true;
      this.radioButton11.Location = new Point(30, 114);
      this.radioButton11.Name = "radioButton11";
      this.radioButton11.Size = new Size(108, 17);
      this.radioButton11.TabIndex = 2;
      this.radioButton11.TabStop = true;
      this.radioButton11.Text = "Недельное реле";
      this.radioButton11.UseVisualStyleBackColor = true;
      this.radioButton11.Click += new EventHandler(this.radioButton11_Click);
      this.radioButton10.AutoSize = true;
      this.radioButton10.Location = new Point(30, 86);
      this.radioButton10.Name = "radioButton10";
      this.radioButton10.Size = new Size(102, 17);
      this.radioButton10.TabIndex = 1;
      this.radioButton10.TabStop = true;
      this.radioButton10.Text = "Месячное реле";
      this.radioButton10.UseVisualStyleBackColor = true;
      this.radioButton10.Click += new EventHandler(this.radioButton10_Click);
      this.radioButton9.AutoSize = true;
      this.radioButton9.Location = new Point(30, 58);
      this.radioButton9.Name = "radioButton9";
      this.radioButton9.Size = new Size(94, 17);
      this.radioButton9.TabIndex = 0;
      this.radioButton9.TabStop = true;
      this.radioButton9.Text = "Годовое реле";
      this.radioButton9.UseVisualStyleBackColor = true;
      this.radioButton9.Click += new EventHandler(this.radioButton9_Click);
      this.tabPage3_Empty.BackColor = SystemColors.Control;
      this.tabPage3_Empty.Controls.Add((Control) this.button49);
      this.tabPage3_Empty.Controls.Add((Control) this.button42);
      this.tabPage3_Empty.Controls.Add((Control) this.groupBox40);
      this.tabPage3_Empty.Controls.Add((Control) this.richTextBox1);
      this.tabPage3_Empty.Location = new Point(4, 22);
      this.tabPage3_Empty.Name = "tabPage3_Empty";
      this.tabPage3_Empty.Padding = new Padding(3);
      this.tabPage3_Empty.Size = new Size(542, 506);
      this.tabPage3_Empty.TabIndex = 2;
      this.tabPage3_Empty.Text = "Prog";
      this.button49.Location = new Point(296, 453);
      this.button49.Name = "button49";
      this.button49.Size = new Size(168, 30);
      this.button49.TabIndex = 11;
      this.button49.Text = "Сбросить настройки";
      this.button49.UseVisualStyleBackColor = true;
      this.button49.Click += new EventHandler(this.button49_Click);
      this.button42.Location = new Point(82, 453);
      this.button42.Name = "button42";
      this.button42.Size = new Size(168, 30);
      this.button42.TabIndex = 10;
      this.button42.Text = "Очистить списки";
      this.button42.UseVisualStyleBackColor = true;
      this.button42.Click += new EventHandler(this.button42_Click);
      this.groupBox40.Controls.Add((Control) this.button39);
      this.groupBox40.Controls.Add((Control) this.comboBox2);
      this.groupBox40.Location = new Point(20, 350);
      this.groupBox40.Name = "groupBox40";
      this.groupBox40.Size = new Size(501, 84);
      this.groupBox40.TabIndex = 2;
      this.groupBox40.TabStop = false;
      this.groupBox40.Text = "Выберите программу для копирования ее настроек:";
      this.button39.Location = new Point(276, 26);
      this.button39.Name = "button39";
      this.button39.Size = new Size(168, 39);
      this.button39.TabIndex = 9;
      this.button39.Text = "    Копировать в \r\nтекущую программу";
      this.button39.UseVisualStyleBackColor = true;
      this.button39.Click += new EventHandler(this.button39_Click);
      this.comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboBox2.FormattingEnabled = true;
      this.comboBox2.Location = new Point(62, 36);
      this.comboBox2.Name = "comboBox2";
      this.comboBox2.Size = new Size(168, 21);
      this.comboBox2.TabIndex = 8;
      this.richTextBox1.BackColor = SystemColors.Control;
      this.richTextBox1.BorderStyle = BorderStyle.None;
      this.richTextBox1.Font = new Font("Arial", 10f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
      this.richTextBox1.Location = new Point(59, 118);
      this.richTextBox1.Name = "richTextBox1";
      this.richTextBox1.ReadOnly = true;
      this.richTextBox1.Size = new Size(405, 170);
      this.richTextBox1.TabIndex = 1;
      this.richTextBox1.Text = componentResourceManager.GetString("richTextBox1.Text");
      this.tabPage4_DayOffs.BackColor = SystemColors.Control;
      this.tabPage4_DayOffs.Controls.Add((Control) this.groupBox4);
      this.tabPage4_DayOffs.Location = new Point(4, 22);
      this.tabPage4_DayOffs.Name = "tabPage4_DayOffs";
      this.tabPage4_DayOffs.Padding = new Padding(3);
      this.tabPage4_DayOffs.Size = new Size(542, 506);
      this.tabPage4_DayOffs.TabIndex = 3;
      this.tabPage4_DayOffs.Text = "DayOffs";
      this.groupBox4.BackColor = SystemColors.Control;
      this.groupBox4.Controls.Add((Control) this.checkBox10);
      this.groupBox4.Controls.Add((Control) this.checkBox9);
      this.groupBox4.Controls.Add((Control) this.checkBox8);
      this.groupBox4.Controls.Add((Control) this.checkBox7);
      this.groupBox4.Controls.Add((Control) this.checkBox6);
      this.groupBox4.Controls.Add((Control) this.checkBox5);
      this.groupBox4.Controls.Add((Control) this.checkBox4);
      this.groupBox4.Location = new Point(6, 6);
      this.groupBox4.Name = "groupBox4";
      this.groupBox4.Size = new Size(531, 491);
      this.groupBox4.TabIndex = 7;
      this.groupBox4.TabStop = false;
      this.groupBox4.Text = "Выберите выходные дни недели:";
      this.checkBox10.AutoSize = true;
      this.checkBox10.Location = new Point(208, 356);
      this.checkBox10.Name = "checkBox10";
      this.checkBox10.Size = new Size(93, 17);
      this.checkBox10.TabIndex = 13;
      this.checkBox10.Text = "Воскресенье";
      this.checkBox10.UseVisualStyleBackColor = true;
      this.checkBox10.Click += new EventHandler(this.checkBox10_Click);
      this.checkBox9.AutoSize = true;
      this.checkBox9.Location = new Point(208, 317);
      this.checkBox9.Name = "checkBox9";
      this.checkBox9.Size = new Size(67, 17);
      this.checkBox9.TabIndex = 12;
      this.checkBox9.Text = "Суббота";
      this.checkBox9.UseVisualStyleBackColor = true;
      this.checkBox9.Click += new EventHandler(this.checkBox9_Click);
      this.checkBox8.AutoSize = true;
      this.checkBox8.Location = new Point(208, 278);
      this.checkBox8.Name = "checkBox8";
      this.checkBox8.Size = new Size(69, 17);
      this.checkBox8.TabIndex = 11;
      this.checkBox8.Text = "Пятница";
      this.checkBox8.UseVisualStyleBackColor = true;
      this.checkBox8.Click += new EventHandler(this.checkBox8_Click);
      this.checkBox7.AutoSize = true;
      this.checkBox7.Location = new Point(208, 239);
      this.checkBox7.Name = "checkBox7";
      this.checkBox7.Size = new Size(68, 17);
      this.checkBox7.TabIndex = 10;
      this.checkBox7.Text = "Четверг";
      this.checkBox7.UseVisualStyleBackColor = true;
      this.checkBox7.Click += new EventHandler(this.checkBox7_Click);
      this.checkBox6.AutoSize = true;
      this.checkBox6.Location = new Point(208, 200);
      this.checkBox6.Name = "checkBox6";
      this.checkBox6.Size = new Size(57, 17);
      this.checkBox6.TabIndex = 9;
      this.checkBox6.Text = "Среда";
      this.checkBox6.UseVisualStyleBackColor = true;
      this.checkBox6.Click += new EventHandler(this.checkBox6_Click);
      this.checkBox5.AutoSize = true;
      this.checkBox5.Location = new Point(208, 161);
      this.checkBox5.Name = "checkBox5";
      this.checkBox5.Size = new Size(68, 17);
      this.checkBox5.TabIndex = 8;
      this.checkBox5.Text = "Вторник";
      this.checkBox5.UseVisualStyleBackColor = true;
      this.checkBox5.Click += new EventHandler(this.checkBox5_Click);
      this.checkBox4.AutoSize = true;
      this.checkBox4.Location = new Point(208, 122);
      this.checkBox4.Name = "checkBox4";
      this.checkBox4.Size = new Size(94, 17);
      this.checkBox4.TabIndex = 7;
      this.checkBox4.Text = "Понедельник";
      this.checkBox4.UseVisualStyleBackColor = true;
      this.checkBox4.Click += new EventHandler(this.checkBox4_Click);
      this.tabPage5_Holidays.BackColor = SystemColors.Control;
      this.tabPage5_Holidays.Controls.Add((Control) this.groupBox5);
      this.tabPage5_Holidays.Location = new Point(4, 22);
      this.tabPage5_Holidays.Name = "tabPage5_Holidays";
      this.tabPage5_Holidays.Padding = new Padding(3);
      this.tabPage5_Holidays.Size = new Size(542, 506);
      this.tabPage5_Holidays.TabIndex = 4;
      this.tabPage5_Holidays.Text = "Holidays";
      this.groupBox5.Controls.Add((Control) this.button43);
      this.groupBox5.Controls.Add((Control) this.button34);
      this.groupBox5.Controls.Add((Control) this.listView1);
      this.groupBox5.Controls.Add((Control) this.button4);
      this.groupBox5.Controls.Add((Control) this.button3);
      this.groupBox5.Controls.Add((Control) this.button2);
      this.groupBox5.Controls.Add((Control) this.monthCalendar1);
      this.groupBox5.Location = new Point(6, 8);
      this.groupBox5.Name = "groupBox5";
      this.groupBox5.Size = new Size(530, 489);
      this.groupBox5.TabIndex = 8;
      this.groupBox5.TabStop = false;
      this.groupBox5.Text = "Список праздничных дней:";
      this.button43.Enabled = false;
      this.button43.Location = new Point(207, 445);
      this.button43.Name = "button43";
      this.button43.Size = new Size(315, 26);
      this.button43.TabIndex = 21;
      this.button43.Text = "Отменить последнее действие";
      this.button43.UseVisualStyleBackColor = true;
      this.button43.Click += new EventHandler(this.button43_Click);
      this.button34.Location = new Point(207, 403);
      this.button34.Name = "button34";
      this.button34.Size = new Size(315, 28);
      this.button34.TabIndex = 20;
      this.button34.Text = "Создать массив праздников";
      this.button34.UseVisualStyleBackColor = true;
      this.button34.Click += new EventHandler(this.button34_Click);
      this.listView1.Columns.AddRange(new ColumnHeader[3]
      {
        this.columnHeader1,
        this.columnHeader2,
        this.columnHeader3
      });
      this.listView1.FullRowSelect = true;
      this.listView1.GridLines = true;
      this.listView1.HeaderStyle = ColumnHeaderStyle.Nonclickable;
      this.listView1.Location = new Point(243, 19);
      this.listView1.Name = "listView1";
      this.listView1.Size = new Size(281, 368);
      this.listView1.TabIndex = 6;
      this.listView1.UseCompatibleStateImageBehavior = false;
      this.listView1.View = View.Details;
      this.columnHeader1.Text = "##";
      this.columnHeader1.Width = 57;
      this.columnHeader2.Text = "День";
      this.columnHeader2.TextAlign = HorizontalAlignment.Center;
      this.columnHeader2.Width = 72;
      this.columnHeader3.Text = "Месяц";
      this.columnHeader3.TextAlign = HorizontalAlignment.Center;
      this.columnHeader3.Width = 144;
      this.button4.Location = new Point(12, 445);
      this.button4.Name = "button4";
      this.button4.Size = new Size(156, 26);
      this.button4.TabIndex = 5;
      this.button4.Text = "Очистить список";
      this.button4.UseVisualStyleBackColor = true;
      this.button4.Click += new EventHandler(this.button4_Click);
      this.button3.Location = new Point(11, 403);
      this.button3.Name = "button3";
      this.button3.Size = new Size(156, 28);
      this.button3.TabIndex = 4;
      this.button3.Text = "Удалить выделенные";
      this.button3.UseVisualStyleBackColor = true;
      this.button3.Click += new EventHandler(this.button3_Click);
      this.button2.Location = new Point(12, 359);
      this.button2.Name = "button2";
      this.button2.Size = new Size(156, 28);
      this.button2.TabIndex = 3;
      this.button2.Text = "Добавить";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new EventHandler(this.button2_Click);
      this.monthCalendar1.Location = new Point(6, 179);
      this.monthCalendar1.MaxSelectionCount = 1;
      this.monthCalendar1.Name = "monthCalendar1";
      this.monthCalendar1.TabIndex = 1;
      this.monthCalendar1.DateChanged += new DateRangeEventHandler(this.monthCalendar1_DateChanged);
      this.tabPage6_ExceptEvents.BackColor = SystemColors.Control;
      this.tabPage6_ExceptEvents.Controls.Add((Control) this.groupBox6);
      this.tabPage6_ExceptEvents.Location = new Point(4, 22);
      this.tabPage6_ExceptEvents.Name = "tabPage6_ExceptEvents";
      this.tabPage6_ExceptEvents.Padding = new Padding(3);
      this.tabPage6_ExceptEvents.Size = new Size(542, 506);
      this.tabPage6_ExceptEvents.TabIndex = 5;
      this.tabPage6_ExceptEvents.Text = "ExceptEvents";
      this.groupBox6.Controls.Add((Control) this.button44);
      this.groupBox6.Controls.Add((Control) this.button36);
      this.groupBox6.Controls.Add((Control) this.groupBox7);
      this.groupBox6.Controls.Add((Control) this.label10);
      this.groupBox6.Controls.Add((Control) this.label9);
      this.groupBox6.Controls.Add((Control) this.label8);
      this.groupBox6.Controls.Add((Control) this.label7);
      this.groupBox6.Controls.Add((Control) this.label6);
      this.groupBox6.Controls.Add((Control) this.numericUpDown3);
      this.groupBox6.Controls.Add((Control) this.numericUpDown2);
      this.groupBox6.Controls.Add((Control) this.numericUpDown1);
      this.groupBox6.Controls.Add((Control) this.listView2);
      this.groupBox6.Controls.Add((Control) this.button5);
      this.groupBox6.Controls.Add((Control) this.button6);
      this.groupBox6.Controls.Add((Control) this.button7);
      this.groupBox6.Location = new Point(6, 8);
      this.groupBox6.Name = "groupBox6";
      this.groupBox6.Size = new Size(530, 489);
      this.groupBox6.TabIndex = 9;
      this.groupBox6.TabStop = false;
      this.groupBox6.Text = "Список исключительных событий:";
      this.button44.Enabled = false;
      this.button44.Location = new Point(193, 445);
      this.button44.Name = "button44";
      this.button44.Size = new Size(330, 26);
      this.button44.TabIndex = 22;
      this.button44.Text = "Отменить последнее действие";
      this.button44.UseVisualStyleBackColor = true;
      this.button44.Click += new EventHandler(this.button44_Click);
      this.button36.Location = new Point(194, 403);
      this.button36.Name = "button36";
      this.button36.Size = new Size(330, 28);
      this.button36.TabIndex = 21;
      this.button36.Text = "Создать массив событий";
      this.button36.UseVisualStyleBackColor = true;
      this.button36.Click += new EventHandler(this.button36_Click);
      this.groupBox7.Controls.Add((Control) this.radioButton18);
      this.groupBox7.Controls.Add((Control) this.radioButton17);
      this.groupBox7.Location = new Point(11, 240);
      this.groupBox7.Name = "groupBox7";
      this.groupBox7.Size = new Size(155, 105);
      this.groupBox7.TabIndex = 16;
      this.groupBox7.TabStop = false;
      this.groupBox7.Text = "Состояние контактов канала:";
      this.radioButton18.AutoSize = true;
      this.radioButton18.Location = new Point(27, 67);
      this.radioButton18.Name = "radioButton18";
      this.radioButton18.Size = new Size(74, 17);
      this.radioButton18.TabIndex = 16;
      this.radioButton18.TabStop = true;
      this.radioButton18.Text = "Включить";
      this.radioButton18.UseVisualStyleBackColor = true;
      this.radioButton17.AutoSize = true;
      this.radioButton17.Location = new Point(27, 35);
      this.radioButton17.Name = "radioButton17";
      this.radioButton17.Size = new Size(80, 17);
      this.radioButton17.TabIndex = 15;
      this.radioButton17.TabStop = true;
      this.radioButton17.Text = "Отключить";
      this.radioButton17.UseVisualStyleBackColor = true;
      this.label10.AutoSize = true;
      this.label10.Location = new Point(113, 198);
      this.label10.Name = "label10";
      this.label10.Size = new Size(10, 13);
      this.label10.TabIndex = 14;
      this.label10.Text = ":";
      this.label9.AutoSize = true;
      this.label9.Location = new Point(55, 198);
      this.label9.Name = "label9";
      this.label9.Size = new Size(10, 13);
      this.label9.TabIndex = 13;
      this.label9.Text = ":";
      this.label8.AutoSize = true;
      this.label8.Location = new Point(124, 171);
      this.label8.Name = "label8";
      this.label8.Size = new Size(51, 13);
      this.label8.TabIndex = 12;
      this.label8.Text = "Секунды";
      this.label7.AutoSize = true;
      this.label7.Location = new Point(62, 171);
      this.label7.Name = "label7";
      this.label7.Size = new Size(46, 13);
      this.label7.TabIndex = 11;
      this.label7.Text = "Минуты";
      this.label6.AutoSize = true;
      this.label6.Location = new Point(8, 171);
      this.label6.Name = "label6";
      this.label6.Size = new Size(35, 13);
      this.label6.TabIndex = 10;
      this.label6.Text = "Часы";
      this.numericUpDown3.Location = new Point(129, 196);
      NumericUpDown numericUpDown3 = this.numericUpDown3;
      int[] bits1 = new int[4];
      bits1[0] = 59;
      Decimal num1 = new Decimal(bits1);
      numericUpDown3.Maximum = num1;
      this.numericUpDown3.Name = "numericUpDown3";
      this.numericUpDown3.Size = new Size(38, 20);
      this.numericUpDown3.TabIndex = 9;
      this.numericUpDown2.Location = new Point(70, 196);
      NumericUpDown numericUpDown2 = this.numericUpDown2;
      int[] bits2 = new int[4];
      bits2[0] = 59;
      Decimal num2 = new Decimal(bits2);
      numericUpDown2.Maximum = num2;
      this.numericUpDown2.Name = "numericUpDown2";
      this.numericUpDown2.Size = new Size(38, 20);
      this.numericUpDown2.TabIndex = 8;
      this.numericUpDown1.Location = new Point(11, 196);
      NumericUpDown numericUpDown1 = this.numericUpDown1;
      int[] bits3 = new int[4];
      bits3[0] = 23;
      Decimal num3 = new Decimal(bits3);
      numericUpDown1.Maximum = num3;
      this.numericUpDown1.Name = "numericUpDown1";
      this.numericUpDown1.Size = new Size(38, 20);
      this.numericUpDown1.TabIndex = 7;
      this.listView2.Columns.AddRange(new ColumnHeader[3]
      {
        this.columnHeader4,
        this.columnHeader5,
        this.columnHeader6
      });
      this.listView2.FullRowSelect = true;
      this.listView2.GridLines = true;
      this.listView2.HeaderStyle = ColumnHeaderStyle.Nonclickable;
      this.listView2.Location = new Point(193, 19);
      this.listView2.Name = "listView2";
      this.listView2.Size = new Size(331, 370);
      this.listView2.TabIndex = 6;
      this.listView2.UseCompatibleStateImageBehavior = false;
      this.listView2.View = View.Details;
      this.columnHeader4.Text = "##";
      this.columnHeader4.Width = 40;
      this.columnHeader5.Text = "Время";
      this.columnHeader5.TextAlign = HorizontalAlignment.Center;
      this.columnHeader5.Width = 70;
      this.columnHeader6.Text = "Контакты";
      this.columnHeader6.TextAlign = HorizontalAlignment.Center;
      this.columnHeader6.Width = 110;
      this.button5.Location = new Point(11, 445);
      this.button5.Name = "button5";
      this.button5.Size = new Size(156, 28);
      this.button5.TabIndex = 5;
      this.button5.Text = "Очистить список";
      this.button5.UseVisualStyleBackColor = true;
      this.button5.Click += new EventHandler(this.button5_Click);
      this.button6.Location = new Point(11, 403);
      this.button6.Name = "button6";
      this.button6.Size = new Size(156, 28);
      this.button6.TabIndex = 4;
      this.button6.Text = "Удалить выделенные";
      this.button6.UseVisualStyleBackColor = true;
      this.button6.Click += new EventHandler(this.button6_Click);
      this.button7.Location = new Point(11, 361);
      this.button7.Name = "button7";
      this.button7.Size = new Size(156, 28);
      this.button7.TabIndex = 3;
      this.button7.Text = "Добавить";
      this.button7.UseVisualStyleBackColor = true;
      this.button7.Click += new EventHandler(this.button7_Click);
      this.tabPage7_Year.BackColor = SystemColors.Control;
      this.tabPage7_Year.Controls.Add((Control) this.groupBox8);
      this.tabPage7_Year.Location = new Point(4, 22);
      this.tabPage7_Year.Name = "tabPage7_Year";
      this.tabPage7_Year.Padding = new Padding(3);
      this.tabPage7_Year.Size = new Size(542, 506);
      this.tabPage7_Year.TabIndex = 6;
      this.tabPage7_Year.Text = "Year";
      this.groupBox8.Controls.Add((Control) this.button45);
      this.groupBox8.Controls.Add((Control) this.button24);
      this.groupBox8.Controls.Add((Control) this.button23);
      this.groupBox8.Controls.Add((Control) this.monthCalendar2);
      this.groupBox8.Controls.Add((Control) this.groupBox9);
      this.groupBox8.Controls.Add((Control) this.label11);
      this.groupBox8.Controls.Add((Control) this.label12);
      this.groupBox8.Controls.Add((Control) this.label13);
      this.groupBox8.Controls.Add((Control) this.label14);
      this.groupBox8.Controls.Add((Control) this.label15);
      this.groupBox8.Controls.Add((Control) this.numericUpDown4);
      this.groupBox8.Controls.Add((Control) this.numericUpDown5);
      this.groupBox8.Controls.Add((Control) this.numericUpDown6);
      this.groupBox8.Controls.Add((Control) this.listView3);
      this.groupBox8.Controls.Add((Control) this.button8);
      this.groupBox8.Controls.Add((Control) this.button9);
      this.groupBox8.Controls.Add((Control) this.button10);
      this.groupBox8.Location = new Point(6, 8);
      this.groupBox8.Name = "groupBox8";
      this.groupBox8.Size = new Size(530, 489);
      this.groupBox8.TabIndex = 10;
      this.groupBox8.TabStop = false;
      this.groupBox8.Text = "Список событий годового реле времени:";
      this.button45.Enabled = false;
      this.button45.Location = new Point(202, 446);
      this.button45.Name = "button45";
      this.button45.Size = new Size(315, 26);
      this.button45.TabIndex = 22;
      this.button45.Text = "Отменить последнее действие";
      this.button45.UseVisualStyleBackColor = true;
      this.button45.Click += new EventHandler(this.button45_Click);
      this.button24.Location = new Point(202, 362);
      this.button24.Name = "button24";
      this.button24.Size = new Size(315, 28);
      this.button24.TabIndex = 19;
      this.button24.Text = "Создать массив событий";
      this.button24.UseVisualStyleBackColor = true;
      this.button24.Click += new EventHandler(this.button24_Click);
      this.button23.Location = new Point(202, 405);
      this.button23.Name = "button23";
      this.button23.Size = new Size(315, 28);
      this.button23.TabIndex = 18;
      this.button23.Text = "Создать список восходов/закатов Солнца";
      this.button23.UseVisualStyleBackColor = true;
      this.button23.Click += new EventHandler(this.SunRiseToolStripMenuItem_Click);
      this.monthCalendar2.Location = new Point(12, 19);
      this.monthCalendar2.MaxSelectionCount = 1;
      this.monthCalendar2.Name = "monthCalendar2";
      this.monthCalendar2.TabIndex = 17;
      this.groupBox9.Controls.Add((Control) this.radioButton19);
      this.groupBox9.Controls.Add((Control) this.radioButton20);
      this.groupBox9.Location = new Point(17, 243);
      this.groupBox9.Name = "groupBox9";
      this.groupBox9.Size = new Size(155, 105);
      this.groupBox9.TabIndex = 16;
      this.groupBox9.TabStop = false;
      this.groupBox9.Text = "Состояние контактов канала:";
      this.radioButton19.AutoSize = true;
      this.radioButton19.Location = new Point(27, 67);
      this.radioButton19.Name = "radioButton19";
      this.radioButton19.Size = new Size(74, 17);
      this.radioButton19.TabIndex = 16;
      this.radioButton19.TabStop = true;
      this.radioButton19.Text = "Включить";
      this.radioButton19.UseVisualStyleBackColor = true;
      this.radioButton20.AutoSize = true;
      this.radioButton20.Location = new Point(27, 35);
      this.radioButton20.Name = "radioButton20";
      this.radioButton20.Size = new Size(80, 17);
      this.radioButton20.TabIndex = 15;
      this.radioButton20.TabStop = true;
      this.radioButton20.Text = "Отключить";
      this.radioButton20.UseVisualStyleBackColor = true;
      this.label11.AutoSize = true;
      this.label11.Location = new Point(114, 210);
      this.label11.Name = "label11";
      this.label11.Size = new Size(10, 13);
      this.label11.TabIndex = 14;
      this.label11.Text = ":";
      this.label12.AutoSize = true;
      this.label12.Location = new Point(56, 210);
      this.label12.Name = "label12";
      this.label12.Size = new Size(10, 13);
      this.label12.TabIndex = 13;
      this.label12.Text = ":";
      this.label13.AutoSize = true;
      this.label13.Location = new Point(125, 183);
      this.label13.Name = "label13";
      this.label13.Size = new Size(51, 13);
      this.label13.TabIndex = 12;
      this.label13.Text = "Секунды";
      this.label14.AutoSize = true;
      this.label14.Location = new Point(63, 183);
      this.label14.Name = "label14";
      this.label14.Size = new Size(46, 13);
      this.label14.TabIndex = 11;
      this.label14.Text = "Минуты";
      this.label15.AutoSize = true;
      this.label15.Location = new Point(9, 183);
      this.label15.Name = "label15";
      this.label15.Size = new Size(35, 13);
      this.label15.TabIndex = 10;
      this.label15.Text = "Часы";
      this.numericUpDown4.Location = new Point(130, 208);
      NumericUpDown numericUpDown4 = this.numericUpDown4;
      int[] bits4 = new int[4];
      bits4[0] = 59;
      Decimal num4 = new Decimal(bits4);
      numericUpDown4.Maximum = num4;
      this.numericUpDown4.Name = "numericUpDown4";
      this.numericUpDown4.Size = new Size(38, 20);
      this.numericUpDown4.TabIndex = 9;
      this.numericUpDown5.Location = new Point(71, 208);
      NumericUpDown numericUpDown5 = this.numericUpDown5;
      int[] bits5 = new int[4];
      bits5[0] = 59;
      Decimal num5 = new Decimal(bits5);
      numericUpDown5.Maximum = num5;
      this.numericUpDown5.Name = "numericUpDown5";
      this.numericUpDown5.Size = new Size(38, 20);
      this.numericUpDown5.TabIndex = 8;
      this.numericUpDown6.Location = new Point(12, 208);
      NumericUpDown numericUpDown6 = this.numericUpDown6;
      int[] bits6 = new int[4];
      bits6[0] = 23;
      Decimal num6 = new Decimal(bits6);
      numericUpDown6.Maximum = num6;
      this.numericUpDown6.Name = "numericUpDown6";
      this.numericUpDown6.Size = new Size(38, 20);
      this.numericUpDown6.TabIndex = 7;
      this.listView3.Activation = ItemActivation.OneClick;
      this.listView3.Columns.AddRange(new ColumnHeader[5]
      {
        this.columnHeader7,
        this.columnHeader8,
        this.columnHeader9,
        this.columnHeader10,
        this.columnHeader11
      });
      this.listView3.FullRowSelect = true;
      this.listView3.GridLines = true;
      this.listView3.HeaderStyle = ColumnHeaderStyle.Nonclickable;
      this.listView3.Location = new Point(250, 19);
      this.listView3.Name = "listView3";
      this.listView3.Size = new Size(267, 329);
      this.listView3.TabIndex = 6;
      this.listView3.UseCompatibleStateImageBehavior = false;
      this.listView3.View = View.Details;
      this.columnHeader7.Text = "##";
      this.columnHeader7.Width = 35;
      this.columnHeader8.Text = "День";
      this.columnHeader8.TextAlign = HorizontalAlignment.Center;
      this.columnHeader8.Width = 40;
      this.columnHeader9.Text = "Месяц";
      this.columnHeader9.TextAlign = HorizontalAlignment.Center;
      this.columnHeader10.Text = "Время";
      this.columnHeader10.TextAlign = HorizontalAlignment.Center;
      this.columnHeader11.Text = "Контакты";
      this.columnHeader11.Width = 74;
      this.button8.Location = new Point(17, 445);
      this.button8.Name = "button8";
      this.button8.Size = new Size(159, 28);
      this.button8.TabIndex = 5;
      this.button8.Text = "Очистить список";
      this.button8.UseVisualStyleBackColor = true;
      this.button8.Click += new EventHandler(this.button8_Click);
      this.button9.Location = new Point(17, 405);
      this.button9.Name = "button9";
      this.button9.Size = new Size(159, 28);
      this.button9.TabIndex = 4;
      this.button9.Text = "Удалить выделенные";
      this.button9.UseVisualStyleBackColor = true;
      this.button9.Click += new EventHandler(this.button9_Click);
      this.button10.Location = new Point(17, 362);
      this.button10.Name = "button10";
      this.button10.Size = new Size(159, 28);
      this.button10.TabIndex = 3;
      this.button10.Text = "Добавить";
      this.button10.UseVisualStyleBackColor = true;
      this.button10.Click += new EventHandler(this.button10_Click);
      this.tabPage8_Month.BackColor = SystemColors.Control;
      this.tabPage8_Month.Controls.Add((Control) this.groupBox10);
      this.tabPage8_Month.Location = new Point(4, 22);
      this.tabPage8_Month.Name = "tabPage8_Month";
      this.tabPage8_Month.Padding = new Padding(3);
      this.tabPage8_Month.Size = new Size(542, 506);
      this.tabPage8_Month.TabIndex = 7;
      this.tabPage8_Month.Text = "Month";
      this.groupBox10.Controls.Add((Control) this.button46);
      this.groupBox10.Controls.Add((Control) this.button25);
      this.groupBox10.Controls.Add((Control) this.numericUpDown16);
      this.groupBox10.Controls.Add((Control) this.label21);
      this.groupBox10.Controls.Add((Control) this.groupBox11);
      this.groupBox10.Controls.Add((Control) this.label16);
      this.groupBox10.Controls.Add((Control) this.label17);
      this.groupBox10.Controls.Add((Control) this.label18);
      this.groupBox10.Controls.Add((Control) this.label19);
      this.groupBox10.Controls.Add((Control) this.label20);
      this.groupBox10.Controls.Add((Control) this.numericUpDown7);
      this.groupBox10.Controls.Add((Control) this.numericUpDown8);
      this.groupBox10.Controls.Add((Control) this.numericUpDown9);
      this.groupBox10.Controls.Add((Control) this.listView4);
      this.groupBox10.Controls.Add((Control) this.button11);
      this.groupBox10.Controls.Add((Control) this.button12);
      this.groupBox10.Controls.Add((Control) this.button13);
      this.groupBox10.Location = new Point(6, 8);
      this.groupBox10.Name = "groupBox10";
      this.groupBox10.Size = new Size(530, 492);
      this.groupBox10.TabIndex = 11;
      this.groupBox10.TabStop = false;
      this.groupBox10.Text = "Список событий месячного реле времени:";
      this.button46.Enabled = false;
      this.button46.Location = new Point(194, 443);
      this.button46.Name = "button46";
      this.button46.Size = new Size(330, 26);
      this.button46.TabIndex = 22;
      this.button46.Text = "Отменить последнее действие";
      this.button46.UseVisualStyleBackColor = true;
      this.button46.Click += new EventHandler(this.button46_Click);
      this.button25.Location = new Point(196, 401);
      this.button25.Name = "button25";
      this.button25.Size = new Size(328, 28);
      this.button25.TabIndex = 20;
      this.button25.Text = "Создать массив событий";
      this.button25.UseVisualStyleBackColor = true;
      this.button25.Click += new EventHandler(this.button25_Click);
      this.numericUpDown16.Location = new Point(105, 142);
      NumericUpDown numericUpDown16_1 = this.numericUpDown16;
      int[] bits7 = new int[4];
      bits7[0] = 31;
      Decimal num7 = new Decimal(bits7);
      numericUpDown16_1.Maximum = num7;
      NumericUpDown numericUpDown16_2 = this.numericUpDown16;
      int[] bits8 = new int[4];
      bits8[0] = 1;
      Decimal num8 = new Decimal(bits8);
      numericUpDown16_2.Minimum = num8;
      this.numericUpDown16.Name = "numericUpDown16";
      this.numericUpDown16.Size = new Size(52, 20);
      this.numericUpDown16.TabIndex = 19;
      NumericUpDown numericUpDown16_3 = this.numericUpDown16;
      int[] bits9 = new int[4];
      bits9[0] = 1;
      Decimal num9 = new Decimal(bits9);
      numericUpDown16_3.Value = num9;
      this.label21.AutoSize = true;
      this.label21.Location = new Point(14, 144);
      this.label21.Name = "label21";
      this.label21.Size = new Size(78, 13);
      this.label21.TabIndex = 18;
      this.label21.Text = "День месяца:";
      this.groupBox11.Controls.Add((Control) this.radioButton21);
      this.groupBox11.Controls.Add((Control) this.radioButton22);
      this.groupBox11.Location = new Point(15, 239);
      this.groupBox11.Name = "groupBox11";
      this.groupBox11.Size = new Size(155, 105);
      this.groupBox11.TabIndex = 16;
      this.groupBox11.TabStop = false;
      this.groupBox11.Text = "Состояние контактов канала:";
      this.radioButton21.AutoSize = true;
      this.radioButton21.Location = new Point(27, 67);
      this.radioButton21.Name = "radioButton21";
      this.radioButton21.Size = new Size(74, 17);
      this.radioButton21.TabIndex = 16;
      this.radioButton21.TabStop = true;
      this.radioButton21.Text = "Включить";
      this.radioButton21.UseVisualStyleBackColor = true;
      this.radioButton22.AutoSize = true;
      this.radioButton22.Location = new Point(27, 35);
      this.radioButton22.Name = "radioButton22";
      this.radioButton22.Size = new Size(80, 17);
      this.radioButton22.TabIndex = 15;
      this.radioButton22.TabStop = true;
      this.radioButton22.Text = "Отключить";
      this.radioButton22.UseVisualStyleBackColor = true;
      this.label16.AutoSize = true;
      this.label16.Location = new Point(111, 210);
      this.label16.Name = "label16";
      this.label16.Size = new Size(10, 13);
      this.label16.TabIndex = 14;
      this.label16.Text = ":";
      this.label17.AutoSize = true;
      this.label17.Location = new Point(53, 210);
      this.label17.Name = "label17";
      this.label17.Size = new Size(10, 13);
      this.label17.TabIndex = 13;
      this.label17.Text = ":";
      this.label18.AutoSize = true;
      this.label18.Location = new Point(122, 183);
      this.label18.Name = "label18";
      this.label18.Size = new Size(51, 13);
      this.label18.TabIndex = 12;
      this.label18.Text = "Секунды";
      this.label19.AutoSize = true;
      this.label19.Location = new Point(60, 183);
      this.label19.Name = "label19";
      this.label19.Size = new Size(46, 13);
      this.label19.TabIndex = 11;
      this.label19.Text = "Минуты";
      this.label20.AutoSize = true;
      this.label20.Location = new Point(6, 183);
      this.label20.Name = "label20";
      this.label20.Size = new Size(35, 13);
      this.label20.TabIndex = 10;
      this.label20.Text = "Часы";
      this.numericUpDown7.Location = new Point((int) sbyte.MaxValue, 208);
      NumericUpDown numericUpDown7 = this.numericUpDown7;
      int[] bits10 = new int[4];
      bits10[0] = 59;
      Decimal num10 = new Decimal(bits10);
      numericUpDown7.Maximum = num10;
      this.numericUpDown7.Name = "numericUpDown7";
      this.numericUpDown7.Size = new Size(38, 20);
      this.numericUpDown7.TabIndex = 9;
      this.numericUpDown8.Location = new Point(68, 208);
      NumericUpDown numericUpDown8 = this.numericUpDown8;
      int[] bits11 = new int[4];
      bits11[0] = 59;
      Decimal num11 = new Decimal(bits11);
      numericUpDown8.Maximum = num11;
      this.numericUpDown8.Name = "numericUpDown8";
      this.numericUpDown8.Size = new Size(38, 20);
      this.numericUpDown8.TabIndex = 8;
      this.numericUpDown9.ImeMode = ImeMode.NoControl;
      this.numericUpDown9.Location = new Point(9, 208);
      NumericUpDown numericUpDown9 = this.numericUpDown9;
      int[] bits12 = new int[4];
      bits12[0] = 23;
      Decimal num12 = new Decimal(bits12);
      numericUpDown9.Maximum = num12;
      this.numericUpDown9.Name = "numericUpDown9";
      this.numericUpDown9.Size = new Size(38, 20);
      this.numericUpDown9.TabIndex = 7;
      this.listView4.Columns.AddRange(new ColumnHeader[4]
      {
        this.columnHeader12,
        this.columnHeader13,
        this.columnHeader15,
        this.columnHeader16
      });
      this.listView4.FullRowSelect = true;
      this.listView4.GridLines = true;
      this.listView4.HeaderStyle = ColumnHeaderStyle.Nonclickable;
      this.listView4.Location = new Point(196, 19);
      this.listView4.Name = "listView4";
      this.listView4.Size = new Size(328, 368);
      this.listView4.TabIndex = 6;
      this.listView4.UseCompatibleStateImageBehavior = false;
      this.listView4.View = View.Details;
      this.columnHeader12.Text = "##";
      this.columnHeader12.Width = 35;
      this.columnHeader13.Text = "День месяца";
      this.columnHeader13.TextAlign = HorizontalAlignment.Center;
      this.columnHeader13.Width = 56;
      this.columnHeader15.Text = "Время";
      this.columnHeader15.TextAlign = HorizontalAlignment.Center;
      this.columnHeader15.Width = 58;
      this.columnHeader16.Text = "Контакты";
      this.columnHeader16.Width = 83;
      this.button11.Location = new Point(15, 443);
      this.button11.Name = "button11";
      this.button11.Size = new Size(155, 28);
      this.button11.TabIndex = 5;
      this.button11.Text = "Очистить список";
      this.button11.UseVisualStyleBackColor = true;
      this.button11.Click += new EventHandler(this.button11_Click);
      this.button12.Location = new Point(15, 401);
      this.button12.Name = "button12";
      this.button12.Size = new Size(155, 28);
      this.button12.TabIndex = 4;
      this.button12.Text = "Удалить выделенные";
      this.button12.UseVisualStyleBackColor = true;
      this.button12.Click += new EventHandler(this.button12_Click);
      this.button13.Location = new Point(15, 359);
      this.button13.Name = "button13";
      this.button13.Size = new Size(155, 28);
      this.button13.TabIndex = 3;
      this.button13.Text = "Добавить";
      this.button13.UseVisualStyleBackColor = true;
      this.button13.Click += new EventHandler(this.button13_Click);
      this.tabPage9_Week.BackColor = SystemColors.Control;
      this.tabPage9_Week.Controls.Add((Control) this.groupBox12);
      this.tabPage9_Week.Location = new Point(4, 22);
      this.tabPage9_Week.Name = "tabPage9_Week";
      this.tabPage9_Week.Padding = new Padding(3);
      this.tabPage9_Week.Size = new Size(542, 506);
      this.tabPage9_Week.TabIndex = 8;
      this.tabPage9_Week.Text = "Week";
      this.groupBox12.Controls.Add((Control) this.button47);
      this.groupBox12.Controls.Add((Control) this.button37);
      this.groupBox12.Controls.Add((Control) this.comboBox1);
      this.groupBox12.Controls.Add((Control) this.label22);
      this.groupBox12.Controls.Add((Control) this.listView5);
      this.groupBox12.Controls.Add((Control) this.groupBox13);
      this.groupBox12.Controls.Add((Control) this.label23);
      this.groupBox12.Controls.Add((Control) this.label24);
      this.groupBox12.Controls.Add((Control) this.label25);
      this.groupBox12.Controls.Add((Control) this.label26);
      this.groupBox12.Controls.Add((Control) this.label27);
      this.groupBox12.Controls.Add((Control) this.numericUpDown12);
      this.groupBox12.Controls.Add((Control) this.numericUpDown13);
      this.groupBox12.Controls.Add((Control) this.numericUpDown14);
      this.groupBox12.Controls.Add((Control) this.button14);
      this.groupBox12.Controls.Add((Control) this.button15);
      this.groupBox12.Controls.Add((Control) this.button16);
      this.groupBox12.Location = new Point(6, 8);
      this.groupBox12.Name = "groupBox12";
      this.groupBox12.Size = new Size(530, 489);
      this.groupBox12.TabIndex = 12;
      this.groupBox12.TabStop = false;
      this.groupBox12.Text = "Список событий недельного реле времени:";
      this.button47.Enabled = false;
      this.button47.Location = new Point(194, 445);
      this.button47.Name = "button47";
      this.button47.Size = new Size(330, 26);
      this.button47.TabIndex = 22;
      this.button47.Text = "Отменить последнее действие";
      this.button47.UseVisualStyleBackColor = true;
      this.button47.Click += new EventHandler(this.button47_Click);
      this.button37.Location = new Point(196, 402);
      this.button37.Name = "button37";
      this.button37.Size = new Size(328, 28);
      this.button37.TabIndex = 21;
      this.button37.Text = "Создать массив событий";
      this.button37.UseVisualStyleBackColor = true;
      this.button37.Click += new EventHandler(this.button37_Click);
      this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboBox1.FormattingEnabled = true;
      this.comboBox1.Items.AddRange(new object[7]
      {
        (object) "Понедельник",
        (object) "Вторник",
        (object) "Среда",
        (object) "Четверг",
        (object) "Пятница",
        (object) "Суббота",
        (object) "Воскресенье"
      });
      this.comboBox1.Location = new Point(15, 144);
      this.comboBox1.Name = "comboBox1";
      this.comboBox1.Size = new Size(144, 21);
      this.comboBox1.TabIndex = 19;
      this.label22.AutoSize = true;
      this.label22.Location = new Point(46, 118);
      this.label22.Name = "label22";
      this.label22.Size = new Size(76, 13);
      this.label22.TabIndex = 18;
      this.label22.Text = "День недели:";
      this.listView5.Columns.AddRange(new ColumnHeader[4]
      {
        this.columnHeader14,
        this.columnHeader17,
        this.columnHeader18,
        this.columnHeader19
      });
      this.listView5.FullRowSelect = true;
      this.listView5.GridLines = true;
      this.listView5.HeaderStyle = ColumnHeaderStyle.Nonclickable;
      this.listView5.Location = new Point(196, 19);
      this.listView5.Name = "listView5";
      this.listView5.Size = new Size(328, 368);
      this.listView5.TabIndex = 6;
      this.listView5.UseCompatibleStateImageBehavior = false;
      this.listView5.View = View.Details;
      this.columnHeader14.Text = "##";
      this.columnHeader14.Width = 29;
      this.columnHeader17.Text = "День недели";
      this.columnHeader17.TextAlign = HorizontalAlignment.Center;
      this.columnHeader17.Width = 80;
      this.columnHeader18.Text = "Время";
      this.columnHeader18.TextAlign = HorizontalAlignment.Center;
      this.columnHeader18.Width = 58;
      this.columnHeader19.Text = "Контакты";
      this.columnHeader19.Width = 83;
      this.groupBox13.Controls.Add((Control) this.radioButton23);
      this.groupBox13.Controls.Add((Control) this.radioButton24);
      this.groupBox13.Location = new Point(15, 240);
      this.groupBox13.Name = "groupBox13";
      this.groupBox13.Size = new Size(155, 105);
      this.groupBox13.TabIndex = 16;
      this.groupBox13.TabStop = false;
      this.groupBox13.Text = "Состояние контактов канала:";
      this.radioButton23.AutoSize = true;
      this.radioButton23.Location = new Point(27, 67);
      this.radioButton23.Name = "radioButton23";
      this.radioButton23.Size = new Size(74, 17);
      this.radioButton23.TabIndex = 16;
      this.radioButton23.TabStop = true;
      this.radioButton23.Text = "Включить";
      this.radioButton23.UseVisualStyleBackColor = true;
      this.radioButton24.AutoSize = true;
      this.radioButton24.Location = new Point(27, 35);
      this.radioButton24.Name = "radioButton24";
      this.radioButton24.Size = new Size(80, 17);
      this.radioButton24.TabIndex = 15;
      this.radioButton24.TabStop = true;
      this.radioButton24.Text = "Отключить";
      this.radioButton24.UseVisualStyleBackColor = true;
      this.label23.AutoSize = true;
      this.label23.Location = new Point(111, 210);
      this.label23.Name = "label23";
      this.label23.Size = new Size(10, 13);
      this.label23.TabIndex = 14;
      this.label23.Text = ":";
      this.label24.AutoSize = true;
      this.label24.Location = new Point(53, 210);
      this.label24.Name = "label24";
      this.label24.Size = new Size(10, 13);
      this.label24.TabIndex = 13;
      this.label24.Text = ":";
      this.label25.AutoSize = true;
      this.label25.Location = new Point(122, 183);
      this.label25.Name = "label25";
      this.label25.Size = new Size(51, 13);
      this.label25.TabIndex = 12;
      this.label25.Text = "Секунды";
      this.label26.AutoSize = true;
      this.label26.Location = new Point(60, 183);
      this.label26.Name = "label26";
      this.label26.Size = new Size(46, 13);
      this.label26.TabIndex = 11;
      this.label26.Text = "Минуты";
      this.label27.AutoSize = true;
      this.label27.Location = new Point(6, 183);
      this.label27.Name = "label27";
      this.label27.Size = new Size(35, 13);
      this.label27.TabIndex = 10;
      this.label27.Text = "Часы";
      this.numericUpDown12.Location = new Point((int) sbyte.MaxValue, 208);
      NumericUpDown numericUpDown12 = this.numericUpDown12;
      int[] bits13 = new int[4];
      bits13[0] = 59;
      Decimal num13 = new Decimal(bits13);
      numericUpDown12.Maximum = num13;
      this.numericUpDown12.Name = "numericUpDown12";
      this.numericUpDown12.Size = new Size(38, 20);
      this.numericUpDown12.TabIndex = 9;
      this.numericUpDown13.Location = new Point(68, 208);
      NumericUpDown numericUpDown13 = this.numericUpDown13;
      int[] bits14 = new int[4];
      bits14[0] = 59;
      Decimal num14 = new Decimal(bits14);
      numericUpDown13.Maximum = num14;
      this.numericUpDown13.Name = "numericUpDown13";
      this.numericUpDown13.Size = new Size(38, 20);
      this.numericUpDown13.TabIndex = 8;
      this.numericUpDown14.Location = new Point(9, 208);
      NumericUpDown numericUpDown14 = this.numericUpDown14;
      int[] bits15 = new int[4];
      bits15[0] = 23;
      Decimal num15 = new Decimal(bits15);
      numericUpDown14.Maximum = num15;
      this.numericUpDown14.Name = "numericUpDown14";
      this.numericUpDown14.Size = new Size(38, 20);
      this.numericUpDown14.TabIndex = 7;
      this.button14.Location = new Point(15, 445);
      this.button14.Name = "button14";
      this.button14.Size = new Size(155, 28);
      this.button14.TabIndex = 5;
      this.button14.Text = "Очистить список";
      this.button14.UseVisualStyleBackColor = true;
      this.button14.Click += new EventHandler(this.button14_Click);
      this.button15.Location = new Point(15, 402);
      this.button15.Name = "button15";
      this.button15.Size = new Size(155, 28);
      this.button15.TabIndex = 4;
      this.button15.Text = "Удалить выделенные";
      this.button15.UseVisualStyleBackColor = true;
      this.button15.Click += new EventHandler(this.button15_Click);
      this.button16.Location = new Point(15, 359);
      this.button16.Name = "button16";
      this.button16.Size = new Size(155, 28);
      this.button16.TabIndex = 3;
      this.button16.Text = "Добавить";
      this.button16.UseVisualStyleBackColor = true;
      this.button16.Click += new EventHandler(this.button16_Click);
      this.tabPage10_Day.BackColor = SystemColors.Control;
      this.tabPage10_Day.Controls.Add((Control) this.groupBox14);
      this.tabPage10_Day.Location = new Point(4, 22);
      this.tabPage10_Day.Name = "tabPage10_Day";
      this.tabPage10_Day.Padding = new Padding(3);
      this.tabPage10_Day.Size = new Size(542, 506);
      this.tabPage10_Day.TabIndex = 9;
      this.tabPage10_Day.Text = "Day";
      this.groupBox14.Controls.Add((Control) this.button48);
      this.groupBox14.Controls.Add((Control) this.button38);
      this.groupBox14.Controls.Add((Control) this.groupBox15);
      this.groupBox14.Controls.Add((Control) this.label28);
      this.groupBox14.Controls.Add((Control) this.label29);
      this.groupBox14.Controls.Add((Control) this.label30);
      this.groupBox14.Controls.Add((Control) this.label31);
      this.groupBox14.Controls.Add((Control) this.label32);
      this.groupBox14.Controls.Add((Control) this.numericUpDown10);
      this.groupBox14.Controls.Add((Control) this.numericUpDown11);
      this.groupBox14.Controls.Add((Control) this.numericUpDown15);
      this.groupBox14.Controls.Add((Control) this.listView6);
      this.groupBox14.Controls.Add((Control) this.button17);
      this.groupBox14.Controls.Add((Control) this.button18);
      this.groupBox14.Controls.Add((Control) this.button19);
      this.groupBox14.Location = new Point(6, 8);
      this.groupBox14.Name = "groupBox14";
      this.groupBox14.Size = new Size(530, 489);
      this.groupBox14.TabIndex = 10;
      this.groupBox14.TabStop = false;
      this.groupBox14.Text = "Список событий суточного реле времени:";
      this.button48.Enabled = false;
      this.button48.Location = new Point(190, 445);
      this.button48.Name = "button48";
      this.button48.Size = new Size(330, 26);
      this.button48.TabIndex = 23;
      this.button48.Text = "Отменить последнее действие";
      this.button48.UseVisualStyleBackColor = true;
      this.button48.Click += new EventHandler(this.button48_Click);
      this.button38.Location = new Point(190, 403);
      this.button38.Name = "button38";
      this.button38.Size = new Size(328, 28);
      this.button38.TabIndex = 22;
      this.button38.Text = "Создать массив событий";
      this.button38.UseVisualStyleBackColor = true;
      this.button38.Click += new EventHandler(this.button38_Click);
      this.groupBox15.Controls.Add((Control) this.radioButton25);
      this.groupBox15.Controls.Add((Control) this.radioButton26);
      this.groupBox15.Location = new Point(16, 241);
      this.groupBox15.Name = "groupBox15";
      this.groupBox15.Size = new Size(155, 105);
      this.groupBox15.TabIndex = 16;
      this.groupBox15.TabStop = false;
      this.groupBox15.Text = "Состояние контактов канала:";
      this.radioButton25.AutoSize = true;
      this.radioButton25.Location = new Point(27, 67);
      this.radioButton25.Name = "radioButton25";
      this.radioButton25.Size = new Size(74, 17);
      this.radioButton25.TabIndex = 16;
      this.radioButton25.TabStop = true;
      this.radioButton25.Text = "Включить";
      this.radioButton25.UseVisualStyleBackColor = true;
      this.radioButton26.AutoSize = true;
      this.radioButton26.Location = new Point(27, 35);
      this.radioButton26.Name = "radioButton26";
      this.radioButton26.Size = new Size(80, 17);
      this.radioButton26.TabIndex = 15;
      this.radioButton26.TabStop = true;
      this.radioButton26.Text = "Отключить";
      this.radioButton26.UseVisualStyleBackColor = true;
      this.label28.AutoSize = true;
      this.label28.Location = new Point(118, 199);
      this.label28.Name = "label28";
      this.label28.Size = new Size(10, 13);
      this.label28.TabIndex = 14;
      this.label28.Text = ":";
      this.label29.AutoSize = true;
      this.label29.Location = new Point(60, 199);
      this.label29.Name = "label29";
      this.label29.Size = new Size(10, 13);
      this.label29.TabIndex = 13;
      this.label29.Text = ":";
      this.label30.AutoSize = true;
      this.label30.Location = new Point(129, 172);
      this.label30.Name = "label30";
      this.label30.Size = new Size(51, 13);
      this.label30.TabIndex = 12;
      this.label30.Text = "Секунды";
      this.label31.AutoSize = true;
      this.label31.Location = new Point(67, 172);
      this.label31.Name = "label31";
      this.label31.Size = new Size(46, 13);
      this.label31.TabIndex = 11;
      this.label31.Text = "Минуты";
      this.label32.AutoSize = true;
      this.label32.Location = new Point(13, 172);
      this.label32.Name = "label32";
      this.label32.Size = new Size(35, 13);
      this.label32.TabIndex = 10;
      this.label32.Text = "Часы";
      this.numericUpDown10.Location = new Point(134, 197);
      NumericUpDown numericUpDown10 = this.numericUpDown10;
      int[] bits16 = new int[4];
      bits16[0] = 59;
      Decimal num16 = new Decimal(bits16);
      numericUpDown10.Maximum = num16;
      this.numericUpDown10.Name = "numericUpDown10";
      this.numericUpDown10.Size = new Size(38, 20);
      this.numericUpDown10.TabIndex = 9;
      this.numericUpDown11.Location = new Point(75, 197);
      NumericUpDown numericUpDown11 = this.numericUpDown11;
      int[] bits17 = new int[4];
      bits17[0] = 59;
      Decimal num17 = new Decimal(bits17);
      numericUpDown11.Maximum = num17;
      this.numericUpDown11.Name = "numericUpDown11";
      this.numericUpDown11.Size = new Size(38, 20);
      this.numericUpDown11.TabIndex = 8;
      this.numericUpDown15.Location = new Point(16, 197);
      NumericUpDown numericUpDown15 = this.numericUpDown15;
      int[] bits18 = new int[4];
      bits18[0] = 23;
      Decimal num18 = new Decimal(bits18);
      numericUpDown15.Maximum = num18;
      this.numericUpDown15.Name = "numericUpDown15";
      this.numericUpDown15.Size = new Size(38, 20);
      this.numericUpDown15.TabIndex = 7;
      this.listView6.Columns.AddRange(new ColumnHeader[3]
      {
        this.columnHeader20,
        this.columnHeader21,
        this.columnHeader22
      });
      this.listView6.FullRowSelect = true;
      this.listView6.GridLines = true;
      this.listView6.HeaderStyle = ColumnHeaderStyle.Nonclickable;
      this.listView6.Location = new Point(190, 19);
      this.listView6.Name = "listView6";
      this.listView6.Size = new Size(334, 368);
      this.listView6.TabIndex = 6;
      this.listView6.UseCompatibleStateImageBehavior = false;
      this.listView6.View = View.Details;
      this.columnHeader20.Text = "##";
      this.columnHeader20.Width = 40;
      this.columnHeader21.Text = "Время";
      this.columnHeader21.TextAlign = HorizontalAlignment.Center;
      this.columnHeader21.Width = 70;
      this.columnHeader22.Text = "Контакты";
      this.columnHeader22.TextAlign = HorizontalAlignment.Center;
      this.columnHeader22.Width = 110;
      this.button17.Location = new Point(14, 444);
      this.button17.Name = "button17";
      this.button17.Size = new Size(156, 28);
      this.button17.TabIndex = 5;
      this.button17.Text = "Очистить список";
      this.button17.UseVisualStyleBackColor = true;
      this.button17.Click += new EventHandler(this.button17_Click);
      this.button18.Location = new Point(15, 403);
      this.button18.Name = "button18";
      this.button18.Size = new Size(156, 28);
      this.button18.TabIndex = 4;
      this.button18.Text = "Удалить выделенные";
      this.button18.UseVisualStyleBackColor = true;
      this.button18.Click += new EventHandler(this.button18_Click);
      this.button19.Location = new Point(16, 359);
      this.button19.Name = "button19";
      this.button19.Size = new Size(156, 28);
      this.button19.TabIndex = 3;
      this.button19.Text = "Добавить";
      this.button19.UseVisualStyleBackColor = true;
      this.button19.Click += new EventHandler(this.button19_Click);
      this.tabPage11_ImpulseRelay.BackColor = SystemColors.Control;
      this.tabPage11_ImpulseRelay.Controls.Add((Control) this.groupBox16);
      this.tabPage11_ImpulseRelay.Location = new Point(4, 22);
      this.tabPage11_ImpulseRelay.Name = "tabPage11_ImpulseRelay";
      this.tabPage11_ImpulseRelay.Padding = new Padding(3);
      this.tabPage11_ImpulseRelay.Size = new Size(542, 506);
      this.tabPage11_ImpulseRelay.TabIndex = 10;
      this.tabPage11_ImpulseRelay.Text = "ImpRel";
      this.groupBox16.Controls.Add((Control) this.groupBox19);
      this.groupBox16.Controls.Add((Control) this.groupBox18);
      this.groupBox16.Controls.Add((Control) this.groupBox17);
      this.groupBox16.Location = new Point(6, 8);
      this.groupBox16.Name = "groupBox16";
      this.groupBox16.Size = new Size(530, 481);
      this.groupBox16.TabIndex = 4;
      this.groupBox16.TabStop = false;
      this.groupBox16.Text = "Настройки импульсного реле времени:";
      this.groupBox19.Controls.Add((Control) this.label39);
      this.groupBox19.Controls.Add((Control) this.numericUpDown21);
      this.groupBox19.Controls.Add((Control) this.label40);
      this.groupBox19.Controls.Add((Control) this.label41);
      this.groupBox19.Controls.Add((Control) this.numericUpDown22);
      this.groupBox19.Location = new Point(28, 245);
      this.groupBox19.Name = "groupBox19";
      this.groupBox19.Size = new Size(206, 106);
      this.groupBox19.TabIndex = 6;
      this.groupBox19.TabStop = false;
      this.groupBox19.Text = "Продолжительность отключенных контактов:";
      this.label39.AutoSize = true;
      this.label39.Location = new Point(109, 40);
      this.label39.Name = "label39";
      this.label39.Size = new Size(51, 13);
      this.label39.TabIndex = 4;
      this.label39.Text = "Секунды";
      this.numericUpDown21.Location = new Point(112, 66);
      NumericUpDown numericUpDown21_1 = this.numericUpDown21;
      int[] bits19 = new int[4];
      bits19[0] = 59;
      Decimal num19 = new Decimal(bits19);
      numericUpDown21_1.Maximum = num19;
      this.numericUpDown21.Name = "numericUpDown21";
      this.numericUpDown21.Size = new Size(47, 20);
      this.numericUpDown21.TabIndex = 3;
      NumericUpDown numericUpDown21_2 = this.numericUpDown21;
      int[] bits20 = new int[4];
      bits20[0] = 1;
      Decimal num20 = new Decimal(bits20);
      numericUpDown21_2.Value = num20;
      this.numericUpDown21.ValueChanged += new EventHandler(this.numericUpDown21_ValueChanged);
      this.label40.AutoSize = true;
      this.label40.Location = new Point(96, 68);
      this.label40.Name = "label40";
      this.label40.Size = new Size(10, 13);
      this.label40.TabIndex = 2;
      this.label40.Text = ":";
      this.label41.AutoSize = true;
      this.label41.Location = new Point(44, 40);
      this.label41.Name = "label41";
      this.label41.Size = new Size(46, 13);
      this.label41.TabIndex = 1;
      this.label41.Text = "Минуты";
      this.numericUpDown22.Location = new Point(43, 66);
      NumericUpDown numericUpDown22 = this.numericUpDown22;
      int[] bits21 = new int[4];
      bits21[0] = 99;
      Decimal num21 = new Decimal(bits21);
      numericUpDown22.Maximum = num21;
      this.numericUpDown22.Name = "numericUpDown22";
      this.numericUpDown22.Size = new Size(47, 20);
      this.numericUpDown22.TabIndex = 0;
      this.numericUpDown22.ValueChanged += new EventHandler(this.numericUpDown22_ValueChanged);
      this.groupBox18.Controls.Add((Control) this.label36);
      this.groupBox18.Controls.Add((Control) this.numericUpDown19);
      this.groupBox18.Controls.Add((Control) this.label37);
      this.groupBox18.Controls.Add((Control) this.label38);
      this.groupBox18.Controls.Add((Control) this.numericUpDown20);
      this.groupBox18.Location = new Point(28, 133);
      this.groupBox18.Name = "groupBox18";
      this.groupBox18.Size = new Size(206, 106);
      this.groupBox18.TabIndex = 5;
      this.groupBox18.TabStop = false;
      this.groupBox18.Text = "Продолжительность включенных контактов:";
      this.label36.AutoSize = true;
      this.label36.Location = new Point(109, 40);
      this.label36.Name = "label36";
      this.label36.Size = new Size(51, 13);
      this.label36.TabIndex = 4;
      this.label36.Text = "Секунды";
      this.numericUpDown19.Location = new Point(112, 66);
      NumericUpDown numericUpDown19_1 = this.numericUpDown19;
      int[] bits22 = new int[4];
      bits22[0] = 59;
      Decimal num22 = new Decimal(bits22);
      numericUpDown19_1.Maximum = num22;
      this.numericUpDown19.Name = "numericUpDown19";
      this.numericUpDown19.Size = new Size(47, 20);
      this.numericUpDown19.TabIndex = 3;
      NumericUpDown numericUpDown19_2 = this.numericUpDown19;
      int[] bits23 = new int[4];
      bits23[0] = 1;
      Decimal num23 = new Decimal(bits23);
      numericUpDown19_2.Value = num23;
      this.numericUpDown19.ValueChanged += new EventHandler(this.numericUpDown19_ValueChanged);
      this.label37.AutoSize = true;
      this.label37.Location = new Point(96, 68);
      this.label37.Name = "label37";
      this.label37.Size = new Size(10, 13);
      this.label37.TabIndex = 2;
      this.label37.Text = ":";
      this.label38.AutoSize = true;
      this.label38.Location = new Point(44, 40);
      this.label38.Name = "label38";
      this.label38.Size = new Size(46, 13);
      this.label38.TabIndex = 1;
      this.label38.Text = "Минуты";
      this.numericUpDown20.Location = new Point(43, 66);
      NumericUpDown numericUpDown20 = this.numericUpDown20;
      int[] bits24 = new int[4];
      bits24[0] = 99;
      Decimal num24 = new Decimal(bits24);
      numericUpDown20.Maximum = num24;
      this.numericUpDown20.Name = "numericUpDown20";
      this.numericUpDown20.Size = new Size(47, 20);
      this.numericUpDown20.TabIndex = 0;
      this.numericUpDown20.ValueChanged += new EventHandler(this.numericUpDown20_ValueChanged);
      this.groupBox17.Controls.Add((Control) this.label35);
      this.groupBox17.Controls.Add((Control) this.numericUpDown18);
      this.groupBox17.Controls.Add((Control) this.label34);
      this.groupBox17.Controls.Add((Control) this.label33);
      this.groupBox17.Controls.Add((Control) this.numericUpDown17);
      this.groupBox17.Location = new Point(28, 33);
      this.groupBox17.Name = "groupBox17";
      this.groupBox17.Size = new Size(206, 94);
      this.groupBox17.TabIndex = 0;
      this.groupBox17.TabStop = false;
      this.groupBox17.Text = "Предварительная задержка:";
      this.label35.AutoSize = true;
      this.label35.Location = new Point(109, 27);
      this.label35.Name = "label35";
      this.label35.Size = new Size(51, 13);
      this.label35.TabIndex = 4;
      this.label35.Text = "Секунды";
      this.numericUpDown18.Location = new Point(112, 53);
      NumericUpDown numericUpDown18 = this.numericUpDown18;
      int[] bits25 = new int[4];
      bits25[0] = 59;
      Decimal num25 = new Decimal(bits25);
      numericUpDown18.Maximum = num25;
      this.numericUpDown18.Name = "numericUpDown18";
      this.numericUpDown18.Size = new Size(47, 20);
      this.numericUpDown18.TabIndex = 3;
      this.numericUpDown18.ValueChanged += new EventHandler(this.numericUpDown18_ValueChanged);
      this.label34.AutoSize = true;
      this.label34.Location = new Point(96, 55);
      this.label34.Name = "label34";
      this.label34.Size = new Size(10, 13);
      this.label34.TabIndex = 2;
      this.label34.Text = ":";
      this.label33.AutoSize = true;
      this.label33.Location = new Point(44, 27);
      this.label33.Name = "label33";
      this.label33.Size = new Size(46, 13);
      this.label33.TabIndex = 1;
      this.label33.Text = "Минуты";
      this.numericUpDown17.Location = new Point(43, 53);
      NumericUpDown numericUpDown17 = this.numericUpDown17;
      int[] bits26 = new int[4];
      bits26[0] = 99;
      Decimal num26 = new Decimal(bits26);
      numericUpDown17.Maximum = num26;
      this.numericUpDown17.Name = "numericUpDown17";
      this.numericUpDown17.Size = new Size(47, 20);
      this.numericUpDown17.TabIndex = 0;
      this.numericUpDown17.ValueChanged += new EventHandler(this.numericUpDown17_ValueChanged);
      this.tabPage12_SimpleRelay.BackColor = SystemColors.Control;
      this.tabPage12_SimpleRelay.Controls.Add((Control) this.groupBox20);
      this.tabPage12_SimpleRelay.Location = new Point(4, 22);
      this.tabPage12_SimpleRelay.Name = "tabPage12_SimpleRelay";
      this.tabPage12_SimpleRelay.Padding = new Padding(3);
      this.tabPage12_SimpleRelay.Size = new Size(542, 506);
      this.tabPage12_SimpleRelay.TabIndex = 11;
      this.tabPage12_SimpleRelay.Text = "SimpRel";
      this.groupBox20.Controls.Add((Control) this.groupBox23);
      this.groupBox20.Location = new Point(6, 8);
      this.groupBox20.Name = "groupBox20";
      this.groupBox20.Size = new Size(530, 489);
      this.groupBox20.TabIndex = 5;
      this.groupBox20.TabStop = false;
      this.groupBox20.Text = "Настройки простого реле времени:";
      this.groupBox23.Controls.Add((Control) this.label48);
      this.groupBox23.Controls.Add((Control) this.numericUpDown27);
      this.groupBox23.Controls.Add((Control) this.label49);
      this.groupBox23.Controls.Add((Control) this.label50);
      this.groupBox23.Controls.Add((Control) this.numericUpDown28);
      this.groupBox23.Location = new Point(28, 33);
      this.groupBox23.Name = "groupBox23";
      this.groupBox23.Size = new Size(206, 107);
      this.groupBox23.TabIndex = 0;
      this.groupBox23.TabStop = false;
      this.groupBox23.Text = "Выдержка перед включением контактов:";
      this.label48.AutoSize = true;
      this.label48.Location = new Point(109, 39);
      this.label48.Name = "label48";
      this.label48.Size = new Size(51, 13);
      this.label48.TabIndex = 4;
      this.label48.Text = "Секунды";
      this.numericUpDown27.Location = new Point(112, 65);
      NumericUpDown numericUpDown27 = this.numericUpDown27;
      int[] bits27 = new int[4];
      bits27[0] = 59;
      Decimal num27 = new Decimal(bits27);
      numericUpDown27.Maximum = num27;
      this.numericUpDown27.Name = "numericUpDown27";
      this.numericUpDown27.Size = new Size(47, 20);
      this.numericUpDown27.TabIndex = 3;
      this.numericUpDown27.ValueChanged += new EventHandler(this.numericUpDown27_ValueChanged);
      this.label49.AutoSize = true;
      this.label49.Location = new Point(96, 67);
      this.label49.Name = "label49";
      this.label49.Size = new Size(10, 13);
      this.label49.TabIndex = 2;
      this.label49.Text = ":";
      this.label50.AutoSize = true;
      this.label50.Location = new Point(44, 39);
      this.label50.Name = "label50";
      this.label50.Size = new Size(46, 13);
      this.label50.TabIndex = 1;
      this.label50.Text = "Минуты";
      this.numericUpDown28.Location = new Point(43, 65);
      NumericUpDown numericUpDown28 = this.numericUpDown28;
      int[] bits28 = new int[4];
      bits28[0] = 99;
      Decimal num28 = new Decimal(bits28);
      numericUpDown28.Maximum = num28;
      this.numericUpDown28.Name = "numericUpDown28";
      this.numericUpDown28.Size = new Size(47, 20);
      this.numericUpDown28.TabIndex = 0;
      this.numericUpDown28.ValueChanged += new EventHandler(this.numericUpDown28_ValueChanged);
      this.tabPage14_RV.BackColor = SystemColors.Control;
      this.tabPage14_RV.Controls.Add((Control) this.groupBox21);
      this.tabPage14_RV.Location = new Point(4, 22);
      this.tabPage14_RV.Name = "tabPage14_RV";
      this.tabPage14_RV.Padding = new Padding(3);
      this.tabPage14_RV.Size = new Size(542, 506);
      this.tabPage14_RV.TabIndex = 12;
      this.tabPage14_RV.Text = "RV";
      this.groupBox21.Controls.Add((Control) this.groupBox36);
      this.groupBox21.Controls.Add((Control) this.groupBox28);
      this.groupBox21.Controls.Add((Control) this.groupBox27);
      this.groupBox21.Controls.Add((Control) this.groupBox26);
      this.groupBox21.Controls.Add((Control) this.groupBox25);
      this.groupBox21.Controls.Add((Control) this.groupBox22);
      this.groupBox21.Location = new Point(6, 8);
      this.groupBox21.Name = "groupBox21";
      this.groupBox21.Size = new Size(531, 489);
      this.groupBox21.TabIndex = 4;
      this.groupBox21.TabStop = false;
      this.groupBox21.Text = "Настройки реле напряжения:";
      this.groupBox36.Controls.Add((Control) this.numericUpDown45);
      this.groupBox36.Controls.Add((Control) this.label71);
      this.groupBox36.Controls.Add((Control) this.numericUpDown46);
      this.groupBox36.Controls.Add((Control) this.label72);
      this.groupBox36.Location = new Point(54, 191);
      this.groupBox36.Name = "groupBox36";
      this.groupBox36.Size = new Size(207, 110);
      this.groupBox36.TabIndex = 12;
      this.groupBox36.TabStop = false;
      this.groupBox36.Text = "Нижний порог рабочего диапазона:";
      this.numericUpDown45.Location = new Point(124, 62);
      NumericUpDown numericUpDown45_1 = this.numericUpDown45;
      int[] bits29 = new int[4];
      bits29[0] = 9;
      Decimal num29 = new Decimal(bits29);
      numericUpDown45_1.Maximum = num29;
      NumericUpDown numericUpDown45_2 = this.numericUpDown45;
      int[] bits30 = new int[4];
      bits30[0] = 3;
      Decimal num30 = new Decimal(bits30);
      numericUpDown45_2.Minimum = num30;
      this.numericUpDown45.Name = "numericUpDown45";
      this.numericUpDown45.Size = new Size(55, 20);
      this.numericUpDown45.TabIndex = 3;
      NumericUpDown numericUpDown45_3 = this.numericUpDown45;
      int[] bits31 = new int[4];
      bits31[0] = 3;
      Decimal num31 = new Decimal(bits31);
      numericUpDown45_3.Value = num31;
      this.numericUpDown45.ValueChanged += new EventHandler(this.numericUpDown45_ValueChanged);
      this.label71.AutoSize = true;
      this.label71.Location = new Point(25, 56);
      this.label71.Name = "label71";
      this.label71.Size = new Size(93, 26);
      this.label71.TabIndex = 2;
      this.label71.Text = "Положительный \r\nгистерезис, В:";
      this.numericUpDown46.Location = new Point(124, 36);
      NumericUpDown numericUpDown46_1 = this.numericUpDown46;
      int[] bits32 = new int[4];
      bits32[0] = 420;
      Decimal num32 = new Decimal(bits32);
      numericUpDown46_1.Maximum = num32;
      NumericUpDown numericUpDown46_2 = this.numericUpDown46;
      int[] bits33 = new int[4];
      bits33[0] = 90;
      Decimal num33 = new Decimal(bits33);
      numericUpDown46_2.Minimum = num33;
      this.numericUpDown46.Name = "numericUpDown46";
      this.numericUpDown46.Size = new Size(55, 20);
      this.numericUpDown46.TabIndex = 1;
      NumericUpDown numericUpDown46_3 = this.numericUpDown46;
      int[] bits34 = new int[4];
      bits34[0] = 100;
      Decimal num34 = new Decimal(bits34);
      numericUpDown46_3.Value = num34;
      this.numericUpDown46.ValueChanged += new EventHandler(this.numericUpDown46_ValueChanged);
      this.label72.AutoSize = true;
      this.label72.Location = new Point(71, 38);
      this.label72.Name = "label72";
      this.label72.Size = new Size(47, 13);
      this.label72.TabIndex = 0;
      this.label72.Text = "Umin, В:";
      this.groupBox28.Controls.Add((Control) this.label55);
      this.groupBox28.Controls.Add((Control) this.numericUpDown33);
      this.groupBox28.Controls.Add((Control) this.label56);
      this.groupBox28.Controls.Add((Control) this.label57);
      this.groupBox28.Controls.Add((Control) this.numericUpDown34);
      this.groupBox28.Location = new Point(267, 307);
      this.groupBox28.Name = "groupBox28";
      this.groupBox28.Size = new Size(207, 105);
      this.groupBox28.TabIndex = 11;
      this.groupBox28.TabStop = false;
      this.groupBox28.Text = "Задержка выключения по верхнему порогу ( U > Umax):";
      this.label55.AutoSize = true;
      this.label55.Location = new Point(104, 40);
      this.label55.Name = "label55";
      this.label55.Size = new Size(51, 13);
      this.label55.TabIndex = 9;
      this.label55.Text = "Секунды";
      this.numericUpDown33.Location = new Point(107, 66);
      NumericUpDown numericUpDown33 = this.numericUpDown33;
      int[] bits35 = new int[4];
      bits35[0] = 59;
      Decimal num35 = new Decimal(bits35);
      numericUpDown33.Maximum = num35;
      this.numericUpDown33.Name = "numericUpDown33";
      this.numericUpDown33.Size = new Size(47, 20);
      this.numericUpDown33.TabIndex = 8;
      this.numericUpDown33.ValueChanged += new EventHandler(this.numericUpDown33_ValueChanged);
      this.label56.AutoSize = true;
      this.label56.Location = new Point(91, 68);
      this.label56.Name = "label56";
      this.label56.Size = new Size(10, 13);
      this.label56.TabIndex = 7;
      this.label56.Text = ":";
      this.label57.AutoSize = true;
      this.label57.Location = new Point(39, 40);
      this.label57.Name = "label57";
      this.label57.Size = new Size(46, 13);
      this.label57.TabIndex = 6;
      this.label57.Text = "Минуты";
      this.numericUpDown34.Location = new Point(38, 66);
      NumericUpDown numericUpDown34 = this.numericUpDown34;
      int[] bits36 = new int[4];
      bits36[0] = 19;
      Decimal num36 = new Decimal(bits36);
      numericUpDown34.Maximum = num36;
      this.numericUpDown34.Name = "numericUpDown34";
      this.numericUpDown34.Size = new Size(47, 20);
      this.numericUpDown34.TabIndex = 5;
      this.numericUpDown34.ValueChanged += new EventHandler(this.numericUpDown34_ValueChanged);
      this.groupBox27.Controls.Add((Control) this.label52);
      this.groupBox27.Controls.Add((Control) this.numericUpDown31);
      this.groupBox27.Controls.Add((Control) this.label53);
      this.groupBox27.Controls.Add((Control) this.label54);
      this.groupBox27.Controls.Add((Control) this.numericUpDown32);
      this.groupBox27.Location = new Point(266, 191);
      this.groupBox27.Name = "groupBox27";
      this.groupBox27.Size = new Size(207, 110);
      this.groupBox27.TabIndex = 10;
      this.groupBox27.TabStop = false;
      this.groupBox27.Text = "Задержка повторного включения  (Umin <  U < Umax):";
      this.label52.AutoSize = true;
      this.label52.Location = new Point(104, 40);
      this.label52.Name = "label52";
      this.label52.Size = new Size(51, 13);
      this.label52.TabIndex = 9;
      this.label52.Text = "Секунды";
      this.numericUpDown31.Location = new Point(107, 66);
      NumericUpDown numericUpDown31_1 = this.numericUpDown31;
      int[] bits37 = new int[4];
      bits37[0] = 59;
      Decimal num37 = new Decimal(bits37);
      numericUpDown31_1.Maximum = num37;
      this.numericUpDown31.Name = "numericUpDown31";
      this.numericUpDown31.Size = new Size(47, 20);
      this.numericUpDown31.TabIndex = 8;
      NumericUpDown numericUpDown31_2 = this.numericUpDown31;
      int[] bits38 = new int[4];
      bits38[0] = 1;
      Decimal num38 = new Decimal(bits38);
      numericUpDown31_2.Value = num38;
      this.numericUpDown31.ValueChanged += new EventHandler(this.numericUpDown31_ValueChanged);
      this.label53.AutoSize = true;
      this.label53.Location = new Point(91, 68);
      this.label53.Name = "label53";
      this.label53.Size = new Size(10, 13);
      this.label53.TabIndex = 7;
      this.label53.Text = ":";
      this.label54.AutoSize = true;
      this.label54.Location = new Point(39, 40);
      this.label54.Name = "label54";
      this.label54.Size = new Size(46, 13);
      this.label54.TabIndex = 6;
      this.label54.Text = "Минуты";
      this.numericUpDown32.Location = new Point(38, 66);
      NumericUpDown numericUpDown32 = this.numericUpDown32;
      int[] bits39 = new int[4];
      bits39[0] = 19;
      Decimal num39 = new Decimal(bits39);
      numericUpDown32.Maximum = num39;
      this.numericUpDown32.Name = "numericUpDown32";
      this.numericUpDown32.Size = new Size(47, 20);
      this.numericUpDown32.TabIndex = 5;
      this.numericUpDown32.ValueChanged += new EventHandler(this.numericUpDown32_ValueChanged);
      this.groupBox26.Controls.Add((Control) this.label46);
      this.groupBox26.Controls.Add((Control) this.numericUpDown29);
      this.groupBox26.Controls.Add((Control) this.label47);
      this.groupBox26.Controls.Add((Control) this.label51);
      this.groupBox26.Controls.Add((Control) this.numericUpDown30);
      this.groupBox26.Location = new Point(266, 83);
      this.groupBox26.Name = "groupBox26";
      this.groupBox26.Size = new Size(207, 102);
      this.groupBox26.TabIndex = 9;
      this.groupBox26.TabStop = false;
      this.groupBox26.Text = "Задержка выключения по нижнему порогу ( U < Umin ):";
      this.label46.AutoSize = true;
      this.label46.Location = new Point(104, 40);
      this.label46.Name = "label46";
      this.label46.Size = new Size(51, 13);
      this.label46.TabIndex = 9;
      this.label46.Text = "Секунды";
      this.numericUpDown29.Location = new Point(107, 66);
      NumericUpDown numericUpDown29 = this.numericUpDown29;
      int[] bits40 = new int[4];
      bits40[0] = 59;
      Decimal num40 = new Decimal(bits40);
      numericUpDown29.Maximum = num40;
      this.numericUpDown29.Name = "numericUpDown29";
      this.numericUpDown29.Size = new Size(47, 20);
      this.numericUpDown29.TabIndex = 8;
      this.numericUpDown29.ValueChanged += new EventHandler(this.numericUpDown29_ValueChanged);
      this.label47.AutoSize = true;
      this.label47.Location = new Point(91, 68);
      this.label47.Name = "label47";
      this.label47.Size = new Size(10, 13);
      this.label47.TabIndex = 7;
      this.label47.Text = ":";
      this.label51.AutoSize = true;
      this.label51.Location = new Point(39, 40);
      this.label51.Name = "label51";
      this.label51.Size = new Size(46, 13);
      this.label51.TabIndex = 6;
      this.label51.Text = "Минуты";
      this.numericUpDown30.Location = new Point(38, 66);
      NumericUpDown numericUpDown30 = this.numericUpDown30;
      int[] bits41 = new int[4];
      bits41[0] = 19;
      Decimal num41 = new Decimal(bits41);
      numericUpDown30.Maximum = num41;
      this.numericUpDown30.Name = "numericUpDown30";
      this.numericUpDown30.Size = new Size(47, 20);
      this.numericUpDown30.TabIndex = 5;
      this.numericUpDown30.ValueChanged += new EventHandler(this.numericUpDown30_ValueChanged);
      this.groupBox25.Controls.Add((Control) this.numericUpDown25);
      this.groupBox25.Controls.Add((Control) this.label44);
      this.groupBox25.Controls.Add((Control) this.numericUpDown26);
      this.groupBox25.Controls.Add((Control) this.label45);
      this.groupBox25.Location = new Point(54, 307);
      this.groupBox25.Name = "groupBox25";
      this.groupBox25.Size = new Size(207, 105);
      this.groupBox25.TabIndex = 9;
      this.groupBox25.TabStop = false;
      this.groupBox25.Text = "Верхний порог рабочего диапазона:";
      this.numericUpDown25.Location = new Point(124, 61);
      NumericUpDown numericUpDown25_1 = this.numericUpDown25;
      int[] bits42 = new int[4];
      bits42[0] = 9;
      Decimal num42 = new Decimal(bits42);
      numericUpDown25_1.Maximum = num42;
      NumericUpDown numericUpDown25_2 = this.numericUpDown25;
      int[] bits43 = new int[4];
      bits43[0] = 3;
      Decimal num43 = new Decimal(bits43);
      numericUpDown25_2.Minimum = num43;
      this.numericUpDown25.Name = "numericUpDown25";
      this.numericUpDown25.Size = new Size(55, 20);
      this.numericUpDown25.TabIndex = 3;
      NumericUpDown numericUpDown25_3 = this.numericUpDown25;
      int[] bits44 = new int[4];
      bits44[0] = 3;
      Decimal num44 = new Decimal(bits44);
      numericUpDown25_3.Value = num44;
      this.numericUpDown25.ValueChanged += new EventHandler(this.numericUpDown25_ValueChanged);
      this.label44.AutoSize = true;
      this.label44.Location = new Point(25, 55);
      this.label44.Name = "label44";
      this.label44.Size = new Size(90, 26);
      this.label44.TabIndex = 2;
      this.label44.Text = "Отрицательный \r\nгистерезис, В:";
      this.numericUpDown26.Location = new Point(124, 35);
      NumericUpDown numericUpDown26_1 = this.numericUpDown26;
      int[] bits45 = new int[4];
      bits45[0] = 420;
      Decimal num45 = new Decimal(bits45);
      numericUpDown26_1.Maximum = num45;
      NumericUpDown numericUpDown26_2 = this.numericUpDown26;
      int[] bits46 = new int[4];
      bits46[0] = 100;
      Decimal num46 = new Decimal(bits46);
      numericUpDown26_2.Minimum = num46;
      this.numericUpDown26.Name = "numericUpDown26";
      this.numericUpDown26.Size = new Size(55, 20);
      this.numericUpDown26.TabIndex = 1;
      NumericUpDown numericUpDown26_3 = this.numericUpDown26;
      int[] bits47 = new int[4];
      bits47[0] = 100;
      Decimal num47 = new Decimal(bits47);
      numericUpDown26_3.Value = num47;
      this.numericUpDown26.ValueChanged += new EventHandler(this.numericUpDown26_ValueChanged);
      this.label45.AutoSize = true;
      this.label45.Location = new Point(71, 37);
      this.label45.Name = "label45";
      this.label45.Size = new Size(50, 13);
      this.label45.TabIndex = 0;
      this.label45.Text = "Umax, В:";
      this.groupBox22.Controls.Add((Control) this.radioButton27);
      this.groupBox22.Controls.Add((Control) this.radioButton33);
      this.groupBox22.Location = new Point(54, 83);
      this.groupBox22.Name = "groupBox22";
      this.groupBox22.Size = new Size(206, 102);
      this.groupBox22.TabIndex = 7;
      this.groupBox22.TabStop = false;
      this.groupBox22.Text = "Режим работы:";
      this.radioButton27.AutoSize = true;
      this.radioButton27.Location = new Point(28, 36);
      this.radioButton27.Name = "radioButton27";
      this.radioButton27.Size = new Size(81, 17);
      this.radioButton27.TabIndex = 6;
      this.radioButton27.TabStop = true;
      this.radioButton27.Text = "Отключено";
      this.radioButton27.UseVisualStyleBackColor = true;
      this.radioButton27.CheckedChanged += new EventHandler(this.radioButton27_CheckedChanged);
      this.radioButton33.AutoSize = true;
      this.radioButton33.Location = new Point(28, 64);
      this.radioButton33.Name = "radioButton33";
      this.radioButton33.Size = new Size(75, 17);
      this.radioButton33.TabIndex = 0;
      this.radioButton33.TabStop = true;
      this.radioButton33.Text = "Включено";
      this.radioButton33.UseVisualStyleBackColor = true;
      this.radioButton33.CheckedChanged += new EventHandler(this.radioButton33_CheckedChanged);
      this.tabPage15_RF.BackColor = SystemColors.Control;
      this.tabPage15_RF.Controls.Add((Control) this.groupBox29);
      this.tabPage15_RF.Location = new Point(4, 22);
      this.tabPage15_RF.Name = "tabPage15_RF";
      this.tabPage15_RF.Padding = new Padding(3);
      this.tabPage15_RF.Size = new Size(542, 506);
      this.tabPage15_RF.TabIndex = 13;
      this.tabPage15_RF.Text = "RF";
      this.groupBox29.Controls.Add((Control) this.groupBox24);
      this.groupBox29.Controls.Add((Control) this.groupBox30);
      this.groupBox29.Controls.Add((Control) this.groupBox31);
      this.groupBox29.Controls.Add((Control) this.groupBox32);
      this.groupBox29.Controls.Add((Control) this.groupBox33);
      this.groupBox29.Controls.Add((Control) this.groupBox35);
      this.groupBox29.Location = new Point(6, 8);
      this.groupBox29.Name = "groupBox29";
      this.groupBox29.Size = new Size(530, 489);
      this.groupBox29.TabIndex = 5;
      this.groupBox29.TabStop = false;
      this.groupBox29.Text = "Настройки фотореле:";
      this.groupBox24.Controls.Add((Control) this.numericUpDown24);
      this.groupBox24.Controls.Add((Control) this.label43);
      this.groupBox24.Controls.Add((Control) this.numericUpDown23);
      this.groupBox24.Controls.Add((Control) this.label42);
      this.groupBox24.Location = new Point(268, 74);
      this.groupBox24.Name = "groupBox24";
      this.groupBox24.Size = new Size(207, 82);
      this.groupBox24.TabIndex = 12;
      this.groupBox24.TabStop = false;
      this.groupBox24.Text = "Порог освещенности:";
      this.numericUpDown24.Location = new Point(124, 46);
      NumericUpDown numericUpDown24_1 = this.numericUpDown24;
      int[] bits48 = new int[4];
      bits48[0] = 999;
      Decimal num48 = new Decimal(bits48);
      numericUpDown24_1.Maximum = num48;
      this.numericUpDown24.Name = "numericUpDown24";
      this.numericUpDown24.Size = new Size(55, 20);
      this.numericUpDown24.TabIndex = 3;
      NumericUpDown numericUpDown24_2 = this.numericUpDown24;
      int[] bits49 = new int[4];
      bits49[0] = 5;
      Decimal num49 = new Decimal(bits49);
      numericUpDown24_2.Value = num49;
      this.numericUpDown24.ValueChanged += new EventHandler(this.numericUpDown24_ValueChanged);
      this.label43.AutoSize = true;
      this.label43.Location = new Point(18, 40);
      this.label43.Name = "label43";
      this.label43.Size = new Size(100, 26);
      this.label43.TabIndex = 2;
      this.label43.Text = "Положительный \r\nгистерезис, люкс:";
      this.numericUpDown23.Location = new Point(124, 20);
      NumericUpDown numericUpDown23_1 = this.numericUpDown23;
      int[] bits50 = new int[4];
      bits50[0] = 9999;
      Decimal num50 = new Decimal(bits50);
      numericUpDown23_1.Maximum = num50;
      this.numericUpDown23.Name = "numericUpDown23";
      this.numericUpDown23.Size = new Size(55, 20);
      this.numericUpDown23.TabIndex = 1;
      NumericUpDown numericUpDown23_2 = this.numericUpDown23;
      int[] bits51 = new int[4];
      bits51[0] = 30;
      Decimal num51 = new Decimal(bits51);
      numericUpDown23_2.Value = num51;
      this.numericUpDown23.ValueChanged += new EventHandler(this.numericUpDown23_ValueChanged);
      this.label42.AutoSize = true;
      this.label42.Location = new Point(49, 22);
      this.label42.Name = "label42";
      this.label42.Size = new Size(66, 13);
      this.label42.TabIndex = 0;
      this.label42.Text = "Lпор, люкс:";
      this.groupBox30.Controls.Add((Control) this.radioButton36);
      this.groupBox30.Controls.Add((Control) this.radioButton39);
      this.groupBox30.Controls.Add((Control) this.radioButton37);
      this.groupBox30.Controls.Add((Control) this.radioButton40);
      this.groupBox30.Controls.Add((Control) this.radioButton38);
      this.groupBox30.Location = new Point(268, 253);
      this.groupBox30.Name = "groupBox30";
      this.groupBox30.Size = new Size(207, 168);
      this.groupBox30.TabIndex = 11;
      this.groupBox30.TabStop = false;
      this.groupBox30.Text = "Положение контактов в случае              L > Lпор:";
      this.radioButton36.AutoSize = true;
      this.radioButton36.Location = new Point(16, 136);
      this.radioButton36.Name = "radioButton36";
      this.radioButton36.Size = new Size(158, 30);
      this.radioButton36.TabIndex = 9;
      this.radioButton36.TabStop = true;
      this.radioButton36.Text = "Включить до следующего \r\nсобытия";
      this.radioButton36.UseVisualStyleBackColor = true;
      this.radioButton36.CheckedChanged += new EventHandler(this.radioButton36_CheckedChanged);
      this.radioButton39.AutoSize = true;
      this.radioButton39.Location = new Point(16, 57);
      this.radioButton39.Name = "radioButton39";
      this.radioButton39.Size = new Size(74, 17);
      this.radioButton39.TabIndex = 6;
      this.radioButton39.TabStop = true;
      this.radioButton39.Text = "Включить";
      this.radioButton39.UseVisualStyleBackColor = true;
      this.radioButton39.CheckedChanged += new EventHandler(this.radioButton39_CheckedChanged);
      this.radioButton37.AutoSize = true;
      this.radioButton37.Location = new Point(16, 101);
      this.radioButton37.Name = "radioButton37";
      this.radioButton37.Size = new Size(161, 30);
      this.radioButton37.TabIndex = 8;
      this.radioButton37.TabStop = true;
      this.radioButton37.Text = "Отключить до следующего\r\nсобытия";
      this.radioButton37.UseVisualStyleBackColor = true;
      this.radioButton37.CheckedChanged += new EventHandler(this.radioButton37_CheckedChanged);
      this.radioButton40.AutoSize = true;
      this.radioButton40.Location = new Point(16, 35);
      this.radioButton40.Name = "radioButton40";
      this.radioButton40.Size = new Size(80, 17);
      this.radioButton40.TabIndex = 5;
      this.radioButton40.TabStop = true;
      this.radioButton40.Text = "Отключить";
      this.radioButton40.UseVisualStyleBackColor = true;
      this.radioButton40.CheckedChanged += new EventHandler(this.radioButton40_CheckedChanged);
      this.radioButton38.AutoSize = true;
      this.radioButton38.Location = new Point(16, 79);
      this.radioButton38.Name = "radioButton38";
      this.radioButton38.Size = new Size(153, 17);
      this.radioButton38.TabIndex = 7;
      this.radioButton38.TabStop = true;
      this.radioButton38.Text = "Повторять реле времени";
      this.radioButton38.UseVisualStyleBackColor = true;
      this.radioButton38.CheckedChanged += new EventHandler(this.radioButton38_CheckedChanged);
      this.groupBox31.Controls.Add((Control) this.label61);
      this.groupBox31.Controls.Add((Control) this.numericUpDown37);
      this.groupBox31.Controls.Add((Control) this.label62);
      this.groupBox31.Controls.Add((Control) this.label63);
      this.groupBox31.Controls.Add((Control) this.numericUpDown38);
      this.groupBox31.Location = new Point(269, 162);
      this.groupBox31.Name = "groupBox31";
      this.groupBox31.Size = new Size(207, 85);
      this.groupBox31.TabIndex = 10;
      this.groupBox31.TabStop = false;
      this.groupBox31.Text = "Задержка в случае L > Lпор:";
      this.label61.AutoSize = true;
      this.label61.Location = new Point(108, 25);
      this.label61.Name = "label61";
      this.label61.Size = new Size(51, 13);
      this.label61.TabIndex = 9;
      this.label61.Text = "Секунды";
      this.numericUpDown37.Location = new Point(111, 51);
      NumericUpDown numericUpDown37_1 = this.numericUpDown37;
      int[] bits52 = new int[4];
      bits52[0] = 59;
      Decimal num52 = new Decimal(bits52);
      numericUpDown37_1.Maximum = num52;
      this.numericUpDown37.Name = "numericUpDown37";
      this.numericUpDown37.Size = new Size(47, 20);
      this.numericUpDown37.TabIndex = 8;
      NumericUpDown numericUpDown37_2 = this.numericUpDown37;
      int[] bits53 = new int[4];
      bits53[0] = 1;
      Decimal num53 = new Decimal(bits53);
      numericUpDown37_2.Value = num53;
      this.numericUpDown37.ValueChanged += new EventHandler(this.numericUpDown37_ValueChanged);
      this.label62.AutoSize = true;
      this.label62.Location = new Point(95, 53);
      this.label62.Name = "label62";
      this.label62.Size = new Size(10, 13);
      this.label62.TabIndex = 7;
      this.label62.Text = ":";
      this.label63.AutoSize = true;
      this.label63.Location = new Point(43, 25);
      this.label63.Name = "label63";
      this.label63.Size = new Size(46, 13);
      this.label63.TabIndex = 6;
      this.label63.Text = "Минуты";
      this.numericUpDown38.Location = new Point(42, 51);
      NumericUpDown numericUpDown38 = this.numericUpDown38;
      int[] bits54 = new int[4];
      bits54[0] = 99;
      Decimal num54 = new Decimal(bits54);
      numericUpDown38.Maximum = num54;
      this.numericUpDown38.Name = "numericUpDown38";
      this.numericUpDown38.Size = new Size(47, 20);
      this.numericUpDown38.TabIndex = 5;
      this.numericUpDown38.ValueChanged += new EventHandler(this.numericUpDown38_ValueChanged);
      this.groupBox32.Controls.Add((Control) this.label64);
      this.groupBox32.Controls.Add((Control) this.numericUpDown39);
      this.groupBox32.Controls.Add((Control) this.label65);
      this.groupBox32.Controls.Add((Control) this.label66);
      this.groupBox32.Controls.Add((Control) this.numericUpDown40);
      this.groupBox32.Location = new Point(55, 162);
      this.groupBox32.Name = "groupBox32";
      this.groupBox32.Size = new Size(207, 85);
      this.groupBox32.TabIndex = 9;
      this.groupBox32.TabStop = false;
      this.groupBox32.Text = "Задержка в случае L < Lпор:";
      this.label64.AutoSize = true;
      this.label64.Location = new Point(104, 25);
      this.label64.Name = "label64";
      this.label64.Size = new Size(51, 13);
      this.label64.TabIndex = 9;
      this.label64.Text = "Секунды";
      this.numericUpDown39.Location = new Point(107, 51);
      NumericUpDown numericUpDown39_1 = this.numericUpDown39;
      int[] bits55 = new int[4];
      bits55[0] = 59;
      Decimal num55 = new Decimal(bits55);
      numericUpDown39_1.Maximum = num55;
      this.numericUpDown39.Name = "numericUpDown39";
      this.numericUpDown39.Size = new Size(47, 20);
      this.numericUpDown39.TabIndex = 8;
      NumericUpDown numericUpDown39_2 = this.numericUpDown39;
      int[] bits56 = new int[4];
      bits56[0] = 1;
      Decimal num56 = new Decimal(bits56);
      numericUpDown39_2.Value = num56;
      this.numericUpDown39.ValueChanged += new EventHandler(this.numericUpDown39_ValueChanged);
      this.label65.AutoSize = true;
      this.label65.Location = new Point(91, 53);
      this.label65.Name = "label65";
      this.label65.Size = new Size(10, 13);
      this.label65.TabIndex = 7;
      this.label65.Text = ":";
      this.label66.AutoSize = true;
      this.label66.Location = new Point(39, 25);
      this.label66.Name = "label66";
      this.label66.Size = new Size(46, 13);
      this.label66.TabIndex = 6;
      this.label66.Text = "Минуты";
      this.numericUpDown40.Location = new Point(38, 51);
      NumericUpDown numericUpDown40 = this.numericUpDown40;
      int[] bits57 = new int[4];
      bits57[0] = 99;
      Decimal num57 = new Decimal(bits57);
      numericUpDown40.Maximum = num57;
      this.numericUpDown40.Name = "numericUpDown40";
      this.numericUpDown40.Size = new Size(47, 20);
      this.numericUpDown40.TabIndex = 5;
      this.numericUpDown40.ValueChanged += new EventHandler(this.numericUpDown40_ValueChanged);
      this.groupBox33.Controls.Add((Control) this.radioButton30);
      this.groupBox33.Controls.Add((Control) this.radioButton35);
      this.groupBox33.Controls.Add((Control) this.radioButton31);
      this.groupBox33.Controls.Add((Control) this.radioButton34);
      this.groupBox33.Controls.Add((Control) this.radioButton32);
      this.groupBox33.Location = new Point(55, 253);
      this.groupBox33.Name = "groupBox33";
      this.groupBox33.Size = new Size(207, 168);
      this.groupBox33.TabIndex = 9;
      this.groupBox33.TabStop = false;
      this.groupBox33.Text = "Положение контактов в случае              L < Lпор:";
      this.radioButton30.AutoSize = true;
      this.radioButton30.Location = new Point(15, 136);
      this.radioButton30.Name = "radioButton30";
      this.radioButton30.Size = new Size(158, 30);
      this.radioButton30.TabIndex = 14;
      this.radioButton30.TabStop = true;
      this.radioButton30.Text = "Включить до следующего \r\nсобытия";
      this.radioButton30.UseVisualStyleBackColor = true;
      this.radioButton30.CheckedChanged += new EventHandler(this.radioButton30_CheckedChanged);
      this.radioButton35.AutoSize = true;
      this.radioButton35.Location = new Point(15, 79);
      this.radioButton35.Name = "radioButton35";
      this.radioButton35.Size = new Size(153, 17);
      this.radioButton35.TabIndex = 12;
      this.radioButton35.TabStop = true;
      this.radioButton35.Text = "Повторять реле времени";
      this.radioButton35.UseVisualStyleBackColor = true;
      this.radioButton35.CheckedChanged += new EventHandler(this.radioButton35_CheckedChanged);
      this.radioButton31.AutoSize = true;
      this.radioButton31.Location = new Point(15, 57);
      this.radioButton31.Name = "radioButton31";
      this.radioButton31.Size = new Size(74, 17);
      this.radioButton31.TabIndex = 11;
      this.radioButton31.TabStop = true;
      this.radioButton31.Text = "Включить";
      this.radioButton31.UseVisualStyleBackColor = true;
      this.radioButton31.CheckedChanged += new EventHandler(this.radioButton31_CheckedChanged);
      this.radioButton34.AutoSize = true;
      this.radioButton34.Location = new Point(15, 35);
      this.radioButton34.Name = "radioButton34";
      this.radioButton34.Size = new Size(80, 17);
      this.radioButton34.TabIndex = 10;
      this.radioButton34.TabStop = true;
      this.radioButton34.Text = "Отключить";
      this.radioButton34.UseVisualStyleBackColor = true;
      this.radioButton34.CheckedChanged += new EventHandler(this.radioButton34_CheckedChanged);
      this.radioButton32.AutoSize = true;
      this.radioButton32.Location = new Point(15, 101);
      this.radioButton32.Name = "radioButton32";
      this.radioButton32.Size = new Size(161, 30);
      this.radioButton32.TabIndex = 13;
      this.radioButton32.TabStop = true;
      this.radioButton32.Text = "Отключить до следующего\r\nсобытия";
      this.radioButton32.UseVisualStyleBackColor = true;
      this.radioButton32.CheckedChanged += new EventHandler(this.radioButton32_CheckedChanged);
      this.groupBox35.Controls.Add((Control) this.radioButton28);
      this.groupBox35.Controls.Add((Control) this.radioButton29);
      this.groupBox35.Location = new Point(55, 73);
      this.groupBox35.Name = "groupBox35";
      this.groupBox35.Size = new Size(206, 83);
      this.groupBox35.TabIndex = 7;
      this.groupBox35.TabStop = false;
      this.groupBox35.Text = "Режим работы:";
      this.radioButton28.AutoSize = true;
      this.radioButton28.Location = new Point(28, 19);
      this.radioButton28.Name = "radioButton28";
      this.radioButton28.Size = new Size(81, 17);
      this.radioButton28.TabIndex = 6;
      this.radioButton28.TabStop = true;
      this.radioButton28.Text = "Отключено";
      this.radioButton28.UseVisualStyleBackColor = true;
      this.radioButton28.CheckedChanged += new EventHandler(this.radioButton28_CheckedChanged);
      this.radioButton29.AutoSize = true;
      this.radioButton29.Location = new Point(28, 47);
      this.radioButton29.Name = "radioButton29";
      this.radioButton29.Size = new Size(75, 17);
      this.radioButton29.TabIndex = 0;
      this.radioButton29.TabStop = true;
      this.radioButton29.Text = "Включено";
      this.radioButton29.UseVisualStyleBackColor = true;
      this.radioButton29.CheckedChanged += new EventHandler(this.radioButton29_CheckedChanged);
      this.tabPage16_Options.BackColor = SystemColors.Control;
      this.tabPage16_Options.Controls.Add((Control) this.groupBox42);
      this.tabPage16_Options.Location = new Point(4, 22);
      this.tabPage16_Options.Name = "tabPage16_Options";
      this.tabPage16_Options.Padding = new Padding(3);
      this.tabPage16_Options.Size = new Size(542, 506);
      this.tabPage16_Options.TabIndex = 15;
      this.tabPage16_Options.Text = "Options";
      this.groupBox42.Controls.Add((Control) this.checkBox12);
      this.groupBox42.Controls.Add((Control) this.groupBox43);
      this.groupBox42.Location = new Point(6, 8);
      this.groupBox42.Name = "groupBox42";
      this.groupBox42.Size = new Size(530, 489);
      this.groupBox42.TabIndex = 6;
      this.groupBox42.TabStop = false;
      this.groupBox42.Text = "Общие настройки устройства:";
      this.checkBox12.AutoSize = true;
      this.checkBox12.Location = new Point(28, 177);
      this.checkBox12.Name = "checkBox12";
      this.checkBox12.Size = new Size(213, 17);
      this.checkBox12.TabIndex = 3;
      this.checkBox12.Text = "Учитывать переход на летнее время";
      this.checkBox12.UseVisualStyleBackColor = true;
      this.checkBox12.CheckedChanged += new EventHandler(this.checkBox12_CheckedChanged);
      this.groupBox43.Controls.Add((Control) this.label76);
      this.groupBox43.Controls.Add((Control) this.numericUpDown41);
      this.groupBox43.Controls.Add((Control) this.label77);
      this.groupBox43.Controls.Add((Control) this.label78);
      this.groupBox43.Controls.Add((Control) this.numericUpDown42);
      this.groupBox43.Location = new Point(28, 33);
      this.groupBox43.Name = "groupBox43";
      this.groupBox43.Size = new Size(206, 124);
      this.groupBox43.TabIndex = 0;
      this.groupBox43.TabStop = false;
      this.groupBox43.Text = "Общая временная задержка между моментом подачи питания и началом работы устройства:";
      this.label76.AutoSize = true;
      this.label76.Location = new Point(108, 53);
      this.label76.Name = "label76";
      this.label76.Size = new Size(51, 13);
      this.label76.TabIndex = 4;
      this.label76.Text = "Секунды";
      this.numericUpDown41.Location = new Point(111, 79);
      NumericUpDown numericUpDown41 = this.numericUpDown41;
      int[] bits58 = new int[4];
      bits58[0] = 59;
      Decimal num58 = new Decimal(bits58);
      numericUpDown41.Maximum = num58;
      this.numericUpDown41.Name = "numericUpDown41";
      this.numericUpDown41.Size = new Size(47, 20);
      this.numericUpDown41.TabIndex = 3;
      this.numericUpDown41.ValueChanged += new EventHandler(this.numericUpDown41_ValueChanged);
      this.label77.AutoSize = true;
      this.label77.Location = new Point(95, 81);
      this.label77.Name = "label77";
      this.label77.Size = new Size(10, 13);
      this.label77.TabIndex = 2;
      this.label77.Text = ":";
      this.label78.AutoSize = true;
      this.label78.Location = new Point(43, 53);
      this.label78.Name = "label78";
      this.label78.Size = new Size(46, 13);
      this.label78.TabIndex = 1;
      this.label78.Text = "Минуты";
      this.numericUpDown42.Location = new Point(42, 79);
      NumericUpDown numericUpDown42 = this.numericUpDown42;
      int[] bits59 = new int[4];
      bits59[0] = 99;
      Decimal num59 = new Decimal(bits59);
      numericUpDown42.Maximum = num59;
      this.numericUpDown42.Name = "numericUpDown42";
      this.numericUpDown42.Size = new Size(47, 20);
      this.numericUpDown42.TabIndex = 0;
      this.numericUpDown42.ValueChanged += new EventHandler(this.numericUpDown42_ValueChanged);
      this.tabPage2_Time.BackColor = SystemColors.Control;
      this.tabPage2_Time.Controls.Add((Control) this.groupBox34);
      this.tabPage2_Time.Location = new Point(4, 22);
      this.tabPage2_Time.Name = "tabPage2_Time";
      this.tabPage2_Time.Padding = new Padding(3);
      this.tabPage2_Time.Size = new Size(542, 506);
      this.tabPage2_Time.TabIndex = 16;
      this.tabPage2_Time.Text = "Time";
      this.groupBox34.Controls.Add((Control) this.groupBox39);
      this.groupBox34.Controls.Add((Control) this.groupBox38);
      this.groupBox34.Controls.Add((Control) this.groupBox37);
      this.groupBox34.Location = new Point(52, 60);
      this.groupBox34.Name = "groupBox34";
      this.groupBox34.Size = new Size(452, 378);
      this.groupBox34.TabIndex = 7;
      this.groupBox34.TabStop = false;
      this.groupBox34.Text = "Настройки устройства:";
      this.groupBox39.Controls.Add((Control) this.label59);
      this.groupBox39.Controls.Add((Control) this.dateTimePicker5);
      this.groupBox39.Controls.Add((Control) this.button21);
      this.groupBox39.Controls.Add((Control) this.dateTimePicker6);
      this.groupBox39.Location = new Point(19, 250);
      this.groupBox39.Name = "groupBox39";
      this.groupBox39.Size = new Size(413, 122);
      this.groupBox39.TabIndex = 3;
      this.groupBox39.TabStop = false;
      this.groupBox39.Text = "Ручная установка времени:";
      this.label59.AutoSize = true;
      this.label59.Location = new Point(97, 81);
      this.label59.Name = "label59";
      this.label59.Size = new Size(116, 13);
      this.label59.TabIndex = 7;
      this.label59.Text = "Загрузить в РЭВ-302:";
      this.dateTimePicker5.CustomFormat = "HH:mm:ss";
      this.dateTimePicker5.Format = DateTimePickerFormat.Custom;
      this.dateTimePicker5.Location = new Point(234, 32);
      this.dateTimePicker5.Name = "dateTimePicker5";
      this.dateTimePicker5.ShowUpDown = true;
      this.dateTimePicker5.Size = new Size(79, 20);
      this.dateTimePicker5.TabIndex = 1;
      this.button21.Location = new Point(234, 74);
      this.button21.Name = "button21";
      this.button21.Size = new Size(79, 27);
      this.button21.TabIndex = 6;
      this.button21.Text = "Применить";
      this.button21.UseVisualStyleBackColor = true;
      this.button21.Click += new EventHandler(this.button21_Click);
      this.dateTimePicker6.CustomFormat = "dd MMMM yyyy";
      this.dateTimePicker6.Format = DateTimePickerFormat.Custom;
      this.dateTimePicker6.Location = new Point(79, 32);
      this.dateTimePicker6.Name = "dateTimePicker6";
      this.dateTimePicker6.Size = new Size(134, 20);
      this.dateTimePicker6.TabIndex = 0;
      this.groupBox38.Controls.Add((Control) this.button22);
      this.groupBox38.Controls.Add((Control) this.label67);
      this.groupBox38.Controls.Add((Control) this.label60);
      this.groupBox38.Location = new Point(19, 19);
      this.groupBox38.Name = "groupBox38";
      this.groupBox38.Size = new Size(413, 104);
      this.groupBox38.TabIndex = 2;
      this.groupBox38.TabStop = false;
      this.groupBox38.Text = "Текущее время РЭВ-302:";
      this.button22.Location = new Point(271, 43);
      this.button22.Name = "button22";
      this.button22.Size = new Size(79, 27);
      this.button22.TabIndex = 6;
      this.button22.Text = "Обновить";
      this.button22.UseVisualStyleBackColor = true;
      this.button22.Click += new EventHandler(this.button22_Click);
      this.label67.AutoSize = true;
      this.label67.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 204);
      this.label67.Location = new Point(36, 62);
      this.label67.Name = "label67";
      this.label67.Size = new Size(48, 15);
      this.label67.TabIndex = 3;
      this.label67.Text = "label67";
      this.label67.TextAlign = ContentAlignment.TopCenter;
      this.label60.AutoSize = true;
      this.label60.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 204);
      this.label60.Location = new Point(36, 29);
      this.label60.Name = "label60";
      this.label60.Size = new Size(48, 15);
      this.label60.TabIndex = 2;
      this.label60.Text = "label60";
      this.label60.TextAlign = ContentAlignment.MiddleCenter;
      this.groupBox37.Controls.Add((Control) this.label68);
      this.groupBox37.Controls.Add((Control) this.label58);
      this.groupBox37.Controls.Add((Control) this.label69);
      this.groupBox37.Controls.Add((Control) this.button20);
      this.groupBox37.Location = new Point(19, 129);
      this.groupBox37.Name = "groupBox37";
      this.groupBox37.Size = new Size(413, 115);
      this.groupBox37.TabIndex = 0;
      this.groupBox37.TabStop = false;
      this.groupBox37.Text = "Системное время:";
      this.label68.AutoSize = true;
      this.label68.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 204);
      this.label68.Location = new Point(36, 40);
      this.label68.Name = "label68";
      this.label68.Size = new Size(48, 15);
      this.label68.TabIndex = 5;
      this.label68.Text = "label68";
      this.label68.TextAlign = ContentAlignment.TopCenter;
      this.label58.AutoSize = true;
      this.label58.Location = new Point(246, 33);
      this.label58.Name = "label58";
      this.label58.Size = new Size(140, 26);
      this.label58.TabIndex = 5;
      this.label58.Text = "Синхронизировать время \r\nРЭВ-302 с системным:";
      this.label69.AutoSize = true;
      this.label69.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 204);
      this.label69.Location = new Point(36, 78);
      this.label69.Name = "label69";
      this.label69.Size = new Size(48, 15);
      this.label69.TabIndex = 4;
      this.label69.Text = "label69";
      this.label69.TextAlign = ContentAlignment.MiddleCenter;
      this.button20.Location = new Point(271, 70);
      this.button20.Name = "button20";
      this.button20.Size = new Size(79, 27);
      this.button20.TabIndex = 4;
      this.button20.Text = "Применить";
      this.button20.UseVisualStyleBackColor = true;
      this.button20.Click += new EventHandler(this.button20_Click);
      this.tabPage3_VoltBright.BackColor = SystemColors.Control;
      this.tabPage3_VoltBright.Controls.Add((Control) this.groupBox44);
      this.tabPage3_VoltBright.Location = new Point(4, 22);
      this.tabPage3_VoltBright.Name = "tabPage3_VoltBright";
      this.tabPage3_VoltBright.Padding = new Padding(3);
      this.tabPage3_VoltBright.Size = new Size(542, 506);
      this.tabPage3_VoltBright.TabIndex = 17;
      this.tabPage3_VoltBright.Text = "VoltBright";
      this.groupBox44.Controls.Add((Control) this.groupBox41);
      this.groupBox44.Controls.Add((Control) this.groupBox45);
      this.groupBox44.Controls.Add((Control) this.groupBox46);
      this.groupBox44.Location = new Point(47, 8);
      this.groupBox44.Name = "groupBox44";
      this.groupBox44.Size = new Size(452, 456);
      this.groupBox44.TabIndex = 8;
      this.groupBox44.TabStop = false;
      this.groupBox44.Text = "Настройки устройства:";
      this.groupBox41.Controls.Add((Control) this.numericUpDown35);
      this.groupBox41.Controls.Add((Control) this.label98);
      this.groupBox41.Controls.Add((Control) this.label97);
      this.groupBox41.Controls.Add((Control) this.button41);
      this.groupBox41.Controls.Add((Control) this.textBox1);
      this.groupBox41.Controls.Add((Control) this.label94);
      this.groupBox41.Controls.Add((Control) this.label96);
      this.groupBox41.Controls.Add((Control) this.label74);
      this.groupBox41.Controls.Add((Control) this.label75);
      this.groupBox41.Controls.Add((Control) this.label91);
      this.groupBox41.Controls.Add((Control) this.button40);
      this.groupBox41.Controls.Add((Control) this.label92);
      this.groupBox41.Controls.Add((Control) this.label93);
      this.groupBox41.Location = new Point(18, 246);
      this.groupBox41.Name = "groupBox41";
      this.groupBox41.Size = new Size(418, 193);
      this.groupBox41.TabIndex = 16;
      this.groupBox41.TabStop = false;
      this.groupBox41.Text = "Коррекция времени:";
      this.numericUpDown35.Location = new Point(229, 101);
      NumericUpDown numericUpDown35 = this.numericUpDown35;
      int[] bits60 = new int[4];
      bits60[0] = (int) sbyte.MaxValue;
      Decimal num60 = new Decimal(bits60);
      numericUpDown35.Maximum = num60;
      this.numericUpDown35.Name = "numericUpDown35";
      this.numericUpDown35.Size = new Size(66, 20);
      this.numericUpDown35.TabIndex = 24;
      this.label98.AutoSize = true;
      this.label98.Location = new Point(306, 77);
      this.label98.Name = "label98";
      this.label98.Size = new Size(27, 13);
      this.label98.TabIndex = 23;
      this.label98.Text = "ppm";
      this.label97.AutoSize = true;
      this.label97.Location = new Point(75, 101);
      this.label97.Name = "label97";
      this.label97.Size = new Size(141, 13);
      this.label97.TabIndex = 21;
      this.label97.Text = "Запись в калибр. регистр:";
      this.button41.Location = new Point(106, 149);
      this.button41.Name = "button41";
      this.button41.Size = new Size(79, 27);
      this.button41.TabIndex = 20;
      this.button41.Text = "Рассчитать";
      this.button41.UseVisualStyleBackColor = true;
      this.button41.Click += new EventHandler(this.button41_Click);
      this.textBox1.Location = new Point(229, 28);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new Size(100, 20);
      this.textBox1.TabIndex = 19;
      this.textBox1.Text = "1953.05";
      this.label94.AutoSize = true;
      this.label94.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 204);
      this.label94.Location = new Point(230, 75);
      this.label94.Name = "label94";
      this.label94.Size = new Size(14, 15);
      this.label94.TabIndex = 18;
      this.label94.Text = "_";
      this.label94.TextAlign = ContentAlignment.MiddleCenter;
      this.label96.AutoSize = true;
      this.label96.Location = new Point(138, 77);
      this.label96.Name = "label96";
      this.label96.Size = new Size(78, 13);
      this.label96.TabIndex = 16;
      this.label96.Text = "Погрешность:";
      this.label74.AutoSize = true;
      this.label74.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 204);
      this.label74.Location = new Point(229, 53);
      this.label74.Name = "label74";
      this.label74.Size = new Size(14, 15);
      this.label74.TabIndex = 15;
      this.label74.Text = "_";
      this.label74.TextAlign = ContentAlignment.MiddleCenter;
      this.label75.AutoSize = true;
      this.label75.Location = new Point(335, 31);
      this.label75.Name = "label75";
      this.label75.Size = new Size(28, 13);
      this.label75.TabIndex = 15;
      this.label75.Text = "мкС";
      this.label91.AutoSize = true;
      this.label91.Location = new Point(306, 55);
      this.label91.Name = "label91";
      this.label91.Size = new Size(19, 13);
      this.label91.TabIndex = 14;
      this.label91.Text = "Гц";
      this.button40.Location = new Point(233, 149);
      this.button40.Name = "button40";
      this.button40.Size = new Size(79, 27);
      this.button40.TabIndex = 11;
      this.button40.Text = "Записать";
      this.button40.UseVisualStyleBackColor = true;
      this.button40.Click += new EventHandler(this.button40_Click);
      this.label92.AutoSize = true;
      this.label92.Location = new Point(102, 31);
      this.label92.Name = "label92";
      this.label92.Size = new Size(121, 13);
      this.label92.TabIndex = 10;
      this.label92.Text = "Период TAMPER-RTC:";
      this.label93.AutoSize = true;
      this.label93.Location = new Point(91, 55);
      this.label93.Name = "label93";
      this.label93.Size = new Size(125, 13);
      this.label93.TabIndex = 8;
      this.label93.Text = "Частота TAMPER-RTC:";
      this.groupBox45.Controls.Add((Control) this.label73);
      this.groupBox45.Controls.Add((Control) this.label83);
      this.groupBox45.Controls.Add((Control) this.label84);
      this.groupBox45.Controls.Add((Control) this.button33);
      this.groupBox45.Controls.Add((Control) this.label85);
      this.groupBox45.Controls.Add((Control) this.label86);
      this.groupBox45.Controls.Add((Control) this.numericUpDown43);
      this.groupBox45.Location = new Point(18, 132);
      this.groupBox45.Name = "groupBox45";
      this.groupBox45.Size = new Size(418, 108);
      this.groupBox45.TabIndex = 12;
      this.groupBox45.TabStop = false;
      this.groupBox45.Text = "Освещенность:";
      this.label73.AutoSize = true;
      this.label73.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 204);
      this.label73.Location = new Point(229, 14);
      this.label73.Name = "label73";
      this.label73.Size = new Size(14, 15);
      this.label73.TabIndex = 15;
      this.label73.Text = "_";
      this.label73.TextAlign = ContentAlignment.MiddleCenter;
      this.label83.AutoSize = true;
      this.label83.Location = new Point(306, 41);
      this.label83.Name = "label83";
      this.label83.Size = new Size(33, 13);
      this.label83.TabIndex = 15;
      this.label83.Text = "люкс";
      this.label84.AutoSize = true;
      this.label84.Location = new Point(306, 16);
      this.label84.Name = "label84";
      this.label84.Size = new Size(33, 13);
      this.label84.TabIndex = 14;
      this.label84.Text = "люкс";
      this.button33.Location = new Point(174, 65);
      this.button33.Name = "button33";
      this.button33.Size = new Size(79, 27);
      this.button33.TabIndex = 11;
      this.button33.Text = "Применить";
      this.button33.UseVisualStyleBackColor = true;
      this.button33.Click += new EventHandler(this.button33_Click);
      this.label85.AutoSize = true;
      this.label85.Location = new Point(70, 41);
      this.label85.Name = "label85";
      this.label85.Size = new Size(153, 13);
      this.label85.TabIndex = 10;
      this.label85.Text = "Установить новое значение:";
      this.label86.AutoSize = true;
      this.label86.Location = new Point(91, 16);
      this.label86.Name = "label86";
      this.label86.Size = new Size(132, 13);
      this.label86.TabIndex = 8;
      this.label86.Text = "Текущая освещенность:";
      this.numericUpDown43.Location = new Point(229, 39);
      NumericUpDown numericUpDown43_1 = this.numericUpDown43;
      int[] bits61 = new int[4];
      bits61[0] = 200;
      Decimal num61 = new Decimal(bits61);
      numericUpDown43_1.Maximum = num61;
      this.numericUpDown43.Name = "numericUpDown43";
      this.numericUpDown43.Size = new Size(66, 20);
      this.numericUpDown43.TabIndex = 6;
      NumericUpDown numericUpDown43_2 = this.numericUpDown43;
      int[] bits62 = new int[4];
      bits62[0] = 100;
      Decimal num62 = new Decimal(bits62);
      numericUpDown43_2.Value = num62;
      this.groupBox46.Controls.Add((Control) this.label70);
      this.groupBox46.Controls.Add((Control) this.label87);
      this.groupBox46.Controls.Add((Control) this.label88);
      this.groupBox46.Controls.Add((Control) this.button35);
      this.groupBox46.Controls.Add((Control) this.label89);
      this.groupBox46.Controls.Add((Control) this.label90);
      this.groupBox46.Controls.Add((Control) this.numericUpDown44);
      this.groupBox46.Location = new Point(18, 19);
      this.groupBox46.Name = "groupBox46";
      this.groupBox46.Size = new Size(418, 107);
      this.groupBox46.TabIndex = 3;
      this.groupBox46.TabStop = false;
      this.groupBox46.Text = "Напряжение сети:";
      this.label70.AutoSize = true;
      this.label70.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 204);
      this.label70.Location = new Point(229, 16);
      this.label70.Name = "label70";
      this.label70.Size = new Size(14, 15);
      this.label70.TabIndex = 14;
      this.label70.Text = "_";
      this.label70.TextAlign = ContentAlignment.MiddleCenter;
      this.label87.AutoSize = true;
      this.label87.Location = new Point(286, 41);
      this.label87.Name = "label87";
      this.label87.Size = new Size(37, 13);
      this.label87.TabIndex = 13;
      this.label87.Text = "Вольт";
      this.label88.AutoSize = true;
      this.label88.Location = new Point(284, 18);
      this.label88.Name = "label88";
      this.label88.Size = new Size(37, 13);
      this.label88.TabIndex = 12;
      this.label88.Text = "Вольт";
      this.button35.Location = new Point(174, 65);
      this.button35.Name = "button35";
      this.button35.Size = new Size(79, 27);
      this.button35.TabIndex = 11;
      this.button35.Text = "Применить";
      this.button35.UseVisualStyleBackColor = true;
      this.button35.Click += new EventHandler(this.button35_Click);
      this.label89.AutoSize = true;
      this.label89.Location = new Point(70, 41);
      this.label89.Name = "label89";
      this.label89.Size = new Size(153, 13);
      this.label89.TabIndex = 10;
      this.label89.Text = "Установить новое значение:";
      this.label90.AutoSize = true;
      this.label90.Location = new Point(103, 16);
      this.label90.Name = "label90";
      this.label90.Size = new Size(120, 13);
      this.label90.TabIndex = 8;
      this.label90.Text = "Текущее напряжение:";
      this.numericUpDown44.Location = new Point(229, 39);
      NumericUpDown numericUpDown44_1 = this.numericUpDown44;
      int[] bits63 = new int[4];
      bits63[0] = 280;
      Decimal num63 = new Decimal(bits63);
      numericUpDown44_1.Maximum = num63;
      this.numericUpDown44.Name = "numericUpDown44";
      this.numericUpDown44.Size = new Size(51, 20);
      this.numericUpDown44.TabIndex = 6;
      NumericUpDown numericUpDown44_2 = this.numericUpDown44;
      int[] bits64 = new int[4];
      bits64[0] = 220;
      Decimal num64 = new Decimal(bits64);
      numericUpDown44_2.Value = num64;
      this.tabPage2_RTcom.BackColor = SystemColors.Control;
      this.tabPage2_RTcom.Controls.Add((Control) this.richTextBox2);
      this.tabPage2_RTcom.Location = new Point(4, 22);
      this.tabPage2_RTcom.Name = "tabPage2_RTcom";
      this.tabPage2_RTcom.Padding = new Padding(3);
      this.tabPage2_RTcom.Size = new Size(542, 506);
      this.tabPage2_RTcom.TabIndex = 18;
      this.tabPage2_RTcom.Text = "RTcom";
      this.richTextBox2.BackColor = SystemColors.Control;
      this.richTextBox2.BorderStyle = BorderStyle.None;
      this.richTextBox2.Font = new Font("Arial", 10f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
      this.richTextBox2.Location = new Point(65, 101);
      this.richTextBox2.Name = "richTextBox2";
      this.richTextBox2.ReadOnly = true;
      this.richTextBox2.Size = new Size(403, 316);
      this.richTextBox2.TabIndex = 2;
      this.richTextBox2.Text = componentResourceManager.GetString("richTextBox2.Text");
      this.tabPage2_Except.BackColor = SystemColors.Control;
      this.tabPage2_Except.Controls.Add((Control) this.richTextBox3);
      this.tabPage2_Except.Location = new Point(4, 22);
      this.tabPage2_Except.Name = "tabPage2_Except";
      this.tabPage2_Except.Padding = new Padding(3);
      this.tabPage2_Except.Size = new Size(542, 506);
      this.tabPage2_Except.TabIndex = 19;
      this.tabPage2_Except.Text = "Exeptions";
      this.richTextBox3.BackColor = SystemColors.Control;
      this.richTextBox3.BorderStyle = BorderStyle.None;
      this.richTextBox3.Font = new Font("Arial", 10f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
      this.richTextBox3.Location = new Point(86, 167);
      this.richTextBox3.Name = "richTextBox3";
      this.richTextBox3.ReadOnly = true;
      this.richTextBox3.Size = new Size(375, 133);
      this.richTextBox3.TabIndex = 3;
      this.richTextBox3.Text = componentResourceManager.GetString("richTextBox3.Text");
      this.panel1.BackColor = Color.DarkGray;
      this.panel1.BorderStyle = BorderStyle.Fixed3D;
      this.panel1.Controls.Add((Control) this.label4);
      this.panel1.Location = new Point(285, 49);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(550, 61);
      this.panel1.TabIndex = 0;
      this.label4.AutoSize = true;
      this.label4.Font = new Font("Microsoft Sans Serif", 18f, FontStyle.Bold, GraphicsUnit.Point, (byte) 204);
      this.label4.ForeColor = Color.Gainsboro;
      this.label4.Location = new Point(17, 12);
      this.label4.Name = "label4";
      this.label4.Size = new Size(128, 29);
      this.label4.TabIndex = 1;
      this.label4.Text = "Канал К1";
      this.usb.ProductId = 23;
      this.usb.VendorId = 1982;
      this.usb.OnSpecifiedDeviceArrived += new EventHandler(this.usb_OnSpecifiedDeviceArrived);
      this.usb.OnSpecifiedDeviceRemoved += new EventHandler(this.usb_OnSpecifiedDeviceRemoved);
      this.usb.OnDeviceArrived += new EventHandler(this.usb_OnDeviceArrived);
      this.usb.OnDeviceRemoved += new EventHandler(this.usb_OnDeviceRemoved);
      this.usb.OnDataRecieved += new DataRecievedEventHandler(this.usb_OnDataRecieved);
      this.usb.OnDataSend += new EventHandler(this.usb_OnDataSend);
      this.openFileDialog1.Filter = "REV-302 JSON settings file (*.tmj)|*.tmj|REV-302 settings file (*.tmr)|*.tmr";
      this.saveFileDialog1.Filter = "REV-302 JSON settings file (*.tmj)|*.tmj|REV-302 settings file (*.tmr)|*.tmr";
      this.progressBar1.Location = new Point(0, 621);
      this.progressBar1.Name = "progressBar1";
      this.progressBar1.Size = new Size(551, 22);
      this.progressBar1.TabIndex = 9;
      this.progressBar1.Visible = false;
      this.label81.AutoSize = true;
      this.label81.Location = new Point(557, 627);
      this.label81.Name = "label81";
      this.label81.Size = new Size(167, 13);
      this.label81.TabIndex = 10;
      this.label81.Text = "USB: есть подключение к реле.";
      this.timer1.Interval = 10000;
      this.timer1.Tick += new EventHandler(this.timer1_Tick);
      this.timer2.Interval = 1000;
      this.timer2.Tick += new EventHandler(this.timer2_Tick);
      this.timer3.Interval = 10;
      this.timer3.Tick += new EventHandler(this.timer3_Tick);
      this.timer4.Interval = 500;
      this.timer4.Tick += new EventHandler(this.timer4_Tick);
      this.label95.AutoSize = true;
      this.label95.Location = new Point(12, 627);
      this.label95.Name = "label95";
      this.label95.Size = new Size(301, 13);
      this.label95.TabIndex = 11;
      this.label95.Text = "Внимание! Последние изменения не записаны в РЭВ-302";
      this.timer5_compDataInRelay.Enabled = true;
      this.timer5_compDataInRelay.Interval = 1000;
      this.timer5_compDataInRelay.Tick += new EventHandler(this.timer5_compDataInRelay_Tick);
      this.languageToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[3]
      {
        (ToolStripItem) this.englishToolStripMenuItem,
        (ToolStripItem) this.polishToolStripMenuItem,
        (ToolStripItem) this.russianToolStripMenuItem
      });
      this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
      this.languageToolStripMenuItem.Size = new Size(66, 20);
      this.languageToolStripMenuItem.Text = "Language";
      this.englishToolStripMenuItem.Name = "englishToolStripMenuItem";
      this.englishToolStripMenuItem.Size = new Size(152, 22);
      this.englishToolStripMenuItem.Text = "English";
      this.englishToolStripMenuItem.Click += new EventHandler(this.englishToolStripMenuItem_Click);
      this.polishToolStripMenuItem.Name = "polishToolStripMenuItem";
      this.polishToolStripMenuItem.Size = new Size(152, 22);
      this.polishToolStripMenuItem.Text = "Polski";
      this.polishToolStripMenuItem.Click += new EventHandler(this.polishToolStripMenuItem_Click);
      this.russianToolStripMenuItem.Name = "russianToolStripMenuItem";
      this.russianToolStripMenuItem.Size = new Size(152, 22);
      this.russianToolStripMenuItem.Text = "Русский";
      this.russianToolStripMenuItem.Click += new EventHandler(this.russianToolStripMenuItem_Click);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = SystemColors.Control;
      this.ClientSize = new Size(835, 643);
      this.Controls.Add((Control) this.panel1);
      this.Controls.Add((Control) this.progressBar1);
      this.Controls.Add((Control) this.label95);
      this.Controls.Add((Control) this.tabControl1);
      this.Controls.Add((Control) this.treeView1);
      this.Controls.Add((Control) this.label81);
      this.Controls.Add((Control) this.statusStrip1);
      this.Controls.Add((Control) this.toolStrip1);
      this.Controls.Add((Control) this.menuStrip1);
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MaximizeBox = false;
      this.MinimumSize = new Size(745, 575);
      this.Name = "Form1";
      this.SizeGripStyle = SizeGripStyle.Hide;
      this.Text = "Конфигуратор реле РЭВ-302";
      this.FormClosing += new FormClosingEventHandler(this.Form1_FormClosing);
      this.Load += new EventHandler(this.Form1_Load);
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.toolStrip1.ResumeLayout(false);
      this.toolStrip1.PerformLayout();
      this.tabControl1.ResumeLayout(false);
      this.tabPage1.ResumeLayout(false);
      this.tabPage1.PerformLayout();
      this.tabPage1_ChannelMode.ResumeLayout(false);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.tabPage2_RtOptions.ResumeLayout(false);
      this.groupBox3.ResumeLayout(false);
      this.groupBox3.PerformLayout();
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.tabPage3_Empty.ResumeLayout(false);
      this.groupBox40.ResumeLayout(false);
      this.tabPage4_DayOffs.ResumeLayout(false);
      this.groupBox4.ResumeLayout(false);
      this.groupBox4.PerformLayout();
      this.tabPage5_Holidays.ResumeLayout(false);
      this.groupBox5.ResumeLayout(false);
      this.tabPage6_ExceptEvents.ResumeLayout(false);
      this.groupBox6.ResumeLayout(false);
      this.groupBox6.PerformLayout();
      this.groupBox7.ResumeLayout(false);
      this.groupBox7.PerformLayout();
      this.numericUpDown3.EndInit();
      this.numericUpDown2.EndInit();
      this.numericUpDown1.EndInit();
      this.tabPage7_Year.ResumeLayout(false);
      this.groupBox8.ResumeLayout(false);
      this.groupBox8.PerformLayout();
      this.groupBox9.ResumeLayout(false);
      this.groupBox9.PerformLayout();
      this.numericUpDown4.EndInit();
      this.numericUpDown5.EndInit();
      this.numericUpDown6.EndInit();
      this.tabPage8_Month.ResumeLayout(false);
      this.groupBox10.ResumeLayout(false);
      this.groupBox10.PerformLayout();
      this.numericUpDown16.EndInit();
      this.groupBox11.ResumeLayout(false);
      this.groupBox11.PerformLayout();
      this.numericUpDown7.EndInit();
      this.numericUpDown8.EndInit();
      this.numericUpDown9.EndInit();
      this.tabPage9_Week.ResumeLayout(false);
      this.groupBox12.ResumeLayout(false);
      this.groupBox12.PerformLayout();
      this.groupBox13.ResumeLayout(false);
      this.groupBox13.PerformLayout();
      this.numericUpDown12.EndInit();
      this.numericUpDown13.EndInit();
      this.numericUpDown14.EndInit();
      this.tabPage10_Day.ResumeLayout(false);
      this.groupBox14.ResumeLayout(false);
      this.groupBox14.PerformLayout();
      this.groupBox15.ResumeLayout(false);
      this.groupBox15.PerformLayout();
      this.numericUpDown10.EndInit();
      this.numericUpDown11.EndInit();
      this.numericUpDown15.EndInit();
      this.tabPage11_ImpulseRelay.ResumeLayout(false);
      this.groupBox16.ResumeLayout(false);
      this.groupBox19.ResumeLayout(false);
      this.groupBox19.PerformLayout();
      this.numericUpDown21.EndInit();
      this.numericUpDown22.EndInit();
      this.groupBox18.ResumeLayout(false);
      this.groupBox18.PerformLayout();
      this.numericUpDown19.EndInit();
      this.numericUpDown20.EndInit();
      this.groupBox17.ResumeLayout(false);
      this.groupBox17.PerformLayout();
      this.numericUpDown18.EndInit();
      this.numericUpDown17.EndInit();
      this.tabPage12_SimpleRelay.ResumeLayout(false);
      this.groupBox20.ResumeLayout(false);
      this.groupBox23.ResumeLayout(false);
      this.groupBox23.PerformLayout();
      this.numericUpDown27.EndInit();
      this.numericUpDown28.EndInit();
      this.tabPage14_RV.ResumeLayout(false);
      this.groupBox21.ResumeLayout(false);
      this.groupBox36.ResumeLayout(false);
      this.groupBox36.PerformLayout();
      this.numericUpDown45.EndInit();
      this.numericUpDown46.EndInit();
      this.groupBox28.ResumeLayout(false);
      this.groupBox28.PerformLayout();
      this.numericUpDown33.EndInit();
      this.numericUpDown34.EndInit();
      this.groupBox27.ResumeLayout(false);
      this.groupBox27.PerformLayout();
      this.numericUpDown31.EndInit();
      this.numericUpDown32.EndInit();
      this.groupBox26.ResumeLayout(false);
      this.groupBox26.PerformLayout();
      this.numericUpDown29.EndInit();
      this.numericUpDown30.EndInit();
      this.groupBox25.ResumeLayout(false);
      this.groupBox25.PerformLayout();
      this.numericUpDown25.EndInit();
      this.numericUpDown26.EndInit();
      this.groupBox22.ResumeLayout(false);
      this.groupBox22.PerformLayout();
      this.tabPage15_RF.ResumeLayout(false);
      this.groupBox29.ResumeLayout(false);
      this.groupBox24.ResumeLayout(false);
      this.groupBox24.PerformLayout();
      this.numericUpDown24.EndInit();
      this.numericUpDown23.EndInit();
      this.groupBox30.ResumeLayout(false);
      this.groupBox30.PerformLayout();
      this.groupBox31.ResumeLayout(false);
      this.groupBox31.PerformLayout();
      this.numericUpDown37.EndInit();
      this.numericUpDown38.EndInit();
      this.groupBox32.ResumeLayout(false);
      this.groupBox32.PerformLayout();
      this.numericUpDown39.EndInit();
      this.numericUpDown40.EndInit();
      this.groupBox33.ResumeLayout(false);
      this.groupBox33.PerformLayout();
      this.groupBox35.ResumeLayout(false);
      this.groupBox35.PerformLayout();
      this.tabPage16_Options.ResumeLayout(false);
      this.groupBox42.ResumeLayout(false);
      this.groupBox42.PerformLayout();
      this.groupBox43.ResumeLayout(false);
      this.groupBox43.PerformLayout();
      this.numericUpDown41.EndInit();
      this.numericUpDown42.EndInit();
      this.tabPage2_Time.ResumeLayout(false);
      this.groupBox34.ResumeLayout(false);
      this.groupBox39.ResumeLayout(false);
      this.groupBox39.PerformLayout();
      this.groupBox38.ResumeLayout(false);
      this.groupBox38.PerformLayout();
      this.groupBox37.ResumeLayout(false);
      this.groupBox37.PerformLayout();
      this.tabPage3_VoltBright.ResumeLayout(false);
      this.groupBox44.ResumeLayout(false);
      this.groupBox41.ResumeLayout(false);
      this.groupBox41.PerformLayout();
      this.numericUpDown35.EndInit();
      this.groupBox45.ResumeLayout(false);
      this.groupBox45.PerformLayout();
      this.numericUpDown43.EndInit();
      this.groupBox46.ResumeLayout(false);
      this.groupBox46.PerformLayout();
      this.numericUpDown44.EndInit();
      this.tabPage2_RTcom.ResumeLayout(false);
      this.tabPage2_Except.ResumeLayout(false);
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    private enum USB_GetSequenceEnum
    {
      NO,
      GET_OPTIONS,
      SEND_OPTIONS,
    }
  }
}
