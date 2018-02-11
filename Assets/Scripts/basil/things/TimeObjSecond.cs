using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using basil.util;

namespace basil.things
{
    public class TimeObjSecond : TimeObj
    {
        // if physical space represents time then these all (H/M/S) start in the same place
        public static int minuteNumber, hourNumber, secondNumber = 0;
        public bool isSecond, isMinute, isHour = false;

        //constructor of a second, which may also be a minute, or hour
        public TimeObjSecond(DateTime dt) : base(dt) {
            myTimeType = TimeType.SecondType;
            secondNumber++;
            isSecond = true;
            InstantiateSecond(TimeObj.secondParent); 
            m_Transform.gameObject.name = "second " + secondNumber;


            if (dt.Second == 0) //this timeObject is ALSO a minute// nope need a minute
            {
                isMinute = true;
                minuteNumber++;

                m_Transform.gameObject.name = "minute"+ minuteNumber;
                TimeObj.secondParent = m_Transform; //the next second made with the superclass
                SetParent(minuteParent);
                //hack to confirm my understanding
                // m_Transform.rotation = getRotationMinute(); // yup... that makes things right again
                //the second objects marked as minute are rotated as seconds (at 12) they,
                //traditionally, would have caused another arm to be correctly rotated,
                // the zero-th (minute indicating) second will allways, however, point upwards.

                //seeing as there is no room in a unique keyed dictionary for a minute at the 
                //same key, the notion of a minute will get tacked on to this second object
                // to keep the abstract notions to a minimum
                // I did think of rotating the whole thing 1/60th degree, then the 0th second would
                // both birth the minute and also render it traditionally. 
                // I think this would eventually lead to stiff necks.




                if (dt.Minute == 0)
                {   
                    isHour = true;
                    hourNumber++;
                    TimeObj.minuteParent = m_Transform; // subsequent minutes belong to me
                    SetParent(hourParent);              // i belong to the previous hour
                    m_Transform.gameObject.name = "hour" + hourNumber;

                    TimeObj.hourParent = m_Transform;   // the next hour will belong to me

                    if (dt.Hour == 0 ) {
                        //isDay = true;
                        // NEW DAY
                    };
                };

            };
        }

        public void SetParent(Transform p)
        {
            m_Transform.parent = p;
        }

        public TimeObjSecond SetActiveFalse()
        {
            m_Transform.gameObject.SetActive(false);
            return this;
        }


        public void InstantiateSecond(Transform tr)
        {
            m_Transform = Transform.Instantiate(GameMgr.Instance.second,
                                                 getPosition(),
                                                 getRotationSeconds(),
                                                            tr) as Transform;
        }

        Quaternion getRotationSeconds()
        {
            return Quaternion.Euler(0f, 0f, m_Date.Second * -EtcMgr.secondsToDegrees);
        }

        Quaternion getRotationMinute()
        {
            return Quaternion.Euler(0f, 0f, m_Date.Minute * -EtcMgr.minutesToDegrees);
        }


        Vector3 getPosition()
        {
            return new Vector3(0, 0, -TimeFactory.SecsSinceMidnight(m_Date) * EtcMgr.secondDepthZ);

        }


        //if a real object is needed.
        TimeObjMinute makeMinute(){ 
            TimeObjMinute tom = new TimeObjMinute(m_Date);
            tom.Instantiate(this.m_Transform);
            return tom;
        }

       void makeHour(){
            //TimeObjHour toh = new TimeObjHour(m_Date);
            //toh.Instantiate(this.m_Transform);
        }



    }//class
}//name