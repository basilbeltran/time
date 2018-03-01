﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileRider : MonoBehaviour {

    public int delay = 4;
    Rigidbody rb;
    MeshRenderer mr;
    TextMesh tm;
    Transform pa;
    string type;

    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        mr = gameObject.GetComponent<MeshRenderer>();
        tm = gameObject.GetComponent<TextMesh>();
        pa = transform.parent;
        type = tm.text;

    }

	// Use this for initialization
	void Start () {
        Invoke("KillHost", 4);     
	}
	
	// Update is called once per frame
	void Update () {
    
    
		
	}

    public void KillHost(){
        DestroyImmediate(transform.gameObject);
    }



}
