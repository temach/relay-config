using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace JsonToRelay
{
  public class CtrlProgramOptions : CollectionBase, ICloneable
  {
    public bool[] ExceptDaysOfWeek = new bool[8];
    public TimerClass ListHolidays = new TimerClass();
    public TimerClass ListEventsException = new TimerClass();
    public TimerClass ListEventsYear = new TimerClass();
    public TimerClass ListEventsMonth = new TimerClass();
    public TimerClass ListEventsWeek = new TimerClass();
    public TimerClass ListEventsDay = new TimerClass();
    public CtrlProgramOptions.RelayTimeModeType RelayTimeMode;
    public bool AllowDaysoffs;
    public bool AllowHolidays;
    public bool AllowCyclicity;
    public CtrlProgramOptions.AdjTime RI_BeforeDelay;
    public CtrlProgramOptions.AdjTime RI_OnDelay;
    public CtrlProgramOptions.AdjTime RI_OffDelay;
    public CtrlProgramOptions.AdjTime RS_Delay;
    public bool RV_OnOff;
    public int RV_Umin;
    public int RV_Uminhyst;
    public int RV_Umax;
    public int RV_Umaxhyst;
    public CtrlProgramOptions.AdjTime RV_DelayUmin;
    public CtrlProgramOptions.AdjTime RV_DelayUnorm;
    public CtrlProgramOptions.AdjTime RV_DelayUmax;
    public bool RF_OnOff;
    public int RF_Lpor;
    public int RF_Lporhyst;
    public CtrlProgramOptions.AdjTime RF_DelayLmin;
    public CtrlProgramOptions.AdjTime RF_DelayLmax;
    public int RF_Condition_Lmin;
    public int RF_Condition_Lmax;

    public CtrlProgramOptions this[int ProgramIndex]
    {
      get
      {
        return (CtrlProgramOptions) this.List[ProgramIndex];
      }
      set
      {
        this.List[ProgramIndex] = (object) value;
      }
    }

    public CtrlProgramOptions()
    {
      this.Init();
    }

    public object Clone()
    {
      CtrlProgramOptions programOptionsClass = (CtrlProgramOptions) this.MemberwiseClone();
      TimerClass timerClass1 = new TimerClass();
      TimerClass timerClass2 = new TimerClass();
      TimerClass timerClass3 = new TimerClass();
      TimerClass timerClass4 = new TimerClass();
      TimerClass timerClass5 = new TimerClass();
      TimerClass timerClass6 = new TimerClass();
      foreach (TimerClass listHoliday in (CollectionBase) this.ListHolidays)
        timerClass1.Add(new TimerClass(listHoliday.DateAndTime, listHoliday.Condition));
      foreach (TimerClass timerClass7 in (CollectionBase) this.ListEventsException)
        timerClass2.Add(new TimerClass(timerClass7.DateAndTime, timerClass7.Condition));
      foreach (TimerClass timerClass7 in (CollectionBase) this.ListEventsYear)
        timerClass3.Add(new TimerClass(timerClass7.DateAndTime, timerClass7.Condition));
      foreach (TimerClass timerClass7 in (CollectionBase) this.ListEventsMonth)
        timerClass4.Add(new TimerClass(timerClass7.DateAndTime, timerClass7.Condition));
      foreach (TimerClass timerClass7 in (CollectionBase) this.ListEventsWeek)
        timerClass5.Add(new TimerClass(timerClass7.DateAndTime, timerClass7.Condition));
      foreach (TimerClass timerClass7 in (CollectionBase) this.ListEventsDay)
        timerClass6.Add(new TimerClass(timerClass7.DateAndTime, timerClass7.Condition));
      programOptionsClass.ListHolidays = timerClass1;
      programOptionsClass.ListEventsException = timerClass2;
      programOptionsClass.ListEventsYear = timerClass3;
      programOptionsClass.ListEventsMonth = timerClass4;
      programOptionsClass.ListEventsWeek = timerClass5;
      programOptionsClass.ListEventsDay = timerClass6;
      bool[] flagArray = new bool[8]
      {
        this.ExceptDaysOfWeek[0],
        this.ExceptDaysOfWeek[1],
        this.ExceptDaysOfWeek[2],
        this.ExceptDaysOfWeek[3],
        this.ExceptDaysOfWeek[4],
        this.ExceptDaysOfWeek[5],
        this.ExceptDaysOfWeek[6],
        this.ExceptDaysOfWeek[7]
      };
      programOptionsClass.ExceptDaysOfWeek = flagArray;
      return (object) programOptionsClass;
    }

    private void Init()
    {
      this.ResetOptions();
      this.ResetCollections();
    }

    public void Reset()
    {
      this.Init();
    }

    public void ResetOptions()
    {
      this.RelayTimeMode = CtrlProgramOptions.RelayTimeModeType.R_T_M_OFF;
      this.AllowDaysoffs = false;
      this.AllowHolidays = false;
      this.AllowCyclicity = true;
      for (int index = 1; index <= 7; ++index)
        this.ExceptDaysOfWeek[index] = false;
      this.RI_BeforeDelay.Minute = 0;
      this.RI_BeforeDelay.Second = 0;
      this.RI_OnDelay.Minute = 0;
      this.RI_OnDelay.Second = 1;
      this.RI_OffDelay.Minute = 0;
      this.RI_OffDelay.Second = 1;
      this.RS_Delay.Minute = 0;
      this.RS_Delay.Second = 0;
      this.RV_OnOff = false;
      this.RV_Umin = 200;
      this.RV_Uminhyst = 5;
      this.RV_Umax = 240;
      this.RV_Umaxhyst = 5;
      this.RV_DelayUmin.Minute = 0;
      this.RV_DelayUmin.Second = 0;
      this.RV_DelayUnorm.Minute = 0;
      this.RV_DelayUnorm.Second = 1;
      this.RV_DelayUmax.Minute = 0;
      this.RV_DelayUmax.Second = 0;
      this.RF_OnOff = false;
      this.RF_Lpor = 30;
      this.RF_Lporhyst = 5;
      this.RF_DelayLmin.Minute = 0;
      this.RF_DelayLmin.Second = 1;
      this.RF_DelayLmax.Minute = 0;
      this.RF_DelayLmax.Second = 1;
      this.RF_Condition_Lmin = 0;
      this.RF_Condition_Lmax = 0;
    }

    public void ResetCollections()
    {
      this.ListHolidays.Clear();
      this.ListEventsException.Clear();
      this.ListEventsYear.Clear();
      this.ListEventsMonth.Clear();
      this.ListEventsWeek.Clear();
      this.ListEventsDay.Clear();
    }

    public void Test1()
    {
      foreach (CtrlProgramOptions programOptionsClass in (CollectionBase) this)
        programOptionsClass.RV_OnOff = true;
    }

    public bool Compare(CtrlProgramOptions PrOp1)
    {
      bool flag = true;
      if (PrOp1.Count == this.Count)
      {
        int index1 = 0;
        foreach (CtrlProgramOptions programOptionsClass in (CollectionBase) this)
        {
          if (programOptionsClass.RelayTimeMode != PrOp1[index1].RelayTimeMode || programOptionsClass.AllowDaysoffs != PrOp1[index1].AllowDaysoffs || (programOptionsClass.AllowHolidays != PrOp1[index1].AllowHolidays || programOptionsClass.AllowCyclicity != PrOp1[index1].AllowCyclicity) || (programOptionsClass.RI_BeforeDelay.Minute != PrOp1[index1].RI_BeforeDelay.Minute || programOptionsClass.RI_BeforeDelay.Second != PrOp1[index1].RI_BeforeDelay.Second || (programOptionsClass.RI_OnDelay.Minute != PrOp1[index1].RI_OnDelay.Minute || programOptionsClass.RI_OnDelay.Second != PrOp1[index1].RI_OnDelay.Second)) || (programOptionsClass.RI_OffDelay.Minute != PrOp1[index1].RI_OffDelay.Minute || programOptionsClass.RI_OffDelay.Second != PrOp1[index1].RI_OffDelay.Second || (programOptionsClass.RS_Delay.Minute != PrOp1[index1].RS_Delay.Minute || programOptionsClass.RS_Delay.Second != PrOp1[index1].RS_Delay.Second) || (programOptionsClass.RV_OnOff != PrOp1[index1].RV_OnOff || programOptionsClass.RV_Umin != PrOp1[index1].RV_Umin || (programOptionsClass.RV_Uminhyst != PrOp1[index1].RV_Uminhyst || programOptionsClass.RV_Umax != PrOp1[index1].RV_Umax))) || (programOptionsClass.RV_Umaxhyst != PrOp1[index1].RV_Umaxhyst || programOptionsClass.RV_DelayUmin.Minute != PrOp1[index1].RV_DelayUmin.Minute || (programOptionsClass.RV_DelayUmin.Second != PrOp1[index1].RV_DelayUmin.Second || programOptionsClass.RV_DelayUnorm.Minute != PrOp1[index1].RV_DelayUnorm.Minute) || (programOptionsClass.RV_DelayUnorm.Second != PrOp1[index1].RV_DelayUnorm.Second || programOptionsClass.RV_DelayUmax.Minute != PrOp1[index1].RV_DelayUmax.Minute || (programOptionsClass.RV_DelayUmax.Second != PrOp1[index1].RV_DelayUmax.Second || programOptionsClass.RF_OnOff != PrOp1[index1].RF_OnOff)) || (programOptionsClass.RF_Lpor != PrOp1[index1].RF_Lpor || programOptionsClass.RF_Lporhyst != PrOp1[index1].RF_Lporhyst || (programOptionsClass.RF_DelayLmin.Minute != PrOp1[index1].RF_DelayLmin.Minute || programOptionsClass.RF_DelayLmin.Second != PrOp1[index1].RF_DelayLmin.Second) || (programOptionsClass.RF_DelayLmax.Minute != PrOp1[index1].RF_DelayLmax.Minute || programOptionsClass.RF_DelayLmax.Second != PrOp1[index1].RF_DelayLmax.Second || (programOptionsClass.RF_Condition_Lmin != PrOp1[index1].RF_Condition_Lmin || programOptionsClass.RF_Condition_Lmax != PrOp1[index1].RF_Condition_Lmax)))))
            flag = false;
          for (int index2 = 1; index2 <= 7; ++index2)
          {
            if (programOptionsClass.ExceptDaysOfWeek[index2] != PrOp1[index1].ExceptDaysOfWeek[index2])
              flag = false;
          }
          if (!programOptionsClass.ListHolidays.Compare(PrOp1[index1].ListHolidays) || !programOptionsClass.ListEventsException.Compare(PrOp1[index1].ListEventsException) || (!programOptionsClass.ListEventsYear.Compare(PrOp1[index1].ListEventsYear) || !programOptionsClass.ListEventsMonth.Compare(PrOp1[index1].ListEventsMonth)) || (!programOptionsClass.ListEventsWeek.Compare(PrOp1[index1].ListEventsWeek) || !programOptionsClass.ListEventsDay.Compare(PrOp1[index1].ListEventsDay)))
            flag = false;
          ++index1;
        }
      }
      else
        flag = false;
      return flag;
    }

    public void Add(CtrlProgramOptions newProgram)
    {
      this.List.Add((object) newProgram);
    }

    public void Remove(CtrlProgramOptions oldProgram)
    {
      this.List.Remove((object) oldProgram);
    }

    public enum RelayTimeModeType
    {
      R_T_M_OFF,
      R_T_M_YEAR,
      R_T_M_MONTH,
      R_T_M_WEEK,
      R_T_M_DAY,
      R_T_M_PULSE,
      R_T_M_SIMPLE,
    }

    [Serializable]
    public struct AdjTime
    {
      public int Minute;
      public int Second;
    }
  }
}
