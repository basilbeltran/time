using UnityEngine;
using System.Collections;
using basil.util;
using System.Collections.Generic;
using System;
using basil.things;
using System.Reflection;
using System.Linq;
using UnityEditor;
namespace basil.util
{
  [ExecuteInEditMode]
    public class InEdit : MonoBehaviour
    {
        void Start() { } 
        void Update(){ }
        public SortedDictionary<DateTime, TimeObj> timeObjDictionary;

// The project is at a branch point, 
// Finish OO the timeObjects.
// delegate or manage?
// need messaging solution


        void OnEnable()
        {
            MakeTime mt;
            bool start = false;
            bool stop = false;
            bool test = true;

            if (start)
            {
                MakeTime dic = MakeTime.Instance;
                dic.StopTime();
                //mt.Start(DateTime.Today, DateTime.Today.AddHours(2));
                //mt.Start(DateTime.Now.AddHours(-2), DateTime.Now);
                //mt.ReStart(1, false);
                dic.ReStart();
//U.Log("ON ENABLE RUNNING :" + dic.GetGO(U.pDTAnyNewDay).Count());

            }


if (test)
{              
               //  MakeTime.ToDtTo(U.isnewMinute, U.aAllup );
               // MakeTime.ToDtTo(U.isnewMinute, U.aActHourDown );
   


}
            
            
                // IEnumerable<TimeObj> tos1 = mt.ToDtAct(U.fDTgt0,U.fToggleActive );
                //U.Log("Count :" + tos1.Count() + " " + tos1.First().Dump() + " to " + tos1.Last().Dump());


                 //  List<TimeObj> los = mt.ToDtActList(U.fDTgt0,U.fToggleActive );
                 //  U.Log("Count :" + los.Count());

                 //IEnumerable<TimeObj> tos2 = mt.ToDtAct(U.fDTnewMinute,U.fToggleActive );





                //if(mt != null)  mt.ToToTo(U.fNewMinute, U.fToggleActive);
               
              // IEnumerable<TimeObj> tos = mt.ToToTo(U.fNewMinute, U.fToggleActive); 
              
              //tos = mt.GetValue(U.fSecNow);
              //U.Log("Count :" + tos.Count() + " " + tos.First().m_GameObjects.ToString() + " to " + tos.Last().ADsecs);
                
                
                  //dic.ToDtTo(U.fDTnewHour, U.fToggleActive);
                
                //dic.ToDtTo(U.fDTnewDay, U.fToggleActive);

                //dic.ToDtTo(U.fToday, U.fToggleActive);
                //dic.ToToTo(U.fSecNow, U.fActiveUp);              
                
                
                
                
                
                //try
                //{
                //    dic.ToDtTo(U.fToday, U.fToggleActive);
                //}
                //catch (Exception ex)
                //{
                //    U.Log(ex.ToString());
                //}
                
                
                


         
            if (stop)
            {
            
                MakeTime dic = MakeTime.Instance;
                dic.StopTime();
                DestroyImmediate(GameManager.Instance.rootOfTime.gameObject);
        
            }
            
            
 
            
            
       }//enable
       
       
                     
        public void test1(Predicate<DateTime> pdt  )
    {
        try
        {
            var retVal =
                 from x in timeObjDictionary
                 where pdt(x.Key)
                 select x.Value;

            U.Log("TEST Count :" +pdt.ToString() +" "+ retVal.Count());          

            
        }
        catch (Exception ex)
        {
            U.Log(ex.ToString());
        }
    }
    
    
           public void test2( Predicate<TimeObj> pdt  )
    {
            try
        {
            var retVal =
                 from x in timeObjDictionary
                 where pdt(x.Value)
                 select x.Value;

            U.Log("TEST Count :" +pdt.ToString() +" "+ retVal.Count());          


        }
        catch (Exception ex)
        {
            U.Log(ex.ToString());
        }
    }
       
    }//class
}//name
            
            
            
            
            
            

            //IEnumerable<GameObject> 
            //GetGameObjects(DateTime dt, Func<DateTime, DateTime, bool> fun)
            //{ var retVal =
            //              from x in secDictionary
            //              where fun(x.Key, dt)
            //              select x.Value.m_Transform.gameObject;
            //    return retVal;
            //}
            //DateTime    KEY(zPosition)  Ktime  < - == + >  Qtime  VALUE    TimeObjSecond

            //https://msdn.microsoft.com/en-us/library/system.datetime_methods(v=vs.110).aspx                   DateTime.Compare(K,Q)


            //where   DateTime.Compare(DateTime.Now, p.StartDate) <= 0
            //where   DateTime.Now <= p.StartDate





            //TimeFactory.NowValues();
            //U.Log("The current gameObject "+ MakeTime.GetGO(DateTime.Now).name);


            //FUNCTIONAL PROJECT







                //testing    //isDTtoday isDTminute  isDThour


                //MakeTime mt = MakeTime.Instance; 
                //gos = MakeTime.Instance.GetGO(U.isDTnewHour);
                
                //GameManager.Instance.Test();
                //GameManager.Instance.Stop();



                //IEnumerable<GameObject> gos = mt.GetGO(U.isDTnewHour);
                //   foreach (GameObject go in gos)  go.toggleActive();


                //MakeTime mt = MakeTime.Instance; 

                //IEnumerable<TimeObj> tos = mt.GetValue(U.isSecNow);
                //foreach (TimeObj to in tos)  to.Dump();

                //******************************************
                //******************************************
                //******************************************
                //******************************************

                //U.Log("now " + TimeFactory.SecsSinceMidnight(DateTime.Now) );


        //mt.ChangeTObyValue(U.isSecNow, U.toggle); //isDTnewHour  //toggle
        
        //MakeTime.Instance.ChangeTObyVALUE(U.isSecNow, U.log, U.toggle); 





            
            
            

            


            //    IEnumerable<GameObject>
            //    gos2 =
            //        Impls.Map<GameObject, GameObject>
            //            (x => x.SetColor(.5f, .5f, .5f, .5f),
            //             MakeTime.GetAGameObjects(DateTime.Now, U.isDTtoday));

            //    U.Log("Count :" + gos2.Count() + " " + gos2.First().name + " to " + gos2.Last().name);
            //}







