using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using basil.util;

namespace basil.things
{
    //an object class representing an Hour 
    public class TimeObjHour : TimeObj
    {
        public TimeObjHour(DateTime dt) : base(dt) {

        }


        void template()
        {
            switch (myTimeType)
            {
                case (TimeType.SecondType):
                    
                    break;
                case (TimeType.HourType):
                    
                    break;
                case (TimeType.DayType):

                    break;
            }
        }



    }//class
}//name