using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using AUA.ProjectName.Common.Consts;

namespace AUA.ProjectName.Common.Extensions
{
    public static class DateTimeExtension
    {

        public static string ToPersianDate(this DateTime date)
        {
            if (date == DateTime.MinValue || date == DateTime.MaxValue)
                return "";
            var persianCalendar = new PersianCalendar();
            return ToPersianDate(persianCalendar.GetYear(date), persianCalendar.GetMonth(date), persianCalendar.GetDayOfMonth(date));
        }


        public static string ToPersianDateTime(this DateTime date, bool showSecond = true)
        {
            try
            {
                var persianCalendar = new PersianCalendar();
                return
                    $"{(object)DateTimeExtension.ToPersianDate(persianCalendar.GetYear(date), persianCalendar.GetMonth(date), persianCalendar.GetDayOfMonth(date))} ({(object)date.ToShortTimeString(showSecond)})";
            }
            catch
            {
                return "";
            }
        }

        public static string ToShortTimeString(this DateTime date, bool showSecond = false)
        {
            PersianCalendar persianCalendar = new PersianCalendar();
            string str = string.Format("{0:d2}:{1:d2}", (object)persianCalendar.GetHour(date), (object)persianCalendar.GetMinute(date));
            return showSecond ? string.Format("{0}:{1:d2}", (object)str, (object)persianCalendar.GetSecond(date)) : str;
        }



        public static DateTime ToGregorianDateTime(this string persianDate)
        {
            if (string.IsNullOrEmpty(persianDate))
                return DateTime.MinValue;

            var strArray = persianDate.Trim().Split(AppConsts.SplitDateTimeChar,
                                                    StringSplitOptions.RemoveEmptyEntries);

            var year = int.Parse(strArray[0].Trim());
            var month = int.Parse(strArray[1].Trim());
            var day = int.Parse(strArray[2].Trim());


            if (strArray.Length <= 3)
                return new PersianCalendar().ToDateTime(year, month, day, 0, 0, 0, 0);

            var hour = int.Parse(strArray[3].Replace("(", "").Trim());
            var minute = int.Parse(strArray[4].Trim());
            var second = int.Parse(strArray[5].Trim());

            return new PersianCalendar().ToDateTime(year, month, day, hour, minute, second, 0);
        }



        public static DateTime ToDateTime(this string persianDate)
        {
            var persianCalendar = new PersianCalendar();
            var strArray = persianDate.Split(AppConsts.SplitDateTimeChar, StringSplitOptions.RemoveEmptyEntries);
            var year = int.Parse(strArray[0]);
            var month = int.Parse(strArray[1]);
            var day = int.Parse(strArray[2]);


            return persianCalendar.ToDateTime(year, month, day, 0, 0, 0, 0);
        }



        public static string ToPersianDate(int persianYear, int persianMonth, int persianDay)
        {
            return string.Format("{0:d2}/{1:d2}/{2:d2}", (object)persianYear, (object)persianMonth, (object)persianDay);
        }



        public static DateTime GetFirstDayOfPersianYear(int persianYear)
        {
            return DateTimeExtension.ToPersianDate(persianYear, 1, 1).ToGregorianDateTime();
        }


        public static DateTime GetLastDayOfPersianYear(this DateTime dateTime)
        {
            return DateTimeExtension.GetLastDayOfPersianYear(dateTime.GetPersianYear());
        }

        public static DateTime GetLastDayOfPersianYear(int persianYear)
        {
            PersianCalendar persianCalendar = new PersianCalendar();
            int year = persianYear + 1;
            DateTime dateTime = persianCalendar.ToDateTime(year, 1, 1, 0, 0, 0, 0);
            return persianCalendar.AddMilliseconds(dateTime, -1.0);
        }




        public static int CountDays(this DateTime start, DateTime end, DayOfWeek[] daysOfWeek)
        {
            return Enumerable.Range(0, end.Subtract(start).Days + 1).Select<int, DateTime>((Func<int, DateTime>)(i => start.AddDays((double)i))).Count<DateTime>((Func<DateTime, bool>)(d => ((IEnumerable<DayOfWeek>)daysOfWeek).Contains<DayOfWeek>(d.DayOfWeek)));
        }

        public static bool IsHatchingDay(this DateTime hatchDate)
        {
            return hatchDate.DayOfWeek != DayOfWeek.Monday && hatchDate.DayOfWeek != DayOfWeek.Thursday && hatchDate.DayOfWeek != DayOfWeek.Friday;
        }

