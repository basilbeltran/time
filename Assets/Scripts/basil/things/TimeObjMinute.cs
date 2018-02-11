using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using basil.util;

namespace basil.things
{
    //an object class representing a Minute, only used if visible mesh differs from second
    public class TimeObjMinute : TimeObj
    {
        


        public TimeObjMinute(DateTime dt) : base(dt)
        {
            myTimeType = TimeType.MinuteType;
        }

        public void Instantiate(Transform tr)
        {    
            m_Transform =  Transform.Instantiate(GameMgr.Instance.minute, 
                                                 getPosition(), 
                                                 getRotationMinute(), 
                                                 GameMgr.root) as Transform;
        }

        Quaternion getRotationMinute()
        {
            return Quaternion.Euler(0f, 0f, m_Date.Minute * -EtcMgr.minutesToDegrees);
        }

        Vector3 getPosition()
        {
            return new Vector3(0, 0, -  TimeFactory.SecsSinceMidnight(m_Date) * EtcMgr.secondDepthZ);

        }


    }//class
}//name