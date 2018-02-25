using System;
using System.Collections;
using System.Collections.Generic;


using UnityEngine;
using UnityEngine.Playables;

using basil.util;
using basil.things;

public class SecondFormBe : MonoBehaviour
{
    public bool dump = true;

    private Color startcolor;

    public Animation mashun;
    public Animator mator;
    public PlayableDirector mao;
    public ActionSet call; // must have definition of called methods
    new Renderer renderer;
    SecondHolderBe holderBe;
    public TimeObjSecond tos;
    
    void Awake()
    {
        renderer = GetComponent<Renderer>();
        holderBe = transform.parent.GetComponent<SecondHolderBe>();
        call = gameObject.AddComponent(typeof(ActionSet)) as ActionSet;
    }


    void Start()
    {

    }
    
           public void Init(TimeObjSecond _tos)
        {
            tos = _tos;
        }
        
        
    public DateTime getDateTime()
    {
        return holderBe.timeNode.m_Date;
    }
    
    

    void OnSecond(DateTime dt)
    {

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
        renderer.material.color = new Color(r,g,b,a);
    }

 
       public void Green()
    {
    renderer = GetComponent<Renderer>();
        renderer.material.color = new Color(.3f, .8f, .3f, .9f );
    }
    
        public void Blue()
    {
    renderer = GetComponent<Renderer>();
        renderer.material.color = new Color(.2f, .2f, .9f, .9f );
    }
    
        public void Red()
    {
    renderer = GetComponent<Renderer>();
        renderer.material.color = new Color(.9f, .2f, .2f, .9f );
    }
    
        public void Light()
    {
    renderer = GetComponent<Renderer>();
        renderer.material.color = new Color(1f, 1f, 1f, 1f );
    }
    
            public void Dark()
    {
    renderer = GetComponent<Renderer>();
        renderer.material.color = new Color(.1f, .1f, .1f, 1f );
    }
    
    
    
    public void ShowMe() { 
    
        gameObject.SetActive(true);
     }
    
    public void HideMe() { }
   

}


