//using System;
//using UnityEngine;
//using basil.util;

//namespace basil.patterns
//{
//    public class Signal
//    {

//        private Transform _root;

//        public Signal(Transform root)  // to send a signal(ROOT) requires a knowledge of the family hierarchy
//        {
//            _root = root;
//        }


//        public Signal signal { get; private set; }
//        DateTime created;
//        DateTime sent;
//        DateTime received;
//        Transform sentTransform;
//        Transform receivedTransform;
//        UnityEngine.Object data;
//        Me sender;
//        Me receiver;

//        public Signal(System.Object _data)
//        {
//            //TODO check if we are in unity world
//            data = (UnityEngine.Object)_data;
//            created = DateTime.Now;
//            //sentTransform = this.transform;
//        }
//    }
//}
////_chain = new SignalChain(root);  // what of targets created after this before Dispatch / 
////_chain.Broadcast("event");
////_chain.Broadcast(new BetterEvent(Color.green));

////_bubbleSignal = new BubbleSignal<Cube>(this.transform);
////_bubbleSignal.Dispatch(new BetterEvent(Color.blue));




////Listener

////public void Listen<T>(T message)  have me implement bChain
////{
////    if (message is BetterEvent)
////    if (message is string && (message as string) == "event") // all evaluative writting
////    {
////        //this.transform.GetComponent<Renderer>().material.color = (message as BetterEvent).color;
////        //no... call abstracted behavior
////        // me.change.color(mychoice or yourchoice)
////    }
////}
