using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;
using basil.util;

//how to select objects with mouse
//saving state of collection (hours)
// generic animations (rotate x slowly)
// you can animate the position of your collider
// scripting animation

public class ClockWorks : MonoBehaviour
{
    bool v2 = true;
    Stopwatch s1, s2, s3, s4;

    DateTime choosen = DateTime.Now;
    public Transform hour, minute, second;
    public Transform clock;
    
    public bool dump = true;
    public bool run = false;
    public bool showSeconds = false;
    public bool showMinutes = false;
    public bool showHours = false;
    public bool showDays = true;

    public int firstPaint = 30000;
    public int loopSize = 10000;
    public bool daystart = true;
    public Transform panel;

    Transform clockHour, clockMinute, clockSecond;


    int secondsReceived =0;
    int secondsProcessed=0;

    Transform priorSecond = null;
    Transform priorMinute = null;
    Transform priorHour = null;
    Transform nextSecond;
    Transform nextMinute;
    Transform nextHour;



    ArrayList secondArray = new ArrayList();
    ArrayList minuteArray = new ArrayList();
    ArrayList hourArray = new ArrayList();
    ArrayList dayArray = new ArrayList();
    ArrayList yearArray = new ArrayList();





    double secToProcess = 0;            // seconds since 00:00:00 minus what have been processed with daystart
    double secInScript; // secs sseperate from Time.time which is "false" .... processed with drift

    SmartField st0; //mgrTime
    SmartField st1; //startTime 
    SmartField st2; //pntTime
    SmartField st3; //secSinceMidnight
    SmartField st4; //secToProcess
    SmartField st5; // Euler

    GameObject go0;
    GameObject go1;
    GameObject go2;
    GameObject go3;
    GameObject go4;
    GameObject go5;

    MessageMgr mess;
    GameObject root;
    DateTime lastProcessedStamp;

    void Awake()
    {   s1 = Stopwatch.StartNew();

        mess = MessageMgr.Instance;


        root = GameObject.FindGameObjectWithTag("GameController");


        clockHour = Instantiate(MessageMgr.Instance.hour, transform) as Transform;    //hour. minute . second prefabs
        clockMinute = Instantiate(MessageMgr.Instance.minute, transform) as Transform;
        clockSecond = Instantiate(MessageMgr.Instance.second, transform) as Transform;
        //TODO add mods to prefabs for clock
        clockSecond.gameObject.SetActive(true);


        //TODO instantiate these ... in a factory
        //fields in the UI
        go0 = panel.Find("Field0").gameObject;
        go1 = panel.Find("Field1").gameObject;
        go2 = panel.Find("Field2").gameObject;
        go3 = panel.Find("Field3").gameObject;
        go4 = panel.Find("Field4").gameObject;
        go5 = panel.Find("Field5").gameObject;
        st0 = go0.GetComponent<SmartField>();
        st1 = go1.GetComponent<SmartField>();
        st2 = go2.GetComponent<SmartField>();
        st3 = go3.GetComponent<SmartField>();
        st4 = go4.GetComponent<SmartField>();
        st5 = go5.GetComponent<SmartField>();


        //set camera to follow this
        //GameObject cam = GameObject.FindGameObjectWithTag("cam1");
        //CinemachineVirtualCamera camscript = cam.GetComponent<CinemachineVirtualCamera>();
        //camscript.m_Follow = transform;
        //camscript.m_LookAt = transform;



        s1.Stop();
        if (dump) UnityEngine.Debug.Log("Camera & UI Prepared in " +s1.ElapsedMilliseconds);

    }


    //void Start()
    //{   s2 = Stopwatch.StartNew();
    //    lastProcessedStamp = DateTime.Today;
    //   if(!v2) processSeconds(DateTime.Today, firstPaint);


    //    s2.Stop();
    //    if (dump) UnityEngine.Debug.Log("Painted "+secondsProcessed +" in "+ s2.ElapsedMilliseconds.ToString());
    //}

    void Update(){
        
    }

    public void OnAxisX(float x)
    {

        //if (x > 0) choosen = choosen.AddHours(1);
        //if (x < 0) choosen = choosen.AddHours(-1);
    }

    void OnAxisZ(float z)
    {


    }


