
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using basil.patterns ;
using basil.util;
using System.Diagnostics;
using System.Linq;


namespace time
{

    //// Exists to manage a Dictionary of TimeObj keyed by DateTime currently one per scene

    public class MakeTime : BasicBehaviour
    {
        bool dump = false;
        public static SortedDictionary<DateTime, TimeObj> timeObjDictionary;
        public SortedDictionary<DateTime, TimeObj>.ValueCollection allSecs;
        public SortedDictionary<DateTime, TimeObj>.KeyCollection allDates;

        Stopwatch timer;
        DateTime lastProcessedStamp;
        TimeObjFactory tof = null;

        bool first = true;
        bool deferred = true;

        public static List<TimeObj> holdingTank1 = new List<TimeObj>();
        public static List<TimeObj> holdingTank2 = new List<TimeObj>();


        private static MakeTime _instance;


        private MakeTime()
        { }


        public static MakeTime Instance
        {
            get
            {
                if (_instance == null)
                    U.Log("issuing new MakeTime singleton");
                _instance = new MakeTime();
                return _instance;
            }
        }



        public void SetDefered(bool tf)
        {
            deferred = tf;
        }

        public SortedDictionary<DateTime, TimeObj> getDict()
        {
            return timeObjDictionary;
        }


        public void Start()
        {
             StartNow(2);
            // StartFullDay();
            // runTests();
        }

        public void ReStart()
        {
            StopTime();
            Start();
        }

        public void StartFullDay()
        {
            Start(DateTime.Today, DateTime.Today.AddHours(24));
        }

        // start now add these hours
        public void StartNow(int hours)
        {
            Start(DateTime.Now, DateTime.Now.AddHours(hours));

        }

        public void StopTime()
        {
            first = true;
            allSecs = null;
            timeObjDictionary = null;
        }


        public void Start(DateTime startTime, DateTime endTime)
        {
            startTime = startTime.PreviousHour();
             U.Log("Beginning at ... " + startTime.Dump());
             
            if (tof == null) tof = new TimeObjFactory(deferred); 
            U.Log(" defered: " + deferred.ToString()
                + "\n start: " + startTime.ToString()
                + "\n end: " + endTime.ToString()
            );


            if (first)
            {

                timeObjDictionary = new SortedDictionary<DateTime, TimeObj>();
                lastProcessedStamp = startTime;
                FillTimeObjDictionary(startTime, endTime);
            }
            else
            {
                U.Log("you want more time?  Use AddTime()");
            }

        }




        //  IEnumerator FillTimeObjDictionary(DateTime start, DateTime end)
        public void FillTimeObjDictionary(DateTime start, DateTime end)
        {


            timer = Stopwatch.StartNew();
            DateTime now = DateTime.Now;

            U.Log("Filling ...  " + Math.Floor(U.ElapsedFunc(start, end).TotalSeconds));


            while (timeObjDictionary.Count < U.ElapsedFunc(start, end).TotalSeconds)
            {
                TimeObj tos = tof.MakeTimeObj(lastProcessedStamp);

                //Neuter flatens the Ticks to make dt == dt comparison faster
                timeObjDictionary.Add(lastProcessedStamp.Neuter(), tos);

                if (first)
                {
                    first = false;
                }

                lastProcessedStamp = lastProcessedStamp.AddSeconds(1);


            }
            allSecs = timeObjDictionary.Values;
            allDates = timeObjDictionary.Keys;

            timer.Stop();
            DateTime then = DateTime.Now;
            U.Log("Timing ...  " + U.ElapsedFunc(now, then).TotalSeconds);
            U.Log("FillTimeObjDictionary w " + allSecs.Count
                  + " in " + timer.Elapsed.Seconds.ToString());



            //configGameObjects();
            //runTests();
            ToToToTo(U.pIsDay, U.aDump, U.aActDayDown);
            U.ActivateHoursUp();


        }

        /// <summary>
        /// ////////////
        /// </summary>

        public static void runTests()
        {

            TimeObj to = new TimeObj(DateTime.Now);
            to.MakeMyDay(true);


            //U.aLevel(8);       
            ToToToTo(U.pIsDay, U.aDump, U.aActDayDown);
        }






        public void configGameObjects()
        {
            GameObject go = GameObject.FindGameObjectWithTag("static");
            ArrayList al = go.GetAllChildren();
            int count = 0;
            foreach (GameObject g in al)
            {
                count++;
                try
                {
                    //g.GetComponent<Me>().enabled = false;
                }
                catch (Exception ex)
                {
                    U.Log(ex.ToString());
                }
            }
            U.Log("static children Count " + count);
        }