        public static int HatchDaysCount(this DateTime fromDate, DateTime toDate)
        {
            return fromDate.CountDays(toDate, new DayOfWeek[4]
            {
        DayOfWeek.Saturday,
        DayOfWeek.Sunday,
        DayOfWeek.Tuesday,
        DayOfWeek.Wednesday
            });
        }


        private static string GetDayOfMonthText(int dayOfMonth)
        {
            switch (dayOfMonth)
            {
                case 1:
                    return "یکم";
                case 2:
                    return "دوم";
                case 3:
                    return "سوم";
                case 4:
                    return "چهارم";
                case 5:
                    return "پنجم";
                case 6:
                    return "ششم";
                case 7:
                    return "هفتم";
                case 8:
                    return "هشتم";
                case 9:
                    return "نهم";
                case 10:
                    return "دهم";
                case 11:
                    return "یازدهم";
                case 12:
                    return "دوازدهم";
                case 13:
                    return "سیزدهم";
                case 14:
                    return "چهاردهم";
                case 15:
                    return "پانزدهم";
                case 16:
                    return "شانزدهم";
                case 17:
                    return "هفدهم";
                case 18:
                    return "هجدهم";
                case 19:
                    return "نوزدهم";
                case 20:
                    return "بیستم";
                case 30:
                    return "سی ام";
                default:
                    return string.Format("{0} ام", (object)dayOfMonth);
            }
        }

        private static string GetDayOfWeekText(DayOfWeek dayOfWeek)
        {
            switch (dayOfWeek)
            {
                case DayOfWeek.Sunday:
                    return "یکشنبه";
                case DayOfWeek.Monday:
                    return "دوشنبه";
                case DayOfWeek.Tuesday:
                    return "سه شنبه";
                case DayOfWeek.Wednesday:
                    return "چهارشنبه";
                case DayOfWeek.Thursday:
                    return "پنجشنبه";
                case DayOfWeek.Friday:
                    return "جمعه";
                case DayOfWeek.Saturday:
                    return "شنبه";
                default:
                    return "";
            }
        }

        public static string TodayPersian
        {
            get
            {
                return DateTime.Now.ToShortPersianDate();
            }
        }

        public static string GetPersianDayOfWeek(this DayOfWeek dayOfWeek)
        {
            switch (dayOfWeek)
            {
                case DayOfWeek.Sunday:
                    return "یکشنبه";
                case DayOfWeek.Monday:
                    return "دوشنبه";
                case DayOfWeek.Tuesday:
                    return "سه شنبه";
                case DayOfWeek.Wednesday:
                    return "چهارشنبه";
                case DayOfWeek.Thursday:
                    return "پنج شنبه";
                case DayOfWeek.Saturday:
                    return "شنبه";
                default:
                    return "جمعه";
            }
        }

        public static string GetPersianPastTime(this DateTime datetime)
        {
            DateTime now = DateTime.Now;
            if (now.Year != datetime.Year)
                return string.Format("{0} سال", (object)(now.Year - datetime.Year));
            if (now.Month != datetime.Month)
                return string.Format("{0} ماه", (object)(now.Month - datetime.Month));
            if (now.Day != datetime.Day && (double)(now.Day - datetime.Day) % 7.0 == 0.0)
                return string.Format("{0} هفته", (object)((now.Day - datetime.Day) / 7));
            if (now.Day != datetime.Day)
                return string.Format("{0} روز", (object)(now.Day - datetime.Day));
            if (now.Hour != datetime.Hour)
                return string.Format("{0} ساعت", (object)(now.Hour - datetime.Hour));
            if (now.Minute != datetime.Minute)
                return string.Format("{0} دقیقه", (object)(now.Minute - datetime.Minute));
            return string.Format("{0} ثانیه", (object)(now.Second - datetime.Second == 0 ? 2 : now.Second - datetime.Second));
        }



        public static string ToShortPersianDate(this DateTime datetime)
        {
            PersianCalendar persianCalendar = new PersianCalendar();
            return string.Format("{0}/{1}/{2}", (object)persianCalendar.GetYear(datetime), (object)persianCalendar.GetMonth(datetime).ToString().PadLeft(2, '0'), (object)persianCalendar.GetDayOfMonth(datetime).ToString().PadLeft(2, '0'));
        }

        public static int GetPersianYear(this DateTime datetime)
        {
            return new PersianCalendar().GetYear(datetime);
        }


    }
}
