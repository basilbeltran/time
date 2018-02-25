using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using basil.util;

namespace basil.things
{
    //an object class representing a unit of time
    public class TimeObj 
    {
    
         public bool dump = true;
        // the object members of a TimeObj...
        [SerializeField] public DateTime m_Date;
        [SerializeField] public double m_Secs;
        [SerializeField] public Transform m_Transform; 
        [SerializeField] public Dictionary<TimeType, Transform> m_GameObjects; 
        [SerializeField] public Dictionary<EventType, Event> m_Events;
        [SerializeField] public Dictionary<System.Object, TimeObj> m_Contacts;
        [SerializeField] public TimeType m_TimeType;
        public bool isSecond, isMinute, isHour, isDay, isWeek, isMonth, isYear = false;


        // in linear parenting scheme hours hold subsequent hour, otherwise, days hold hours
        // this is for gameObject parenting. The Dictionary is flat and every entry is a second
        public static bool linear = false;         
        public static int secondNumber, minuteNumber, hourNumber,  dayNumber, monthNumber, yearNumber = 0;
        public static Transform dayParent =  MessageMgr.Instance.transform;
        public static Transform hourParent =  MessageMgr.Instance.transform;
        public static Transform minuteParent =  MessageMgr.Instance.transform; 
        public static Transform secondParent =  MessageMgr.Instance.transform;




        //making a timeObj that manages this slice of time
        public TimeObj(DateTime dt)
        {
            m_Date = dt;
            m_Secs = TimeFactory.SecsSinceMidnight(m_Date);
            m_GameObjects = new Dictionary <TimeType, Transform>();
            m_Transform = SetTimeTypes(m_Date);

         if(dump) U.Log("m_Secs  " + this.m_Secs 
                        + "secondNumber  " + secondNumber
                        + "secondParent  " + secondParent
                        );
        }



       public enum EventType
        {
            LocalDevice, LocalApp
        };
               

        //A single tick represents one hundred nanoseconds or one ten-millionth of a second.There are 10,000 ticks in a millisecond.
        public enum TimeType
        {
            TickType, MSecondType, SecondType,
            MinuteType, HourType, DayType, YearType
        };



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



        Transform SetTimeTypes(DateTime dt)
        {
            if (dt.Hour == 0)   { m_TimeType = TimeType.DayType;    return MakeMyDay(); }
            if (dt.Minute == 0) { m_TimeType = TimeType.HourType;   return MakeMyHour(); }
            if (dt.Second == 0) { m_TimeType = TimeType.MinuteType; return MakeMyMinute(); }
        
            return null;
        }


         Transform  MakeMyDay()
                {
                    isDay = true;
                     dayNumber++;
                     Transform _t = Transform.Instantiate(MessageMgr.Instance.day,
                                                 getPosition(),
                                                 getRotationDay(),
                                                 dayParent) as Transform;

                      _t.gameObject.name = "day" + dayNumber;
                      
                       m_GameObjects.Add( TimeType.HourType,   MakeMyHour() );
                       m_GameObjects.Add( TimeType.MinuteType, MakeMyMinute() );
                       m_GameObjects.Add( TimeType.SecondType, MakeMySecond() );

                hourParent = _t;
                return _t;
                }
                
                
                
                
        Transform MakeMyHour()
                {
                    isHour = true;
                     hourNumber++;
                     Transform _t = Transform.Instantiate(MessageMgr.Instance.hour,
                                                 getPosition(),
                                                 getRotationHour(),
                                                 m_Transform) as Transform;

                      _t.gameObject.name = "hour" + hourNumber;
                      
                       m_GameObjects.Add( TimeType.MinuteType, MakeMyMinute() );
                       m_GameObjects.Add( TimeType.SecondType, MakeMySecond() );

                minuteParent = _t;
                return _t;
                }
                
                
       Transform MakeMyMinute()
                {
                    isMinute = true;
                    minuteNumber++;
                     Transform _t = Transform.Instantiate(MessageMgr.Instance.minute,
                                                 getPosition(),
                                                 getRotationMinute(),
                                                 m_Transform) as Transform;

                      m_Transform.gameObject.name = "minute" + minuteNumber;

                       m_GameObjects.Add( TimeType.SecondType, MakeMySecond() );

                secondParent = _t;
                return _t;
                }
                
       Transform MakeMySecond()
                {        
                    isSecond = true;
                    secondNumber++;
                     Transform _t =
                     _t = Transform.Instantiate(MessageMgr.Instance.minute,
                                                 getPosition(),
                                                 getRotationSeconds(m_Date),
                                                 m_Transform) as Transform;

                      m_Transform.gameObject.name = "second" + secondNumber;

                return _t;
                }
                
                
                
                
                
                
                
            
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
        
        

        Vector3 getPosition()
        {
            return new Vector3(0, 0, -TimeFactory.SecsSinceMidnight(m_Date) * EtcMgr.secondDepthZ);
        }    
        
        
        
        
        void DoByTimeType(DateTime dt)
        {
            switch (m_TimeType)
            {
                case (TimeType.SecondType):
                    
                    break;
                case (TimeType.MinuteType):

                    break;
                case (TimeType.HourType):
                    
                    break;

                case (TimeType.DayType):

                    break;
            } 
        }

    }//class
}//name



