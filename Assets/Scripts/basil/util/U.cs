using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using System.Diagnostics;
using UnityEngine.SceneManagement;
using System;
using System.Linq;
using basil.things;
using System.Reflection;

namespace basil.util 
{

public static class U
{
      
   public static DateTime 
now;
  
    static bool 
dump = true;
        

    private static System.Random 
random = new System.Random();

    static int 
GetRandomInt(){ random.Next(); random.Next();  return random.Next(); }
        

    public static string 
RandomString(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
    }

    public static Color
RandomColor()
        {
               return new Color(GetRandomInt() / 2147483647,
              (new System.Random().Next(1, 10)) / 10f,
              (new System.Random().Next(1, 10)) / 10f, 1);
        }
        
        public static Action
getRandomNumber = () => new System.Random().Next(1, 10);


//NB: the end follows the beginning, except in the calculation

        public static TimeSpan 
ElapsedMeth(DateTime from, DateTime to){ return to - from; }


        public static double 
ElapsedDblMeth(DateTime from, DateTime to) { return (to - from).TotalSeconds; }

        
        public static Func<DateTime, DateTime, double> 
ElapsedDblFunc = (from , to ) => (to - from).TotalSeconds;


        public static Func<DateTime, DateTime, TimeSpan>
ElapsedFunc = (from , to ) => (to - from);



//System.Threading.Thread.Sleep(5000);
//public static void Color()      {  MakeTime.ToDtTo(U.pDTnewDay, U.aColor );  }

// Predicates for Collection from dictionary on the primary key ...DateTime stamp

//past v future
public static Predicate<DateTime> pHasPast = (dt) => dt.Ticks < DateTime.Now.Ticks; 
public static Predicate<DateTime> pDTzeroSec = (dt) => dt.Second == 0; 
public static Predicate<DateTime> pDTisHour   = (dt) => dt.Minute == 0 && dt.Second == 0; 
public static Predicate<DateTime> pDTisDay    = (dt) => dt.Hour == 0 && dt.Minute == 0 && dt.Second == 0; 
public static Predicate<DateTime> pDTtoday = (dt) => dt.Date.Day == DateTime.Now.Date.Day;
public static Predicate<DateTime> pDTminute = (dt) => dt.Minute == DateTime.Now.Minute;
public static Predicate<DateTime> pDThour = (dt) => dt.Minute == DateTime.Now.Hour;
public static Predicate<DateTime> pDTsecond = (dt) => dt.Minute == DateTime.Now.Second;

public static Predicate<DateTime> pDTthisVeryMoment = (dt) => dt.Neuter() == DateTime.Now.Neuter();

//which came first
public static Func<DateTime, DateTime, bool> fIsBefore = (dt, dt2) => dt.Ticks < dt2.Ticks; 
public static Func<DateTime, DateTime, TimeSpan> GetSpan = (from , to ) => (to - from);
public static Func<DateTime, DateTime, bool> fDTmatchDate = (db_dt, ur_date) => db_dt.Date == ur_date.Date;
public static Func<DateTime, DateTime, bool> fDTmatchSecond = (db_dt, ur_date) => db_dt == ur_date;


//Predicates for TimeObj. Each dictionary Value has bool values as follows


public static Predicate<TimeObj> pIsMinute = (to) => to.isMinute;
public static Predicate<TimeObj> pIsHour = (to) => to.isHour;
public static Predicate<TimeObj> pIsDay = (to) => to.isDay;

// one way to find thisVeryMoment
public static Predicate<TimeObj> pNow = (to) => to.m_Secs == TimeFactory.SecsSinceMidnight(DateTime.Now);


//show details
public static Action<TimeObj> aDump = (to) => to.Dump();     
// all timeObjects have a defined Z axis offset from the origin  (EtcMgr.cs)
public static Action<TimeObj> aPosition = (to) => U.Log( to.getPosition().ToString() );


//actions to be applied upon a TIME OBJECT TO activate gameObjects
//ActivateAll a GameObject extention to recursively (de)activate children

//directly to a gameObject
public static Action<GameObject> aActiveGoDown = (go) => go.ActivateDown(); 
public static Action<GameObject> aActiveGoUp = (go) => go.ActivateUp(); 

//via the timeObject
public static Action<TimeObj> aActDayDown = (to) => to.Day.ActivateDown(); 
public static Action<TimeObj> aDeActDayDown = (to) => to.Day.DeactivateDown();
public static Action<TimeObj> aActHourDown = (to) => to.Hour.ActivateDown();
public static Action<TimeObj> aActHourUp = (to) => to.Hour.ActivateUp();

public static Action<TimeObj> aDeActHourDown = (to) => to.Hour.DeactivateDown();
public static Action<TimeObj> aActMinDown = (to) => to.Minute.ActivateDown(); 
public static Action<TimeObj> aDeActMinDown = (to) => to.Minute.DeactivateDown(); 
public static Action<TimeObj> aToggleActiveSec = (to) => to.Second.ToggleActive();     

// magic is better...
// this will toggle the layer, so to see seconds, send the function int 8, minutes are int 9 etc 
public static Action<int> aLevel = (intg) => Camera.main.cullingMask ^= 1 << intg;
 //private void Show() { camera.cullingMask |= 1 << LayerMask.NameToLayer("SomeLayer");    }
 //private void Hide() { camera.cullingMask &=  ~(1 << LayerMask.NameToLayer("SomeLayer")); }

//todo think about superclass or interface for all forms and holders
///public static Action<Form> aColor = (form) => form.SetColor(0.1f,.1f,.1f,.1f);

public static Action<List<int>> aMap = (obj) => Impls.TestMap(obj);
public static Action<List<int>> aTest = Impls.TestMap;



//this will notify the timeObject that its minute is in focus. 
// Could manage this top down or delegate. Any case, The Day , Hour, Minute , Second react,
//ensuring proper parents are notified (Activated, Focused) and handles the seconds instantiation.
public static Action<TimeObj> aShine = (to) => to.Shine(); //Make like a clock   
















///////////////////////// shorts ///////////////////////


//public static void Clock()             {  MakeTime.ToDt(U.pDTthisVeryMoment );  }  



//public static void All()             {  MakeTime.ToToTo(U.pIsDay, U.aActDayDown );  }  
//// todo public static void AColor()          {  MakeTime.ToToTo(U.pIsMinute, U.aColor );  }
////public static void ActiveNow()       {  MakeTime.ToToTo(U.pNow, U.aAllup );  }  
////public static void ActiveDayDown()   {  MakeTime.ToToTo(U.pIsDay, U.aBothDown );  }
public static void ActivateHoursUp()   {  MakeTime.ToDtTo(U.pDTisHour, U.aActHourUp );  }
//public static void ActiveateHoursDown() {  MakeTime.ToDtTo(U.pDTisMinute, U.aActMinDown );  }
//public static void ActivateDay()     {  MakeTime.ToToTo(U.pIsDay, U.aActiveGoDown );  }
//public static void AllFrom00()       {  MakeTime.ToDtTo(U.pDTisDay, U.aActiveGoDown );  }

//public static void ToggleMinutes()   {  MakeTime.ToDtTo(U.pDTisDay, U.aActiveGoDown );  }


/// <summary>
/// HERE WE GO
/// </summary>

// Each second MessageMgr calls Clock(), Clock() calls the matching particular second. 
// It may be deflated (hold no second objects).
public static void Clock()             {  MakeTime.ToDtTo(U.pDTthisVeryMoment, U.aShine );  }  


// in the case there is no second inflated (likely) or minute (just as likely)find the
// previous timeObject could manage the event... the default scenario.
//public static void PreviousTOwMinute() {  MakeTime.ToDtTo(U.pDTthisVeryMoment, U.aShine );  }  





    
    

/// <summary>
/// //LOGGING
/// </summary>
/// <returns>The log.</returns>
/// <param name="message">Message.</param>

