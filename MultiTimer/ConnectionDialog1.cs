// NoAuthor
// Type: MultiTimerWinForms.ConnectionDialog1
// Assembly: MultiTimer, Version=1.5.2.0, Culture=neutral, PublicKeyToken=null
// MVID: BCBF5A5D-507A-4FEA-8EFC-8CECD33998F9
// Assembly location: C:\Program Files (x86)\Novatek-Electro\Configurator REV-302\MultiTimer.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using UsbLibrary;

namespace MultiTimerWinForms
{
  public class ConnectionDialog1 : Form
  {
    private IContainer components;
    private Label label1;
    private ProgressBar progressBar1;
    private Button button1;
    private UsbHidPort usb;

    public int ProcBar1
    {
      get
      {
        return this.progressBar1.Value;
      }
      set
      {
        this.progressBar1.Value = value;
      }
    }

    public ConnectionDialog1()
    {
      this.InitializeComponent();
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
      this.components = (IContainer) new Container();
      this.label1 = new Label();
      this.progressBar1 = new ProgressBar();
      this.button1 = new Button();
      this.usb = new UsbHidPort(this.components);
      this.SuspendLayout();
      this.label1.AutoSize = true;
      this.label1.Location = new Point(54, 21);
      this.label1.Name = "label1";
      this.label1.Size = new Size(243, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Прием данных. Подождите несколько минут...";
      this.progressBar1.Location = new Point(12, 51);
      this.progressBar1.Name = "progressBar1";
      this.progressBar1.Size = new Size(330, 23);
      this.progressBar1.TabIndex = 1;
      this.button1.DialogResult = DialogResult.Cancel;
      this.button1.Location = new Point(126, 92);
      this.button1.Name = "button1";
      this.button1.Size = new Size(96, 25);
      this.button1.TabIndex = 2;
      this.button1.Text = "Отмена";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new EventHandler(this.button1_Click);
      this.usb.ProductId = 23;
      this.usb.VendorId = 1982;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(354, 129);
      this.Controls.Add((Control) this.button1);
      this.Controls.Add((Control) this.progressBar1);
      this.Controls.Add((Control) this.label1);
      this.Name = "ConnectionDialog1";
      this.Text = "Обмен данными с РЭС-302";
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    private void Init()
    {
    }

    private void button1_Click(object sender, EventArgs e)
    {
      this.Close();
    }
  }
}
