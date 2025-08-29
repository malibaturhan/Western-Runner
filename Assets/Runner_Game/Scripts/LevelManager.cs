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
    [SerializeField] private float lastZoneZPoint;

    [Header("***Actions***")]
    public static Action ZoneEndedAction;

    [Header("***Settings***")]
    [SerializeField] private float zoneStartZOffset;


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
        //ResetZones();
    }

    private void ResetZones()
    {
        Zones.Clear();
        selectedZonesEndZPoints.Clear();
    }

    private void CreateNewZoneElements()
    {
        int startIndex = selectedZonesEndZPoints.Count;
        for (int i = 0; i < CountOfNewZones; i++)
        {
            float zoneEnd = selectedZonesEndZPoints[i] + zoneStartZOffset;
            float zoneStart = (zoneEnd - selectedZones[i].Length);

            obstacleGenerator.GenerateObstacle(
                selectedZones[i].BarricadeCount,
                selectedZones[i].EnemyCount,
                zoneStart,
                zoneEnd);
        }
        zoneStartZOffset = selectedZonesEndZPoints[^1];
    }
    private void SetNewZones()
    {
        //Debug.Log("SETTING NEW ZONES");
        selectedZones.AddRange(level.SelectNewZones(CountOfNewZones));
    }
    private void ReplaceZoneEndTrigger()
    {
        SetZoneStartEndPositions();
        zoneEndTrigger.transform.position += Vector3.forward + Vector3.forward * selectedZonesEndZPoints[(int)(CountOfNewZones / 2)];
    }

    private void SetZoneStartEndPositions()
    {
        int startIndex = selectedZonesEndZPoints.Count;
        for (int i = startIndex; i < selectedZones.Count; i++)
        {
            selectedZonesEndZPoints.Add(lastZoneZPoint + selectedZones[i].Length);
            Debug.LogWarning($"Selected zone end point Z: {lastZoneZPoint + selectedZones[i].Length}");
            lastZoneZPoint += selectedZones[i].Length;
        }

    }

    public List<Zone> Zones => selectedZones;

    public float LastZoneZPoint => lastZoneZPoint;
}