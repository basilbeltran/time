using System;
using System.Collections.Generic;

using UnityEngine;
namespace basil.util
{
    public static class TransformUtil
    {
       


        //transform.GetAll(); returns a Func
        public static Func<Transform[]> GetAll(this Transform t)
        {
            return RecursiveGetAll(t, new List<Transform>());
        }


        public static Func<Transform[]> RecursiveGetAll(Transform t, List<Transform> l)
        {
            //gather the children recursively 
            l.Add(t);
            for (int i = 0; i < t.childCount; i++)
            {
                RecursiveGetAll(t.GetChild(i), l);
            }

            return () => { 
                return l.ToArray();
            };
        }
 




    }//class
}//name
 
