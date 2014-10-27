using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.ObjectModel;

namespace ManufactureMonitor.Entity
{
    public class Shift
    {
        public int ID { get; set; }
        public string Name { get; set; }
        DateTime startTime;
        public string StartTime
        {
            get { return startTime.ToString(); }
            set
            {
                if (value == String.Empty)
                {

                }
                else
                {
                    try
                    {
                        startTime = DateTime.Parse(value);

                    }
                    catch (Exception e)
                    {
                        return;
                    }
                }
            }
        }

        DateTime endTime;
        public string EndTime
        {
            get { return endTime.ToString(); }
            set
            {
                if (value == String.Empty)
                {

                }
                else
                {
                    try
                    {
                        endTime = DateTime.Parse(value);
                    }
                    catch (Exception e)
                    {
                        return;
                    }
                }
            }
        }

        public SessionCollection Sessions;

        public SessionCollection Breaks;

        Boolean Sunday = false;
        Boolean Monday = false;
        Boolean Tuesday = false;
        Boolean Wednesday = false;
        Boolean Thursday = false;
        Boolean Friday = false;
        Boolean Saturday = false;

        public bool IsActive = false;


        public Shift()
        {
        }

        public Shift(int id, string description, string startTime, string endTime)
        {
            ID = id;
            Name = description;
            StartTime = startTime;
            EndTime = endTime;
            Sessions = new SessionCollection();



        }


        public Shift(int id, string description, DateTime startTime, DateTime endTime)
        {
            ID = id;
            Name = description;
            this.startTime = startTime;
            this.endTime = endTime;




        }

        public Shift(int id, string description, DateTime startTime, DateTime endTime,
            Boolean sunday, Boolean monday, Boolean tuesday, Boolean wednesday, Boolean thursday, Boolean friday,
            Boolean saturday)
        {
            ID = id;
            Name = description;
            this.startTime = startTime;
            this.endTime = endTime;
            Sunday = sunday;
            Monday = monday;
            Tuesday = tuesday;
            Wednesday = wednesday;
            Thursday = thursday;
            Friday = friday;
            Saturday = saturday;

            switch (DateTime.Now.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    IsActive = Sunday;
                    break;
                case DayOfWeek.Monday:
                    IsActive = Monday;
                    break;
                case DayOfWeek.Tuesday:
                    IsActive = Tuesday;
                    break;
                case DayOfWeek.Wednesday:
                    IsActive = Wednesday;
                    break;
                case DayOfWeek.Thursday:
                    IsActive = Thursday;
                    break;
                case DayOfWeek.Friday:
                    IsActive = Friday;
                    break;

                case DayOfWeek.Saturday:
                    IsActive = Saturday;
                    break;
            }


        }

        public Shift(String from, string to)
        {
            StartTime = from;
            EndTime = to;
        }

        public Session getSession(DateTime time)
        {
            foreach (Session s in Sessions)
            {
                if (s.IsWithin(time) == true)
                    return s;
            }
            return null;
        }

        public double getSessionDuration(Session s)
        {
            double duration = s.getDuration();
            foreach (Session b in Breaks)
            {
                if (IsWithin(b, s))
                    duration -= b.getDuration();
            }
            return duration;
        }
        

        public bool inBreak()
        {

            foreach (Session s in Breaks)
            {
                if (s.IsWithin(DateTime.Now) == true)
                    return true;
            }
            return false;
        }

        public bool IsWithin(DateTime ts)
        {
            DateTime start = startTime;
            DateTime end = endTime;


            if (end.TimeOfDay < startTime.TimeOfDay)
            {
                if ((ts.TimeOfDay <= startTime.TimeOfDay) && ts.TimeOfDay < endTime.TimeOfDay)
                    return true;
                else if ((ts.TimeOfDay >= startTime.TimeOfDay) && ts.TimeOfDay > endTime.TimeOfDay)
                    return true;
                return false;
            }

            if ((ts.TimeOfDay >= startTime.TimeOfDay) && ts.TimeOfDay < endTime.TimeOfDay)
                return true;
            return false;



            //DateTime currentTime = new DateTime(endTime.Year, endTime.Month, endTime.Day, ts.Hour, ts.Minute, ts.Second);

            //if (currentTime < endTime)
            //    return true;
            //else return false;


        }

        public bool IsWithin(Session s1, Session s2)
        {
           if( DateTime.Parse(s1.StartTime) >= DateTime.Parse(s2.StartTime) && 
               DateTime.Parse(s1.EndTime) <= DateTime.Parse(s2.EndTime))
           {
               return true;
           }
           else return false;

        }


       //public double getActiveDuration(DateTime start , DateTime end )
       //{
       //    double duration = (end -start).TotalSeconds;

       //    foreach(Session b in Breaks)
       //    {
       //        if( b.IsWithin(start) )
       //        {
       //            DateTime temp = DateTime.Parse(b.StartTime);

       //            DateTime breakStart = new DateTime(start.Year,start.Month,start.Day,temp.Hour,temp.Minute,temp.Second);
       //            duration -= breakStart - start 

            //DateTime currentTime = new DateTime(endTime.Year, endTime.Month, endTime.Day, ts.Hour, ts.Minute, ts.Second);

            //if (currentTime < endTime)
            //    return true;
            //else return false;


        

        public override string ToString()
        {
            return startTime.ToString("HH:mm");
        }

    }

    public class ShiftCollection : ObservableCollection<Shift>
    {
        public List<Shift> getShifts(DateTime time)
        {
            List<Shift> shiftList = new List<Shift>();
            IEnumerator<Shift> enumerator = this.GetEnumerator();

            while (enumerator.MoveNext())
            {
                if (enumerator.Current.IsWithin(time))
                {
                    shiftList.Add(enumerator.Current);
                }

            }
            return shiftList;
        }
        public Shift getCurrentShift()
        {

            IEnumerator<Shift> enumerator = this.GetEnumerator();

            while (enumerator.MoveNext())
            {
                if (enumerator.Current.IsWithin(DateTime.Now))
                {
                    return enumerator.Current;

                }

            }
            return null;

        }





        public Shift getShift(DateTime from, DateTime to)
        {
            IEnumerator<Shift> enumerator = this.GetEnumerator();

            while (enumerator.MoveNext())
            {
                if (enumerator.Current.IsWithin(from) )
                {
                    return enumerator.Current;

                }

            }
            return null;
        }
    }



    public class shiftInfo
    {
        public string Name { get; set; }

        public string StartTime { get; set; }
        public string EndTime { get; set; }


        public shiftInfo()
        {
        }
    }
}