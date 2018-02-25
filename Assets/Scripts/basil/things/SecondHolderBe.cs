using System;
using System.Collections;
using System.Collections.Generic;
using basil.patterns;
using basil.things;

using UnityEngine;
using UnityEngine.Playables;



namespace basil.util
{
    public class SecondHolderBe : MonoBehaviour, ISignalListener
    {

        public  bool dump = false;
        public  DateTime mytime;
        private bool moved = false;
        private bool colorChanged = false;

        public TimeObjSecond tos;
        public GameObject shape;
        public SecondFormBe doit;
        //private BehSecond me;
        public TimeObj timeNode = null;
        
        
        public float red;
        public float green;
        public float blue;
        public float alpha;
        
        public void Register(TimeObj to)
        {
            timeNode = to;
        }
        
        private void Awake()
        {
            shape = transform.GetChild(0).gameObject;
            doit = shape.GetComponent<SecondFormBe>();
        }

        public void setDateTime(DateTime _dt)
        {

            this.mytime = _dt;
        }
        
        
        void Start()
        {

        }


        void OnSecond(DateTime dt)
        {
           
            try
            {
           
            if (  U.pDTthisVeryMoment.Invoke( this.mytime )  ) doit.Light();
                 
            }
            catch (Exception ex)
            {
                U.Log("  " + ex.ToString());
            }

        }
        
        private void Update()
        {
            
        }



        void OnMouseEnter() 
        {

            
        }
        
        void OnMouseExit() {  
  
  
            
            }

        void OnMouseDown() { U.LData("", gameObject); }
        void OnMouseUp() { U.LData("", gameObject); }
 
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
               // doit.call.explode();
            }
        }

        public void OnSignal<Signal>(Signal message)
        {
            U.Log(message.ToString());
        }



        public void ToggleActive()
        {
            gameObject.SetActive(!gameObject.activeSelf);
            doit.ToggleActive();
        }

        public void ShowMe()
        {

            gameObject.SetActive(true);
            doit = shape.GetComponent<SecondFormBe>();
            doit.gameObject.SetActive(true);
    
            doit.ShowMe();
            doit.Dark();
        }








        public bool GetMoved()      { return moved;   }
        public void SetMoved(bool m){ this.moved = m; }








    }//class
}//name
