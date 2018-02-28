using System;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

namespace time
{

    public class GameManager
    {
        public static bool dump = true;

        private static GameManager _instance;
        public MakeTime mt;
        public GameController controller;



        public Transform rootOfTime;

        public Transform hour;
        public Transform minute;
        public Transform second;
        public Transform clock;


        private GameManager() { }

        public static GameManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    U.Log("GameManager Instance initialization");

                    _instance = new GameManager();
                }
                return _instance;
            }
        }

        public void MakeGame()
        {


            mt = MakeTime.Instance;
            mt.Start();
            if (dump) Test();
        }

        public MakeTime getDic() { return mt; }

        public void holdThis(GameController gc) { controller = gc; }
        public void Stop() { controller.Stop(); }
        public void Test()
        {

        }
    }//class
}
