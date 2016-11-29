// NoAuthor
// Type: MultiTimerWinForms.About
// Assembly: MultiTimer, Version=1.5.2.0, Culture=neutral, PublicKeyToken=null
// MVID: BCBF5A5D-507A-4FEA-8EFC-8CECD33998F9
// Assembly location: C:\Program Files (x86)\Novatek-Electro\Configurator REV-302\MultiTimer.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace MultiTimerWinForms
{
  public class About : Form
  {
    public uint ProgramVersion = 1;
    public uint ProgramSubversion = 5;
    public uint ProgramRevision = 2;
    public uint ProgramSubrevision;
    private IContainer components;
    private PictureBox pictureBox1;
    private Label label1;
    private Label label2;
    private Label label3;
    private Button button1;

    public About()
    {
      this.InitializeComponent();
      SystemSettings systemSettings = new SystemSettings();
      string str = this.ProgramVersion.ToString() + "." + this.ProgramSubversion.ToString() + "." + this.ProgramRevision.ToString() + "." + this.ProgramSubrevision.ToString();
      if (systemSettings.Lang == SystemSettings.TypeLanguage.RUSSIAN)
      {
        this.label1.Text = "2009-2016. Novatek-Electro ltd.";
        this.label2.Text = "Версия программы: v" + str;
      }
      else if (systemSettings.Lang == SystemSettings.TypeLanguage.POLISH)
      {
        this.Text = "O programie";
        this.label1.Text = "2009-2016. Novatek-Electro ltd.";
        this.label2.Text = "Wersja programu: v" + str;
        this.label3.Text = "Wszystkie prawa zastrzeżone.";
      }
      else
      {
        this.Text = "About program";
        this.label1.Text = "2009-2016. Novatek-Electro ltd.";
        this.label2.Text = "Program version: v" + str;
        this.label3.Text = "All rights reserved.";
      }
    }

    private void button1_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (About));
      this.pictureBox1 = new PictureBox();
      this.label1 = new Label();
      this.label2 = new Label();
      this.label3 = new Label();
      this.button1 = new Button();
      ((ISupportInitialize) this.pictureBox1).BeginInit();
      this.SuspendLayout();
      this.pictureBox1.Image = (Image) componentResourceManager.GetObject("pictureBox1.Image");
      this.pictureBox1.Location = new Point(12, 12);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new Size(106, 98);
      this.pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
      this.pictureBox1.TabIndex = 0;
      this.pictureBox1.TabStop = false;
      this.label1.AutoSize = true;
      this.label1.Location = new Point(136, 83);
      this.label1.Name = "label1";
      this.label1.Size = new Size(58, 13);
      this.label1.TabIndex = 1;
      this.label1.Text = "2009-2013";
      this.label2.AutoSize = true;
      this.label2.Location = new Point(136, 26);
      this.label2.Name = "label2";
      this.label2.Size = new Size(124, 13);
      this.label2.TabIndex = 2;
      this.label2.Text = "Версия программы 1.2";
      this.label3.AutoSize = true;
      this.label3.Location = new Point(136, 55);
      this.label3.Name = "label3";
      this.label3.Size = new Size(121, 13);
      this.label3.TabIndex = 3;
      this.label3.Text = "Все права защищены.";
      this.button1.DialogResult = DialogResult.OK;
      this.button1.Location = new Point(98, (int) sbyte.MaxValue);
      this.button1.Name = "button1";
      this.button1.Size = new Size(105, 28);
      this.button1.TabIndex = 5;
      this.button1.Text = "OK";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new EventHandler(this.button1_Click);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(303, 176);
      this.Controls.Add((Control) this.button1);
      this.Controls.Add((Control) this.label3);
      this.Controls.Add((Control) this.label2);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.pictureBox1);
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.Name = "About";
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "О программе";
      ((ISupportInitialize) this.pictureBox1).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
