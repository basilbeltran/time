using System;
using System.Collections.Generic;

using UnityEngine;
namespace basil.util
{
    public static class ExtTransform
    {



        //transform.GetAll(); returns a Func
        public static Func<Transform[]> AllTransDown(this Transform t)
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


        //transform.GetAll(); returns a Func
        public static Func<Transform[]> RunRecursive(this Transform t, Action<Transform> act)
        {
            return RunRecursiveGetAll(t, new List<Transform>(), act);
        }


        public static Func<Transform[]> RunRecursiveGetAll(Transform t, List<Transform> l, Action<Transform>  act)
        {
            //gather the children recursively 
            l.Add(t);
            for (int i = 0; i < t.childCount; i++)
            {
                RunRecursiveGetAll(t.GetChild(i), l, act);
            }

            l.ForEach(act);

            return () => { return l.ToArray(); };
        }
        
        

        public static void ActiveUp( this Transform t)
        {           
            while (t != t.root)
            {
                t.gameObject.SetActive(true);
                t = t.parent;
            }
            t.gameObject.SetActive(true);
        }

        public static void DeactiveUp( this Transform t)
        {           
            while (t != t.root)
            {
                t.gameObject.SetActive(false);
                t = t.parent;
            }
            t.gameObject.SetActive(false);
        }
        
        public static void ActiveDown(this Transform obj)
        {
            foreach (Transform child in obj)
            {
                ActiveDown(child);
            }
 
            obj.gameObject.SetActive(true);
        }
        
                public static void DeactiveDown(this Transform obj)
        {
            foreach (Transform child in obj)
            {
                DeactiveDown(child);
            }
 
            obj.gameObject.SetActive(false);
        }

    }//class
}//name
 
