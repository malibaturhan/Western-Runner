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

    public void EndZone()
    {
        //Debug.LogError("THIS ZONE ENDED");
        SetNewZone();
        ReplaceZoneEndTrigger();
    }
    private void SetNewZone()
    {
        Debug.Log("SETTING new ZONE");
        Zone selectedZone = level.SelectNewZone();
    }
    private void ReplaceZoneEndTrigger()
    {
        //Debug.LogWarning("ZONE END TRIGGER REPLACED TO " + Vector3.forward * level.Zone.ZoneLength);
        zoneEndTrigger.transform.position += Vector3.forward * level.Zone.ZoneLength;
    }

    


}
