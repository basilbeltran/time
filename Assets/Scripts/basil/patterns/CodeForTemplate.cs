using UnityEngine;
using System.Collections;

//https://gamedev.stackexchange.com/questions/116009/in-unity-how-do-i-correctly-implement-the-singleton-pattern


public class SomeClass : MonoBehaviour {
    private static SomeClass _instance;

    public static SomeClass Instance { get { return _instance; } }


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }
}

//using System;
//using Mono.CSharp;

//namespace REPLtest
//{
//    class MainClass
//    {
//        public static void Main (string[] args)
//        {
//            var r = new Report (new ConsoleReportPrinter ());
//            var cmd = new CommandLineParser (r);

//            var settings = cmd.ParseArguments (args);
//            if (settings == null || r.Errors > 0)
//                Environment.Exit (1);

//            var evaluator = new Evaluator (settings, r);

//            evaluator.Run("using System;");

//            int sum = (int) evaluator.Evaluate("1+2;");

//            Console.WriteLine ("The sum of 1 + 2 is {0}", sum);
//        }
//    }
//}