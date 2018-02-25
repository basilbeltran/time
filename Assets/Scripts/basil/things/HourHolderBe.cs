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
    public class MinuteHolderBe : MonoBehaviour, ISignalListener
    {

        public  bool dump = true;
        public DateTime mytime;
        
        
        private bool moved = false;
        private bool colorChanged = false;
        public GameObject shape;
        public MinuteFormBe doit;
        private MinuteHolderBe me;
        public TimeObj timeObject = null;
        public TimeObjMinute tom;
        public float red;
        public float green;
        public float blue;
        public float alpha;
        

        
        private void Awake()
        {

        }

        void Start()
        {
            me = GetComponent<MinuteHolderBe>();
            shape = transform.GetChild(0).gameObject;
            doit = shape.GetComponent<MinuteFormBe>();
            //if (dump) gameObject.Dump();
        }

        private void Update()
        {
            
        }

        public void Register(TimeObj to)
        {
            timeObject = to;
        }

        public void Init(TimeObjMinute _tom)
        {
            tom = _tom;
            U.Log("AAAAAAAAAAA " + tom.ToString());
        }

        public void setDateTime(DateTime _dt)
        {

            this.mytime = _dt;
        }
        
        //very hacky as this minute isnt guaranteed to exist
        //  ////if(U.pThisVeryMoment.Invoke(timeObject.m_Date)) timeObject.OnSecond(dt);

        void OnSecond(DateTime dt)
        {
            //// limit log message to the first minute holder instance
            
            
            
            if (  U.pDTzeroSec.Invoke( dt  ) && U.pDTthisVeryMoment.Invoke(mytime )) timeObject.OnSecond(mytime);
            
            try
            {
            // the time must be "on the minute" and match 
            if (  U.pDTzeroSec.Invoke( dt  ) && U.pDTthisVeryMoment.Invoke(mytime )) test(dt);

                 
            }
            catch (Exception ex)
            {
                U.Log("  " + ex.ToString());
            }

        }


        void test(DateTime _dt)
        {

        U.Log(" mytime TVM is " +     U.pDTthisVeryMoment.Invoke(mytime).ToString() 
       + "  \n  pDTisDay is " +      U.pDTisDay.Invoke(_dt).ToString() 
       + "  \n pDTtoday is " +      U.pDTtoday.Invoke(_dt).ToString()
       + "  \n pDTisHour is " +     U.pDTisHour.Invoke(_dt).ToString() 
       + "  \n  pDTzeroSec is " +    U.pDTzeroSec.Invoke(_dt).ToString() 
       + "  \n  pDTminute is " +     U.pDTminute.Invoke(_dt).ToString() 
       + "  \n   pDTthisVeryMoment is " +     U.pDTthisVeryMoment.Invoke(_dt).ToString() 
       + "  \n   mytime TVM is " +     U.pDTthisVeryMoment.Invoke(mytime).ToString()     
       + "  \n   fDTmatchDate now is " +  U.fDTmatchDate.Invoke(_dt, DateTime.Now ).ToString() 
       + "  \n   fDTmatchDate now Neuter " +  U.fDTmatchDate.Invoke(_dt, DateTime.Now.Neuter() ).ToString() 
       + "  \n   fDTmatch AddSeconds(2) " +       U.fDTmatchSecond.Invoke(_dt, DateTime.Now.AddSeconds(2).Neuter() ).ToString()
       + "  \n   fDTmatch AddSeconds(-2)  is " +  U.fDTmatchSecond.Invoke(_dt, DateTime.Now.AddSeconds(-2).Neuter() ).ToString() 
       + "  \n   fDTmatchSecond now Neuter  " +   U.fDTmatchSecond.Invoke(_dt, DateTime.Now.Neuter()).ToString()
      
  );
       

        }
        

        void OnMouseDown()  { doit.call.explode(); }
        void OnMouseUp()    { doit.call.implode(); }
        


        void OnMouseEnter()   // from the minute, not second
        {
            if(dump ) U.Log(" Mouse Enter " + transform.GetChild(0).name );
 
                try
                {
                    timeObject.tom.InflateMySeconds();
                }
                catch (System.Exception ex)
                {
                    U.Log(ex.ToString());
                }           
          
        }
        
        void OnMouseExit() { 
            U.Log(" Mouse Exit " + transform.GetChild(0).name );
                         
                        
            try
            {
                timeObject.tom.DeflateMySeconds();
            }
            catch (Exception ex)
            {
                U.Log(ex.ToString());
            }

            }

        void OnTriggerEnter(Collider other)
        {
            ShowChildren();
        }

         void OnTriggerStay(Collider other)
        {

        }

         void OnTriggerExit(Collider other)
        {
            HideChildren();
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


        

        //all scene objects under management
        public void Yell(string method, System.Object o)
        {
            MessageMgr.Instance.Yell(method, o);
        }

        //siblings
        public void Say(string method, System.Object o)
        { 
            transform.parent.BroadcastMessage(method, o);
        }


        public void ToggleActive()
        {
            gameObject.SetActive(!gameObject.activeSelf);
            doit.ToggleActive();
        }

        public void ShowMe()
        {
           U.Log( "" + "MHB Showing " + gameObject.name );

            gameObject.SetActive(true);
            doit.gameObject.SetActive(true);
    
            doit.ShowMe();
            doit.ColorIt(234,234,234,34);
        }

        public void HideMe()
        {
            gameObject.SetActive(false);
            doit.HideMe();
        }


        public void ShowChildren()
        {
            //if (dump) gameObject.Dump();
            foreach (MinuteHolderBe m in U.GetComponentsInDirectChildren<MinuteHolderBe>(gameObject))
            {
                m.ShowMe();
            }

        }

        public void HideChildren()
        {
            foreach (MinuteHolderBe m in U.GetComponentsInDirectChildren<MinuteHolderBe>(gameObject))
            {
                m.HideMe(); 
            }
        }

        public GameObject SetColor(float red, float green, float blue, float alpha)
        {
            
            foreach (MinuteHolderBe m in U.GetComponentsInDirectChildren<MinuteHolderBe>(gameObject))
            {
                m.ShowMe();
                m.doit.ColorIt(red, green, blue, alpha);
                SetColorChildren(red, green, blue, alpha);
            }
            return gameObject;
        }

        public  void SetColorChildren(float red, float green, float blue,  float alpha)
        {
            foreach (MinuteHolderBe m in U.GetComponentsInDirectChildren<MinuteHolderBe>(gameObject))
            {

                this.red = red;
                this.green = green;
                this.blue = blue;
                m.ShowMe();
                m.doit.ColorIt(red, green, blue, alpha);
            }
        }


        public bool GetMoved()      { return moved;   }
        public void SetMoved(bool m){ this.moved = m; }








    }//class
}//name
