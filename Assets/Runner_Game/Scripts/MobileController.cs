using System;
using UnityEngine;

public class MobileController : MonoBehaviour
{
    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;
    [SerializeField] private float swipeThreshold = 50f;

    public delegate void SwipeAction(string direction);
    public static event SwipeAction OnSwipe;

    void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase) 
            {
                case TouchPhase.Began:
                    startTouchPosition = touch.position;
                    break;
                case TouchPhase.Ended:
                    endTouchPosition = touch.position;
                    DetectSwipe();
                    break;
            }        
    }
}

    private void DetectSwipe()
    {
        Vector2 swipeOffset = endTouchPosition - startTouchPosition;

        if(swipeOffset.magnitude < swipeThreshold)
        {
            if (Mathf.Abs(swipeOffset.x) > Mathf.Abs(swipeOffset.y)) 
            {
                if(swipeOffset.x > 0)
                {
                    OnSwipe?.Invoke("RIGHT");
                }
                else
                {
                    OnSwipe?.Invoke("LEFT");
                }
            }
            else
            {
                if (swipeOffset.y > 0)
                {
                    OnSwipe?.Invoke("UP");
                }
                else
                {
                    OnSwipe?.Invoke("DOWN");
                }
            }
        }

    }
}
