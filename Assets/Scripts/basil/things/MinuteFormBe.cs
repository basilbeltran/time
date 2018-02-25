using System;
using System.Collections;
using System.Collections.Generic;


using UnityEngine;
using UnityEngine.Playables;

using basil.util;

public class MeCanDoIt : MonoBehaviour
{
    public bool dump = true;

    private Color startcolor;

    public Animation mashun;
    public Animator mator;
    public PlayableDirector mao;
    public ActionSet call; // must have definition of called methods
    new Renderer renderer;
    BehSecond beh;

    void Awake()
    {

    }


    void Start()
    {
        renderer = GetComponent<Renderer>();
        beh = transform.parent.GetComponent<BehSecond>();
        call = gameObject.AddComponent(typeof(ActionSet)) as ActionSet;
    }

    public void SetActive(bool tf)
    {
        gameObject.SetActive(tf);

    }
    
            public void ToggleActive()
        {
            gameObject.SetActive(!gameObject.activeSelf);
        }

    //void OnMouseDown()  { U.LData("", gameObject); }
    //void OnMouseUp()    { U.LData("", gameObject); }
    //void OnMouseEnter() { U.LData("", gameObject); }
    //void OnMouseExit()  { U.LData("", gameObject); }

    public void ColorIt(float r, float g, float b, float a){
        renderer = GetComponent<Renderer>();
        startcolor = renderer.material.color;
        //Color c = new Color(.5f, .5f, .5f, .5f);
        //renderer.material.color = Color.red;
        renderer.material.color = new Color(r,g,b,a);

    }

    public void Natural()
    {
        renderer.material.color = startcolor;
    }

    public void ShowMe() { }
    public void HideMe() { }

}


