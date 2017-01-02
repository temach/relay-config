using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsbLibrary;
using Newtonsoft.Json;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.Collections.Concurrent;
using System.Threading;

namespace timerelay_server
{
    class JsonReadWrite
    {
        DeviceOptions DeviceOpts = new DeviceOptions();
        CtrlProgramOptions CtrlProgramsOpts = new CtrlProgramOptions();

        public Tuple<DeviceOptions, CtrlProgramOptions> OpenFileJSON(string json_data)
        {
            StringReader jsonStream = new StringReader(json_data);
            DeviceOptions deviceOptions = new DeviceOptions();
            CtrlProgramOptions programOptions = new CtrlProgramOptions();
            for (int index = 0; index <= 9; ++index)
            {
                programOptions.Add(new CtrlProgramOptions());
            }
            using (JsonReader jsonReader = (JsonReader)new JsonTextReader((TextReader)jsonStream))
            {
                while (jsonReader.Read())
                {
                    if (jsonReader.Value != null)
                    {
                        if (jsonReader.Value.Equals((object)"format"))
                        {
                            if (jsonReader.Read() && jsonReader.Value != null && Convert.ToInt32(jsonReader.Value) != 1)
                                throw new ArgumentException("Fault File Format!");
                        }
                        else if (jsonReader.Value.Equals((object)"channel1"))
                        {
                            if (jsonReader.Read() && jsonReader.Value != null)
                                deviceOptions.Channel_CtrlProg[1] = Convert.ToByte(jsonReader.Value);
                        }
                        else if (jsonReader.Value.Equals((object)"channel2"))
                        {
                            if (jsonReader.Read() && jsonReader.Value != null)
                                deviceOptions.Channel_CtrlProg[2] = Convert.ToByte(jsonReader.Value);
                        }
                        else if (jsonReader.Value.Equals((object)"dstonoff"))
                        {
                            if (jsonReader.Read() && jsonReader.Value != null)
                                deviceOptions.DST_OnOff = Convert.ToBoolean(jsonReader.Value);
                        }
                        else if (jsonReader.Value.Equals((object)"dstonoff"))
                        {
                            if (jsonReader.Read() && jsonReader.Value != null)
                                deviceOptions.DST_OnOff = Convert.ToBoolean(jsonReader.Value);
                        }
                        else if (jsonReader.Value.Equals((object)"delaystart"))
                        {
                            if (jsonReader.Read() && jsonReader.Value == null)
                            {
                                if (jsonReader.Read() && jsonReader.Value != null)
                                    deviceOptions.CommonDelay.Minute = Convert.ToInt32(jsonReader.Value);
                                if (jsonReader.Read() && jsonReader.Value != null)
                                    deviceOptions.CommonDelay.Second = Convert.ToInt32(jsonReader.Value);
                                jsonReader.Read();
                            }
                        }
                        else if (jsonReader.Value.Equals((object)"program"))
                        {
                            int index1 = 0;
                            if (jsonReader.Read() && jsonReader.Value == null)
                            {
                                while (jsonReader.Read() && jsonReader.Value != null)
                                {
                                    if (jsonReader.Value.Equals((object)"number"))
                                    {
                                        if (jsonReader.Read() && jsonReader.Value != null)
                                            index1 = Convert.ToInt32(jsonReader.Value);
                                    }
                                    else if (jsonReader.Value.Equals((object)"timermode"))
                                    {
                                        if (jsonReader.Read() && jsonReader.Value != null)
                                            programOptions[index1].RelayTimeMode = (CtrlProgramOptions.RelayTimeModeType)Convert.ToInt32(jsonReader.Value);
                                    }
                                    else if (jsonReader.Value.Equals((object)"excweekdays"))
                                    {
                                        if (jsonReader.Read() && jsonReader.Value == null)
                                        {
                                            for (int index2 = 0; index2 < 7; ++index2)
                                            {
                                                if (jsonReader.Read() && jsonReader.Value != null)
                                                    programOptions[index1].ExceptDaysOfWeek[index2 + 1] = Convert.ToBoolean(jsonReader.Value);
                                            }
                                            jsonReader.Read();
                                        }
                                    }
                                    else if (jsonReader.Value.Equals((object)"allowdayoffs"))
                                    {
                                        if (jsonReader.Read() && jsonReader.Value != null)
                                            programOptions[index1].AllowDaysoffs = Convert.ToBoolean(jsonReader.Value);
                                    }
                                    else if (jsonReader.Value.Equals((object)"allowholidays"))
                                    {
                                        if (jsonReader.Read() && jsonReader.Value != null)
                                            programOptions[index1].AllowHolidays = Convert.ToBoolean(jsonReader.Value);
                                    }
                                    else if (jsonReader.Value.Equals((object)"allowciclicity"))
                                    {
                                        if (jsonReader.Read() && jsonReader.Value != null)
                                            programOptions[index1].AllowCyclicity = Convert.ToBoolean(jsonReader.Value);
                                    }
                                    else if (jsonReader.Value.Equals((object)"ribeforedelay"))
                                    {
                                        if (jsonReader.Read() && jsonReader.Value == null)
                                        {
                                            if (jsonReader.Read() && jsonReader.Value != null)
                                                programOptions[index1].RI_BeforeDelay.Minute = Convert.ToInt32(jsonReader.Value);
                                            if (jsonReader.Read() && jsonReader.Value != null)
                                                programOptions[index1].RI_BeforeDelay.Second = Convert.ToInt32(jsonReader.Value);
                                            jsonReader.Read();
                                        }
                                    }
                                    else if (jsonReader.Value.Equals((object)"riondelay"))
                                    {
                                        if (jsonReader.Read() && jsonReader.Value == null)
                                        {
                                            if (jsonReader.Read() && jsonReader.Value != null)
                                                programOptions[index1].RI_OnDelay.Minute = Convert.ToInt32(jsonReader.Value);
                                            if (jsonReader.Read() && jsonReader.Value != null)
                                                programOptions[index1].RI_OnDelay.Second = Convert.ToInt32(jsonReader.Value);
                                            jsonReader.Read();
                                        }
                                    }
                                    else if (jsonReader.Value.Equals((object)"rioffdelay"))
                                    {
                                        if (jsonReader.Read() && jsonReader.Value == null)
                                        {
                                            if (jsonReader.Read() && jsonReader.Value != null)
                                                programOptions[index1].RI_OffDelay.Minute = Convert.ToInt32(jsonReader.Value);
                                            if (jsonReader.Read() && jsonReader.Value != null)
                                                programOptions[index1].RI_OffDelay.Second = Convert.ToInt32(jsonReader.Value);
                                            jsonReader.Read();
                                        }
                                    }
                                    else if (jsonReader.Value.Equals((object)"rsdelay"))
                                    {
                                        if (jsonReader.Read() && jsonReader.Value == null)
                                        {
                                            if (jsonReader.Read() && jsonReader.Value != null)
                                                programOptions[index1].RS_Delay.Minute = Convert.ToInt32(jsonReader.Value);
                                            if (jsonReader.Read() && jsonReader.Value != null)
                                                programOptions[index1].RS_Delay.Second = Convert.ToInt32(jsonReader.Value);
                                            jsonReader.Read();
                                        }
                                    }
                                    else if (jsonReader.Value.Equals((object)"rvdelayumin"))
                                    {
                                        if (jsonReader.Read() && jsonReader.Value == null)
                                        {
                                            if (jsonReader.Read() && jsonReader.Value != null)
                                                programOptions[index1].RV_DelayUmin.Minute = Convert.ToInt32(jsonReader.Value);
                                            if (jsonReader.Read() && jsonReader.Value != null)
                                                programOptions[index1].RV_DelayUmin.Second = Convert.ToInt32(jsonReader.Value);
                                            jsonReader.Read();
                                        }
                                    }
                                    else if (jsonReader.Value.Equals((object)"rvdelayunorm"))
                                    {
                                        if (jsonReader.Read() && jsonReader.Value == null)
                                        {
                                            if (jsonReader.Read() && jsonReader.Value != null)
                                                programOptions[index1].RV_DelayUnorm.Minute = Convert.ToInt32(jsonReader.Value);
                                            if (jsonReader.Read() && jsonReader.Value != null)
                                                programOptions[index1].RV_DelayUnorm.Second = Convert.ToInt32(jsonReader.Value);
                                            jsonReader.Read();
                                        }
                                    }
                                    else if (jsonReader.Value.Equals((object)"rvdelayumax"))
                                    {
                                        if (jsonReader.Read() && jsonReader.Value == null)
                                        {
                                            if (jsonReader.Read() && jsonReader.Value != null)
                                                programOptions[index1].RV_DelayUmax.Minute = Convert.ToInt32(jsonReader.Value);
                                            if (jsonReader.Read() && jsonReader.Value != null)
                                                programOptions[index1].RV_DelayUmax.Second = Convert.ToInt32(jsonReader.Value);
                                            jsonReader.Read();
                                        }
                                    }
                                    else if (jsonReader.Value.Equals((object)"rfdelaylmin"))
                                    {
                                        if (jsonReader.Read() && jsonReader.Value == null)
                                        {
                                            if (jsonReader.Read() && jsonReader.Value != null)
                                                programOptions[index1].RF_DelayLmin.Minute = Convert.ToInt32(jsonReader.Value);
                                            if (jsonReader.Read() && jsonReader.Value != null)
                                                programOptions[index1].RF_DelayLmin.Second = Convert.ToInt32(jsonReader.Value);
                                            jsonReader.Read();
                                        }
                                    }
                                    else if (jsonReader.Value.Equals((object)"rfdelaylmax"))
                                    {
                                        if (jsonReader.Read() && jsonReader.Value == null)
                                        {
                                            if (jsonReader.Read() && jsonReader.Value != null)
                                                programOptions[index1].RF_DelayLmax.Minute = Convert.ToInt32(jsonReader.Value);
                                            if (jsonReader.Read() && jsonReader.Value != null)
                                                programOptions[index1].RF_DelayLmax.Second = Convert.ToInt32(jsonReader.Value);
                                            jsonReader.Read();
                                        }
                                    }
                                    else if (jsonReader.Value.Equals((object)"rvonoff"))
                                    {
                                        if (jsonReader.Read() && jsonReader.Value != null)
                                            programOptions[index1].RV_OnOff = Convert.ToBoolean(jsonReader.Value);
                                    }
                                    else if (jsonReader.Value.Equals((object)"rvumin"))
                                    {
                                        if (jsonReader.Read() && jsonReader.Value != null)
                                            programOptions[index1].RV_Umin = Convert.ToInt32(jsonReader.Value);
                                    }
                                    else if (jsonReader.Value.Equals((object)"rvumax"))
                                    {
                                        if (jsonReader.Read() && jsonReader.Value != null)
                                            programOptions[index1].RV_Umax = Convert.ToInt32(jsonReader.Value);
                                    }
                                    else if (jsonReader.Value.Equals((object)"rvuminhyst"))
                                    {
                                        if (jsonReader.Read() && jsonReader.Value != null)
                                            programOptions[index1].RV_Uminhyst = Convert.ToInt32(jsonReader.Value);
                                    }
                                    else if (jsonReader.Value.Equals((object)"rvumaxhyst"))
                                    {
                                        if (jsonReader.Read() && jsonReader.Value != null)
                                            programOptions[index1].RV_Umaxhyst = Convert.ToInt32(jsonReader.Value);
                                    }
                                    else if (jsonReader.Value.Equals((object)"rfonoff"))
                                    {
                                        if (jsonReader.Read() && jsonReader.Value != null)
                                            programOptions[index1].RF_OnOff = Convert.ToBoolean(jsonReader.Value);
                                    }
                                    else if (jsonReader.Value.Equals((object)"rflpor"))
                                    {
                                        if (jsonReader.Read() && jsonReader.Value != null)
                                            programOptions[index1].RF_Lpor = Convert.ToInt32(jsonReader.Value);
                                    }
                                    else if (jsonReader.Value.Equals((object)"rflporhyst"))
                                    {
                                        if (jsonReader.Read() && jsonReader.Value != null)
                                            programOptions[index1].RF_Lporhyst = Convert.ToInt32(jsonReader.Value);
                                    }
                                    else if (jsonReader.Value.Equals((object)"rfcontlmin"))
                                    {
                                        if (jsonReader.Read() && jsonReader.Value != null)
                                            programOptions[index1].RF_Condition_Lmin = Convert.ToInt32(jsonReader.Value);
                                    }
                                    else if (jsonReader.Value.Equals((object)"rfcontlmax"))
                                    {
                                        if (jsonReader.Read() && jsonReader.Value != null)
                                            programOptions[index1].RF_Condition_Lmax = Convert.ToInt32(jsonReader.Value);
                                    }
                                    else if (jsonReader.Value.Equals((object)"lists"))
                                    {
                                        int num1 = 0;
                                        int num2 = 0;
                                        TimerClass timerClass = new TimerClass();
                                        if (jsonReader.Read() && jsonReader.Value == null)
                                        {
                                            while (jsonReader.Read() && jsonReader.Value != null)
                                            {
                                                if (jsonReader.Value.Equals((object)"listnum"))
                                                {
                                                    if (jsonReader.Read() && jsonReader.Value != null)
                                                        num1 = Convert.ToInt32(jsonReader.Value);
                                                }
                                                else if (jsonReader.Value.Equals((object)"eventsmax"))
                                                {
                                                    if (jsonReader.Read() && jsonReader.Value != null)
                                                    {
                                                        num2 = Convert.ToInt32(jsonReader.Value);
                                                        if (num2 == 0)
                                                            break;
                                                    }
                                                }
                                                else if (jsonReader.Value.Equals((object)"event"))
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
                                                            if (jsonReader.Value.Equals((object)"eventnum"))
                                                            {
                                                                if (jsonReader.Read() && jsonReader.Value != null)
                                                                    index2 = Convert.ToInt32(jsonReader.Value);
                                                            }
                                                            else if (jsonReader.Value.Equals((object)"sec"))
                                                            {
                                                                if (jsonReader.Read() && jsonReader.Value != null)
                                                                    second = Convert.ToInt32(jsonReader.Value);
                                                            }
                                                            else if (jsonReader.Value.Equals((object)"min"))
                                                            {
                                                                if (jsonReader.Read() && jsonReader.Value != null)
                                                                    minute = Convert.ToInt32(jsonReader.Value);
                                                            }
                                                            else if (jsonReader.Value.Equals((object)"hour"))
                                                            {
                                                                if (jsonReader.Read() && jsonReader.Value != null)
                                                                    hour = Convert.ToInt32(jsonReader.Value);
                                                            }
                                                            else if (jsonReader.Value.Equals((object)"weekday"))
                                                            {
                                                                if (jsonReader.Read() && jsonReader.Value != null)
                                                                    day1 = Convert.ToInt32(jsonReader.Value) + 1;
                                                            }
                                                            else if (jsonReader.Value.Equals((object)"monthday"))
                                                            {
                                                                if (jsonReader.Read() && jsonReader.Value != null)
                                                                    day2 = Convert.ToInt32(jsonReader.Value);
                                                            }
                                                            else if (jsonReader.Value.Equals((object)"month"))
                                                            {
                                                                if (jsonReader.Read() && jsonReader.Value != null)
                                                                    month = Convert.ToInt32(jsonReader.Value);
                                                            }
                                                            else if (jsonReader.Value.Equals((object)"condition"))
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
                                                programOptions[index1].ListHolidays = timerClass;
                                                break;
                                            case 1:
                                                programOptions[index1].ListEventsException = timerClass;
                                                break;
                                            case 2:
                                                programOptions[index1].ListEventsYear = timerClass;
                                                break;
                                            case 3:
                                                programOptions[index1].ListEventsMonth = timerClass;
                                                break;
                                            case 4:
                                                programOptions[index1].ListEventsWeek = timerClass;
                                                break;
                                            case 5:
                                                programOptions[index1].ListEventsDay = timerClass;
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
            jsonStream.Close();
            return new Tuple<DeviceOptions, CtrlProgramOptions>(deviceOptions, programOptions);
        }

        public string SaveFileJSON(DeviceOptions devOpts, CtrlProgramOptions progsOpts)
        {
            StringWriter json = new StringWriter();
            json.NewLine = "\n";
            this.DeviceOpts = devOpts;
            this.CtrlProgramsOpts = progsOpts;
            TimerClass[] timerClassArray = new TimerClass[6];
            using (JsonWriter jsonWriter = (JsonWriter)new JsonTextWriter((TextWriter)json))
            {
                jsonWriter.Formatting = Formatting.Indented;
                jsonWriter.WriteStartObject();
                jsonWriter.WritePropertyName("format");
                jsonWriter.WriteValue(1);
                jsonWriter.WritePropertyName("channel1");
                jsonWriter.WriteValue(this.DeviceOpts.Channel_CtrlProg[1]);
                jsonWriter.WritePropertyName("channel2");
                jsonWriter.WriteValue(this.DeviceOpts.Channel_CtrlProg[2]);
                jsonWriter.WritePropertyName("dstonoff");
                if (this.DeviceOpts.DST_OnOff)
                    jsonWriter.WriteValue(1);
                else
                    jsonWriter.WriteValue(0);
                jsonWriter.WritePropertyName("delaystart");
                jsonWriter.WriteStartArray();
                jsonWriter.WriteValue(this.DeviceOpts.CommonDelay.Minute);
                jsonWriter.WriteValue(this.DeviceOpts.CommonDelay.Second);
                jsonWriter.WriteEndArray();
                for (int index1 = 1; index1 <= 8; ++index1)
                {
                    jsonWriter.WritePropertyName("program");
                    jsonWriter.WriteStartObject();
                    jsonWriter.WritePropertyName("number");
                    jsonWriter.WriteValue(index1);
                    jsonWriter.WritePropertyName("timermode");
                    jsonWriter.WriteValue((object)this.CtrlProgramsOpts[index1].RelayTimeMode);
                    jsonWriter.WritePropertyName("excweekdays");
                    jsonWriter.WriteStartArray();
                    for (int index2 = 1; index2 <= 7; ++index2)
                    {
                        if (this.CtrlProgramsOpts[index1].ExceptDaysOfWeek[index2])
                            jsonWriter.WriteValue(1);
                        else
                            jsonWriter.WriteValue(0);
                    }
                    jsonWriter.WriteEndArray();
                    jsonWriter.WritePropertyName("allowdayoffs");
                    if (this.CtrlProgramsOpts[index1].AllowDaysoffs)
                        jsonWriter.WriteValue(1);
                    else
                        jsonWriter.WriteValue(0);
                    jsonWriter.WritePropertyName("allowholidays");
                    if (this.CtrlProgramsOpts[index1].AllowHolidays)
                        jsonWriter.WriteValue(1);
                    else
                        jsonWriter.WriteValue(0);
                    jsonWriter.WritePropertyName("allowciclicity");
                    if (this.CtrlProgramsOpts[index1].AllowCyclicity)
                        jsonWriter.WriteValue(1);
                    else
                        jsonWriter.WriteValue(0);
                    jsonWriter.WritePropertyName("ribeforedelay");
                    jsonWriter.WriteStartArray();
                    jsonWriter.WriteValue(this.CtrlProgramsOpts[index1].RI_BeforeDelay.Minute);
                    jsonWriter.WriteValue(this.CtrlProgramsOpts[index1].RI_BeforeDelay.Second);
                    jsonWriter.WriteEndArray();
                    jsonWriter.WritePropertyName("riondelay");
                    jsonWriter.WriteStartArray();
                    jsonWriter.WriteValue(this.CtrlProgramsOpts[index1].RI_OnDelay.Minute);
                    jsonWriter.WriteValue(this.CtrlProgramsOpts[index1].RI_OnDelay.Second);
                    jsonWriter.WriteEndArray();
                    jsonWriter.WritePropertyName("rioffdelay");
                    jsonWriter.WriteStartArray();
                    jsonWriter.WriteValue(this.CtrlProgramsOpts[index1].RI_OffDelay.Minute);
                    jsonWriter.WriteValue(this.CtrlProgramsOpts[index1].RI_OffDelay.Second);
                    jsonWriter.WriteEndArray();
                    jsonWriter.WritePropertyName("rsdelay");
                    jsonWriter.WriteStartArray();
                    jsonWriter.WriteValue(this.CtrlProgramsOpts[index1].RS_Delay.Minute);
                    jsonWriter.WriteValue(this.CtrlProgramsOpts[index1].RS_Delay.Second);
                    jsonWriter.WriteEndArray();
                    jsonWriter.WritePropertyName("rvdelayumin");
                    jsonWriter.WriteStartArray();
                    jsonWriter.WriteValue(this.CtrlProgramsOpts[index1].RV_DelayUmin.Minute);
                    jsonWriter.WriteValue(this.CtrlProgramsOpts[index1].RV_DelayUmin.Second);
                    jsonWriter.WriteEndArray();
                    jsonWriter.WritePropertyName("rvdelayunorm");
                    jsonWriter.WriteStartArray();
                    jsonWriter.WriteValue(this.CtrlProgramsOpts[index1].RV_DelayUnorm.Minute);
                    jsonWriter.WriteValue(this.CtrlProgramsOpts[index1].RV_DelayUnorm.Second);
                    jsonWriter.WriteEndArray();
                    jsonWriter.WritePropertyName("rvdelayumax");
                    jsonWriter.WriteStartArray();
                    jsonWriter.WriteValue(this.CtrlProgramsOpts[index1].RV_DelayUmax.Minute);
                    jsonWriter.WriteValue(this.CtrlProgramsOpts[index1].RV_DelayUmax.Second);
                    jsonWriter.WriteEndArray();
                    jsonWriter.WritePropertyName("rfdelaylmin");
                    jsonWriter.WriteStartArray();
                    jsonWriter.WriteValue(this.CtrlProgramsOpts[index1].RF_DelayLmin.Minute);
                    jsonWriter.WriteValue(this.CtrlProgramsOpts[index1].RF_DelayLmin.Second);
                    jsonWriter.WriteEndArray();
                    jsonWriter.WritePropertyName("rfdelaylmax");
                    jsonWriter.WriteStartArray();
                    jsonWriter.WriteValue(this.CtrlProgramsOpts[index1].RF_DelayLmax.Minute);
                    jsonWriter.WriteValue(this.CtrlProgramsOpts[index1].RF_DelayLmax.Second);
                    jsonWriter.WriteEndArray();
                    jsonWriter.WritePropertyName("rvonoff");
                    if (this.CtrlProgramsOpts[index1].RV_OnOff)
                        jsonWriter.WriteValue(1);
                    else
                        jsonWriter.WriteValue(0);
                    jsonWriter.WritePropertyName("rvumin");
                    jsonWriter.WriteValue(this.CtrlProgramsOpts[index1].RV_Umin);
                    jsonWriter.WritePropertyName("rvumax");
                    jsonWriter.WriteValue(this.CtrlProgramsOpts[index1].RV_Umax);
                    jsonWriter.WritePropertyName("rvuminhyst");
                    jsonWriter.WriteValue(this.CtrlProgramsOpts[index1].RV_Uminhyst);
                    jsonWriter.WritePropertyName("rvumaxhyst");
                    jsonWriter.WriteValue(this.CtrlProgramsOpts[index1].RV_Umaxhyst);
                    jsonWriter.WritePropertyName("rfonoff");
                    if (this.CtrlProgramsOpts[index1].RF_OnOff)
                        jsonWriter.WriteValue(1);
                    else
                        jsonWriter.WriteValue(0);
                    jsonWriter.WritePropertyName("rflpor");
                    jsonWriter.WriteValue(this.CtrlProgramsOpts[index1].RF_Lpor);
                    jsonWriter.WritePropertyName("rflporhyst");
                    jsonWriter.WriteValue(this.CtrlProgramsOpts[index1].RF_Lporhyst);
                    jsonWriter.WritePropertyName("rfcontlmin");
                    jsonWriter.WriteValue(this.CtrlProgramsOpts[index1].RF_Condition_Lmin);
                    jsonWriter.WritePropertyName("rfcontlmax");
                    jsonWriter.WriteValue(this.CtrlProgramsOpts[index1].RF_Condition_Lmax);
                    timerClassArray[0] = this.CtrlProgramsOpts[index1].ListHolidays;
                    timerClassArray[1] = this.CtrlProgramsOpts[index1].ListEventsException;
                    timerClassArray[2] = this.CtrlProgramsOpts[index1].ListEventsYear;
                    timerClassArray[3] = this.CtrlProgramsOpts[index1].ListEventsMonth;
                    timerClassArray[4] = this.CtrlProgramsOpts[index1].ListEventsWeek;
                    timerClassArray[5] = this.CtrlProgramsOpts[index1].ListEventsDay;
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
            return json.ToString();
        }
    }
}
