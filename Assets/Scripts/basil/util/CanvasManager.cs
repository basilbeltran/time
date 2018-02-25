using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

using basil.util;

public class CanvasManager : MonoBehaviour {
     public GameObject  panel;


    public void ToggleActive()
    {

        panel.SetActive(!panel.activeSelf);
        U.LData(" ", panel);

    }

	// Use this for initialization
	void Start () {
        try
        {
            panel = GameObject.FindGameObjectWithTag("stats");
            U.LData("", panel);
        }
        catch (System.Exception ex)
        {
            U.Log(ex.ToString());
        }
	}

	// Update is called once per frame
	void Update () { }





    public void clickH() { U.aLevel(10); }
    public void clickM() { U.aLevel(9); }
    public void clickS() { U.aLevel(8); }
    
}
