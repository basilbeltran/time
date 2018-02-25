using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using basil.util;


//The things that make up a timescape...
// a dictionary key of DateTime value of timeObj s

// timeObj


namespace basil.things
{
    public class TimeObjMinute  
    {
    
        public TimeObj dictValue = null;
        public DateTime dt;
        public GameObject mGo = null;
        public GameObject mHolderGo;
        public GameObject mFormGo;
        public MinuteHolderBe mHolderB;
        public MinuteFormBe mFormB;
        Dictionary<int, TimeObjSecond> seconds;
        
        

        // Class knows how to populate seconds but will wait
        public TimeObjMinute(DateTime _dt, Transform parent, TimeObj _dictValue, bool cascade) 
        {
    
            Transform _t = Transform.Instantiate(MessageMgr.Instance.minute,
                                EtcMgr.getPosition(_dt),
                                EtcMgr.getRotationMinute(_dt),
                                parent  ) as Transform;
            dictValue = _dictValue; // the TimeObj
            mGo = _t.gameObject;
            dictValue.Minute = mGo;
            dictValue.isMinute = true;

            this.dt = _dt;
           
            mGo.name = "M" + dt.Minute; 
            
            mHolderGo = mGo.GetFirstChild();                   
            mHolderGo.layer = 9;    
            mHolderB = mGo.GetComponent<MinuteHolderBe>();
            mHolderB.setDateTime(_dt);
            mHolderB.Register(dictValue);

        }

        public void
InflateMySeconds()
        {
            InflateSeconds(dt, mGo.transform, dictValue);
        }



        //this option makes seconds and keeps them in one timeObject's local dictionary
        public void 
InflateSeconds(DateTime _dt, Transform _parent, TimeObj _dictValue)
        {

            seconds = new Dictionary<int, TimeObjSecond>(); //todo rid of this


            for (int i = 0; i < 60; ++i)
            {
                DateTime ndt = _dt.AddSeconds(i);
                TimeObjSecond tos = new TimeObjSecond(ndt.Neuter(), mGo.transform, dictValue);
                tos.sGo.SetActive(true);
                seconds.Add(i, tos);
            }
      
           //speak to the new 60 seconds    
            mGo.BroadcastMessage("ShowMe", this);
        }
       
       
       

        //this option inflates the appropriate timeobj 
        public static void 
InflateSecond(DateTime _dt, Transform _parent, TimeObj _dictValue)
        {
            //The tos will add itself to the dict 
            TimeObjSecond tos = new TimeObjSecond(_dt, _parent, _dictValue);
        }


        public void
DeflatePrior()
        {
            DateTime cloned = dt.AddMinutes(-1).Neuter();
            TimeObj prior = MakeTime.timeObjDictionary[cloned];
            prior.tom.DeflateMySeconds();
        }


        public void 
DeflateMySeconds()
        {
            if (seconds != null)
            {
            
                for (int i = 0; i < 60; ++i)
                {
                        dictValue.isSecond = false;
                    GameObject go = seconds[i].sGo;
                    Transform.Destroy(seconds[i].sGo);
                       
                }
              seconds = null;
            }
        }

        
    }
}  
