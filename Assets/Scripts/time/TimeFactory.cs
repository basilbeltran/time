using System;
using System.Diagnostics;

using UnityEngine;

using basil.patterns;
using basil.util;

[AddComponentMenu("Singletons/TimeFactory")]
public  class TimeFactory : Singleton<TimeFactory>
{
    public static bool dump = true;
    public static readonly DateTime startDateTime = DateTime.Now;

    public static void 
       SingletonAwake()
    {
        string me = " SingletonAwake called ";
        if (dump) UnityEngine.Debug.Log(me);
    }




    //the distance of an event from the start position of the day 
    public static float MidnightOffset(DateTime dt)  // Z offset midnight to dt
    {
        return (float)(SecsSinceMidnight(dt) * EtcMgr.secondDepthZ );

    }

    public static string t()             //  start
    {
        string s = "* ";
        return s += DateTime.Now.ToLongTimeString();
    }

    public static DateTime StartTime()             //  start
    {
        return startDateTime;
    }

    public static int StartTimeSec()             //  start
    {
        return SecsSinceMidnight(startDateTime);
    }

    public static int RunTimeSecs()             // total seconds start to now
    {
        return Mathf.FloorToInt((float)DateTime.Now.Subtract(startDateTime).TotalSeconds); //total secs START to now

    }

    public static int RunTimeSecs(DateTime dt)  // total seconds start to dt
    {
        return Mathf.FloorToInt((float)dt.Subtract(startDateTime).TotalSeconds); //total secs  start to dt

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











    public static string Faster()
    {
        if (dump) UnityEngine.Debug.Log("static timescale " + Time.timeScale.ToString());

        Time.timeScale = Time.timeScale + .2f;
        return Time.timeScale.ToString();
    }

    public static string Slower()
    {

        Time.timeScale = Time.timeScale - .2f;
        if (dump) UnityEngine.Debug.Log("static timescale " + Time.timeScale.ToString());
        return Time.timeScale.ToString();
    }

    public static string Normal()
    {

        Time.timeScale = 1;
        if (dump) UnityEngine.Debug.Log("static timescale " + Time.timeScale.ToString());

        return Time.timeScale.ToString();
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
                              + "\n RunTimeSecs() = " + RunTimeSecs()
                              + "\n MidnightSecs() = " + MidnightSecs()
                              + "\n MidnightOffset(now) = " + MidnightOffset(DateTime.Now)
                              + "\n ToString " + dt.ToString() 
                             );
    }

 


}
