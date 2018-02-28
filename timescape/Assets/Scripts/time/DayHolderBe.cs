using System;
using System.Collections;
using System.Collections.Generic;
using basil.patterns;

using UnityEngine;
using UnityEngine.Playables;



namespace time
{
//the Holder and Form duo help to animate from a steady position ie: (0,0,0) 
    public class DayHolderBe : MonoBehaviour, ISignalListener
    {

        public  bool dump = true;
        public DateTime mytime;
        public GameObject shape;
        public DayFormBe formBe;
        public DayHolderBe me;
        public TimeObj timeObject = null;
        public TimeObjDay tod;

        

        
        private void Awake()
        {

        }

        void Start()
        {
            me = GetComponent<DayHolderBe>();
            shape = transform.GetChild(0).gameObject;
            formBe = shape.GetComponent<DayFormBe>();
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
        

        void OnMouseDown()  { formBe.call.explode(); }
        void OnMouseUp()    { formBe.call.implode(); }
        


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
                formBe.call.explode();
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
            formBe.gameObject.SetActive(true);    
            formBe.ShowMe();
        }

        public void HideMe()
        {
            gameObject.SetActive(false);
            formBe.HideMe();
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
                m.formBe.ColorIt(red, green, blue, alpha);
                SetColorChildren(red, green, blue, alpha);
            }
            return gameObject;
        }

        public  void SetColorChildren(float red, float green, float blue,  float alpha)
        {
            foreach (DayHolderBe m in U.GetComponentsInDirectChildren<DayHolderBe>(gameObject))
            {
                m.ShowMe();
                m.formBe.ColorIt(red, green, blue, alpha);
            }
        }

    }//class
}//name
