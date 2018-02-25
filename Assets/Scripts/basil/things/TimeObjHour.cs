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
    public class TimeObjHour  
    {
    
        public TimeObj dictValue = null;
        public DateTime dt;
        public GameObject hGo = null;
        public GameObject hHolderGo;
        public GameObject hForhGo;
        public HourHolderBe hHolderB;
        public MinuteFormBe hFormB;
        Dictionary<int, TimeObjMinute> minutes;
        
        
        

        public TimeObjHour(DateTime _dt, Transform parent, TimeObj _dictValue, bool cascade) 
        {
            // U.Log(" constructor " +_dictValue.m_Date.ToString()  );
    
            Transform _t = Transform.Instantiate(MessageMgr.Instance.hour,
                                EtcMgr.getPosition(_dt),
                                EtcMgr.getRotationHour(_dt),
                                parent  ) as Transform;
            dictValue = _dictValue; // the TimeObj
            hGo = _t.gameObject;
            dictValue.Hour = hGo;
            dictValue.isHour = true;

            this.dt = _dt;

            hGo.name = "H" + dt.Hour; 
            
            hHolderGo = hGo.GetFirstChild();                   
            hHolderGo.layer = 10;    
            hHolderB = hGo.GetComponent<HourHolderBe>();
            hHolderB.setDateTime(_dt);
            hHolderB.Register(dictValue);
                     
            if(cascade) InflateMyMinutes(true);
        }

    
      


        public void
InflateMyMinutes(bool cascade)
        {
            InflateMinutes(dt, hGo.transform, dictValue, cascade);
        }



        //this option makes minutes and keeps them in one timeObject's local dictionary
        public void 
InflateMinutes(DateTime _dt, Transform _parent, TimeObj _dictValue, bool cascade)
        {

            minutes = new Dictionary<int, TimeObjMinute>(); //todo rid of this


            for (int i = 0; i < 60; ++i)
            {
                DateTime ndt = _dt.AddMinutes(i);
                TimeObjMinute tom = new TimeObjMinute(ndt.Neuter(), hGo.transform, dictValue, cascade);
                tom.mGo.SetActive(true);
                minutes.Add(i, tom);
            }
      
           //speak to the new 60 minutes    
            hGo.BroadcastMessage("ShowMe", this);
        }     









        //this option inflates the appropriate timeobj 
        public static void 
InflateMinute(DateTime _dt, Transform _parent, TimeObj _dictValue)
        {
            //The tom should add itself to the dict, MakeTime will have to stop doing that
            TimeObjMinute tom = new TimeObjMinute(_dt, _parent, _dictValue, false);
        }


        public void
DeflatePrior()
        {
            DateTime cloned = dt.AddHours(-1).Neuter();
            TimeObj prior = MakeTime.timeObjDictionary[cloned];
            prior.toh.DeflateMyMinutes();
        }


        public void 
DeflateMyMinutes()
        {
            if (minutes != null)
            {
            
                for (int i = 0; i < 60; ++i)
                {
                        dictValue.isMinute = false;
                    GameObject go = minutes[i].mGo;
                    Transform.Destroy(minutes[i].mGo);
                       
                }
              minutes = null;
            }
        }

        
    }
}  
