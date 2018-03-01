using System;
using System.Diagnostics;

using UnityEngine;

using basil.patterns;
using basil.util;

[AddComponentMenu("Singletons/TMsingleton")]
public class TMsingleton : Singleton<TMsingleton>
{


    public static  DateTime gmStart;
    



    public static string TimeString()             //  start
    {
        return  DateTime.Now.ToLongTimeString();
    }

    public static DateTime StartTime()             //  start
    {
        return gmStart;
    }

    public static int StartTimeSec()             //  start in seconds from last midnight
    {
        return SecsSinceMidnight(gmStart);
    }



    public static int RunTimeMillis()             // total seconds start to now
    {
        return RunTime().Milliseconds; 
    }
    
    
    
    public static TimeSpan RunTime()             // total seconds start to now
    {
        return  RunTime( DateTime.Now );
    }

    public static TimeSpan RunTime(DateTime dt)  // total seconds start to dateTime
    {
       return ElapsedMeth(gmStart, dt);
    }






    public static int MidnightSecs()    // total seconds midnight to now
    {
        return Mathf.FloorToInt((float)DateTime.Now.Subtract(DateTime.Today).TotalSeconds);

    }

    public static int SecsSinceMidnight(DateTime dt)  // total seconds midnight to dt
    {
        return Mathf.FloorToInt((float)dt.Subtract(DateTime.Today).TotalSeconds); 

    }

    public static int ADSecs() // total seconds AD to now
    {
        return Mathf.FloorToInt((float)DateTime.Now.Subtract(DateTime.MinValue).TotalSeconds); //total secs  AD TO START

    }

    public static int ADSecs(DateTime dt) // total seconds AD to stamp
    {
        return Mathf.FloorToInt((float)dt.Subtract(DateTime.MinValue).TotalSeconds); //total secs  AD TO START

    }



    public static void NowValues()
    {
        DateTime dt = DateTime.Now;

        U.Log("\n Date = " + dt.Date
                              + "\n Day = " + dt.Day
                              + "\n DayOfWeek = " + dt.DayOfWeek
                              + "\n DayOfYear = " + dt.DayOfYear
                              + "\n Hour = " + dt.Hour
                              + "\n Minute = " + dt.Minute
                              + "\n Second = " + dt.Second
                              + "\n TimeOfDay = " + dt.TimeOfDay
                              + "\n TimeOfDay = " + dt.TimeOfDay
                              + "\n ToLongTimeString = " + dt.ToLongTimeString()
                              + "\n ToShortTimeString = " + dt.ToShortTimeString()
                              + "***********************"
                              + "\n StartTimeSec() = " + StartTimeSec()
                              + "\n RunTimeMillis() = " + RunTimeMillis()
                              + "\n MidnightSecs() = " + MidnightSecs()
                              + "\n MidnightOffset(now) = " + UTMsingleton.MidnightOffset(DateTime.Now)
                              + "\n ToString " + dt.ToString() 
                             );
    }



    static int toInt(float f)
    {
        return Mathf.FloorToInt(f);
    }


//NB: the end follows the beginning, except in the calculation
        public static TimeSpan 
ElapsedMeth(DateTime from, DateTime to){ return to - from; }


        public static double 
ElapsedDblMeth(DateTime from, DateTime to) { return (to - from).TotalSeconds; }

        
        public static Func<DateTime, DateTime, double> 
ElapsedDblFunc = (from , to ) => (to - from).TotalSeconds;


        public static Func<DateTime, DateTime, TimeSpan>
ElapsedFunc = (from , to ) => (to - from);

}