        public static void testPredDT(Predicate<DateTime> pdt)
        {
            try
            {
                var retVal =
                     from x in timeObjDictionary
                     where pdt(x.Key)
                     select x.Value;

                U.Log("TEST Count :" + pdt.ToString() + " " + retVal.Count());


            }
            catch (Exception ex)
            {
                U.Log(ex.ToString());
            }
        }




        public static void testPredTO(Predicate<TimeObj> pdt)
        {
            try
            {
                var retVal =
                     from x in timeObjDictionary
                     where pdt(x.Value)
                     select x.Value;

                U.Log("TEST Count :" + pdt.ToString() + " " + retVal.Count());


            }
            catch (Exception ex)
            {
                U.Log(ex.ToString());
            }
        }

        public static void test3(Predicate<TimeObj> pdt, Action<TimeObj> act)
        {
            //int i =0;
            //while (i < 10)
            //{
            //i++;
            try
            {
                var retVal =
                     from x in timeObjDictionary
                     where pdt(x.Value)
                     select x.Value;
                List<TimeObj> tos = retVal.ToList();
                tos.ForEach(act);
                U.Log("TEST Count :" + act.ToString() + " " + retVal.Count());

                //System.Threading.Thread.Sleep(1000);

            }
            catch (Exception ex)
            {
                U.Log(ex.ToString());
            }
            //}
        }



        public void check(DateTime dt)
        {


            U.Log("\nEvents :" + timeObjDictionary[dt].Events.Count
                 + "\n GOs :" + timeObjDictionary[dt].m_GameObjects.Count
                 + "\n Contacts :" + timeObjDictionary[dt].m_Contacts.Count
                 );
        }




        //*********************************//INFORMATION
        //*********************************//INFORMATION
        //*********************************//INFORMATION
        //*********************************//INFORMATION


        public bool HasEvent(DateTime dt)
        {
            return timeObjDictionary[dt].Events.Count > 0;
        }





        //**************************  TIME OBJECTS <<< DateTime *********************


        //use DateTime key directly
        public TimeObj
    OneToDt(DateTime dt)
        {
            return timeObjDictionary[dt];
        }



        //Func will evaluate PK only

        public static IEnumerable<TimeObj>
    ToDt(Predicate<DateTime> fun)
        {

            var retVal =
                     from x in timeObjDictionary
                     where fun(x.Key)
                     select x.Value;

            List<TimeObj> tos = retVal.ToList();
            U.Log(tos.Count + " DateTime.Now.Neuter()   " + tos.First().Dump());
            return retVal;
        }



        // with an action   
        public IEnumerable<TimeObj>
ToDtAct(
           Predicate<DateTime> pred,
           Action<TimeObj> act)
        {
            var retVal =
                     from x in timeObjDictionary
                     where pred(x.Key)
                     select x.Value;
            List<TimeObj> tos = retVal.ToList();
            tos.ForEach(act);

            return retVal;
        }


        //list
        public List<TimeObj>
        ToDtActList(
                   Predicate<DateTime> pred,
                   Action<TimeObj> act)
        {
            var retVal =
                     from x in timeObjDictionary
                     where pred(x.Key)
                     select x.Value;
            List<TimeObj> tos = retVal.ToList();
            tos.ForEach(act);

            return retVal.ToList();
        }





        //**************************  TIME OBJECTS <<< DateTime *********************

        //Func will evaluate PK only
        public IEnumerable<TimeObj>
    ToTo(Predicate<TimeObj> fun)
        {

            var retVal =
                     from x in timeObjDictionary
                     where fun(x.Value)
                     select x.Value;

            return retVal;
        }




        //**************************  TIME OBJECTS <<< DateTime *********************




        public static List<TimeObj>                            //**************** RETURN 
     ToToTo(
                Predicate<TimeObj> pred,
                Action<TimeObj> act)
        {
            List<TimeObj> tos = null;
            try
            {
                var retVal =
                         from x in timeObjDictionary
                         where pred(x.Value)
                         select x.Value;
                tos = retVal.ToList();
                tos.ForEach(act);
                U.Log("OKO");
            }
            catch (Exception ex)
            {
                U.Log("" + ex.ToString());
            }
            return tos;
        }