        public static void Log(string message) { Loger("0", message, null); }        // log 
        public static void LError(string message) { Loger("1", message, null); }        // log error
        public static void LWarning(string message) { Loger("2", message, null); }        // log warning
        public static void LData(string message, UnityEngine.Object o) { Loger("3", message, o); }  // log debug

        public static void Loger(string level, string message, UnityEngine.Object obj)
        {

            switch (level)
            {
                case "0":
                    UnityEngine.Debug.Log(TimeFactory.t() 
                                          + "-" + ClassMethodString(4) 
                                          + "\n" + message);
                    break;

                case "1":
                    UnityEngine.Debug.LogError(message);

                    break;

                case "2":
                    UnityEngine.Debug.LogWarning(message);

                    break;

                case "3":
            UnityEngine.Debug.Log(TimeFactory.t() 
                                          + "-" + ClassMethodString(4) 
                                          + "\n" + message);
              
                    break;

                default: break;
            }
        }


        public static string Status(this UnityEngine.Object o)
        {
            string typ = o.GetType().ToString();
            int index = typ.LastIndexOf(".");
            string _s = "  " + typ.Substring(index);
            //TODO create case
            return _s;
        }


        public static string ClassMethodString(int frame)
        {
            System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace();
            string _s = "";
            StackFrame f = trace.GetFrame(frame);

                try
            {
                _s += frame + " " + f.GetMethod().ReflectedType.ToString();
                _s += " " + f.GetMethod().Name + " ";

            }
            catch (Exception ex)
            {

            }


            //if (dump) _s += ClassMethodString();
            return _s;
        }

