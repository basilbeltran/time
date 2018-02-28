using System;
using System.Collections;
using System.Collections.Generic;


using UnityEngine;
using UnityEngine.Playables;
using basil.patterns;
using basil.Act;


namespace time
{

    //attached to the minute form, the minute hand of a clock
    public class DayFormBe : BasicBehaviour
    {

        private Color startcolor;

        public Animation mashun;
        public Animator mator;
        public PlayableDirector mao;
        public ActionSet call; // must have definition of called methods
        new Renderer renderer;
        MinuteHolderBe mhb;

        void Awake()
        {
            base.SetDump(true);
            renderer = GetComponent<Renderer>();
            mhb = transform.parent.GetComponent<MinuteHolderBe>();
            call = gameObject.AddComponent(typeof(ActionSet)) as ActionSet;
        }


        void Start()
        {


        }



        private void Update()
        {

        }




        // OnSecond is called from MessageMgr to all children
        void OnSecond(DateTime dt)
        {



        }







        public void ColorForm(Color c)
        {
            renderer.material.color = c;
        }



        public void ColorIt(float r, float g, float b, float a)
        {
            startcolor = renderer.material.color;
            renderer.material.color = new Color(r, g, b, a);

        }

        public void Green()
        {
            renderer.material.color = new Color(.3f, .8f, .3f, .9f);
        }

        public void Blue()
        {
            renderer.material.color = new Color(.2f, .2f, .9f, .9f);
        }

        public void Red()
        {
            renderer.material.color = new Color(.9f, .2f, .2f, .9f);
        }






        public void ShowMe() { if (dump) U.Log("" + "DFB Showing " + gameObject.name); }
        public void HideMe() { }

    }
}

