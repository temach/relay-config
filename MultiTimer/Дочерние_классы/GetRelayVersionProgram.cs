// NoAuthor
// Type: MultiTimerWinForms.Дочерние_классы.GetRelayVersionProgram
// Assembly: MultiTimer, Version=1.5.2.0, Culture=neutral, PublicKeyToken=null
// MVID: BCBF5A5D-507A-4FEA-8EFC-8CECD33998F9
// Assembly location: C:\Program Files (x86)\Novatek-Electro\Configurator REV-302\MultiTimer.exe

using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace MultiTimerWinForms.Дочерние_классы
{
  public class GetRelayVersionProgram : Form
  {
    private IContainer components;

    public GetRelayVersionProgram()
    {
      this.InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.SuspendLayout();
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(362, 117);
      this.Name = "GetRelayVersionProgram";
      this.Text = "Версия программы РЭВ-302";
      this.ResumeLayout(false);
    }
  }
}