        public static string SuperClassMethodString(int frame)
        {
            System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace();
            string _s = "";
            StackFrame f = trace.GetFrame(frame);

          try
            {
                _s += frame + " " + f.GetMethod().ReflectedType.ToString();
                _s += "\n " + f.GetMethod().Name + " ";

                foreach (ParameterInfo p in f.GetMethod().GetParameters()) {
                    _s += " \n" + p.RawDefaultValue.ToString();
                }

               _s += " \n" +  f.GetFileName();
               _s += " \n" +  f.GetFileLineNumber();

                
            }
            catch (Exception ex)
            {

            }


            //if (dump) _s += ClassMethodString();
            return _s;
        }

        public static string ClassMethodString()
        {
            System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace();
            string _s ="";


            for (int i = 0; i < trace.FrameCount; i++){
                StackFrame f = trace.GetFrame(i);
                _s +=i+"<" + f.GetMethod().ReflectedType.ToString();
                _s += ">" + f.GetMethod().Name +" ";
                _s += "\n FILE  " + f.GetFileName();
                _s += "\n LINE  " + f.GetFileLineNumber().ToString();
                _s += "\n\n";

          }
            UnityEngine.Debug.Log(_s);
            return _s;
        }



        public static string AppString()
        {
            string prod = Application.productName;
            prod += Application.unityVersion;
            prod += Application.dataPath;
            return prod;
        }


        public static T[] GetComponentsInDirectChildren<T>(GameObject gameObject)
        {
            int indexer = 0;

            foreach (Transform transform in gameObject.transform)
            {
                if (transform.GetComponent<T>() != null)
                {
                    indexer++;
                }
            }

            T[] returnArray = new T[indexer];

            indexer = 0;

            foreach (Transform transform in gameObject.transform)
            {
                if (transform.GetComponent<T>() != null)
                {
                    returnArray[indexer++] = transform.GetComponent<T>();
                }
            }

            return returnArray;
        }



        public static ArrayList GetComponents(GameObject go)
        {
            ArrayList list = new ArrayList();
            var comps = go.GetComponents(typeof(Component));
            foreach (Component c in comps)
            {
                list.Add(c);
            }
            return list;
        }



        public static GameObject FindInActiveObjectByName(string s)
        {
            Transform[] objs = Resources.FindObjectsOfTypeAll<Transform>() as Transform[];
            for (int i = 0; i < objs.Length; i++)
            {
                if (objs[i].hideFlags == HideFlags.None)
                {
                    if (objs[i].name == s)
                    {
                        if (dump) UnityEngine.Debug.Log("found " + objs[i].name);
                        return objs[i].gameObject;
                    }
                }
            }
            return null;
        }

        //foreach (Component c in Utils.GetComponents(time)){
        //    Debug.Log(c.name + " " + c.GetType());
        //}




        public static void SceneChange()
        {
            Scene ourScene = SceneManager.GetActiveScene();
            Scene newScene = SceneManager.CreateScene("Scenic");
            GameObject[] gos = ourScene.GetRootGameObjects();
            foreach (GameObject g in gos){SceneManager.MoveGameObjectToScene(g, newScene);}
        }






        //public static UnityEngine.Object[] 
        //              Map(this List<UnityEngine.Object> toMap,
        //                  Action<UnityEngine.Object> doMap)
        //{
        //    UnityEngine.Object[] transformed = toMap.ToArray();
        //    for (int i = 0; i < transformed.Count(); i++)
        //    {
        //        transformed[i] = doMap(transformed[i]);
        //    }
        //    return () => {
        //        return transformed;
        //    };
        //}

        //public static Transform[] GetRoots()
        //{
        //    Scene ourScene = SceneManager.GetActiveScene();
        //    GameObject[] gos = ourScene.GetRootGameObjects();
        //    return Map(gos, p => p = transform);
        //}



//public static void ForEach<T>(this IEnumerable<T> value, Action<T> action)
//{
//  foreach (T item in value)
//  {
//    action(item);
//  }
//}





    }//class
}//name

        //test(U.pDTgt0);
        //test(U.pDTnewMinute);
        //test(U.pDTnewHour);
        //test(U.pDTnewDay);

        //test2(U.pIsMinute);
        //test2(U.pNewHour);
        //test2(U.pNewDay);
        //test2(U.pNow);
       