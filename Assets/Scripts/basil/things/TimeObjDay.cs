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
    public class TimeObjDay  
    {
    
        public TimeObj dictValue = null;
        public DateTime dt;
        public GameObject dGo = null;
        public GameObject dHolderGo;
        public GameObject dFormGo;
        public DayHolderBe dHolderB;
        public MinuteFormBe dFormB;
        Dictionary<int, TimeObjHour> hours;
        // Dictionary<DateTime, TimeObjHour> hours;

        
        
        
        
        
        
        
        public TimeObjDay(DateTime _dt, Transform parent, TimeObj _dictValue, bool cascade) 
        {
    
            Transform _t = Transform.Instantiate(MessageMgr.Instance.day,
                                EtcMgr.getPosition(_dt),
                                EtcMgr.getRotationDay(_dt),
                                MessageMgr.Instance.gameRoot  ) as Transform;
            dictValue = _dictValue;
            dGo = _t.gameObject;
            dictValue.Day = dGo;
            dGo.SetActive(true);
            dictValue.isDay = true;
            this.dt = _dt;
            dGo.name = "D" + dt.Day;         
            dHolderGo = dGo.GetFirstChild();                   
            dHolderGo.layer = 11;    
            dHolderB = dGo.GetComponent<DayHolderBe>();
            dHolderB.setDateTime(_dt);
            dHolderB.Register(dictValue);
            
            if(cascade) InflateMyHours(true);
        }




        public void
InflateMyHours(bool cascade)
        {
            InflateHours(dt, dGo.transform, dictValue, cascade );
        }



        //this option makes minutes and keeps them in one timeObject's local dictionary
        public void 
InflateHours(DateTime _dt, Transform _parent, TimeObj _dictValue, bool cascade)
        {

            hours = new Dictionary<int, TimeObjHour>(); //todo rid of this
            //hours = new Dictionary<DateTime, TimeObjHour>(); //todo rid of this


            for (int i = 0; i < 24; ++i)
            {
                DateTime ndt = DateTime.Today.AddHours(i);
                TimeObjHour toh = new TimeObjHour(ndt.Neuter(), dGo.transform, dictValue, cascade);
                toh.hGo.SetActive(true);
                //hours.Add(ndt, toh);
                hours.Add(i, toh);

            }
      
           //speak to the new 24 hours    
            dGo.BroadcastMessage("ShowMe", this);
        }     









        //this option inflates the appropriate timeobj 
        public static void 
InflateHour(DateTime _dt, Transform _parent, TimeObj _dictValue)
        {
            //The toh should add itself to the dict, MakeTime will have to stop doing that
            TimeObjHour toh = new TimeObjHour(_dt, _parent, _dictValue, false);
        }


        public void
DeflatePrior()
        {
            DateTime cloned = dt.AddHours(-1).Neuter();
            TimeObj prior = MakeTime.timeObjDictionary[cloned];
            prior.toh.DeflateMyMinutes();
        }


        public void 
DeflateMyHours()
        {
            if (hours != null)
            {
            
                for (int i = 0; i < 24; ++i)
                {
                        dictValue.isHour = false;
                    GameObject go = hours[i].hGo;
                    Transform.Destroy(hours[i].hGo);
                       
                }
              hours = null;
            }
        }

        
    }
}  
