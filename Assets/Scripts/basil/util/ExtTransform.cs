using System;
using System.Collections.Generic;

using UnityEngine;
namespace basil.util
{
    public static class TransformUtil
    {



        //transform.GetAll(); returns a Func
        public static Func<Transform[]> GetAllDown(this Transform t)
        {
            return RecursiveGetAllDown(t, new List<Transform>());
        }


        public static Func<Transform[]> RecursiveGetAllDown(Transform t, List<Transform> l)
        {
            //gather the children recursively 
            l.Add(t);
            for (int i = 0; i < t.childCount; i++)
            {
                RecursiveGetAllDown(t.GetChild(i), l);
            }

            return () =>
            {
                return l.ToArray();
            };
        }

        //public static Func<DateTime, DateTime, TimeSpan> isHourInt = (from , to ) => (to - from);

        //transform.GetAllUp(); returns a Func to gather ancestors
        public static Func<Transform[]> GetAllUp(this Transform t)
        {
            List<Transform> l = new List<Transform>();
           
            while (t != t.root)
            {
                l.Add(t);
                t = t.parent;
            }
            l.Add(t);
            return () =>
            {
                return l.ToArray();
            };
        }


    }//class
}//name
 
