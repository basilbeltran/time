using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using basil.patterns;

[AddComponentMenu("Singletons/EtcMgr")]
public class EtcMgr : Singleton<EtcMgr>
{
    protected EtcMgr() { }


    public static float dayDepthZ = hourDepthZ * 24;
    public static float hourDepthZ = 4;                    //  1
    public static float minuteDepthZ = hourDepthZ / 60;    // .016666666 when hourDepthZ = 1
    public static float secondDepthZ = minuteDepthZ / 60; //  .000277777 when hourDepthZ = 1

    public static int secondsInMinute = 60;
    public static int minutesInHour = 60;
    public static int hoursInDay = 24;
    public static int minutesInDay = minutesInHour * hoursInDay;
    public static int secondsInDay = secondsInMinute * minutesInHour * hoursInDay;

    public static int spacerX = 10; 


    public static float
        daysToDegrees = 360f / 365f,
        hoursToDegrees = 360f / 12f,   // each hour, the hour hand moves 1/12 of a circle 360 = 30 degrees
        minutesToDegrees = 360f / 60f, // each minute, the minute hand moves 1/60 of a circle = 6 degrees
        secondsToDegrees = 360f / 60f; // each second, the second hand moves 1/60 of a circle= 6 degrees

        
        
        // A single tick represents one hundred nanoseconds or one ten-millionth of a second.
        // There are 10,000 ticks in a millisecond.
        public enum TimeType  // highest order
        {
            TickType, 
            MSecondType, 
            SecondType,
            MinuteType, 
            HourType, 
            DayType, 
            YearType
        };


    public static void SystemCheck(){
        //TODO:
    }
    
            public static Quaternion getRotationSeconds(DateTime dt)
        {
            return Quaternion.Euler(0f, 0f, dt.Second * -EtcMgr.secondsToDegrees);
        }

        public static Quaternion getRotationMinute(DateTime dt)
        {
            return Quaternion.Euler(0f, 0f, dt.Minute * -EtcMgr.minutesToDegrees);
        }
        
        public static Quaternion getRotationHour(DateTime dt)
        {
            return Quaternion.Euler(0f, 0f, dt.Minute * -EtcMgr.minutesToDegrees);
        }


        public static Quaternion getRotationDay(DateTime dt)
        {
            return Quaternion.Euler(0f, 0f, dt.DayOfYear * -EtcMgr.daysToDegrees);
        }
     

        public static Vector3 getPosition(DateTime dt)
        {
            return new Vector3(0, 0, -TMsingleton.SecsSinceMidnight(dt) * EtcMgr.secondDepthZ);
        }  

}
