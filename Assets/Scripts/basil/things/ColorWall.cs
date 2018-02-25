using UnityEngine;
using System.Collections;

public class ColorWall : MonoBehaviour
{   

    int[,,] myArray = new int[255,255,255];
    int r, g, b;
    
	// Use this for initialization
	void Start()
	{
    

         for( r = 0 ; r < 255 ; r++){
            for( g = 0 ; g < 255 ; g++){
                for (g = 0; g < 255; g++)
                {
                    //myArray[r, g, b] = new cube;
                }
            }
         }
	}

	// Update is called once per frame
	void Update()
	{
			
	}
}
