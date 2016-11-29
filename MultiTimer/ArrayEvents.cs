// NoAuthor
// Type: MultiTimerWinForms.ArrayEvents
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
  public class ArrayEvents : Form
  {
    public TimerClass ListEvents = new TimerClass();
    private SystemSettings SysSet = new SystemSettings();
    public int TypeOfList;
    private IContainer components;
    private Button button2;
    private Button button1;
    private GroupBox groupBox1;
    private DateTimePicker dateTimePicker1;
    private DateTimePicker dateTimePicker5;
    private ComboBox comboBox5;
    private Label label12;
    private GroupBox groupBox2;
    private Label label2;
    private Label label1;
    private ComboBox comboBox1;
    private DateTimePicker dateTimePicker2;
    private NumericUpDown numericUpDown2;
    private Label label4;
    private Label label3;
    private NumericUpDown numericUpDown1;
    private CheckBox checkBox3;

    public ArrayEvents()
    {
      this.InitializeComponent();
      if (this.SysSet.Lang == SystemSettings.TypeLanguage.ENGLISH)
      {
        this.Text = "Events array wizard";
        this.groupBox1.Text = "First event setup";
        this.label12.Text = "Contacts:";
        this.comboBox5.Items[0] = (object) "Close";
        this.comboBox5.Items[1] = (object) "Open";
        this.groupBox2.Text = "Array:";
        this.label4.Text = "Events general quantity:";
        this.label2.Text = "Step:";
        this.label3.Text = "days";
        this.label1.Text = "Contacts:";
        this.comboBox1.Items[0] = (object) "like the first event";
        this.comboBox1.Items[1] = (object) "alternate";
        this.checkBox3.Text = "Preliminary erase the existing list";
        this.button1.Text = "Create array";
        this.button2.Text = "Cancel";
      }
      else if (this.SysSet.Lang == SystemSettings.TypeLanguage.POLISH)
      {
        this.Text = "Kreator listy zdarzeń";
        this.groupBox1.Text = "Ustaw pierwsze zdarzenie";
        this.label12.Text = "Styki:";
        this.comboBox5.Items[0] = (object) "Załącz";
        this.comboBox5.Items[1] = (object) "Wyłącz";
        this.groupBox2.Text = "Lista:";
        this.label4.Text = "Ogólna ilość zdarzeń:";
        this.label2.Text = "Krok:";
        this.label3.Text = "dni";
        this.label1.Text = "Styki:";
        this.comboBox1.Items[0] = (object) "jak w pierwszym zdarzeniu";
        this.comboBox1.Items[1] = (object) "zmieniaj za każdym razem";
        this.checkBox3.Text = "Najpierw usuń istniejącą listę";
        this.button1.Text = "Utwórz listę";
        this.button2.Text = "Anuluj";
      }
      this.Init();
    }

    private void Init()
    {
      this.comboBox5.SelectedIndex = 0;
      this.comboBox1.SelectedIndex = 0;
    }

    public void ChangeShowElements(int NewTypeList)
    {
      this.TypeOfList = NewTypeList;
      this.dateTimePicker1.Visible = true;
      this.numericUpDown1.Visible = true;
      this.label3.Visible = true;
      this.dateTimePicker5.Visible = true;
      this.label12.Visible = true;
      this.comboBox5.Visible = true;
      this.dateTimePicker2.Visible = true;
      this.label1.Visible = true;
      this.comboBox1.Visible = true;
      if (this.SysSet.Lang == SystemSettings.TypeLanguage.RUSSIAN)
      {
        this.Text = "Создание массива событий";
        this.groupBox1.Text = "Настройка первого события:";
        this.label4.Text = "Общее кол-во событий:";
      }
      else if (this.SysSet.Lang == SystemSettings.TypeLanguage.ENGLISH)
      {
        this.Text = "Events array wizard";
        this.groupBox1.Text = "First event setup:";
        this.label4.Text = "Events general quantity:";
      }
      else if (this.SysSet.Lang == SystemSettings.TypeLanguage.POLISH)
      {
        this.Text = "Kreator listy zdarzeń";
        this.groupBox1.Text = "Ustaw pierwsze zdarzenie:";
        this.label4.Text = "Ogólna ilość zdarzeń:";
      }
      switch (NewTypeList)
      {
        case 0:
          this.dateTimePicker5.Visible = false;
          this.label12.Visible = false;
          this.comboBox5.Visible = false;
          this.dateTimePicker2.Visible = false;
          this.label1.Visible = false;
          this.comboBox1.Visible = false;
          this.dateTimePicker5.Value = new DateTime(1996, 1, 1, 0, 0, 0);
          this.dateTimePicker2.Value = new DateTime(1996, 1, 1, 0, 0, 0);
          if (this.SysSet.Lang == SystemSettings.TypeLanguage.RUSSIAN)
          {
            this.Text = "Создание массива праздников";
            this.groupBox1.Text = "Настройка первого праздника:";
            this.label4.Text = "Общее кол-во праздников:";
          }
          else if (this.SysSet.Lang == SystemSettings.TypeLanguage.ENGLISH)
          {
            this.Text = "Holidays array wizard";
            this.groupBox1.Text = "First holiday setup:";
            this.label4.Text = "Holidays general quantity:";
          }
          else if (this.SysSet.Lang == SystemSettings.TypeLanguage.POLISH)
          {
            this.Text = "Kreator listy świąt";
            this.groupBox1.Text = "Ustaw pierwsze święto:";
            this.label4.Text = "Ogólna ilość świąt:";
          }
          this.numericUpDown1.Maximum = new Decimal(365);
          break;
        case 1:
          this.dateTimePicker1.Visible = false;
          this.numericUpDown1.Visible = false;
          this.label3.Visible = false;
          this.numericUpDown1.Value = new Decimal(0);
          break;
        case 2:
          this.numericUpDown1.Maximum = new Decimal(365);
          break;
        case 3:
          this.numericUpDown1.Maximum = new Decimal(30);
          break;
        case 4:
          this.numericUpDown1.Maximum = new Decimal(6);
          break;
        case 5:
          this.dateTimePicker1.Visible = false;
          this.numericUpDown1.Visible = false;
          this.label3.Visible = false;
          this.numericUpDown1.Value = new Decimal(0);
          break;
      }
    }

    private void button1_Click_1(object sender, EventArgs e)
    {
      TimerClass timerClass = new TimerClass();
      foreach (TimerClass listEvent in (CollectionBase) this.ListEvents)
        timerClass.Add(new TimerClass(listEvent.DateAndTime, listEvent.Condition));
      bool flag = false;
      if (this.checkBox3.Checked)
        this.ListEvents.Clear();
      bool newCondition = this.comboBox5.SelectedIndex == 0;
      int count1 = this.ListEvents.Count;
      DateTime dateTime = new DateTime(this.dateTimePicker1.Value.Year, this.dateTimePicker1.Value.Month, this.dateTimePicker1.Value.Day, this.dateTimePicker5.Value.Hour, this.dateTimePicker5.Value.Minute, this.dateTimePicker5.Value.Second);
      if (this.TypeOfList == 4)
        this.ListEvents.AddSmart(new TimerClass(new DateTime(1996, 1, this.ConvertDayOfWeekInInt(dateTime.DayOfWeek), dateTime.Hour, dateTime.Minute, dateTime.Second), newCondition), this.TypeOfList);
      else
        this.ListEvents.AddSmart(new TimerClass(new DateTime(1996, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute, dateTime.Second), newCondition), this.TypeOfList);
      if (count1 == this.ListEvents.Count)
        flag = true;
      for (int index = 1; index < (int) this.numericUpDown2.Value; ++index)
      {
        if (this.comboBox1.SelectedIndex != 0 && this.comboBox1.SelectedIndex == 1)
          newCondition = !newCondition;
        dateTime = dateTime.AddDays((double) (int) this.numericUpDown1.Value);
        dateTime = dateTime.AddHours((double) this.dateTimePicker2.Value.Hour);
        dateTime = dateTime.AddMinutes((double) this.dateTimePicker2.Value.Minute);
        dateTime = dateTime.AddSeconds((double) this.dateTimePicker2.Value.Second);
        int count2 = this.ListEvents.Count;
        if (this.TypeOfList == 4)
          this.ListEvents.AddSmart(new TimerClass(new DateTime(1996, 1, this.ConvertDayOfWeekInInt(dateTime.DayOfWeek), dateTime.Hour, dateTime.Minute, dateTime.Second), newCondition), this.TypeOfList);
        else
          this.ListEvents.AddSmart(new TimerClass(new DateTime(1996, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute, dateTime.Second), newCondition), this.TypeOfList);
        if (count2 == this.ListEvents.Count)
          flag = true;
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
        else if (this.SysSet.Lang == SystemSettings.TypeLanguage.ENGLISH)
        {
          if (MessageBox.Show("Some new elements of list concured with old.\n\nReplace old elements by new?", "Attention!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
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
          if (this.SysSet.Lang != SystemSettings.TypeLanguage.POLISH)
            return;
          if (MessageBox.Show("Niektóre nowe zdarzenia na liście kolidują czasowo ze starymi.\n\nZamienić stare zdarzenia na nowe?", "Uwaga!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
          {
            this.ListEvents = timerClass;
          }
          else
          {
            this.DialogResult = DialogResult.OK;
            this.Close();
          }
        }
      }
      else
      {
        this.DialogResult = DialogResult.OK;
        this.Close();
      }
    }

    private int ConvertDayOfWeekInInt(DayOfWeek inday)
    {
      switch (inday)
      {
        case DayOfWeek.Sunday:
          return 7;
        case DayOfWeek.Monday:
          return 1;
        case DayOfWeek.Tuesday:
          return 2;
        case DayOfWeek.Wednesday:
          return 3;
        case DayOfWeek.Thursday:
          return 4;
        case DayOfWeek.Friday:
          return 5;
        case DayOfWeek.Saturday:
          return 6;
        default:
          return 1;
      }
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.button2 = new Button();
      this.button1 = new Button();
      this.groupBox1 = new GroupBox();
      this.label12 = new Label();
      this.comboBox5 = new ComboBox();
      this.dateTimePicker5 = new DateTimePicker();
      this.dateTimePicker1 = new DateTimePicker();
      this.groupBox2 = new GroupBox();
      this.numericUpDown2 = new NumericUpDown();
      this.label4 = new Label();
      this.label3 = new Label();
      this.numericUpDown1 = new NumericUpDown();
      this.label2 = new Label();
      this.label1 = new Label();
      this.comboBox1 = new ComboBox();
      this.dateTimePicker2 = new DateTimePicker();
      this.checkBox3 = new CheckBox();
      this.groupBox1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.numericUpDown2.BeginInit();
      this.numericUpDown1.BeginInit();
      this.SuspendLayout();
      this.button2.DialogResult = DialogResult.Cancel;
      this.button2.Location = new Point(171, 303);
      this.button2.Name = "button2";
      this.button2.Size = new Size((int) sbyte.MaxValue, 28);
      this.button2.TabIndex = 3;
      this.button2.Text = "Отмена";
      this.button2.UseVisualStyleBackColor = true;
      this.button1.Location = new Point(23, 303);
      this.button1.Name = "button1";
      this.button1.Size = new Size((int) sbyte.MaxValue, 28);
      this.button1.TabIndex = 2;
      this.button1.Text = "Создать список";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new EventHandler(this.button1_Click_1);
      this.groupBox1.Controls.Add((Control) this.label12);
      this.groupBox1.Controls.Add((Control) this.comboBox5);
      this.groupBox1.Controls.Add((Control) this.dateTimePicker5);
      this.groupBox1.Controls.Add((Control) this.dateTimePicker1);
      this.groupBox1.Location = new Point(12, 12);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new Size(300, 110);
      this.groupBox1.TabIndex = 0;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Настройка первого события:";
      this.label12.AutoSize = true;
      this.label12.Location = new Point(67, 73);
      this.label12.Name = "label12";
      this.label12.Size = new Size(59, 13);
      this.label12.TabIndex = 2;
      this.label12.Text = "Контакты:";
      this.comboBox5.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboBox5.FormattingEnabled = true;
      this.comboBox5.Items.AddRange(new object[2]
      {
        (object) "включить",
        (object) "отключить"
      });
      this.comboBox5.Location = new Point(143, 70);
      this.comboBox5.Name = "comboBox5";
      this.comboBox5.Size = new Size(125, 21);
      this.comboBox5.TabIndex = 3;
      this.dateTimePicker5.CustomFormat = "HH:mm:ss";
      this.dateTimePicker5.Format = DateTimePickerFormat.Custom;
      this.dateTimePicker5.Location = new Point(189, 31);
      this.dateTimePicker5.Name = "dateTimePicker5";
      this.dateTimePicker5.ShowUpDown = true;
      this.dateTimePicker5.Size = new Size(79, 20);
      this.dateTimePicker5.TabIndex = 1;
      this.dateTimePicker5.Value = new DateTime(2009, 12, 11, 0, 0, 0, 0);
      this.dateTimePicker1.CustomFormat = "dd MMMM yyyy ddd";
      this.dateTimePicker1.Format = DateTimePickerFormat.Custom;
      this.dateTimePicker1.Location = new Point(11, 31);
      this.dateTimePicker1.Name = "dateTimePicker1";
      this.dateTimePicker1.Size = new Size(155, 20);
      this.dateTimePicker1.TabIndex = 0;
      this.dateTimePicker1.Value = new DateTime(2012, 1, 1, 0, 0, 0, 0);
      this.groupBox2.Controls.Add((Control) this.numericUpDown2);
      this.groupBox2.Controls.Add((Control) this.label4);
      this.groupBox2.Controls.Add((Control) this.label3);
      this.groupBox2.Controls.Add((Control) this.numericUpDown1);
      this.groupBox2.Controls.Add((Control) this.label2);
      this.groupBox2.Controls.Add((Control) this.label1);
      this.groupBox2.Controls.Add((Control) this.comboBox1);
      this.groupBox2.Controls.Add((Control) this.dateTimePicker2);
      this.groupBox2.Location = new Point(12, 128);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new Size(300, 124);
      this.groupBox2.TabIndex = 1;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Массив:";
      this.numericUpDown2.Location = new Point(193, 19);
      NumericUpDown numericUpDown2_1 = this.numericUpDown2;
      int[] bits1 = new int[4];
      bits1[0] = 10000;
      Decimal num1 = new Decimal(bits1);
      numericUpDown2_1.Maximum = num1;
      NumericUpDown numericUpDown2_2 = this.numericUpDown2;
      int[] bits2 = new int[4];
      bits2[0] = 2;
      Decimal num2 = new Decimal(bits2);
      numericUpDown2_2.Minimum = num2;
      this.numericUpDown2.Name = "numericUpDown2";
      this.numericUpDown2.Size = new Size(57, 20);
      this.numericUpDown2.TabIndex = 1;
      NumericUpDown numericUpDown2_3 = this.numericUpDown2;
      int[] bits3 = new int[4];
      bits3[0] = 2;
      Decimal num3 = new Decimal(bits3);
      numericUpDown2_3.Value = num3;
      this.label4.AutoSize = true;
      this.label4.Location = new Point(21, 21);
      this.label4.Name = "label4";
      this.label4.Size = new Size((int) sbyte.MaxValue, 13);
      this.label4.TabIndex = 0;
      this.label4.Text = "Общее кол-во событий:";
      this.label3.AutoSize = true;
      this.label3.Location = new Point(154, 55);
      this.label3.Name = "label3";
      this.label3.Size = new Size(31, 13);
      this.label3.TabIndex = 4;
      this.label3.Text = "дней";
      this.numericUpDown1.Location = new Point(91, 51);
      NumericUpDown numericUpDown1 = this.numericUpDown1;
      int[] bits4 = new int[4];
      bits4[0] = 365;
      Decimal num4 = new Decimal(bits4);
      numericUpDown1.Maximum = num4;
      this.numericUpDown1.Name = "numericUpDown1";
      this.numericUpDown1.Size = new Size(57, 20);
      this.numericUpDown1.TabIndex = 3;
      this.label2.AutoSize = true;
      this.label2.Location = new Point(55, 55);
      this.label2.Name = "label2";
      this.label2.Size = new Size(30, 13);
      this.label2.TabIndex = 2;
      this.label2.Text = "Шаг:";
      this.label1.AutoSize = true;
      this.label1.Location = new Point(41, 89);
      this.label1.Name = "label1";
      this.label1.Size = new Size(59, 13);
      this.label1.TabIndex = 6;
      this.label1.Text = "Контакты:";
      this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboBox1.FormattingEnabled = true;
      this.comboBox1.Items.AddRange(new object[2]
      {
        (object) "как в первом событии",
        (object) "чередовать"
      });
      this.comboBox1.Location = new Point(106, 86);
      this.comboBox1.Name = "comboBox1";
      this.comboBox1.Size = new Size(166, 21);
      this.comboBox1.TabIndex = 7;
      this.dateTimePicker2.CustomFormat = "HH:mm:ss";
      this.dateTimePicker2.Format = DateTimePickerFormat.Custom;
      this.dateTimePicker2.Location = new Point(193, 51);
      this.dateTimePicker2.Name = "dateTimePicker2";
      this.dateTimePicker2.ShowUpDown = true;
      this.dateTimePicker2.Size = new Size(79, 20);
      this.dateTimePicker2.TabIndex = 5;
      this.dateTimePicker2.Value = new DateTime(2009, 12, 11, 0, 0, 0, 0);
      this.checkBox3.AutoSize = true;
      this.checkBox3.Location = new Point(13, 270);
      this.checkBox3.Name = "checkBox3";
      this.checkBox3.Size = new Size(271, 17);
      this.checkBox3.TabIndex = 4;
      this.checkBox3.Text = "предварительно стереть существующий список";
      this.checkBox3.UseVisualStyleBackColor = true;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(324, 349);
      this.Controls.Add((Control) this.checkBox3);
      this.Controls.Add((Control) this.groupBox2);
      this.Controls.Add((Control) this.groupBox1);
      this.Controls.Add((Control) this.button2);
      this.Controls.Add((Control) this.button1);
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.Name = "ArrayEvents";
      this.SizeGripStyle = SizeGripStyle.Hide;
      this.Text = "Создание массива событий";
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.numericUpDown2.EndInit();
      this.numericUpDown1.EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
