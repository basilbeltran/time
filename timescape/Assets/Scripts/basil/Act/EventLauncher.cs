using System;

using basil.util;
using basil.patterns;
using UnityEngine;



namespace action {
public class EventLauncher : BasicBehaviour  {
        
        static bool awake = false;
        public Rigidbody flinger;
        bool moved = false;
        
        int OnEnableCounter = 0;
        int OnApplicationPauseCounter = 0;
        int FixedUpdateCounter = 0;
        int UpdateCounter = 0;
        int LateUpdateCounter = 0;
        int OnPreCullCounter = 0;
        int OnBecameVisibleCounter = 0;
        int OnBecameInvisibleCounter = 0;
        int OnWillRenderObjectCounter = 0;
        int OnPreRenderCounter = 0;
        int OnRenderObjectCounter = 0;
        int OnPostRenderCounter = 0;
        int OnRenderImageCounter = 0;
        int OnGUICounter = 0;
        int OnDrawGizmosCounter = 0;
        int OnDestroyCounter = 0;
        int OnDisableCounter = 0;
    
        Func<int, bool>[] every;     
  
    public void Awake() {   
            awake = true;
            InvokeRepeating("MySecond", 1, 1); 
            every = U.MakeMods(10);
            if (dump) U.Log("Test passed: " + Test() );            
            }
            
    public void Start() {   flinger = (Rigidbody)Resources.Load("prefab/textile"); }

    
    public void MySecond() {
            DateTime now = DateTime.Now.Neuter();
            Intervals(now);
            
            
    }
    
     public void Intervals(DateTime _dt)
    {
        //identifying the "top of the day/hour/minute."
        if (_dt.Hour == 0 && _dt.Minute == 0 && _dt.Second == 0)    OnDay(_dt); 
        if (_dt.Minute == 0 && _dt.Second == 0)                     OnHour(_dt);
        if (_dt.Second % 15 ==0)                                    On15(_dt);
        if (_dt.Second % 5 ==0)                                     On5(_dt);        
        if (_dt.Second == 0)                                        OnMinute(_dt);

    }

    public void OnDay(DateTime _dt)     { }
    public void OnHour(DateTime _dt)    { }
    public void On15(DateTime _dt)      { }
    public void On5(DateTime _dt)       { }
    public void OnMinute(DateTime _dt)  { }
    public void MySecond(DateTime _dt)  { }


    public void OnMouseEnter()  { U.LData("holder", gameObject); }
    public void OnMouseExit()   { U.LData("holder", gameObject); }
    public void OnMouseDown()   {U.LData("", gameObject); }
    public void OnMouseUp()     {  U.LData("", gameObject);}
    public void OnTriggerEnter(Collider other) {}
    public void OnTriggerStay(Collider other) {}
    public void OnTriggerExit(Collider other) {}

        void OnDrawGizmos() {
            Func<int, bool> mod9 = every[9];
            bool aBool = mod9(OnDrawGizmosCounter);
             if(aBool) Fling("OnDrawGizmos", Color.blue, 12);              
        }

        void OnApplicationPause() {
             Fling("OnApplicationPause", Color.red, 50);
        }               
        
        void FixedUpdate() {
            FixedUpdateCounter++;
            if( every[9](FixedUpdateCounter)) Fling("FixedUpdate", Color.black, 50);
        }
            
        void Update() {
            UpdateCounter++;
           if( every[9](UpdateCounter)) Fling("Update", Color.blue, 50);
        }
        
        void LateUpdate() {
            LateUpdateCounter++;
            if( every[9](LateUpdateCounter)) Fling("LateUpdate", Color.red, 12);
        }
        
        void OnPreCull() {
            OnPreCullCounter++;
            if( every[1](OnPreCullCounter)) Fling("OnPreCull", Color.white, 5);
        }
        
        
        void OnBecameVisible() {
            OnBecameVisibleCounter++;
            if( every[1](OnBecameVisibleCounter)) Fling("OnBecameVisible", Color.yellow, 20);
        }
        
        void OnBecameInvisible() {
             OnBecameInvisibleCounter++;
            if( every[1](OnBecameInvisibleCounter)) Fling("OnBecameInvisible", Color.white, 20);
        }
        
        
        void OnWillRenderObject() {
            OnWillRenderObjectCounter++;
            if( every[1](OnWillRenderObjectCounter)) Fling("OnWillRenderObject", Color.yellow, 4);
        }
        void OnPreRender() {
            OnPreRenderCounter++;
            if( every[1](OnPreRenderCounter))    Fling("OnPreRender", Color.green, 8);
        }
        void OnRenderObject() {
            OnRenderObjectCounter++;
            if( every[1](OnRenderObjectCounter))    Fling("OnRenderObject", Color.red, 12);
        }
        void OnPostRender() {
            OnPostRenderCounter++;
            if( every[1](OnPostRenderCounter))  Fling("OnPostRender", Color.black, 15);
        }

