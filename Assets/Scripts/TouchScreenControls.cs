using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchScreenControls : MonoBehaviour
{
    
    public GameObject character;

    
    private float ScreenWidth;


    // Use this for initialization
    void Start()
    {
        ScreenWidth = Screen.width;
    }

    // Update is called once per frame
    void Update()
    {
        int i = 0;
        //loop over every touch found
        while (i < Input.touchCount)
        {
            if (Input.GetTouch(i).position.x > ScreenWidth / 2)
            {
                //jump up
                gameObject.GetComponent<PlayerController2>().JumpFunction();
            }
            if (Input.GetTouch(i).position.x < ScreenWidth / 2)
            {
                //slide on the ground
                gameObject.GetComponent<PlayerController2>().SlideFunction();
            }
            ++i;
        }
    }
 

   
}