using System;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

using basil.util;
using basil.patterns;
[AddComponentMenu("Singletons/GameMgr")]
public class GameMgr : Singleton<GameMgr>
{
    protected GameMgr() { }

    public static bool dump = false;
    public static Transform root;
    public  Transform rootOfTime;


    // these are configurable and added in the unity inspector

    //public Transform canvas;

    int timeLineId = 0;
    Vector3 beginPosition;


    //void Awake()
    //{
    //    U.Log("The game is on!");

    //    GameManager gmInstance = GameManager.Instance;
    //}

    void Start(){
        //root = transform; 
        
        
            //MakeTime mt =  MakeTime.Instance;            
            //mt.ReStart(1);
            
            //U.Log("root " + mt.getRootOfTime());
            //IEnumerable<GameObject> gos =     mt.GetGO(U.isDTtoday);
            //U.Log("Count :" + gos.Count() + " " + gos.First().name + " to " + gos.Last().name);

        
        

    }

    
    
 


}
