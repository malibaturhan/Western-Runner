using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class MobileController : MonoBehaviour
{
    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;
    [SerializeField] private float swipeThreshold = 50f;

    public delegate void SwipeAction(string direction);
    public static event SwipeAction OnSwipe;

    void Update()
    {
        if (Touchscreen.current == null || Touchscreen.current.primaryTouch.press.isPressed == false)
        {
            return;
        }
        var touch = Touchscreen.current.primaryTouch;
        if (touch.phase.ReadValue() == UnityEngine.InputSystem.TouchPhase.Began)
        {
            Debug.Log($"TOUCH START: {startTouchPosition} END: {endTouchPosition}");
            startTouchPosition = touch.position.ReadValue();
        }
        else if (touch.phase.ReadValue() == UnityEngine.InputSystem.TouchPhase.Ended)
        {
            endTouchPosition = touch.position.ReadValue();
            DetectSwipe();
        }
    }

    private void DetectSwipe()
    {
        Vector2 swipeOffset = endTouchPosition - startTouchPosition;

        if (swipeOffset.magnitude < swipeThreshold)
        {
            if (Mathf.Abs(swipeOffset.x) > Mathf.Abs(swipeOffset.y))
            {
                if (swipeOffset.x > 0)
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
