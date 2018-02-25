using System;
using System.Collections;
using System.Collections.Generic;
using basil.patterns;
using basil.things;

using UnityEngine;
using UnityEngine.Playables;



namespace basil.util
{
//the Holder and Form duo help to animate from a steady position ie: (0,0,0) 
    public class DayHolderBe : MonoBehaviour, ISignalListener
    {

        public  bool dump = true;
        public DateTime mytime;
        public GameObject shape;
        public DayFormBe doit;
        private DayHolderBe me;
        public TimeObj timeObject = null;
        public TimeObjDay tod;

        

        
        private void Awake()
        {

        }

        void Start()
        {
            me = GetComponent<DayHolderBe>();
            shape = transform.GetChild(0).gameObject;
            doit = shape.GetComponent<DayFormBe>();
            //if (dump) gameObject.Dump();
        }

        private void Update()
        {
            
        }

        public void Register(TimeObj to)
        {
            timeObject = to;
        }

        public void Init(TimeObjDay _tod)
        {
            tod = _tod;
            U.Log("AAAAAAAAAAA " + tod.ToString());
        }

        public void setDateTime(DateTime _dt)
        {

            this.mytime = _dt;
        }
        

        void OnSecond(DateTime dt)
        {

            
            // if (  U.pDTzeroSec.Invoke( dt  ) && U.pDTthisVeryMoment.Invoke(mytime )) timeObject.OnSecond(mytime);
            

        }


        void test(DateTime _dt)
        {
       

        }
        

        void OnMouseDown()  { doit.call.explode(); }
        void OnMouseUp()    { doit.call.implode(); }
        


        void OnMouseEnter()   // from the minute, not second
        {         
          
        }
        
        void OnMouseExit() { 

            }

        void OnTriggerEnter(Collider other)
        {

        }

         void OnTriggerStay(Collider other)
        {

        }

         void OnTriggerExit(Collider other)
        {

        }


        public void Listen<T>(T message)
        {
            if (message.ToString() == "open")
            {
                U.Log(message.ToString() + "MESSSAGE OPEN");
                doit.call.explode();
            }
        }

        public void OnSignal<Signal>(Signal message)
        {
            U.Log(message.ToString());
        }


        

        public void ShowMe()
        {
          if (dump) U.Log( "" + "DHB Showing " + gameObject.name );

            gameObject.SetActive(true);
            doit.gameObject.SetActive(true);    
            doit.ShowMe();
        }

        public void HideMe()
        {
            gameObject.SetActive(false);
            doit.HideMe();
        }


        public void ShowChildren()
        {
            //if (dump) gameObject.Dump();
            foreach (DayHolderBe m in U.GetComponentsInDirectChildren<DayHolderBe>(gameObject))
            {
                m.ShowMe();
            }

        }

        public void HideChildren()
        {
            foreach (DayHolderBe m in U.GetComponentsInDirectChildren<DayHolderBe>(gameObject))
            {
                m.HideMe(); 
            }
        }

        public GameObject SetColor(float red, float green, float blue, float alpha)
        {
            
            foreach (DayHolderBe m in U.GetComponentsInDirectChildren<DayHolderBe>(gameObject))
            {
                m.ShowMe();
                m.doit.ColorIt(red, green, blue, alpha);
                SetColorChildren(red, green, blue, alpha);
            }
            return gameObject;
        }

        public  void SetColorChildren(float red, float green, float blue,  float alpha)
        {
            foreach (DayHolderBe m in U.GetComponentsInDirectChildren<DayHolderBe>(gameObject))
            {
                m.ShowMe();
                m.doit.ColorIt(red, green, blue, alpha);
            }
        }

    }//class
}//name
