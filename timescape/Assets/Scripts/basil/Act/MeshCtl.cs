
using UnityEngine;

public class MeshCtl : MonoBehaviour {

    public int delay = 4;
    MeshRenderer mr;
    TextMesh tm;
    string type;

    void Awake()
    {
        mr = gameObject.GetComponent<MeshRenderer>();
        tm = gameObject.GetComponent<TextMesh>();
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