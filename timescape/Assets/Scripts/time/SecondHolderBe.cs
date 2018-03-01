using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using basil.util;

using UnityEngine;
using UnityEngine.Playables;



namespace time 

{
public class SecondHolderBe: MonoBehaviour, ISignalListener {
        public TimeObjSecond tos;
        public GameObject shape;
        public SecondFormBe formBe;
        public TimeObj timeNode = null;
        
        
        public bool dump = false;
        public DateTime mytime;
        private bool moved = false;
        private bool focus = false;
        bool flingish = true;

        public Rigidbody flinger;
        Func<int, bool> fMod;

        public void Register(TimeObj to) {
            timeNode = to;
        }

        private void Awake() {
            shape = transform.GetChild(0).gameObject;
            formBe = shape.GetComponent < SecondFormBe > ();
            
        }

        public void setDateTime(DateTime _dt) {

            this.mytime = _dt;
        }


        void Start() {
            U.Log(flinger.ToString() +" LOADED");
        }
        


// if this matches the current time, set flag display as appropriate
        void OnSecond(DateTime dt) {

            try {
            

                if (U.pDTthisVeryMoment.Invoke(this.mytime)) {
                    focus = true;
                    formBe.Light();

                } else {
                    focus = false;
                }
            } catch (Exception ex) {
                U.Log("  " + ex.ToString());
            }

        }


void OnMouseEnter() { U.LData("holder", gameObject); }
void OnMouseExit()  { U.LData("holder", gameObject); }


        void OnMouseDown() {
            U.LData("", gameObject);
        }
        void OnMouseUp() {
            U.LData("", gameObject);
        }

        void OnTriggerEnter(Collider other) {}

        void OnTriggerStay(Collider other) {

        }

        void OnTriggerExit(Collider other) {

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

        void OnApplicationPause() {
            if (focus && flingish) Fling("OnApplicationPause", Color.red, 12);
        }               
        
        void FixedUpdate() {

         if (focus && flingish) Fling("FixedUpdate", Color.black, 12);
        }
                
        void Update() {
            if (focus && flingish) Fling("Update", Color.blue, 24);
        }
        void mLateUpdate() {
            if (focus && flingish) Fling("LateUpdate", Color.blue, 12);
        }
        void OnPreCull() {
            if (focus && flingish) Fling("OnPreCull", Color.white, 12);
        }
        void OnBecameVisible() {
            if (focus && flingish) Fling("OnBecameVisible", Color.yellow, 6);
        }
        void OnBecameInvisible() {
            if (focus && flingish) Fling("OnBecameInvisible", Color.yellow, 12);
        }
        void OnWillRenderObject() {
            if (focus && flingish) Fling("OnWillRenderObject", Color.red, 4);
        }
        void OnPreRender() {
            if (focus && flingish) Fling("OnPreRender", Color.red, 8);
        }
        void OnRenderObject() {
            if (focus && flingish) Fling("OnRenderObject", Color.red, 12);
        }
        void OnPostRender() {
            if (focus && flingish) Fling("OnPostRender", Color.red, 15);
        }
        
        void OnRenderImage(RenderTexture src, RenderTexture dest)
        {
            Graphics.Blit(src, dest, null);
            if (focus && flingish) Fling("OnRenderImage", Color.red, 20);
        }


        void OnGUI() {
            if (focus && flingish) Fling("OnGUI", Color.blue, 6);
        }
        void OnDrawGizmos() {
            if (focus && flingish) Fling("OnDrawGizmos", Color.blue, 12);
        }
        void OnDestroy() {
            if (focus && flingish) Fling("OnDestroy", Color.green, 6);
        }
        void OnDisable() {
            if (focus && flingish) Fling("OnDisable", Color.green, 12);
        }

        void OnEnable() {
            if (focus && flingish) Fling("OnEnable", Color.green, 18);
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
        




        public void ToggleActive() {
            gameObject.SetActive(!gameObject.activeSelf);
            formBe.ToggleActive();
        }

        public void ShowMe() {

            gameObject.SetActive(true);
            formBe = shape.GetComponent < SecondFormBe > ();
            formBe.gameObject.SetActive(true);

            formBe.ShowMe();
            formBe.Dark();
        }

        public bool GetMoved() {
            return moved;
        }
        public void SetMoved(bool m) {
            this.moved = m;
        }


    } //class
} //name