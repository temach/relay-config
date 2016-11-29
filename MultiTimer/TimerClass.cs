// NoAuthor
// Type: MultiTimerWinForms.TimerClass
// Assembly: MultiTimer, Version=1.5.2.0, Culture=neutral, PublicKeyToken=null
// MVID: BCBF5A5D-507A-4FEA-8EFC-8CECD33998F9
// Assembly location: C:\Program Files (x86)\Novatek-Electro\Configurator REV-302\MultiTimer.exe

using System;
using System.Collections;

namespace MultiTimerWinForms
{
  [Serializable]
  public class TimerClass : CollectionBase
  {
    public DateTime DateAndTime;
    public bool Condition;

    public TimerClass this[int ItemIndex]
    {
      get
      {
        return (TimerClass) this.List[ItemIndex];
      }
      set
      {
        this.List[ItemIndex] = (object) value;
      }
    }

    public TimerClass()
    {
    }

    public TimerClass(DateTime newDateAndTime)
    {
      this.DateAndTime = newDateAndTime;
      this.Condition = false;
    }

    public TimerClass(DateTime newDateAndTime, bool newCondition)
    {
      this.DateAndTime = newDateAndTime;
      this.Condition = newCondition;
    }

    public bool Compare(TimerClass TC1)
    {
      bool flag = true;
      if (TC1.Count == this.Count)
      {
        int index = 0;
        foreach (TimerClass timerClass in (CollectionBase) this)
        {
          if (DateTime.Compare(timerClass.DateAndTime, TC1[index].DateAndTime) != 0 || timerClass.Condition != TC1[index].Condition)
            flag = false;
          ++index;
        }
      }
      else
        flag = false;
      return flag;
    }

    public int AddSmart(TimerClass newItem, int TypeOfListEvets)
    {
      switch (TypeOfListEvets)
      {
        case 0:
          newItem.DateAndTime = new DateTime(1996, newItem.DateAndTime.Month, newItem.DateAndTime.Day);
          break;
        case 1:
          newItem.DateAndTime = new DateTime(1996, 1, 1, newItem.DateAndTime.Hour, newItem.DateAndTime.Minute, newItem.DateAndTime.Second);
          break;
        case 2:
          newItem.DateAndTime = new DateTime(1996, newItem.DateAndTime.Month, newItem.DateAndTime.Day, newItem.DateAndTime.Hour, newItem.DateAndTime.Minute, newItem.DateAndTime.Second);
          break;
        case 3:
          newItem.DateAndTime = new DateTime(1996, 1, newItem.DateAndTime.Day, newItem.DateAndTime.Hour, newItem.DateAndTime.Minute, newItem.DateAndTime.Second);
          break;
        case 4:
          newItem.DateAndTime = new DateTime(1996, 1, newItem.DateAndTime.Day, newItem.DateAndTime.Hour, newItem.DateAndTime.Minute, newItem.DateAndTime.Second);
          break;
        case 5:
          newItem.DateAndTime = new DateTime(1996, 1, 1, newItem.DateAndTime.Hour, newItem.DateAndTime.Minute, newItem.DateAndTime.Second);
          break;
      }
      this.List.Add((object) new TimerClass());
      if (this.Count == 1)
      {
        this[0] = newItem;
        return 0;
      }
      int index;
      for (index = this.Count - 2; index >= 0; --index)
      {
        switch (DateTime.Compare(this[index].DateAndTime, newItem.DateAndTime))
        {
          case 1:
            this[index + 1] = this[index];
            break;
          case 0:
            this[index] = newItem;
            this.RemoveAt(index + 1);
            return index;
          case -1:
            this[index + 1] = newItem;
            return index + 1;
        }
      }
      this[0] = newItem;
      return index + 1;
    }

    public void Add(TimerClass newItem)
    {
      this.List.Add((object) newItem);
    }

    public void Remove(TimerClass oldItem)
    {
      this.List.Remove((object) oldItem);
    }

    public new void RemoveAt(int index)
    {
      this.List.RemoveAt(index);
    }

    public new void Clear()
    {
      this.List.Clear();
    }
  }
}
