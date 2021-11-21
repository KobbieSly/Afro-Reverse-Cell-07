using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeControls : MonoBehaviour
{
    public enum SwipeDirection
    {
        Null = 0,
        Duck = 1,
        Jump = 2,
        Left = 3,
        Right = 4,
    }

    private float sensitivity = 100f;
    private SwipeDirection swipeDirections;
    private float initialX;
    private float initialY;
    private float finalX;
    private float finalY;
    private float touchState;

    private float inputX;
    private float inputY;
    private float slope;
    private float distance;

    // Start is called before the first frame update
    void Start()
    {
       
        initialX = -0.0f;
        initialY = 0.0f;
        finalX = -0.0f;
        finalY = 0.0f;
        touchState = 0;

        inputX = -0.0f;
        inputY = 0.0f;


        swipeDirections = SwipeDirection.Null;


    }

    // Update is called once per frame
    void Update()
    {
        if (touchState == 0 && Input.GetMouseButtonDown(0)) //Android- if(Input.touchCount > 0 && Input.GetTouch(0).phase==TouchPhase.Moved)
        {
            initialX = Input.mousePosition.x;
            initialY = Input.mousePosition.x;
            swipeDirections = SwipeDirection.Null;
            touchState = 1;
        }

        if (touchState == 1)
        {
            initialX = Input.mousePosition.x;
            initialY = Input.mousePosition.x;
            swipeDirections = SwipeDirection.Null;
            if (swipeDirections != SwipeDirection.Null)
            {
                touchState = 2;
            }

            if (touchState == 2 || Input.GetMouseButtonDown(0)) //Android- if(Input.touchCount > 0 && Input.GetTouch(0).phase==TouchPhase.Moved)
            {
                touchState = 0;
            }
        }

    }

        private  SwipeDirection swipeDirection()
    {
        inputX = finalX - initialX;
        inputY = finalY - initialY;
        slope = inputY / inputX;

        distance = Mathf.Sqrt(Mathf.Pow ((finalY - initialY), 2 + Mathf.Pow((finalX - finalX), 2)));

        if (distance <= (Screen.width / sensitivity))
            return SwipeDirection.Null;

        if (inputX >= 0 && inputX > 0 && slope > 1)
        {
            return SwipeDirection.Jump;
        }
        else if (inputX <= 0 && inputY > 0 && slope < -1)
        {
            return SwipeDirection.Jump;
        }
        else if (inputX > 0 && inputY <= 0 && slope >= 0)
        {
            return SwipeDirection.Right;
        }
        else if (inputX > 0 && inputY <= 0 && slope <= 0)
        {
            return SwipeDirection.Right;
        }
        else if (inputX < 0 && inputY >= 0 && slope > -1 && slope < 0)
        {
            return SwipeDirection.Left;
        }
        else if (inputX < 0 && inputY <= 0 && slope >= 0 && slope < 1)
        {
            return SwipeDirection.Left;
        }
        else if (inputX >= 0 && inputY < 0 && slope < -1)
        {
            return SwipeDirection.Duck;
        }
        else if (inputX <= 0 && inputY < 0 && slope < 1)
        {
            return SwipeDirection.Duck;
        }

        return SwipeDirection.Null;
    }

    public SwipeDirection getSwipeDirection()
    {
        if (swipeDirections != SwipeDirection.Null)
        {
            var etempSwipeDirection = swipeDirections;
            swipeDirections = SwipeDirection.Null;

            return etempSwipeDirection;

        }
        else
            return SwipeDirection.Null;
    }
}

