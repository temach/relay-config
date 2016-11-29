// NoAuthor
// Type: MultiTimerWinForms.ListsEvents
// Assembly: MultiTimer, Version=1.5.2.0, Culture=neutral, PublicKeyToken=null
// MVID: BCBF5A5D-507A-4FEA-8EFC-8CECD33998F9
// Assembly location: C:\Program Files (x86)\Novatek-Electro\Configurator REV-302\MultiTimer.exe

using System.Collections;

namespace MultiTimerWinForms
{
  internal class ListsEvents : CollectionBase
  {
    public ListsEvents this[int ProgramIndex]
    {
      get
      {
        return (ListsEvents) this.List[ProgramIndex];
      }
      set
      {
        this.List[ProgramIndex] = (object) value;
      }
    }

    public void Add(ListsEvents newProgram)
    {
      this.List.Add((object) newProgram);
    }

    public void Remove(ListsEvents oldProgram)
    {
      this.List.Remove((object) oldProgram);
    }
  }
}
