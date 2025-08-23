using NUnit.Framework.Constraints;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float laneChangeSpeed = 10f;
    private float[] roadLaneXCoordinates;
    private int currentRoadLaneIndex = 1;

    [Header("***Elements***")]
    [SerializeField] private RoadGenerator roadGenerator;


    void Start()
    {
        GetRoadLaneXCoordinates();
    }


    void Update()
    {
        if (Keyboard.current.leftArrowKey.wasPressedThisFrame)
        {
            ChangeRoadLane(currentRoadLaneIndex - 1);
            ChangePlayerLane();
        }
        if (Keyboard.current.rightArrowKey.wasPressedThisFrame)
        {
            ChangeRoadLane(currentRoadLaneIndex + 1);
            ChangePlayerLane();
        }
        MoveForward();
    }

    private void ChangePlayerLane()
    {
        var newX = roadLaneXCoordinates[currentRoadLaneIndex];
        var newPosition = new Vector3(newX, transform.position.y, transform.position.z);
        transform.Translate(newPosition);
    }

    private void ChangeRoadLane(int nextLaneIndex)
    {
        if (nextLaneIndex < 0 || nextLaneIndex >= roadLaneXCoordinates.Length) return;
        currentRoadLaneIndex = nextLaneIndex;
        Debug.Log("currentRoadLaneIndex: " + currentRoadLaneIndex);
    }

    private void MoveForward()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }
    private void GetRoadLaneXCoordinates()
    {
        roadLaneXCoordinates = roadGenerator.GetRoadLanesXCoordinates();
    }

}
