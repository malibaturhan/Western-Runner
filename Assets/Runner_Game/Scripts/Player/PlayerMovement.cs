using NUnit.Framework.Constraints;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float jumpSpeed = 10f;
    [SerializeField] private float laneChangeDuration = 0.2f;
    private float[] roadLaneXCoordinates;
    private int currentRoadLaneIndex = 1;

    [Header("***Elements***")]
    [SerializeField] private RoadGenerator roadGenerator;


    void Start()
    {
        GetRoadLaneXCoordinates();
        currentRoadLaneIndex = (int)roadLaneXCoordinates.Length / 2;
        MobileController.OnSwipe += HandleSwipe;
    }

    private void HandleSwipe(string direction)
    {
        if (direction == "LEFT")
        {
            MoveLeft();
        }
        if (direction == "RIGHT")
        {
            MoveRight();
        }
    
    }

    void Update()
    {
        if (Keyboard.current.leftArrowKey.wasPressedThisFrame)
        {
            MoveLeft();
        }
        if (Keyboard.current.rightArrowKey.wasPressedThisFrame)
        {
            MoveRight();
        }
        if (Keyboard.current.upArrowKey.wasPressedThisFrame)
        {
            Jump();
        }
        if (Keyboard.current.downArrowKey.wasPressedThisFrame)
        {
            Tumble();
        }
        MoveForward();
    }

    private void MoveRight()
    {
        ChangeRoadLane(currentRoadLaneIndex + 1);
        ChangePlayerLane();
    }

    private void MoveLeft()
    {
        ChangeRoadLane(currentRoadLaneIndex - 1);
        ChangePlayerLane();
    }

    private void Jump()
    {
        Debug.Log("JUMPING...");
    }

    private void Tumble()
    {
        Debug.Log("TUMBLING......");
    }



    private void ChangePlayerLane()
    {
        //Debug.LogWarning($"Current road index: {currentRoadLaneIndex}");
        float targetX = roadLaneXCoordinates[currentRoadLaneIndex];
        transform.DOMoveX(targetX, laneChangeDuration);
    }

    private void ChangeRoadLane(int nextLaneIndex)
    {
        if (nextLaneIndex < 0 || nextLaneIndex >= roadLaneXCoordinates.Length) return;
        currentRoadLaneIndex = nextLaneIndex;
        //Debug.Log("currentRoadLaneIndex: " + currentRoadLaneIndex);
    }

    private void MoveForward()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }
    private void GetRoadLaneXCoordinates()
    {
        roadLaneXCoordinates = roadGenerator.GetRoadLanesXPoints();
    }


    private void OnDisable()
    {
        MobileController.OnSwipe -= HandleSwipe;
    }

}
