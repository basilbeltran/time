using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System;
using basil.util;
using System.Collections.Generic;



//namespace basil.util
//{
public static class ExtDictionary
    {

        public static string DumpKeys<T, U> (this Dictionary<T, U> dic)
        {
        string s =""; int count = 0;
             foreach (T key in dic.Keys)
            {
            count++;
             s += " K:"+ key.ToString();
            if (count > 5) break;
            }
        return s;

        }
        
        
        
        
        
        
         public static U GetOrDefault<T, U>(this Dictionary<T, U> dic, T key)
        {
            if (dic.ContainsKey(key)) return dic[key];
            return default(U);
        }
        

    }

 