        public static List<TimeObj>                            //**************** RETURN 
     ToDtTo(
                Predicate<DateTime> pred,
                Action<TimeObj> act)
        {
            List<TimeObj> tos = null;
            try
            {
                var retVal =
                         from x in timeObjDictionary
                         where pred(x.Key)
                         select x.Value;
                tos = retVal.ToList();
                tos.ForEach(act);

            }
            catch (Exception ex)
            {
                U.Log("" + ex.ToString());
            }
            return tos;
        }

        public static List<TimeObj>
    ToToToTo(
                Predicate<TimeObj> pred,
                Action<TimeObj> log,
                Action<TimeObj> act)
        {
            var retVal =
                from x in timeObjDictionary
                where pred(x.Value)
                select x.Value;
            List<TimeObj> tos = retVal.ToList();
            tos.ForEach(act);
            tos.ForEach(log);

            return tos;
        }
























        public void
          TEST(
              Predicate<TimeObj> pred,
              Action<TimeObj> act)
        {
            //U.Log(          pred.ToString() 
            //+ "/" + act.ToString()
            //+"\n+ "+ from x in timeObjDictionary
            //+"\n+ "+ (from y in timeObjDictionary  where pred(y.Value ).ToString
            //+"\n+ "+ from x in timeObjDictionary  where pred(x.Value) select x.Value
            //);
            var retVal =
                     from x in timeObjDictionary

                     select x.Value;
            retVal.ToList().ForEach(act);
        }






        //will evaluate TimeObj only; 
        public IEnumerable<TimeObj>
        GetValue(Predicate<TimeObj> fun)
        {
            var retVal =
                     from x in timeObjDictionary
                     where fun(x.Value)
                     select x.Value;
            return retVal;
        }



        public IEnumerable<TimeObj>
        GetValue(DateTime dt,
                 Predicate<DateTime> fun)
        {
            var retVal =
                     from x in timeObjDictionary
                     where fun(x.Key)
                     select x.Value;
            return retVal;
        }



        public IEnumerable<TimeObj>
        GetValue(DateTime dt, Func<DateTime, DateTime, bool> fun)
        {
            var retVal =
                     from x in timeObjDictionary
                     where fun(x.Key, dt)
                     select x.Value;
            return retVal;
        }

        //**************************  GetType *********************


        public IEnumerable<EtcMgr.TimeType>
        GetType(Predicate<DateTime> fun)
        {
            var retVal =
                     from x in timeObjDictionary
                     where fun(x.Key)
                     select x.Value.m_TimeType;
            return retVal;
        }

        //**************************  GAME OBJECTS *********************



        //Func will evaluate PK only
        public IEnumerable<GameObject>
        GetGO(Predicate<DateTime> fun)
        {

            var retVal =
                     from x in timeObjDictionary
                     where fun(x.Key)
                     select x.Value.m_Transform.gameObject;
            return retVal;
        }



        //will evaluate TimeObj only; 
        public IEnumerable<GameObject>
        GetGO(Predicate<TimeObj> fun)
        {
            var retVal =
                     from x in timeObjDictionary
                     where fun(x.Value)
                     select x.Value.m_Transform.gameObject;
            return retVal;
        }



        public IEnumerable<GameObject>
        GetGO(DateTime dt, Predicate<DateTime> fun)
        {
            var retVal =
                     from x in timeObjDictionary
                     where fun(x.Key)
                     select x.Value.m_Transform.gameObject;
            return retVal;
        }



        public IEnumerable<GameObject>
        GetGO(DateTime dt, Func<DateTime, DateTime, bool> fun)
        {
            var retVal =
                     from x in timeObjDictionary
                     where fun(x.Key, dt)
                     select x.Value.m_Transform.gameObject;
            return retVal;
        }













        //*********************************//ACTIONS

        public void DoSomething()
        {
            foreach (KeyValuePair<DateTime, TimeObj> kvp in timeObjDictionary)
            {
                if (kvp.Key.Second == 0)
                {
                    kvp.Value.m_Transform.gameObject.SetActive(true);
                }
            }
        }

        public void
        testPredicate()
        {

            //where fun(x.Key)
            //select x.Value.m_Transform.gameObject;
            U.Log("count:" + timeObjDictionary.Count.ToString());

        }




        //**************************  GAME OBJECTS <<< DateTime *********************

        // gameObject for a date
        public GameObject
      GetGO(DateTime dt)
        {
            return timeObjDictionary[dt].m_Transform.gameObject;
        }





    }
}