        void OnRenderImage(RenderTexture src, RenderTexture dest)
        {
            OnRenderImageCounter++;
            Graphics.Blit(src, dest, null);
        
            if( every[1](OnRenderImageCounter))  Fling("OnRenderImage", Color.red, 30);
        }


        void OnGUI() {
            OnGUICounter++;
            if( every[9](OnGUICounter))  Fling("OnGUI", Color.green, 6);
        }

        void OnDestroy() {
            OnDestroyCounter++;
            bool aBool = every[1](OnDestroyCounter);
            if(aBool) Fling("OnDestroy", Color.red, 50);
        }
        void OnDisable() {
            OnDisableCounter++;
            //if( every[1](OnDisableCounter)) 
            Fling("OnDisable", Color.red, 50);
        }

        void OnEnable() {
            OnEnableCounter++;
            if( every[1](OnEnableCounter)) Fling("OnEnable", Color.green, 100);
        }

        public void Fling(string _text, Color _c, int size) {
            Rigidbody clone = Instantiate(
            flinger, 
            transform.position, 
            transform.rotation, 
            transform);
            
            TextMesh tm = clone.GetComponent < TextMesh > ();
            tm.color = _c;
            tm.text = _text;
            tm.fontSize = size;
            clone.gameObject.SetActive(true);
            clone.velocity = transform.TransformDirection(Vector3.up * size);

        }



        public void Listen < T > (T message) {
            if (message.ToString() == "open") {
                U.Log(message.ToString() + "MESSSAGE OPEN");
                // doit.call.explode();
            }
        }

        public void OnSignal < Signal > (Signal message) {
            U.Log(message.ToString());
        }

        void print()
        {
            string s = "";
            s += "asdf";
            s += "\n OnEnableCounter  : \t "                + OnEnableCounter             + " ";
            s += "\n OnApplicationPauseCounter  : \t "      + OnApplicationPauseCounter   +" ";            
            s += "\n FixedUpdateCounter  : \t "             + FixedUpdateCounter          +" ";
            s += "\n UpdateCounter  : \t "                  + UpdateCounter               +" ";
            s += "\n LateUpdateCounter  : \t "              + LateUpdateCounter           +" ";
            s += "\n OnPreCullCounter  : \t "               + OnPreCullCounter            +" ";
            s += "\n OnBecameVisibleCounter  : \t "         + OnBecameVisibleCounter      +" ";
            s += "\n OnBecameInvisibleCounter  : \t "       + OnBecameInvisibleCounter    +" ";
            s += "\n OnWillRenderObjectCounter  : \t "      + OnWillRenderObjectCounter   +" ";
            s += "\n OnPreRenderCounter  : \t "             + OnPreRenderCounter          +" ";
            s += "\n OnRenderObjectCounter  : \t "          + OnRenderObjectCounter       +" ";
            s += "\n OnPostRenderCounter  : \t "            + OnPostRenderCounter         +" ";
            s += "\n OnRenderImageCounter  : \t "           + OnRenderImageCounter        +" ";
            s += "\n OnGUICounter  : \t "                   + OnGUICounter                +" ";
            s += "\n OnDrawGizmosCounter  : \t "            + OnDrawGizmosCounter         +" ";
            s += "\n OnDestroyCounter  : \t "               + OnDestroyCounter            +" ";
            s += "\n OnDisableCounter  : \t "               + OnDisableCounter            +" ";
        }





            //switch (level)
            //{
            //    case "0":
            //        UnityEngine.Debug.Log(TimeFactory.t() 
            //                              + "-" + ClassMethodString(4) 
            //                              + "\n" + message);
            //        break;

            //    case "1":
            //        UnityEngine.Debug.LogError(message);

            //        break;

            //    case "2":
            //        UnityEngine.Debug.LogWarning(message);

            //        break;

            //    case "3":
            //UnityEngine.Debug.Log(TimeFactory.t() 
            //                              + "-" + ClassMethodString(4) 
            //                              + "\n" + message
            //                              + "\n" + obj.Status());
              
            //        break;

            //    default: break;
            //}










        public void ToggleActive() {
            gameObject.SetActive(!gameObject.activeSelf);
        }

        public void ShowMe() {

            gameObject.SetActive(true);
            gameObject.SetActive(true);

        }

        public bool GetMoved() {
            return moved;
        }



    } //class
} //name