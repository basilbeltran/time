using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using basil.util;

namespace basil.things
{
    //an object class responsible for organizing TimeObjs in a hierarchy
    public class TimeObjFactory
    {

        bool dump = false;
        
        public EtcMgr.TimeType lowestToInstantiate;
        // in linear parenting scheme hours hold subsequent hour, otherwise, days hold hours
        // this is for gameObject parenting. The Dictionary is flat and every entry is a second
        public bool linear = false;
        public bool deferSeconds = true;


        public int secondNumber, minuteNumber, hourNumber, dayNumber, monthNumber, yearNumber = 0;
        public Transform dayParent = MessageMgr.Instance.gameRoot;
        public Transform hourParent = null;
        public Transform minuteParent = null;
        public Transform secondParent = null;
        
        
        public TimeObjFactory(bool tf)
        {   
           deferSeconds = tf;

          // U.Log( "defer = " + deferSeconds.ToString() );
          // U.Log( "dayParent = " + dayParent.name);

        }


        //making a timeObj that manages this slice of time
        public TimeObj MakeTimeObj(DateTime dt)
        {  
        
         TimeObj to = new TimeObj(dt, this);
            to.MakeFaces(dt);
         
            //if (dump)
            //{
            //    try
            //    {
            //        //   //// U.Log(dt.Dump());
            //        //if(dump) U.Log(

            //         //"\t M:" + minuteNumber + "/" + minuteParent.gameObject.name
            //         //+ "\t H:" + hourNumber + " / " + hourParent.gameObject.name 

            //         //);
            //    }
            //    catch (Exception ex)
            //    {
            //        Debug.Log( ex.ToString() );
            //    }
            //}

           
            return to;

        }
        

    

    }//class
}//name



