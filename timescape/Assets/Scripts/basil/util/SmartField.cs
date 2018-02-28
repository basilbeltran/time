using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartField : MonoBehaviour {

    public bool dump = true;

    ArrayList components = new ArrayList();
    ArrayList children = new ArrayList();

    void Awake()
    {
       // if (dump) Debug.Log(GetState());

    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void setMe(string lable, string value){
        UnityEngine.UI.Text l =  gameObject.GetComponent<UnityEngine.UI.Text>();
        if(!l.text.Equals(lable)) l.text = lable;
        UnityEngine.UI.Text t = transform.GetChild(0).GetComponent<UnityEngine.UI.Text>();
        t.text = value;
    }


}