    void OnSecond(DateTime now)
    {
            secondsReceived++;
            st2.setMe("secondsReceived", secondsReceived.ToString());
            st0.setMe("H-M-S", now.ToLongTimeString());
            st1.setMe("mid-now-sec", TimeFactory.MidnightSecs().ToString());


        if(daystart)secToProcess = TimeFactory.MidnightSecs() - secondsProcessed;

        if(run && secToProcess > 0){
            
            if (!v2)  processSeconds(lastProcessedStamp.AddSeconds(1), secToProcess > loopSize? loopSize : secToProcess );
            showStats();

        } else
        {
            if (run ) {

                SetClockCubes(now); 
            } 
        }
    }

    //high speed addition of already passed seconds
    DateTime processSeconds(DateTime start, double secs)
    {

        if (dump) UnityEngine.Debug.Log("Processing " + TimeFactory.SecsSinceMidnight(start) + " to "
                                        + TimeFactory.SecsSinceMidnight(start) + secs
                                       );

        for (double i = 0; i < secs; ++i) // ++i dont AddSecond for the first itteration
        {
            try
            {
                SetClockCubes(start.AddSeconds((int)i));

            }
            catch (Exception ex)
            {
                if (dump) U.Log(ex.ToString());
            }
        }
        return start.AddSeconds(secs);
    }


    void showStats()
    {
        if(dump)TimeFactory.NowValues();
        if (dump)UnityEngine.Debug.Log("\n secondsProcessed = " + secondsProcessed
                              + "\n secondsReceived= " + secondsReceived
                              + "\n remaining = " + (TimeFactory.MidnightSecs() - secondsProcessed)
                              + "\n lastProcessedSec "+ TimeFactory.SecsSinceMidnight(lastProcessedStamp)
                             );
    }


    // Unity uses a left-handed coordinate system, the rotation must be negative around the Z axis
    public void SetClockCubes(DateTime dt)
    {
        secondsProcessed++;
        lastProcessedStamp = dt;
        st3.setMe("Processed", secondsProcessed.ToString());
        //st6.setMe("pntTime", paintingTime.TimeOfDay.TotalSeconds.ToString());

        var d = dt.DayOfYear * -EtcMgr.daysToDegrees;
        var a = dt.Hour * -EtcMgr.hoursToDegrees;
        var b = dt.Minute * -EtcMgr.minutesToDegrees;
        var c = dt.Second * -EtcMgr.secondsToDegrees;


        clockHour.localRotation = Quaternion.Euler(0f, 0f, a);
        clockMinute.localRotation = Quaternion.Euler(0f, 0f, b);
        clockSecond.localRotation = Quaternion.Euler(0f, 0f, c);

        st5.setMe("Degrees", a.ToString()+" " + b.ToString() +" " + c.ToString());





        //make new hour 
        if (dt.Minute == 0 && dt.Second == 0)
        {

            // the next minute should be a child of the new hour
            priorMinute = null;



            if (priorHour)
            {
                nextHour = Instantiate(hour, clockHour.position, clockHour.rotation) as Transform;
                nextHour.transform.parent = root.transform;
            }
            else
            {
                nextHour = Instantiate(hour, clockHour.position, clockHour.rotation) as Transform;
                // if there is no prior top level time type, parent to the controller for messaging
                nextHour.transform.parent = root.transform;
            }



            priorHour = nextHour;


            if (hourArray == null) hourArray = new ArrayList();
            hourArray.Add(nextHour);

            if (!showHours) nextHour.gameObject.SetActive(false);

            MessageMgr.Instance.Yell("OnHour", dt);
        }




        //make new minute
        if (dt.Second == 0)
        {
            priorSecond = null; // next second will be a child of the new minute
            //transform.Translate(Vector3.back * TimeHeartBeat.minuteDepthZ);

            if (priorMinute)
            {
                nextMinute = Instantiate(minute, clockMinute.position, clockMinute.rotation, nextHour) as Transform;
                nextMinute.transform.parent = nextHour;            
            }
            else
            {
                nextMinute = Instantiate(minute, clockMinute.position, clockMinute.rotation, nextHour) as Transform;
                nextMinute.transform.parent = nextHour;
            }

            //for parenting
            priorMinute = nextMinute; 

            if (minuteArray == null) minuteArray = new ArrayList();
            minuteArray.Add(nextMinute);

            if (!showMinutes) nextMinute.gameObject.SetActive(false);

            //tell root to call all the kids
            MessageMgr.Instance.Yell("OnMinute", dt);
        }



        //always make new second
        //move this clock forward by the 

         transform.Translate(Vector3.back * EtcMgr.secondDepthZ);

        //paint UI
        st4.setMe("X-Y-Z", transform.position.ToString());

        if (priorSecond)  // parent each time type to the prior instance
        {
            nextSecond = Instantiate(second, clockSecond.position, clockSecond.rotation, nextMinute) as Transform;
            nextSecond.transform.parent = nextMinute;

        }
        else
        {
            // the first second is a child of the first minute
            nextSecond = Instantiate(second, clockSecond.position, clockSecond.rotation, nextMinute) as Transform;
            //      huh?          nextSecond = Instantiate(second, clockSecond.position + new Vector3(0, dt.Second / 60, 0), clockSecond.rotation, nextMinute) as Transform;
            //
            nextSecond.transform.parent = nextMinute;

            //add script to the the first second
            nextSecond.gameObject.AddComponent<TimeListener>();

        }

            
            priorSecond = nextSecond;

            //add new second to its array
            if (secondArray == null) secondArray = new ArrayList();
            secondArray.Add(nextSecond);

            if (!showSeconds) nextSecond.gameObject.SetActive(false);

        //if (dump)showStats();
    }



