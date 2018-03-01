using UnityEngine;
using basil.util;
using System;
using time; //todo fix this ..get TMSingleton out of time

namespace basil.patterns{


public class BasicBehaviour : MonoBehaviour
{
    public bool dump = false;
    public DateTime birthdate = DateTime.Now;
    public bool moved = false;

    public bool SetDump(bool tf){
        dump = tf;
        return  enabled;
    }

     public bool Test()
    {
 ;
            bool testPassed = true;
            
            
            
            return testPassed;
    }   


    public void Activate()
    {
        gameObject.SetActive(true);

    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }


    public void ToggleActive()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }
    
    
    

    void OnEnable()
    {
       // if (dump) U.Log(gameObject.name + " is ACTIVE " +gameObject.Status() );
    }

    void OnDisable()
    {
       // if (dump)  U.Log(gameObject.name + " is ACTIVE " + gameObject.Status());
    }
    
    public void SetMoved(bool m){ this.moved = m; }



        string LifeSpanStats()
        {
            string s = ""
                + " \n gameStart=\t"      + TMsingleton.gmStart.ToLongTimeString()  +"\t+0"  
                + " \n i started=\t"      + birthdate.ToLongTimeString()            +"\t+"+ TMsingleton.RunTime(birthdate) 
                + " \n now=\t"            + TMsingleton.TimeString()                +"\t+"+ TMsingleton.RunTime()
            ;
            return s;
        }
        
        

    void OnDestroy()
        {
            if (dump) U.Log("RIP " + LifeSpanStats() );
        }
    
    
    
  }  
}
    
    