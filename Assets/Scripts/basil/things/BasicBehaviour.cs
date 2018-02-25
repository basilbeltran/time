using UnityEngine;
using System.Collections;

namespace basil.util{


public class BasicBehaviour : MonoBehaviour
{
    public bool dump = false;
    public bool moved = true;

    public bool SetDump(bool tf){
        dump = tf;
        return  enabled;
    }




    public void Activate()
    {
        gameObject.SetActive(true);

    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }


    public void ToggleActive()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }
    
    
    

    void OnEnable()
    {
       // if (dump) U.Log(gameObject.name + " is ACTIVE " +gameObject.Status() );
    }

    void OnDisable()
    {
       // if (dump)  U.Log(gameObject.name + " is ACTIVE " + gameObject.Status());
    }
    
    public void SetMoved(bool m){ this.moved = m; }
    




    void OnDestroy()
        {
          if (dump)  U.Log("bye bye");
        }
    
    
    
  }  
}
    
    