using UnityEngine;
using System.Collections;
using basil.util;

namespace time
{

    public class GameController : MonoBehaviour
    {
        //Create a local reference so that the editor can read it.
        public GameManager gameManager;


        void Awake()
        {
            U.LData("the gameObject holds GameController" , gameObject);
            U.gm = gameObject;          
            gameManager = GameManager.Instance;
            U.LData("gameManager starting", this);
            gameManager.holdThis(this);
            GameObject go = GameObject.FindWithTag("static");
            U.LData(go.name, go);
 
            //ExtGameObject.Dump(go); // thats wierd 

            gameManager.MakeGame();
        }


        //public void Test(){
        //    gameManager.Test();
        //}

        public void Stop()
        {
            U.Log("gameManager stopping");

            MakeTime mt = MakeTime.Instance;
            mt.StopTime();
            DestroyImmediate(gameManager.rootOfTime.gameObject);
        }

        public static void TheEnd(Transform root)
        {
            foreach (Transform t in root)
            {
                DestroyImmediate(t.gameObject);
            }
        }

    }
}