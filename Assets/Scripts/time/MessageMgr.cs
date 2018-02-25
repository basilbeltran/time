using System;

using UnityEngine;

using basil.util;
using basil.patterns;

public class MessageMgr : Singleton<MessageMgr>
{
    public Transform day, hour, minute, second, clock;
    public Transform gameRoot;
    protected MessageMgr() { }
    public bool dump = true;


    private void Start()
    {
        InvokeRepeating("Tick", 1, 1);
       // hour.Rotate(90, 0, 0);
    }




// The procedural model will identify the timeobjects responsible for handling
// the fact that its time for them to be in focus and manipulating them directly.

// The delegated model has every timeobject deciding how to react.
// Lets do this first. It could be cpu intensive, but easy to implement.
// It will also provide options for more behavior if things know what time it is.
// Could also extend MonoBehaviour to impliment interface "OnSecond"

// A compromise would be broadcasting a message to a subset of objects

    private void Tick()
    {
        //NEUTER will remove Ticks past the second signifigance
        U.now = DateTime.Now.Neuter();
       
       
       
        // Delegated implementations
        // Tell everything what time it is and let them react themselves
        Yell("OnSecond", U.now );
        
        
        
        // Top Down implementations
        // lookup the time in the dictionary and call into identified time object to react
        // U.Clock();
    }




    public void Router(string m)
    {

        if (dump && m.Length > 0) { U.Log("got an " + m); }

    }


    public void Yell(string method, System.Object o) // indirection for future messsage system
    {
        gameObject.BroadcastMessage(method, o);
    }



}