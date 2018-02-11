//using UnityEngine;
//using System.Collections;
//using System.Collections.Generic;

//using System.Reflection;
//using System.Runtime.CompilerServices;
//using System.Diagnostics;
//using Svelto.Communication.SignalChain;
//using UnityEngine.SceneManagement;
//using System;
//using System.Linq;

//namespace basil.util   //TODO ensure singletons TimeFactory are available
//{

//    [AddComponentMenu("Util/Logg")]
//    public static class Logg
//    {
//        static bool dump = true;




//        public static void Log(string message) { Loger("0", message, null); }        // log 
//        public static void LError(string message) { Loger("1", message, null); }        // log error
//        public static void LWarning(string message) { Loger("2", message, null); }        // log warning
//        public static void LData(string message, UnityEngine.Object o) { Loger("3", message, o); }  // log debug

//        public static void Loger(string level, string message, UnityEngine.Object obj)
//        {

//            switch (level)
//            {
//                case "0":
//                    UnityEngine.Debug.Log(TimeFactory.t() 
//                                          //+ "-" + ClassMethodString(4) 
//                                          + "-" + message);
//                    break;

//                case "1":
//                    UnityEngine.Debug.LogError(message);

//                    break;

//                case "2":
//                    UnityEngine.Debug.LogWarning(message);

//                    break;

//                case "3":

//                    break;

//                default: break;
//            }
//        }


//        public static string Status(this UnityEngine.Object o)
//        {
//            string typ = o.GetType().ToString();
//            int index = typ.LastIndexOf(".");
//            string _s = "  " + typ.Substring(index);
//            //TODO create case
//            return _s;
//        }



//        public static string ClassMethodString(int frame)
//        {
//            System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace();
//            string _s = "";
//            StackFrame f = trace.GetFrame(frame);
//            _s += frame + "<" + f.GetMethod().ReflectedType.ToString();
//            _s += ">" + f.GetMethod().Name + " ";
//            return _s;
//        }

//        public static string ClassMethodString()
//        {
//            System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace();
//            string _s ="";


//            for (int i = 0; i < trace.FrameCount; i++){
//                StackFrame f = trace.GetFrame(i);
//                _s +=i+"<" + f.GetMethod().ReflectedType.ToString();
//                _s += ">" + f.GetMethod().Name +" ";
//                _s += "\n FILE  " + f.GetFileName();
//                _s += "\n LINE  " + f.GetFileLineNumber().ToString();
//                _s += "\n\n";

            
//          }
//            UnityEngine.Debug.Log(_s);
//            return _s;
//        }



//        public static string AppString()
//        {
//            string prod = Application.productName;
//            prod += Application.unityVersion;
//            prod += Application.dataPath;
//            return prod;
//        }









//        public static T[] GetComponentsInDirectChildren<T>(GameObject gameObject)
//        {
//            int indexer = 0;

//            foreach (Transform transform in gameObject.transform)
//            {
//                if (transform.GetComponent<T>() != null)
//                {
//                    indexer++;
//                }
//            }

//            T[] returnArray = new T[indexer];

//            indexer = 0;

//            foreach (Transform transform in gameObject.transform)
//            {
//                if (transform.GetComponent<T>() != null)
//                {
//                    returnArray[indexer++] = transform.GetComponent<T>();
//                }
//            }

//            return returnArray;
//        }



//        public static ArrayList GetComponents(GameObject go)
//        {
//            ArrayList list = new ArrayList();
//            var comps = go.GetComponents(typeof(Component));
//            foreach (Component c in comps)
//            {
//                list.Add(c);
//            }
//            return list;
//        }



//        public static GameObject FindInActiveObjectByName(string s)
//        {
//            Transform[] objs = Resources.FindObjectsOfTypeAll<Transform>() as Transform[];
//            for (int i = 0; i < objs.Length; i++)
//            {
//                if (objs[i].hideFlags == HideFlags.None)
//                {
//                    if (objs[i].name == s)
//                    {
//                        if (dump) UnityEngine.Debug.Log("found " + objs[i].name);
//                        return objs[i].gameObject;
//                    }
//                }
//            }
//            return null;
//        }

//        //foreach (Component c in Utils.GetComponents(time)){
//        //    Debug.Log(c.name + " " + c.GetType());
//        //}




//        public static void SceneChange()
//        {
//            Scene ourScene = SceneManager.GetActiveScene();
//            Scene newScene = SceneManager.CreateScene("Scenic");
//            GameObject[] gos = ourScene.GetRootGameObjects();
//            foreach (GameObject g in gos){SceneManager.MoveGameObjectToScene(g, newScene);}
//        }






//        //public static UnityEngine.Object[] 
//        //              Map(this List<UnityEngine.Object> toMap,
//        //                  Action<UnityEngine.Object> doMap)
//        //{
//        //    UnityEngine.Object[] transformed = toMap.ToArray();
//        //    for (int i = 0; i < transformed.Count(); i++)
//        //    {
//        //        transformed[i] = doMap(transformed[i]);
//        //    }
//        //    return () => {
//        //        return transformed;
//        //    };
//        //}

//        //public static Transform[] GetRoots()
//        //{
//        //    Scene ourScene = SceneManager.GetActiveScene();
//        //    GameObject[] gos = ourScene.GetRootGameObjects();
//        //    return Map(gos, p => p = transform);
//        //}


//        public static Func<Tuple<string, float>> OnEvent(this Func<Event[]> f)
//        {
//            //receive a message from the outside world...
//            string s = "message"; //event message
//            int t = 0; //timestamp event was received 
//            return () => {  return new Tuple<string, float>(s, t); };
//        }





//    }//class
//}//name

