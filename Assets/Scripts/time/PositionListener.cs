
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEditor;
//using basil.util;

//namespace basil.util
//{

//    [AddComponentMenu("Util/ReactToPosition")]
//    public class PositionReactor : MonoBehaviour
//    {
//        public bool dump = true;
//        Me me;
//        public bool reactToMover = false;
//        Animation ashun;
//        private void Awake()
//        {
//                me = GetComponent<Me>();
//                ashun = gameObject.GetComponent<Animation>();
//            U.Log("Animation " + ashun.clip.name);
//        }
//        // Use this for initialization
//        void Start(){

//        }

//        // Update is called once per frame
//        void Update()
//        {

//        }

//        //this method allows behaviour to be customized by the exact distance to (camera)
//        // but feedback is constant .... you can ignore triggerStay
//        public void BroadcastPosition(Vector3 mover)
//        {
//            var dist = Mathf.Abs(mover.z - transform.position.z);


//            if (dist < 2 && reactToMover)
//            {
//                U.Log("\n distance is less than 2" + dist);

//                //if(!ashun.isPlaying){
//                //    ashun.Play();
//                //}
//                //foreach (Transform t in transform) //include inactive
//                //{
//                //    if (t.name.Equals("second(clone)"))
//                //    {
//                //        UnityEngine.Debug.Log("setting active" + t.gameObject.GetType() + " " + t.gameObject.name);
//                //        t.gameObject.SetActive(true);
//                //    }
//                //}
//            }
//        }




//    }
//}

