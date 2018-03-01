using System;
using System.Diagnostics;

using UnityEngine;

using basil.patterns;
using basil.util;

[AddComponentMenu("Singletons/UnityTimeSingleton")]
public class UTMsingleton : Singleton<UTMsingleton>
{



    //the distance of an event from the start position of the day 
    public static float MidnightOffset(DateTime dt)  // Z offset midnight to dt
    {
        return (float)(TMsingleton.SecsSinceMidnight(dt) * EtcMgr.secondDepthZ );

    }

    public static string Faster()
    {
        if (Instance.dump) UnityEngine.Debug.Log("static timescale " + Time.timeScale.ToString());

        Time.timeScale = Time.timeScale + .2f;
        return Time.timeScale.ToString();
    }

    public static string Slower()
    {

        Time.timeScale = Time.timeScale - .2f;
        if (Instance.dump) UnityEngine.Debug.Log("static timescale " + Time.timeScale.ToString());
        return Time.timeScale.ToString();
    }

    public static string Normal()
    {

        Time.timeScale = 1;
        if (Instance.dump) UnityEngine.Debug.Log("static timescale " + Time.timeScale.ToString());

        return Time.timeScale.ToString();
    }



}
