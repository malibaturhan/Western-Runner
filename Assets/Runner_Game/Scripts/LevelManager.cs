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
        Debug.LogError("THIS ZONE ENDED");
        SetNewZone();
        ReplaceZoneEndTrigger();
    }
    private void SetNewZone()
    {
        throw new NotImplementedException();
    }
    private void ReplaceZoneEndTrigger()
    {
        throw new NotImplementedException();
    }


}
