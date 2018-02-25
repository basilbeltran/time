//using UnityEngine;
//using System.Collections;
//using UnityStandardAssets.CrossPlatformInput;
//using basil.util;


//public class PositionMove : MonoBehaviour
//{
//    Me me;
//    float inputX = 0, inputZ = 0 ;

//    private void Awake()
//    {
//            me = GetComponent<Me>(); // that happens to have method "SetMoved"
//    }


//    void Update()
//    {
//        inputX = CrossPlatformInputManager.GetAxis("Horizontal") * Time.deltaTime;
//        inputZ = CrossPlatformInputManager.GetAxis("Vertical") * Time.deltaTime;

//        //get a vertical (Y) movement from key combination
//        if (inputX < 0 && inputZ < 0)
//        {
//            transform.Translate(0, inputX, 0);
//            me.SetMoved(true);            
//        }
//        else if (inputX > 0 && inputZ >0)
//        {
//            transform.Translate(0, inputX, 0);
//            me.SetMoved(true);
//        }
//        else if (inputX != 0 || inputZ != 0)
//        {
//            transform.Translate(inputX, 0, inputZ);
//            me.SetMoved(true);

//        }
//        else{
//            me.SetMoved(false);
//        }
//    }

//}

