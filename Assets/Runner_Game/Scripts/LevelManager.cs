using System;
using UnityEngine;
using System.Collections.Generic;
public class LevelManager : MonoBehaviour
{
    [Header("***Level***")]
    [SerializeField] private Level level;
    [SerializeField] private int CountOfNewZones = 10;

    [Header("***Elements***")]
    [SerializeField] private RoadGenerator roadGenerator;
    [SerializeField] private ObstacleGenerator obstacleGenerator;
    [SerializeField] private GameObject zoneEndTrigger;
    [SerializeField] private List<Zone> selectedZones;
    [SerializeField] private List<float> selectedZonesEndZPoints;
    private float zoneEndTriggerZPoint;
    private float lastZoneZPoint;

    [Header("***Actions***")]
    public static Action ZoneEndedAction;


    private void Awake()
    {
        selectedZones = new List<Zone>(5);
        selectedZonesEndZPoints = new List<float>();
        roadGenerator.SetLaneCount(level.laneCount);
        lastZoneZPoint = zoneEndTriggerZPoint;
    }
    public void EndZone(float triggerZPoint)
    {
        zoneEndTriggerZPoint = triggerZPoint;
        SetNewZones();
        ReplaceZoneEndTrigger();
        SetZoneStartEndPositions();
        CreateNewZoneElements();
        obstacleGenerator.ResetOccupiedLanes();
    }

    private void CreateNewZoneElements()
    {
        for (int i = 0; i < CountOfNewZones; i++)
        {
            obstacleGenerator.GenerateObstacle(selectedZones[i].BarricadeCount,
                                                selectedZones[i].EnemyCount,
                                                selectedZones[i].ZoneStartZPoint,
                                                selectedZones[i].ZoneEndZPoint);

        }
    }

    private void SetNewZones()
    {
        selectedZones.AddRange(level.SelectNewZones(CountOfNewZones));
    }
    private void ReplaceZoneEndTrigger()
    {
        SetZoneStartEndPositions();
        zoneEndTrigger.transform.position += Vector3.forward + Vector3.forward * selectedZonesEndZPoints[(int)(CountOfNewZones / 2)];
    }

    private void SetZoneStartEndPositions()
    {
        for (int i = 0; i < selectedZones.Count; i++)
        {
            selectedZonesEndZPoints.Add(lastZoneZPoint + selectedZones[i].Length);
            Debug.Log($"Selected zone end point Z: {lastZoneZPoint + selectedZones[i].Length}");
            lastZoneZPoint += selectedZones[i].Length;
        }

    }

    public List<Zone> Zones => selectedZones;


}