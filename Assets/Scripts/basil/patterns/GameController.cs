using UnityEngine;
using System.Collections;
using basil.util;


public class GameController: MonoBehaviour{
   //Create a local reference so that the editor can read it.
   public GameManager gameManager;

   
   void Awake(){
       U.Log("gameManager starting");
       gameManager = GameManager.Instance;
       gameManager.holdThis(this);
                   GameObject go = GameObject.FindWithTag("static");
            U.Log(go.name);
       //try
        //{

        //}
        //catch (System.Exception ex)
        //{
        //    U.Log(ex.ToString());
        //}
  
   gameManager.MakeGame();
   }
   
   
   //public void Test(){
   //    gameManager.Test();
   //}
   
   public void Stop()
   {
                U.Log("gameManager stopping");

                MakeTime mt =  MakeTime.Instance;
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