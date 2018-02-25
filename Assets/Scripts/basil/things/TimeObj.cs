using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using basil.util;

namespace basil.things
{
    //an object class representing A POINT IN TIME, a DateTime based collection
    //of Transforms representing notions of time visually (minutes, hours)
    // beginning at the DateTime of this point
    public class TimeObj : BasicBehaviour 
    {
    
         public bool dump = false;
        // the object members of a TimeObj...
        
         public DateTime m_Date;
         public double m_Secs;
         public double m_EpochSecs;
         public Transform m_Transform; 
         public Dictionary<EtcMgr.TimeType, Transform> m_GameObjects; 
         public Dictionary<EventType, Event> m_Events;
         public Dictionary<System.Object, TimeObj> m_Contacts;
         public EtcMgr.TimeType m_TimeType;
        
         public Dictionary<int, TimeObjSecond> m_Seconds; 
         public Dictionary<int, TimeObjMinute> m_Minutes;
         public Dictionary<int, TimeObjHour> m_Hours;

         public TimeObjSecond tos;
         public GameObject Second = null;
         
         public TimeObjMinute tom;
         public GameObject Minute = null;   //Me
          
         
         public GameObject Hour = null; 
         public TimeObjHour toh;

         public GameObject Day = null;
         public TimeObjDay tod;         
         
         public GameObject Week = null;
         public GameObject Month = null;
         public GameObject Year = null; 
             
        public bool isSecond, isMinute, isHour, isDay, isWeek, isMonth, isYear = false;
        TimeObjFactory tof;
        Transform deferredParent; 

        
       public  enum EventType
        {
            LocalDevice, LocalApp 

        };
                              
               
        //making a timeObj that manages this slice of time
        public TimeObj(DateTime dt, TimeObjFactory tof)
        {  
            this.tof = tof;
                        
            m_Date = dt;  //make key useful ... Remove for micro usefullnes
            m_Secs = TimeFactory.SecsSinceMidnight(dt);
            m_EpochSecs = dt.ConvertToUnixTimestamp();
            
            //m_GameObjects = new Dictionary <EtcMgr.TimeType, Transform>();
            //m_Events = new Dictionary <EventType, Event>();
            //m_Contacts = new Dictionary <object, TimeObj>();
            
            if (dump) U.Log(Dump());            
        }
        
        
        //making a timeObj that manages all time
        public TimeObj(DateTime dt)
        {  
                        
            m_Date = dt; 
            m_Secs = TimeFactory.SecsSinceMidnight(dt);
            m_EpochSecs = dt.ConvertToUnixTimestamp();
        }
        
        
        

        //Delegated implementation
        public void OnSecond(DateTime dt)
        {
           U.Log("timeObject recieved OnSecond from: "+ dt.ToString() );
            if (Minute)
            {
                tom.InflateMySeconds();
                tom.DeflatePrior();
            }
        }
        
        
        // Top Down implementation          //public Dictionary<EventType, Event>  Shine()
        //this GameObject second has matched the current (or selected) time. is in focus
        // Called from Message Mgr on DateTime Now match
        public void Shine()
        {                  
            // this TimeObject has a minute instantiated
            if (Minute)
            {
              U.Log("InflateMySeconds " + Dump() );                   
                tom.InflateMySeconds();
                tom.DeflatePrior();                //Deflate the prior set of sec
            }
            //return m_Events;
        }
 
 
 
 
 
        
          public string Dump()
        {
            string s = "\n TO:";

            s += "\n "+ m_Date.ToString();
            s += "  " + m_Secs.ToString();
            s += "  " + m_EpochSecs.ToString();
            //s += " "  + m_TimeType;
            //s += "\n " + m_GameObjects.DumpKeys();
            //s += "\n "+ m_Events;
            //s += "\n "+ m_Contacts;
       if(dump) U.Log(s);

         return s;
        }
        
        
        
         public Transform MakeFaces(DateTime _dt)
        {
        

            //identifying the "top of the day/hour/minute." Only one condition will be met.
            
            //the first condition appears once a day, but not be created yet
            if (_dt.Hour == 0 && _dt.Minute == 0 && _dt.Second == 0)   
                        { m_TimeType = EtcMgr.TimeType.DayType; 
                            m_Transform = MakeMyDay();
                        //  m_Transform = MakeMyDay(false);

                            return m_Transform; 
                           }
          
            // in the first hour dt.hour == 0 60 times, subsequent "tops" occur at every...
            if (_dt.Minute == 0 && _dt.Second == 0) 
                        { m_TimeType = EtcMgr.TimeType.HourType; 
                        m_Transform = MakeMyHour();

                return m_Transform;
                         }
            
            //this will occcur every minute
            if (_dt.Second == 0) 
                        { m_TimeType = EtcMgr.TimeType.MinuteType; 
                        m_Transform = MakeMyMinute();
                       Minute  = m_Transform.gameObject;
                        return m_Transform;
                         }
                         

            

            return null;
        }


        public Transform MakeMyDay(bool tf)
        {
            isDay = true;
            tod = new TimeObjDay(m_Date,  MessageMgr.Instance.gameRoot,  this, tf);
            return tod.dGo.transform;
        }


    
          Transform  MakeMyDay()
          {
            isDay = true;
            tod = new TimeObjDay(m_Date,  tof.dayParent,  this, false);
            tof.hourParent = tod.dGo.transform;
            return tod.dGo.transform;
          }                 
               
               
               
