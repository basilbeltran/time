using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using basil.util;

namespace time
{
    public class TimeObjSecond
    {


        public TimeObj dictValue;
        public DateTime dt;
        public GameObject sGo = null;
        public GameObject sHolderGo;
        public GameObject sFormGo;
        public SecondHolderBe sHolderB;
        public SecondFormBe sFormB;
        

        
        public TimeObjSecond(DateTime dt, Transform parent, TimeObj _dictValue)
        {
            

            Transform _t = Transform.Instantiate(MessageMgr.Instance.second,
                                EtcMgr.getPosition(dt),
                                EtcMgr.getRotationSeconds(dt),
                                parent) as Transform;
            dictValue = _dictValue;
            dictValue.Second = sGo;
            dictValue.isSecond = true;
            
            sGo = _t.gameObject;
            sGo.name = "S" + dt.Second;
            sGo.GetFirstChild().layer = 8;
            


            sHolderGo = sGo.GetFirstChild();
            sHolderB = sGo.GetComponent<SecondHolderBe>();
            sHolderB.setDateTime(dt);

        }
    }
}            
              
              
              
              
              
              
              
//       //       parent = null;
//       //        // a brand new display object (gameObject)
//       //        ConfigureAsSecond();
//       //        parent = MessageMgr.Instance.transform;
               
               

//       //     //we have a minute - a DateTime with a value of zero meas we increment the next higher order
//       //     if (dt.Second == 0) //this timeObject is ALSO a minute
//       //     {
            
//       //           // LOOKING BACK give that game object a new key, and seat in m_GameObjects
//       //          // m_GameObjects.Add(TimeType.SecondType, m_Transform.gameObject );
                  
//       //           // what was a second is now a minute. Swap in a new tTransform
//       //           ConfigureAsMinute(); 
                 
                 
                 
//       //         // but passing here we know it is also now, an hour
//       //         if (dt.Minute == 0) 
//       //         {
//       //           // LOOKING BACK give that game object a new key, 
//       //           m_GameObjects.Add(TimeType.MinuteType, m_Transform.gameObject );
                  
//       //             ConfigureAsHour();
//       //              m_GameObjects.Add(TimeType.HourType, newHourShape().gameObject );

                    
//       //             if (base.linear)
//       //             {
//       //                 SetParent(hourParent);
//       //                 TimeObj.hourParent = m_Transform;  // the next hour will belong to me

//       //             }
//       //               else SetParent(hourParent);            //the hours will collect under the day 
                      

//       //                 if (dt.Hour == 0 ) {
//       //                     isDay = true;
//       //                     dayNumber++;
//       //                     TimeObj.hourParent = m_Transform; // subsequent hours belong to me
//       //                     SetParent(dayParent);              // i belong to the previous hour
//       //                     m_Transform.gameObject.name = "day" + dayNumber;
        
//       //                 };
//       //         };

//       //     };
            
//       //     // ADD 
//       //     m_GameObjects.Add( ttype,  parent.gameObject );

//       // }

        


//       // // instanciate and name the gameObject place in m_Transform
//       // public GameObject   ConfigureAsSecond()
//       // {   
//       //     // set a flag to identify this as a second
//       //     isSecond = true;
            
//       //     // the timeType is used as a key in the m_GameObjects Dictionary
//       //     m_TimeType = TimeType.SecondType;
            
//       //     // this is the first second the next will be next
//       //     secondNumber++;
            
//       //     // how many seconds have been made should equal the enties in Dictionary
//       //     if (dump) U.Log("second  " + secondNumber);

//       //     //m_Transform is the last simple field to be populated
//       //     InstantiateSecond(TimeObj.secondParent);  

//       //     //set it to what we know it is (so far)
//       //     m_Transform.gameObject.name = "second " + secondNumber;
        
//       //      if (dump) U.Log("m_Transform.gameObject.name  " + m_Transform.gameObject.name);
//       //     return m_Transform.gameObject;
//       // }
         
         
//       //    public GameObject ConfigureAsMinute()
//       // {       //change things about this object and make another to replace it
//       //         isMinute = true;
//       //         m_TimeType = TimeType.MinuteType;
//       //         minuteNumber++;
//       //         //InstantiateMinute(TimeObj.secondParent);  
//       //         m_Transform = newMinuteShape();
//       //         m_Transform.gameObject.name = "minute"+ minuteNumber;
                
//       //         TimeObj.secondParent = m_Transform; //i will be parent to the next second made with the superclass
//       //         SetParent(minuteParent);
                
                
//       //         //hack to confirm my understanding
//       //         m_Transform.rotation = getRotationMinute(); // yup... that makes things right again
//       //                                                     //the second objects marked as minute are rotated as seconds (at 12) they,
//       //                                                     //traditionally, would have caused another arm to be correctly rotated,
//       //                                                     // the zero-th (minute indicating) second will allways, however, point upwards.

//       //     //seeing as there is no room in a unique keyed dictionary for a minute at the 
//       //     //same key, the notion of a minute will get tacked on to this second object
//       //     // to keep the abstract notions to a minimum
//       //     // I did think of rotating the whole thing 1/60th degree, then the 0th second would
//       //     // both birth the minute and also render it traditionally. 
//       //     // I think this would eventually lead to a stiff neck.

//       //     //m_GameObjects.Add(TimeType.MinuteType, this.);
//       //     return m_Transform.gameObject;
//       // }//make




//       // public void ConfigureAsHour()
//       // {
//       //             isHour = true;
//       //             hourNumber++;
//       //             m_TimeType = TimeType.HourType;
//       //             m_Transform = newHourShape();
//       //             m_Transform.gameObject.name = "hour" + hourNumber;
//       //             TimeObj.minuteParent = m_Transform; // subsequent minutes belong to me
//       //              SetParent(hourParent);
//       // }
        
        
        
        
//       //         //if a real object is needed.
//       // Transform  newMinuteShape(){ 
//       //     TimeObjMinute tom = new TimeObjMinute(m_Date);
//       //     return tom.Instantiate(TimeObj.minuteParent).transform;
//       // }

//       //Transform newHourShape(){
//        //     TimeObjHour toh = new TimeObjHour(m_Date);
//        //     return toh.Instantiate(TimeObj.hourParent).transform;
//        //}
        
        
//        ////public void SetParent(Transform p)
//        ////{
//        ////    m_Transform.parent = p;
//        ////}



//        //public TimeObjSecond SetActiveFalse()
//        //{
//        //    m_Transform.gameObject.SetActive(false);
//        //    return this;
//        //}


//        //public Transform InstantiateSecond(Transform tr)
//        //{                                

//        //     m_Transform = Transform.Instantiate(MessageMgr.Instance.second,
//        //                                         getPosition(),
//        //                                         getRotationSeconds(),
//        //                                         tr) as Transform;
                                                 
//        //   if(dump) U.Log(m_Transform.gameObject.name +"  parents  "+ tr.gameObject.name );
//        //    return m_Transform;
//        //}










//    }//class
//}//name