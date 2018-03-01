using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBodyCtl : MonoBehaviour {

    public int delay = 4;
    Rigidbody rb;
    Transform pa;
    string type;

    void Awake()
    {    
        Invoke("KillHost", delay); 
        rb = gameObject.GetComponent<Rigidbody>();
        pa = transform.parent;
    }

    // Use this for initialization
    void Start () {
            
    }
    
    // Update is called once per frame
    void Update () {
    
    
        
    }

    public void KillHost(){
        DestroyImmediate(transform.gameObject);
    }
    
    }