        Transform MakeMyHour()
                {
            isHour = true;
            if (tof.hourParent == null) MakeMyDay(false);
            toh = new TimeObjHour(m_Date,  tof.hourParent,  this, false);
            tof.minuteParent = toh.hGo.transform;
            return toh.hGo.transform;
                }

        Transform MakeMyMinute()
        {
            if (tof.minuteParent == null) MakeMyHour();
            tom = new TimeObjMinute(m_Date,  tof.minuteParent,  this, false);
            isMinute = true;
            tof.secondParent = tom.mGo.transform;
            return tom.mGo.transform;
        } 
    
    ///****************************///****************************///****************************            
//       Transform MakeMyMinute()
//                {
//                if (tof.minuteParent == null) MakeMyHour();
//                    isMinute = true;
//                    tof.minuteNumber++;
//                     Transform _t = Transform.Instantiate(MessageMgr.Instance.minute,
//                                                 getPosition(),
//                                                 getRotationMinute(),
//                                                 tof.minuteParent) as Transform;

//            //let the MonoBehaviour know where it is
//            MinuteHolderBe b = _t.gameObject.GetComponent<MinuteHolderBe>();
//                      b.Register(this);
//            U.Log( " minute made " + b.timeObject.m_Date.Dump() );
                      
//                      _t.gameObject.name = "M" + m_Date.Minute;
////tof.secondParent = _t;
                        
                //        // associate minutes with layer
                //        _t.gameObject.GetFirstChild().layer = 9;
                        
                //        //represent the minute aspect of this timeObject
                //        Minute = _t.gameObject;
                        

                //return _t;
                //}
                
                
               
    //Transform  MakeMySecond()
       //  {
       //            deferredParent = tof.secondParent; // stash this 

       //       //this could(NOT) be the entry point so (whatever) handle by evaluating parent 
       //      if (tof.hourParent == null ||
       //         tof.minuteParent == null ||
       //         tof.secondParent ==null) {
       //         throw new Exception("not prepared for random starts");
       //         }//MakeMyDay(); // we assUme there is no Hour or Minute  


       //     if (!tof.deferSeconds && !isSecond)
       //     {
       //         MakeTheSecondAllready();
       //     }
       // return null;    
       //}


        // Transform MakeTheSecondAllready()
        //{
        //                  U.Log(" MakeTheSecondAllready  " + deferredParent.gameObject.name);

        //        isSecond = true;

        //        Transform _t = Transform.Instantiate(MessageMgr.Instance.second,
        //                    getPosition(),
        //                    getRotationSeconds(m_Date),
        //                    getSecondParent()  ) as Transform;

        //        _t.gameObject.name = "S" + m_Date.Second;
        //        _t.gameObject.GetFirstChild().layer = 8;
        //        tof.secondNumber++;
        //        Second = _t.gameObject;
        //        Second.GetComponent<Me>().ShowMe();
        //                //Second.GetComponent<Me>().Register(this);
        //        return _t;
        //}

        //Transform getSecondParent()
        //{
        //    // TimeObj to = MakeTime.timeObjDictionary[m_Date];
        //   return deferredParent;
        //}       
            
        static Quaternion getRotationSeconds(DateTime dt)
        {
            return Quaternion.Euler(0f, 0f, dt.Second * -EtcMgr.secondsToDegrees);
        }

        Quaternion getRotationMinute()
        {
            return Quaternion.Euler(0f, 0f, m_Date.Minute * -EtcMgr.minutesToDegrees);
        }
        
        Quaternion getRotationHour()
        {
            return Quaternion.Euler(0f, 0f, m_Date.Minute * -EtcMgr.minutesToDegrees);
        }


        Quaternion getRotationDay()
        {
            return Quaternion.Euler(0f, 0f, m_Date.DayOfYear * -EtcMgr.daysToDegrees);
        }
        
        

        public Vector3 getPosition()
        {
            return new Vector3(0, 0, -TimeFactory.SecsSinceMidnight(m_Date) * EtcMgr.secondDepthZ);
        }    
        
        
        
        
        void DoByTimeType(DateTime dt)
        {
            switch (m_TimeType)
            {
                case (EtcMgr.TimeType.SecondType):
                    
                    break;
                case (EtcMgr.TimeType.MinuteType):

                    break;
                case (EtcMgr.TimeType.HourType):
                    
                    break;

                case (EtcMgr.TimeType.DayType):

                    break;
            } 
        }




        public double ADsecs
        {
            get
            {
                return m_Secs;
            }
            set
            {
                m_Secs = value;
            }
        }

        public DateTime Date
        {
            get
            {
                return m_Date;
            }
            set
            {
                m_Date = value;
            }
        }

        public Transform Go
        {
            get
            {
                return m_Transform;
            }
            set
            {
                m_Transform = value;
            }
        }

        public Dictionary<EventType, UnityEngine.Event> Events
        {
            get
            {
                return Events;
            }
            set
            {
                Events = value;
            }
        }



    }//class
}//name



