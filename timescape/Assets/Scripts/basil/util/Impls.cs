using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;

namespace basil.util   
{
    public static class Impls
    {


            public static IEnumerable<TResult>   
        Map<T, TResult>     (Func<T, TResult> func, IEnumerable<T> list)
                {
                    foreach (var i in list)
                                yield return func(i);
                }



            public static T                     
        Reduce<T, U>        (Func<U, T, T> func,    IEnumerable<U> list, T acc)
            {
                    foreach (var i in list)
                                acc = func(i, acc);

                                return acc;
             }



        public static void TestMap(List<int> arg)
        {
            var mapList = Map<int, int>(x => x + 2, arg);
            mapList.ToList<int>().ForEach(i => U.Log(i + " "));

            //return mapList.ToList<int>();

        }


        public static void testReduce(string[] args)
        {
            var testList = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Console.WriteLine(Reduce<int, int>((x, y) => x + y, testList, 0));
            //Console.ReadKey();
        }


        public static Func<int, int>    tripleMe      = x => x * 3;


 






        //public static Func<Tuple<string, float>> OnEvent(this Func<Event[]> f)
        //{
        //    //receive a message from the outside world...
        //    string s = "message"; //event message
        //    int t = 0; //timestamp event was received 
        //    return () => { return new Tuple<string, float>(s, t); };
        //}


        public static int HowMany(List<Transform> list)
        {
            int c = list.Count();
            U.Log(c.ToString());
            return c;
        }




    }//class
}//name

