// NoAuthor
// Type: MultiTimerWinForms.SunRises
// Assembly: MultiTimer, Version=1.5.2.0, Culture=neutral, PublicKeyToken=null
// MVID: BCBF5A5D-507A-4FEA-8EFC-8CECD33998F9
// Assembly location: C:\Program Files (x86)\Novatek-Electro\Configurator REV-302\MultiTimer.exe

using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace MultiTimerWinForms
{
  public class SunRises : Form
  {
    public TimerClass ListEvents = new TimerClass();
    private SystemSettings SysSet = new SystemSettings();
    private IContainer components;
    private Button button1;
    private GroupBox groupBox1;
    private GroupBox groupBox2;
    private GroupBox groupBox3;
    private ComboBox comboBox1;
    private Label label3;
    private NumericUpDown numericUpDown3;
    private Label label2;
    private NumericUpDown numericUpDown2;
    private Label label1;
    private NumericUpDown numericUpDown1;
    private GroupBox groupBox4;
    private ComboBox comboBox2;
    private Label label4;
    private NumericUpDown numericUpDown4;
    private Label label5;
    private NumericUpDown numericUpDown5;
    private Label label6;
    private NumericUpDown numericUpDown6;
    private GroupBox groupBox5;
    private NumericUpDown numericUpDown7;
    private Label label8;
    private DateTimePicker dateTimePicker1;
    private Label label9;
    private Label label10;
    private ComboBox comboBox3;
    private ComboBox comboBox5;
    private Label label12;
    private Label label11;
    private DateTimePicker dateTimePicker5;
    private CheckBox checkBox3;
    private Button button2;
    private CheckBox checkBox4;
    private Label label19;
    private ComboBox comboBox8;
    private ComboBox comboBox4;
    private Label label13;
    private DateTimePicker dateTimePicker2;
    private NumericUpDown numericUpDown8;
    private Label label7;
    private int CountItemsInListEvents;
    private DateTime CalculateTime;
    private bool ContactCondition;
    private double day;
    private double month;
    private double year;
    private double latitude;
    private double longitude;
    private double localOffsetMin;
    private double zenith;
    private bool WhatDesired;

    public SunRises()
    {
      this.InitializeComponent();
      if (this.SysSet.Lang == SystemSettings.TypeLanguage.ENGLISH)
      {
        this.Text = "Sunrises and Sunsets";
        this.groupBox2.Text = "Location geographic coordinates";
        this.groupBox4.Text = "Latitude:";
        this.label6.Text = "Degrees:";
        this.label5.Text = "Minutes:";
        this.label4.Text = "Seconds:";
        this.groupBox3.Text = "Longitude:";
        this.label1.Text = "Degrees:";
        this.label2.Text = "Minutes:";
        this.label3.Text = "Seconds:";
        this.comboBox2.Items[0] = (object) "Northern latitude";
        this.comboBox2.Items[1] = (object) "Southern latitude";
        this.comboBox1.Items[0] = (object) "East longitude";
        this.comboBox1.Items[1] = (object) "West longitude";
        this.groupBox5.Text = "Difference with Greenwich";
        this.checkBox4.Text = "Recognize summer time conversion";
        this.groupBox1.Text = "List events Sunrise/Sunset setup:";
        this.label13.Text = "List type:";
        this.comboBox4.Items[0] = (object) "Sunrises";
        this.comboBox4.Items[1] = (object) "Sunsets";
        this.label19.Text = "Day/Night boundary:";
        this.comboBox8.Items[0] = (object) "Official Sun's zenith";
        this.comboBox8.Items[1] = (object) "Civil Twilight";
        this.comboBox8.Items[2] = (object) "Nautical Twilight";
        this.comboBox8.Items[3] = (object) "Astronomical Twilight";
        this.label8.Text = "First day:";
        this.label9.Text = "Last day:";
        this.label10.Text = "Time shift:";
        this.comboBox3.Items[0] = (object) "befor Sunrise/Sunset";
        this.comboBox3.Items[1] = (object) "after Sunrise/Sunset";
        this.label11.Text = "on";
        this.label12.Text = "Contacts after event occurrence:";
        this.comboBox5.Items[0] = (object) "Close";
        this.comboBox5.Items[1] = (object) "Open";
        this.checkBox3.Text = "Preliminary erase the existing list";
        this.button1.Text = "Create array";
        this.button2.Text = "Cancel";
      }
      else if (this.SysSet.Lang == SystemSettings.TypeLanguage.POLISH)
      {
        this.Text = "Wschody i zachody Słońca";
        this.groupBox2.Text = "Współrzędne geograficzne";
        this.groupBox4.Text = "Szerokość geograficzna:";
        this.label6.Text = "Stopnie:";
        this.label5.Text = "Minuty:";
        this.label4.Text = "Secundy:";
        this.groupBox3.Text = "Długość geograficzna:";
        this.label1.Text = "Stopnie:";
        this.label2.Text = "Minuty:";
        this.label3.Text = "Secundy:";
        this.comboBox2.Items[0] = (object) "Szerokości północnej";
        this.comboBox2.Items[1] = (object) "Szerokości południowej";
        this.comboBox1.Items[0] = (object) "Długości wschodniej";
        this.comboBox1.Items[1] = (object) "Długości zachodniej";
        this.groupBox5.Text = "Różnica względem Greenwich";
        this.checkBox4.Text = "Rozpoznaj czas letni";
        this.groupBox1.Text = "Lista wschodów i zachodów Słońca:";
        this.label13.Text = "Typ listy:";
        this.comboBox4.Items[0] = (object) "Wschody";
        this.comboBox4.Items[1] = (object) "Zachody";
        this.label19.Text = "Granica dnia/nocy:";
        this.comboBox8.Items[0] = (object) "Oficjalny zachód Słońca - dokładnie na linii horyzontu";
        this.comboBox8.Items[1] = (object) "Cywilny zachód Słońca - 6° poniżej linii horyzontu";
        this.comboBox8.Items[2] = (object) "Żeglarski zachód Słońca - 12° poniżej linii horyzontu";
        this.comboBox8.Items[3] = (object) "Astronomiczny zachód Słońca - 18° poniżej linii horyzontu";
        this.label8.Text = "Pierwszy dzień:";
        this.label9.Text = "Ostatni dzień:";
        this.label10.Text = "Przesuń w czasie:";
        this.comboBox3.Items[0] = (object) "przed wschodem/zachodem Słońca";
        this.comboBox3.Items[1] = (object) "po wschodzie/zachodzie Słońca";
        this.label11.Text = "o";
        this.label12.Text = "Styki:";
        this.comboBox5.Items[0] = (object) "Załącz";
        this.comboBox5.Items[1] = (object) "Wyłącz";
        this.checkBox3.Text = "Najpierw usuń istniejącą listę";
        this.button1.Text = "Utwórz listę";
        this.button2.Text = "Anuluj";
        this.numericUpDown6.Value = new Decimal(52);
        this.numericUpDown5.Value = new Decimal(13);
        this.numericUpDown4.Value = new Decimal(0);
        this.numericUpDown1.Value = new Decimal(21);
        this.numericUpDown2.Value = new Decimal(2);
        this.numericUpDown3.Value = new Decimal(0);
        this.numericUpDown7.Value = new Decimal(1);
      }
      this.Init();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.button1 = new Button();
      this.groupBox1 = new GroupBox();
      this.dateTimePicker2 = new DateTimePicker();
      this.comboBox4 = new ComboBox();
      this.label13 = new Label();
      this.label19 = new Label();
      this.comboBox8 = new ComboBox();
      this.comboBox5 = new ComboBox();
      this.label12 = new Label();
      this.label11 = new Label();
      this.dateTimePicker5 = new DateTimePicker();
      this.comboBox3 = new ComboBox();
      this.label10 = new Label();
      this.dateTimePicker1 = new DateTimePicker();
      this.label9 = new Label();
      this.label8 = new Label();
      this.groupBox2 = new GroupBox();
      this.groupBox5 = new GroupBox();
      this.checkBox4 = new CheckBox();
      this.numericUpDown7 = new NumericUpDown();
      this.groupBox4 = new GroupBox();
      this.comboBox2 = new ComboBox();
      this.label4 = new Label();
      this.numericUpDown4 = new NumericUpDown();
      this.label5 = new Label();
      this.numericUpDown5 = new NumericUpDown();
      this.label6 = new Label();
      this.numericUpDown6 = new NumericUpDown();
      this.groupBox3 = new GroupBox();
      this.comboBox1 = new ComboBox();
      this.label3 = new Label();
      this.numericUpDown3 = new NumericUpDown();
      this.label2 = new Label();
      this.numericUpDown2 = new NumericUpDown();
      this.label1 = new Label();
      this.numericUpDown1 = new NumericUpDown();
      this.checkBox3 = new CheckBox();
      this.button2 = new Button();
      this.label7 = new Label();
      this.numericUpDown8 = new NumericUpDown();
      this.groupBox1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.groupBox5.SuspendLayout();
      this.numericUpDown7.BeginInit();
      this.groupBox4.SuspendLayout();
      this.numericUpDown4.BeginInit();
      this.numericUpDown5.BeginInit();
      this.numericUpDown6.BeginInit();
      this.groupBox3.SuspendLayout();
      this.numericUpDown3.BeginInit();
      this.numericUpDown2.BeginInit();
      this.numericUpDown1.BeginInit();
      this.numericUpDown8.BeginInit();
      this.SuspendLayout();
      this.button1.Location = new Point(60, 547);
      this.button1.Name = "button1";
      this.button1.Size = new Size((int) sbyte.MaxValue, 28);
      this.button1.TabIndex = 4;
      this.button1.Text = "Создать список";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new EventHandler(this.button1_Click);
      this.groupBox1.Controls.Add((Control) this.dateTimePicker2);
      this.groupBox1.Controls.Add((Control) this.comboBox4);
      this.groupBox1.Controls.Add((Control) this.label13);
      this.groupBox1.Controls.Add((Control) this.label19);
      this.groupBox1.Controls.Add((Control) this.comboBox8);
      this.groupBox1.Controls.Add((Control) this.comboBox5);
      this.groupBox1.Controls.Add((Control) this.label12);
      this.groupBox1.Controls.Add((Control) this.label11);
      this.groupBox1.Controls.Add((Control) this.dateTimePicker5);
      this.groupBox1.Controls.Add((Control) this.comboBox3);
      this.groupBox1.Controls.Add((Control) this.label10);
      this.groupBox1.Controls.Add((Control) this.dateTimePicker1);
      this.groupBox1.Controls.Add((Control) this.label9);
      this.groupBox1.Controls.Add((Control) this.label8);
      this.groupBox1.Location = new Point(12, 257);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new Size(402, 231);
      this.groupBox1.TabIndex = 2;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Установки списка событий восходов/закатов Солнца:";
      this.dateTimePicker2.CustomFormat = "dd MMMM yyyy";
      this.dateTimePicker2.Format = DateTimePickerFormat.Custom;
      this.dateTimePicker2.Location = new Point(116, 117);
      this.dateTimePicker2.Name = "dateTimePicker2";
      this.dateTimePicker2.Size = new Size(163, 20);
      this.dateTimePicker2.TabIndex = 7;
      this.dateTimePicker2.Value = new DateTime(2012, 12, 31, 0, 0, 0, 0);
      this.comboBox4.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboBox4.FormattingEnabled = true;
      this.comboBox4.Items.AddRange(new object[2]
      {
        (object) "восходы",
        (object) "закаты"
      });
      this.comboBox4.Location = new Point(116, 24);
      this.comboBox4.Name = "comboBox4";
      this.comboBox4.Size = new Size(163, 21);
      this.comboBox4.TabIndex = 1;
      this.label13.AutoSize = true;
      this.label13.Location = new Point(40, 27);
      this.label13.Name = "label13";
      this.label13.Size = new Size(68, 13);
      this.label13.TabIndex = 0;
      this.label13.Text = "Тип списка:";
      this.label19.AutoSize = true;
      this.label19.Location = new Point(7, 60);
      this.label19.Name = "label19";
      this.label19.Size = new Size(101, 13);
      this.label19.TabIndex = 2;
      this.label19.Text = "Граница дня/ночи:";
      this.comboBox8.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboBox8.FormattingEnabled = true;
      this.comboBox8.Items.AddRange(new object[4]
      {
        (object) "видимый восход/закат Солнца по линии горизонта",
        (object) "конец гражданских сумерек",
        (object) "конец навигационных сумерек",
        (object) "конец астрономических сумерек"
      });
      this.comboBox8.Location = new Point(116, 57);
      this.comboBox8.Name = "comboBox8";
      this.comboBox8.Size = new Size(268, 21);
      this.comboBox8.TabIndex = 3;
      this.comboBox5.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboBox5.FormattingEnabled = true;
      this.comboBox5.Items.AddRange(new object[2]
      {
        (object) "включить",
        (object) "отключить"
      });
      this.comboBox5.Location = new Point(258, 180);
      this.comboBox5.Name = "comboBox5";
      this.comboBox5.Size = new Size(118, 21);
      this.comboBox5.TabIndex = 13;
      this.label12.AutoSize = true;
      this.label12.Location = new Point(31, 183);
      this.label12.Name = "label12";
      this.label12.Size = new Size(206, 13);
      this.label12.TabIndex = 12;
      this.label12.Text = "После наступления события контакты:";
      this.label11.AutoSize = true;
      this.label11.Location = new Point(283, 151);
      this.label11.Name = "label11";
      this.label11.Size = new Size(19, 13);
      this.label11.TabIndex = 10;
      this.label11.Text = "на";
      this.dateTimePicker5.CustomFormat = "HH:mm:ss";
      this.dateTimePicker5.Format = DateTimePickerFormat.Custom;
      this.dateTimePicker5.Location = new Point(305, 148);
      this.dateTimePicker5.Name = "dateTimePicker5";
      this.dateTimePicker5.ShowUpDown = true;
      this.dateTimePicker5.Size = new Size(79, 20);
      this.dateTimePicker5.TabIndex = 11;
      this.dateTimePicker5.Value = new DateTime(2009, 12, 11, 0, 0, 0, 0);
      this.comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboBox3.FormattingEnabled = true;
      this.comboBox3.Items.AddRange(new object[2]
      {
        (object) "до восхода/заката",
        (object) "после восхода/заката"
      });
      this.comboBox3.Location = new Point(134, 148);
      this.comboBox3.Name = "comboBox3";
      this.comboBox3.Size = new Size(145, 21);
      this.comboBox3.TabIndex = 9;
      this.label10.AutoSize = true;
      this.label10.Location = new Point(7, 151);
      this.label10.Name = "label10";
      this.label10.Size = new Size(121, 13);
      this.label10.TabIndex = 8;
      this.label10.Text = "Сместить по времени:";
      this.dateTimePicker1.CustomFormat = "dd MMMM yyyy";
      this.dateTimePicker1.Format = DateTimePickerFormat.Custom;
      this.dateTimePicker1.Location = new Point(116, 89);
      this.dateTimePicker1.Name = "dateTimePicker1";
      this.dateTimePicker1.Size = new Size(163, 20);
      this.dateTimePicker1.TabIndex = 5;
      this.dateTimePicker1.Value = new DateTime(2012, 1, 1, 0, 0, 0, 0);
      this.label9.AutoSize = true;
      this.label9.Location = new Point(13, 117);
      this.label9.Name = "label9";
      this.label9.Size = new Size(97, 13);
      this.label9.TabIndex = 6;
      this.label9.Text = "Последние сутки:";
      this.label8.AutoSize = true;
      this.label8.Location = new Point(29, 91);
      this.label8.Name = "label8";
      this.label8.Size = new Size(81, 13);
      this.label8.TabIndex = 4;
      this.label8.Text = "Первые сутки:";
      this.groupBox2.Controls.Add((Control) this.groupBox5);
      this.groupBox2.Controls.Add((Control) this.groupBox4);
      this.groupBox2.Controls.Add((Control) this.groupBox3);
      this.groupBox2.Location = new Point(12, 12);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new Size(402, 239);
      this.groupBox2.TabIndex = 0;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Координаты местности:";
      this.groupBox5.Controls.Add((Control) this.numericUpDown8);
      this.groupBox5.Controls.Add((Control) this.label7);
      this.groupBox5.Controls.Add((Control) this.checkBox4);
      this.groupBox5.Controls.Add((Control) this.numericUpDown7);
      this.groupBox5.Location = new Point(17, 182);
      this.groupBox5.Name = "groupBox5";
      this.groupBox5.Size = new Size(367, 48);
      this.groupBox5.TabIndex = 2;
      this.groupBox5.TabStop = false;
      this.groupBox5.Text = "Разница с Гринвичем:";
      this.checkBox4.AutoSize = true;
      this.checkBox4.Checked = true;
      this.checkBox4.CheckState = CheckState.Checked;
      this.checkBox4.Location = new Point(148, 22);
      this.checkBox4.Name = "checkBox4";
      this.checkBox4.Size = new Size(213, 17);
      this.checkBox4.TabIndex = 3;
      this.checkBox4.Text = "Учитывать переход на летнее время";
      this.checkBox4.UseVisualStyleBackColor = true;
      this.numericUpDown7.Location = new Point(15, 18);
      NumericUpDown numericUpDown7_1 = this.numericUpDown7;
      int[] bits1 = new int[4];
      bits1[0] = 24;
      Decimal num1 = new Decimal(bits1);
      numericUpDown7_1.Maximum = num1;
      this.numericUpDown7.Minimum = new Decimal(new int[4]
      {
        24,
        0,
        0,
        int.MinValue
      });
      this.numericUpDown7.Name = "numericUpDown7";
      this.numericUpDown7.Size = new Size(49, 20);
      this.numericUpDown7.TabIndex = 1;
      NumericUpDown numericUpDown7_2 = this.numericUpDown7;
      int[] bits2 = new int[4];
      bits2[0] = 3;
      Decimal num2 = new Decimal(bits2);
      numericUpDown7_2.Value = num2;
      this.groupBox4.Controls.Add((Control) this.comboBox2);
      this.groupBox4.Controls.Add((Control) this.label4);
      this.groupBox4.Controls.Add((Control) this.numericUpDown4);
      this.groupBox4.Controls.Add((Control) this.label5);
      this.groupBox4.Controls.Add((Control) this.numericUpDown5);
      this.groupBox4.Controls.Add((Control) this.label6);
      this.groupBox4.Controls.Add((Control) this.numericUpDown6);
      this.groupBox4.Location = new Point(17, 19);
      this.groupBox4.Name = "groupBox4";
      this.groupBox4.Size = new Size(367, 76);
      this.groupBox4.TabIndex = 0;
      this.groupBox4.TabStop = false;
      this.groupBox4.Text = "Широта:";
      this.comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboBox2.FormattingEnabled = true;
      this.comboBox2.Items.AddRange(new object[2]
      {
        (object) "северной широты (с.ш.)",
        (object) "южной широты (ю.ш.)"
      });
      this.comboBox2.Location = new Point(207, 45);
      this.comboBox2.Name = "comboBox2";
      this.comboBox2.Size = new Size(150, 21);
      this.comboBox2.TabIndex = 6;
      this.label4.AutoSize = true;
      this.label4.Location = new Point(245, 23);
      this.label4.Name = "label4";
      this.label4.Size = new Size(54, 13);
      this.label4.TabIndex = 4;
      this.label4.Text = "Секунды:";
      this.numericUpDown4.Location = new Point(305, 19);
      this.numericUpDown4.Name = "numericUpDown4";
      this.numericUpDown4.Size = new Size(52, 20);
      this.numericUpDown4.TabIndex = 5;
      NumericUpDown numericUpDown4 = this.numericUpDown4;
      int[] bits3 = new int[4];
      bits3[0] = 20;
      Decimal num3 = new Decimal(bits3);
      numericUpDown4.Value = num3;
      this.label5.AutoSize = true;
      this.label5.Location = new Point(132, 23);
      this.label5.Name = "label5";
      this.label5.Size = new Size(49, 13);
      this.label5.TabIndex = 2;
      this.label5.Text = "Минуты:";
      this.numericUpDown5.Location = new Point(187, 19);
      this.numericUpDown5.Name = "numericUpDown5";
      this.numericUpDown5.Size = new Size(52, 20);
      this.numericUpDown5.TabIndex = 3;
      NumericUpDown numericUpDown5 = this.numericUpDown5;
      int[] bits4 = new int[4];
      bits4[0] = 45;
      Decimal num4 = new Decimal(bits4);
      numericUpDown5.Value = num4;
      this.label6.AutoSize = true;
      this.label6.Location = new Point(15, 23);
      this.label6.Name = "label6";
      this.label6.Size = new Size(53, 13);
      this.label6.TabIndex = 0;
      this.label6.Text = "Градусы:";
      this.numericUpDown6.Location = new Point(74, 19);
      NumericUpDown numericUpDown6_1 = this.numericUpDown6;
      int[] bits5 = new int[4];
      bits5[0] = 70;
      Decimal num5 = new Decimal(bits5);
      numericUpDown6_1.Maximum = num5;
      this.numericUpDown6.Name = "numericUpDown6";
      this.numericUpDown6.Size = new Size(52, 20);
      this.numericUpDown6.TabIndex = 1;
      NumericUpDown numericUpDown6_2 = this.numericUpDown6;
      int[] bits6 = new int[4];
      bits6[0] = 55;
      Decimal num6 = new Decimal(bits6);
      numericUpDown6_2.Value = num6;
      this.groupBox3.Controls.Add((Control) this.comboBox1);
      this.groupBox3.Controls.Add((Control) this.label3);
      this.groupBox3.Controls.Add((Control) this.numericUpDown3);
      this.groupBox3.Controls.Add((Control) this.label2);
      this.groupBox3.Controls.Add((Control) this.numericUpDown2);
      this.groupBox3.Controls.Add((Control) this.label1);
      this.groupBox3.Controls.Add((Control) this.numericUpDown1);
      this.groupBox3.Location = new Point(17, 101);
      this.groupBox3.Name = "groupBox3";
      this.groupBox3.Size = new Size(367, 75);
      this.groupBox3.TabIndex = 1;
      this.groupBox3.TabStop = false;
      this.groupBox3.Text = "Долгота:";
      this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboBox1.FormattingEnabled = true;
      this.comboBox1.Items.AddRange(new object[2]
      {
        (object) "восточной долготы (в.д.)",
        (object) "западной долготы (з.д.)"
      });
      this.comboBox1.Location = new Point(207, 45);
      this.comboBox1.Name = "comboBox1";
      this.comboBox1.Size = new Size(150, 21);
      this.comboBox1.TabIndex = 6;
      this.label3.AutoSize = true;
      this.label3.Location = new Point(245, 23);
      this.label3.Name = "label3";
      this.label3.Size = new Size(54, 13);
      this.label3.TabIndex = 4;
      this.label3.Text = "Секунды:";
      this.numericUpDown3.Location = new Point(305, 19);
      this.numericUpDown3.Name = "numericUpDown3";
      this.numericUpDown3.Size = new Size(52, 20);
      this.numericUpDown3.TabIndex = 5;
      NumericUpDown numericUpDown3 = this.numericUpDown3;
      int[] bits7 = new int[4];
      bits7[0] = 3;
      Decimal num7 = new Decimal(bits7);
      numericUpDown3.Value = num7;
      this.label2.AutoSize = true;
      this.label2.Location = new Point(132, 23);
      this.label2.Name = "label2";
      this.label2.Size = new Size(49, 13);
      this.label2.TabIndex = 2;
      this.label2.Text = "Минуты:";
      this.numericUpDown2.Location = new Point(187, 19);
      this.numericUpDown2.Name = "numericUpDown2";
      this.numericUpDown2.Size = new Size(52, 20);
      this.numericUpDown2.TabIndex = 3;
      NumericUpDown numericUpDown2 = this.numericUpDown2;
      int[] bits8 = new int[4];
      bits8[0] = 37;
      Decimal num8 = new Decimal(bits8);
      numericUpDown2.Value = num8;
      this.label1.AutoSize = true;
      this.label1.Location = new Point(15, 23);
      this.label1.Name = "label1";
      this.label1.Size = new Size(53, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Градусы:";
      this.numericUpDown1.Location = new Point(74, 19);
      NumericUpDown numericUpDown1_1 = this.numericUpDown1;
      int[] bits9 = new int[4];
      bits9[0] = 179;
      Decimal num9 = new Decimal(bits9);
      numericUpDown1_1.Maximum = num9;
      this.numericUpDown1.Name = "numericUpDown1";
      this.numericUpDown1.Size = new Size(52, 20);
      this.numericUpDown1.TabIndex = 1;
      NumericUpDown numericUpDown1_2 = this.numericUpDown1;
      int[] bits10 = new int[4];
      bits10[0] = 37;
      Decimal num10 = new Decimal(bits10);
      numericUpDown1_2.Value = num10;
      this.checkBox3.AutoSize = true;
      this.checkBox3.Location = new Point(12, 510);
      this.checkBox3.Name = "checkBox3";
      this.checkBox3.Size = new Size(271, 17);
      this.checkBox3.TabIndex = 3;
      this.checkBox3.Text = "предварительно стереть существующий список";
      this.checkBox3.UseVisualStyleBackColor = true;
      this.button2.DialogResult = DialogResult.Cancel;
      this.button2.Location = new Point(236, 547);
      this.button2.Name = "button2";
      this.button2.Size = new Size((int) sbyte.MaxValue, 28);
      this.button2.TabIndex = 0;
      this.button2.Text = "Отмена";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new EventHandler(this.button2_Click);
      this.label7.AutoSize = true;
      this.label7.Location = new Point(70, 22);
      this.label7.Name = "label7";
      this.label7.Size = new Size(10, 13);
      this.label7.TabIndex = 14;
      this.label7.Text = ":";
      this.numericUpDown8.Location = new Point(86, 18);
      NumericUpDown numericUpDown8 = this.numericUpDown8;
      int[] bits11 = new int[4];
      bits11[0] = 59;
      Decimal num11 = new Decimal(bits11);
      numericUpDown8.Maximum = num11;
      this.numericUpDown8.Name = "numericUpDown8";
      this.numericUpDown8.Size = new Size(49, 20);
      this.numericUpDown8.TabIndex = 2;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(426, 596);
      this.Controls.Add((Control) this.button2);
      this.Controls.Add((Control) this.checkBox3);
      this.Controls.Add((Control) this.groupBox2);
      this.Controls.Add((Control) this.groupBox1);
      this.Controls.Add((Control) this.button1);
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.Name = "SunRises";
      this.SizeGripStyle = SizeGripStyle.Hide;
      this.Text = "Восходы и закаты Солнца";
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.groupBox2.ResumeLayout(false);
      this.groupBox5.ResumeLayout(false);
      this.groupBox5.PerformLayout();
      this.numericUpDown7.EndInit();
      this.groupBox4.ResumeLayout(false);
      this.groupBox4.PerformLayout();
      this.numericUpDown4.EndInit();
      this.numericUpDown5.EndInit();
      this.numericUpDown6.EndInit();
      this.groupBox3.ResumeLayout(false);
      this.groupBox3.PerformLayout();
      this.numericUpDown3.EndInit();
      this.numericUpDown2.EndInit();
      this.numericUpDown1.EndInit();
      this.numericUpDown8.EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    private void Init()
    {
      this.comboBox1.SelectedIndex = 0;
      this.comboBox2.SelectedIndex = 0;
      this.comboBox3.SelectedIndex = 0;
      this.comboBox4.SelectedIndex = 0;
      this.comboBox5.SelectedIndex = 0;
      this.comboBox8.SelectedIndex = 0;
    }

    private void button1_Click(object sender, EventArgs e)
    {
      TimerClass timerClass = new TimerClass();
      foreach (TimerClass listEvent in (CollectionBase) this.ListEvents)
        timerClass.Add(new TimerClass(listEvent.DateAndTime, listEvent.Condition));
      bool flag = false;
      this.latitude = (double) this.numericUpDown6.Value + (double) this.numericUpDown5.Value / 60.0 + (double) this.numericUpDown4.Value / 3600.0;
      if (this.comboBox2.SelectedIndex == 1)
        this.latitude = -this.latitude;
      this.longitude = (double) this.numericUpDown1.Value + (double) this.numericUpDown2.Value / 60.0 + (double) this.numericUpDown3.Value / 3600.0;
      if (this.comboBox1.SelectedIndex == 1)
        this.longitude = -this.longitude;
      this.localOffsetMin = (double) this.numericUpDown7.Value * 60.0;
      this.localOffsetMin = this.localOffsetMin >= 0.0 ? this.localOffsetMin + (double) this.numericUpDown8.Value : this.localOffsetMin - (double) this.numericUpDown8.Value;
      this.WhatDesired = this.comboBox4.SelectedIndex == 0;
      switch (this.comboBox8.SelectedIndex)
      {
        case 0:
          this.zenith = 90.83333;
          break;
        case 1:
          this.zenith = 96.0;
          break;
        case 2:
          this.zenith = 102.0;
          break;
        case 3:
          this.zenith = 108.0;
          break;
        default:
          this.zenith = 90.83333;
          break;
      }
      this.ContactCondition = this.comboBox5.SelectedIndex == 0;
      if (this.checkBox3.Checked)
      {
        this.ListEvents.Clear();
        this.CountItemsInListEvents = -1;
      }
      if (DateTime.Compare(this.dateTimePicker1.Value, this.dateTimePicker2.Value) > 0)
      {
        if (this.SysSet.Lang == SystemSettings.TypeLanguage.RUSSIAN)
        {
          int num1 = (int) MessageBox.Show("Последние сутки в списке предшествуют первым!\nРасчет невозможен.", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        else if (this.SysSet.Lang == SystemSettings.TypeLanguage.POLISH)
        {
          int num2 = (int) MessageBox.Show("Ostatni dzień na liście poprzedza pierwszy dzień!\nWyliczenia nie są możliwe.", "Uwaga!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        else
        {
          int num3 = (int) MessageBox.Show("Last day in list precede first day!\nCalculation is not possible.", "Attention!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
      }
      else if (this.latitude > 90.0 || this.latitude < -90.0 || (this.longitude > 180.0 || this.longitude < -180.0))
      {
        if (this.SysSet.Lang == SystemSettings.TypeLanguage.RUSSIAN)
        {
          int num4 = (int) MessageBox.Show("Недопустимые координаты местности!\nРасчет невозможен.", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        else if (this.SysSet.Lang == SystemSettings.TypeLanguage.POLISH)
        {
          int num5 = (int) MessageBox.Show("Nieprawidłowe współrzędne geograficzne miejsca!\nWyliczenia nie są możliwe.", "Uwaga!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        else
        {
          int num6 = (int) MessageBox.Show("Illegal location geographic coordinates!\nCalculation is not possible.", "Attention!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
      }
      else
      {
        this.CalculateTime = this.dateTimePicker1.Value.AddDays(-1.0);
        while (this.CalculateTime != this.dateTimePicker2.Value)
        {
          this.CalculateTime = this.CalculateTime.AddDays(1.0);
          this.day = (double) this.CalculateTime.Day;
          this.month = (double) this.CalculateTime.Month;
          this.year = (double) this.CalculateTime.Year;
          double num7 = Math.Floor(275.0 * this.month / 9.0) - Math.Floor((this.month + 9.0) / 12.0) * (1.0 + Math.Floor((this.year - 4.0 * Math.Floor(this.year / 4.0) + 2.0) / 3.0)) + this.day - 30.0;
          double num8 = this.longitude / 15.0;
          double num9 = !this.WhatDesired ? num7 + (18.0 - num8) / 24.0 : num7 + (6.0 - num8) / 24.0;
          double num10 = 616.0 / 625.0 * num9 - 3.289;
          double num11 = num10 + 1.916 * Math.Sin(num10 * Math.PI / 180.0) + 0.02 * Math.Sin(2.0 * num10 * Math.PI / 180.0) + 282.634;
          while (num11 >= 360.0)
            num11 -= 360.0;
          while (num11 < 0.0)
            num11 += 360.0;
          double num12 = Math.Atan(0.91764 * Math.Tan(num11 * Math.PI / 180.0)) * 180.0 / Math.PI;
          while (num12 >= 360.0)
            num12 -= 360.0;
          while (num12 < 0.0)
            num12 += 360.0;
          double num13 = Math.Floor(num11 / 90.0) * 90.0;
          double num14 = Math.Floor(num12 / 90.0) * 90.0;
          double num15 = (num12 + (num13 - num14)) / 15.0;
          double d1 = 0.39782 * Math.Sin(num11 * Math.PI / 180.0);
          double num16 = Math.Cos(Math.Asin(d1));
          double d2 = (Math.Cos(this.zenith * Math.PI / 180.0) - d1 * Math.Sin(this.latitude * Math.PI / 180.0)) / (num16 * Math.Cos(this.latitude * Math.PI / 180.0));
          if (d2 <= 1.0 && d2 >= -1.0)
          {
            double d3 = (!this.WhatDesired ? Math.Acos(d2) * 180.0 / Math.PI : 360.0 - Math.Acos(d2) * 180.0 / Math.PI) / 15.0 + num15 - 0.06571 * num9 - 6.622 - num8;
            while (d3 >= 24.0)
              d3 -= 24.0;
            while (d3 < 0.0)
              d3 += 24.0;
            double num17 = Math.Floor(d3);
            double d4 = (d3 - num17) * 60.0;
            double num18 = (d4 - Math.Floor(d4)) * 60.0;
            DateTime d1_1 = new DateTime(this.CalculateTime.Year, this.CalculateTime.Month, this.CalculateTime.Day, (int) num17, (int) d4, (int) num18);
            d1_1 = d1_1.AddMinutes(this.localOffsetMin);
            if (this.checkBox4.Checked && this.CheckDayOnSummerTime(d1_1))
              d1_1 = d1_1.AddHours(1.0);
            int num19 = this.dateTimePicker5.Value.Hour * 3600 + this.dateTimePicker5.Value.Minute * 60 + this.dateTimePicker5.Value.Second;
            d1_1 = this.comboBox3.SelectedIndex != 0 ? d1_1.AddSeconds((double) num19) : d1_1.AddSeconds((double) -num19);
            ++this.CountItemsInListEvents;
            int count = this.ListEvents.Count;
            this.ListEvents.AddSmart(new TimerClass(new DateTime(1996, d1_1.Month, d1_1.Day, d1_1.Hour, d1_1.Minute, d1_1.Second), this.ContactCondition), 2);
            if (count == this.ListEvents.Count)
              flag = true;
          }
        }
        if (!this.checkBox3.Checked && flag)
        {
          if (this.SysSet.Lang == SystemSettings.TypeLanguage.RUSSIAN)
          {
            if (MessageBox.Show("Некоторые новые события списка совпадают по времени со старыми.\n\nЗаменить старые события новыми?", "Внимание!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
            {
              this.ListEvents = timerClass;
            }
            else
            {
              this.DialogResult = DialogResult.OK;
              this.Close();
            }
          }
          else if (this.SysSet.Lang == SystemSettings.TypeLanguage.POLISH)
          {
            if (MessageBox.Show("Niektóre nowe zdarzenia na liście kolidują czasowo ze starymi.\nZamienić stare zdarzenia na nowe?", "Uwaga!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
            {
              this.ListEvents = timerClass;
            }
            else
            {
              this.DialogResult = DialogResult.OK;
              this.Close();
            }
          }
          else if (MessageBox.Show("Some new elements of list concured with old.\n\nReplace old elements by new?", "Attention!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
          {
            this.ListEvents = timerClass;
          }
          else
          {
            this.DialogResult = DialogResult.OK;
            this.Close();
          }
        }
        else
        {
          this.DialogResult = DialogResult.OK;
          this.Close();
        }
      }
    }

    private bool CheckDayOnSummerTime(DateTime d1)
    {
      if (d1.Month > 3 && d1.Month < 10)
        return true;
      if (d1.Month == 3)
      {
        if (d1.DayOfWeek == DayOfWeek.Sunday)
          return d1.AddDays(7.0).Month != 3 && d1.Hour >= 3;
        for (; d1.Month == 3; d1 = d1.AddDays(1.0))
        {
          if (d1.DayOfWeek == DayOfWeek.Sunday)
            return false;
        }
        return true;
      }
      if (d1.Month != 10)
        return false;
      if (d1.DayOfWeek == DayOfWeek.Sunday)
        return d1.AddDays(7.0).Month == 10 || d1.Hour <= 2;
      for (; d1.Month == 10; d1 = d1.AddDays(1.0))
      {
        if (d1.DayOfWeek == DayOfWeek.Sunday)
          return true;
      }
      return false;
    }

    private void CreateSunRises()
    {
    }

    private void CreateSunSets()
    {
    }

    private void button2_Click(object sender, EventArgs e)
    {
      this.Close();
    }
  }
}
