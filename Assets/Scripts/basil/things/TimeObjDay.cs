using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using basil.util;

namespace basil.things
{
    //an object class representing a Minute 
    public class TimeObjDay : TimeObj
    {
        public TimeObjDay(DateTime dt) : base(dt) {

        }

        //[SerializeField] DateTime m_Date;
        //[SerializeField] double m_Secs;
        //[SerializeField] GameObject m_GameObject;
        //[SerializeField] Transform m_Transform;
        //[SerializeField] ArrayList m_Events;
        //[SerializeField] TimeObj m_Children;


        void template()
        {
            switch (myTimeType)
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