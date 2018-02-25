using System.Collections;
using System.Collections.Generic;
using basil.patterns;
using basil.things;

using UnityEngine;
using UnityEngine.Playables;



namespace basil.util
{
    public class BehSecond : MonoBehaviour, ISignalListener
    {

        public  bool dump = false;
        private bool moved = false;
        private bool colorChanged = false;
        public GameObject shape;
        private BehSecondForm formBehaviour;
        //private BehSecond me;
        private TimeObj timeNode = null;
        
        
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

        }

        void Start()
        {
            //me = GetComponent<Me>();
            shape = transform.GetChild(0).gameObject;
            formBehaviour = shape.GetComponent<BehSecondForm>();
            //if (dump) gameObject.Dump();
        }

        private void Update()
        {
            
        }

            //formBehaviour.ColorIt(red, green, blue, alpha);
            //SetColorChildren(red, green, blue, alpha);

        //void OnMouseDown() { U.Log("",gameObject); }
        //void OnMouseUp()   { U.Log("", gameObject); }
        //void OnMouseDown() { formBehaviour.call.explode(); }
        //void OnMouseUp() { formBehaviour.call.implode(); }
        
        
        //void OnMouseEnter() { U.Log("", gameObject); }
        //void OnMouseExit() { U.Log( gameObject); }
       //void OnMouseEnter() { me.formBehaviour.ColorIt(.5f, .5f, .5f, .5f); }
        //void OnMouseExit() { me.formBehaviour.Natural(); }


        void OnMouseEnter() 
        {
            U.Log(" Mouse Enter " + transform.GetChild(0).name );

            if (transform.GetChild(0).name == "minuteShape")
            {  //ur a min
                timeNode.InflateSeconds();
            }
            
            //ShowChildren(); 
            //SetColor(.1f,.1f,.1f,.1f); 
            
            
        }
        
        void OnMouseExit() {  
            U.Log(" Mouse EXit " + transform.GetChild(0).name );
                         
                         
            if (transform.GetChild(0).name == "minuteShape")
            {  //ur a min
                timeNode.DeflateSeconds();
            }

            ////HideChildren(); 
            //formBehaviour.Natural();
            //SetColor(.5f, .5f, .5f, .5f);  
            
            }

        void OnMouseDown() { U.LData("", gameObject); }
        void OnMouseUp() { U.LData("", gameObject); }
 
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
               // formBehaviour.call.explode();
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

        ////talk to yourself
        //public void Consider(System.Object o)
        //{
        //    SignalChain _chain = new SignalChain(transform);
        //    _chain.Send(o);
        //}

        ////no, dont wake sleeping kids
        //public void Whisper(System.Object o) 
        //{
        //    SignalChain _chain = new SignalChain(transform);
        //    _chain.Broadcast(o);
        //}

        ////ok... wake your sleeping kids
        //public void Speak(System.Object o)
        //{
        //    SignalChain _chain = new SignalChain(transform);
        //    _chain.DeepBroadcast(o);
        //}

        public void ToggleActive()
        {
            gameObject.SetActive(!gameObject.activeSelf);
            formBehaviour.ToggleActive();
        }

        public void ShowMe()
        {
           U.Log( "" + " Showing " + gameObject.name );

            gameObject.SetActive(true);
            formBehaviour = shape.GetComponent<BehSecondForm>();
            formBehaviour.gameObject.SetActive(true);
    
            formBehaviour.ShowMe();
            formBehaviour.ColorIt(234,234,234,34);
        }

        public void HideMe()
        {
            gameObject.SetActive(false);

        }


        public void ShowChildren()
        {
            //if (dump) gameObject.Dump();
            foreach (BehSecondForm m in U.GetComponentsInDirectChildren<BehSecondForm>(gameObject))
            {
                m.ShowMe();
            }

        }

        public void HideChildren()
        {
            foreach (BehSecondForm m in U.GetComponentsInDirectChildren<BehSecondForm>(gameObject))
            {
                m.HideMe(); 
            }
        }

        public GameObject SetColor(float red, float green, float blue, float alpha)
        {
            
            foreach (BehSecondForm m in U.GetComponentsInDirectChildren<BehSecondForm>(gameObject))
            {
                m.ShowMe();
                m.ColorIt(red, green, blue, alpha);
                SetColorChildren(red, green, blue, alpha);
            }
            return gameObject;
        }

        public  void SetColorChildren(float red, float green, float blue,  float alpha)
        {
            foreach (BehSecondForm m in U.GetComponentsInDirectChildren<BehSecondForm>(gameObject))
            {

                this.red = red;
                this.green = green;
                this.blue = blue;
                m.ShowMe();
                m.ColorIt(red, green, blue, alpha);
            }
        }


        public bool GetMoved()      { return moved;   }
        public void SetMoved(bool m){ this.moved = m; }








    }//class
}//name
