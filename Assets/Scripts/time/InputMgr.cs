using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

using basil.patterns;
using basil.util;

[AddComponentMenu("Singletons/InputMgr")]
public class InputMgr : Singleton<InputMgr>{
    protected InputMgr() { }


    public bool dump = false;

    void Awake()
    {
    }

	void Start () {
	}

    // (!leftShift ^ Input.GetKey(KeyCode.LeftShift));

    void Update()
    {

        float x = CrossPlatformInputManager.GetAxis("Horizontal");

        //clock.OnAxisX(x );
       // clock.OnAxisZ(CrossPlatformInputManager.GetAxis("Vertical") * Time.deltaTime * 100 );

        //if (Input.GetKeyDown("space"))

        var input = Input.inputString;
        var a = Input.touches;
        //foreach(Touch t in a) Debug.Log(" \n Touch: " + t.ToString() );

        switch (input)
        {
            case "0":
                TimeFactory.NowValues();
                break;

            case "1":
                TimeFactory.Normal();
                break;
           
            case "2":
                TimeFactory.Slower();
                break;

            case "3":
                TimeFactory.Faster();
                break;

            case "D":
                MessageMgr.Instance.Router(Input.inputString); //Dump();
                break;

            default:  
                //MessageMgr.Instance.Route(input);
                break;

         }

    }

}