    double getMyDrift()
    {
        double runTime = DateTime.Now.Subtract(TimeFactory.StartTime()).TotalSeconds;  // "real" seconds
        double delta = runTime - secInScript;
        if (delta > 3)
        {
            secInScript = runTime;
            return delta;
        }
        else
        {
            secInScript = runTime;
            return 0;
        }

    }

    public void setTimeScale(float t){
        UnityEngine.Debug.Log("Setting timescale " + t.ToString());
        Time.timeScale = t;
    }


        void timeScaleInOut()
        {
            if (secToProcess > 1)
            {
            if (secToProcess > TimeFactory.MidnightSecs() / 2)
                {
                    Time.timeScale = Time.timeScale + .1f;
                }
                else
                {
                    Time.timeScale = Time.timeScale - .1f;
                }
            }
            else
            {
                daystart = false;
                Time.timeScale = 1;
            }

        if (dump) UnityEngine.Debug.Log(" Time.timeScale " + Time.timeScale);

        }





    public void ToggleSeconds(){
        if (dump) UnityEngine.Debug.Log(" ToggleSeconds" + !showSeconds);

        if (showSeconds)
        {
            
            foreach (Transform t in secondArray)
            {
                Transform tt = (Transform)t;

                tt.gameObject.SetActive(false);
            }
            showSeconds = false;
        }else{
           
            foreach (Transform t in secondArray)
            {
                t.gameObject.SetActive(true);
            }
            showSeconds = true;
        }
    }

    public void ToggleMinutes()
    {
        if (dump) UnityEngine.Debug.Log(" Minutes" + !showMinutes);

        if (showMinutes)
        {

            foreach (Transform t in minuteArray)
            {
                Transform tt = (Transform)t;

                tt.gameObject.SetActive(false);
            }
            showMinutes = false;
        }
        else
        {

            foreach (Transform t in minuteArray)
            {
                t.gameObject.SetActive(true);
            }
            showMinutes = true;
        }
    }

    public void ToggleHours()
    {
        if (dump) UnityEngine.Debug.Log(" Hours" + !showHours);

        if (showHours)
        {

            foreach (Transform t in hourArray)
            {
                Transform tt = (Transform)t;

                tt.gameObject.SetActive(false);
            }
            showHours = false;
        }
        else
        {

            foreach (Transform t in hourArray)
            {
                t.gameObject.SetActive(true);
            }
            showHours = true;
        }
    }


}// end


//Timer myTimer = new Timer();
//myTimer.Elapsed += new ElapsedEventHandler(EverySecond);
//myTimer.Interval = 1000; // 1000 ms is one second
//myTimer.Start();


//Transform cam2t = GameObject.FindGameObjectWithTag("cam2").transform;
//CinemachineVirtualCamera cam2 = new Cinemachine.CinemachineVirtualCamera();
//cam2.transform.parent = cam2t;
//cam2.m_Follow = clock;
//cam2.m_LookAt = clock;
//cam2.GetComponent<CinemachineTransposer>().m_FollowOffset = new Vector3(0, 0, 0);
//cam2.enabled = true;