///*
// * 
// * 
// * 
// * 
//* using Microsoft.CSharp;
//* CSharpCodeProvider
//* CompilerParameters
//* options.ReferencedAssemblies.Add("System.dll");
//* U.Log(" loc: "+typeof(EditorWindow).Assembly.Location);
//* /Applications/Unity2017/Unity.app/Contents/Managed/UnityEditor.dll
//*  /Users/basilbeltran/Desktop/ORGANIZED/unity2017/time/Library/ScriptAssemblies/Assembly-CSharp.dll
//* /Users/basilbeltran/Desktop/ORGANIZED/unity2017/time/Library/ScriptAssemblies
// * 
// * 
// * 
// * /


// linq project


//REFLECTION PROJECT
        
        //PropertyInfo[] properties = typeof(U).GetProperties();
        //foreach (PropertyInfo pi in properties) { U.Log(pi.Name + " " + pi.GetType().FullName); }

        //MethodInfo[] methods = typeof(U).GetMethods();
        //foreach (MethodInfo mi in methods) { U.Log(mi.Name + " " + mi.ReturnType); }

        //var type = result.CompiledAssembly.GetType("ImmediateWindowCodeWrapper");
        //lastScriptMethod = type.GetMethod("PerformAction", BindingFlags.Public | BindingFlags.Static);


// UTIL project






    ////a table or dictionary 
    //static Func<int, int> GetFunc(string name)
    //{
    //    switch (name)
    //    {
    //        case "weekByHours":

    //            break;

    //        default:
    //            return null;
    //            break;

    //    }
    //}


  //U.Log("GameManager RUNNING TEST");
        //try  // getting full values
        //{
        //    IEnumerable<TimeObj> tos = mt.GetValue(U.isDTtoday); //expect 3600 seconds
        //    U.Log("isDTtoday :" + tos.Count() + " " + tos.First().m_TimeType + " to " + tos.Last().Dump());

        //    tos = mt.GetValue(U.isDTnewDay);
        //    U.Log("isDTday :" + tos.Count() + " " + tos.First().m_TimeType + " to " + tos.Last().Dump());

        //    tos = mt.GetValue(U.isDTnewHour);
        //    U.Log("isDThour :" + tos.Count() + " " + tos.First().m_TimeType + " to " + tos.Last().Dump());

        //    tos = mt.GetValue(U.isDTnewMinute);
        //    U.Log("isDTminute :" + tos.Count() + " " + tos.First().m_TimeType + " to " + tos.Last().Dump());
        //}
        //catch (Exception ex) { U.Log(ex.ToString()); }


        //try
        //{
        //    IEnumerable<EtcMgr.TimeType>
        //      tps = mt.GetType(U.isDTtoday); //expect all entries
        //    U.Log("isDTtoday :" + tps.Count() + " " + tps.First().GetType().ToString() + " to " + tps.Last().ToString());
       
        
        //  }
        //catch (Exception ex) { U.Log(ex.ToString()); }
//////           var mt = MakeTime.Instance; MakeTime.Instance.ChangeTMbyVALUE(U.isSecNow, U.ActiveUp);
        //try
        //{

        //    //  tos = mt.GetValue(U.isSecNow); //expect one entries
        //    //U.Log("isSecNow :" + tos.Count() + " " + tos.First().m_Secs + " , " + tos.First().Dump());
        //    //U.Log("isSecNow :" + tos.Count() + " " + tos.First().m_TimeType + " to " + tos.Last().Dump());

        
        //  }
        //catch (Exception ex) { U.Log(ex.ToString()); }

