using UnityEngine;
using System.Collections;
using System;
using time; //todo fix this 
using System.Reflection;

namespace basil.util
{

public static class ExtDateTime
{
    static bool dump = true;

static ExtDateTime()
{
 dump = U.extensionsDump;
 U.Log(MethodBase.GetCurrentMethod().DeclaringType.Name +"\t dumping :"+ dump );
}
    
    private static readonly DateTime 
epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);





    public static DateTime  ConvertFromUnixTimestamp(this DateTime dt, double timestamp)
{
    return epoch.AddSeconds(timestamp);
}




    public static double  ConvertToUnixTimestamp(this DateTime dt)
{
        TimeSpan diff = dt.ToUniversalTime() - epoch;
        return Math.Floor(diff.TotalSeconds);
}


public static TimeSpan SinceEpoch(this DateTime dt) 
{
    return   dt - epoch;
}


public static TimeSpan SinceAD(this DateTime dt) 
{
    return DateTime.MinValue - dt ;
}

        // allow for pain free comparison of DateTimes
        // return a stamp for the previous "top of the hour"
        public static DateTime PreviousHour(this DateTime dt)
        {   
        
           DateTime dtNew = dt.AddSeconds(- dt.Second);
                    dtNew = dtNew.AddMinutes(- dtNew.Minute);
          
            return dtNew;
        } 
        
    
        // allow for pain free comparison of DateTimes
        public static DateTime Neuter(this DateTime dt)
        {   
        
           DateTime dtNew = dt.AddTicks(-(dt.Ticks % 10000000));
            return dtNew;
        }
    
    


        public static string Dump (this DateTime dt)
        { 

            string s = 
             "\t H:" + dt.Hour
           + "\t M:" + dt.Minute
           + "\t S:" + dt.Second
           + "\t Y:" + dt.Year
           + "\t M:" + dt.Month
           + "\t D:" + dt.Day
           + "\t Dw" + dt.DayOfWeek
           + "\t Dy" + dt.DayOfYear
           + "\t M:" + dt.Millisecond
           + "\t T:" + dt.Ticks

           
           ;
            return s;

        }
    
    
    
    
    
    
    
    }
}