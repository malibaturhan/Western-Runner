using System;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [Header("***Level***")]
    [SerializeField] private Level level;

    [Header("***Elements***")]
    [SerializeField] private RoadGenerator roadGenerator;
    [SerializeField] private ObstacleGenerator obstacleGenerator;
    [SerializeField] private GameObject zoneEndTrigger;
    Zone selectedZone;

    [Header("***Actions***")]
    public static Action ZoneEndedAction;


    private void Awake()
    {
        roadGenerator.SetLaneCount(level.laneCount);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CreateZoneEntities()
    {
        obstacleGenerator.GenerateObstacle(level.Zone.BarricadeCount, 
                                            level.Zone.EnemyCount,
                                            level.Zone.ZoneStartZPoint,
                                            level.Zone.ZoneEndZPoint
                                            );
    }

    public void EndZone()
    {
        //Debug.LogError("THIS ZONE ENDED");
        SetNewZone();
        CreateNewZoneElements();
        ReplaceZoneEndTrigger();
    }

    private void CreateNewZoneElements()
    {
        obstacleGenerator.GenerateObstacle(selectedZone.BarricadeCount,
                                            selectedZone.EnemyCount,
                                            selectedZone.ZoneStartZPoint,
                                            selectedZone.ZoneEndZPoint);
    }

    private void SetNewZone()
    {
        //Debug.Log("SETTING new ZONE");
        selectedZone = level.SelectNewZone();
    }
    private void ReplaceZoneEndTrigger()
    {
        SetZoneStartEndPositions();
        zoneEndTrigger.transform.position += Vector3.forward * level.Zone.ZoneLength;
    }

    private void SetZoneStartEndPositions()
    {
        level.Zone.ZoneStartZPoint = zoneEndTrigger.transform.position.z;
        level.Zone.ZoneEndZPoint = ZoneEndZPoint;
    }

    public float ZoneEndZPoint => zoneEndTrigger.transform.position.z + level.Zone.ZoneLength;





}
