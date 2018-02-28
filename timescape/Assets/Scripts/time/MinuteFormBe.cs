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
    public class MinuteFormBe : BasicBehaviour
    {

        bool dump = false;

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
            //the ActionSet functions somewhat like an interface
            // here is the call from the holder... mFormBe.call.implode();
            // so whatever componant is assigned to "call" should have method implode
            // so this MinuteFormBe can change its behaviour over time by swaping ActionSets
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

        IEnumerator FadeOut()
        {
            for (float f = 1f; f >= 0; f -= 0.1f)
            {
                Color c = renderer.material.color;
                c.a = f;
                renderer.material.color = c;
                yield return null;
            }
        }


        public void ColorForm(Color c)
        {
            renderer.material.color = c;
        }







        public void ShowMe() { if (dump) U.Log("" + "MFB Showing " + gameObject.name); }


        public void HideMe() { }




        void SetMinutesColor(DateTime dt)
        {

            if (dt.Second % 2 == 0)
            {

                ColorForm(Color.black);
            }
            else
            {
                ColorForm(Color.white);

            }
        }




    }
}


