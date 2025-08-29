using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    [Header("***Elements***")]
    [SerializeField] private RoadGenerator roadGenerator;
    private float[] lanesXPoints;
    [SerializeField] private ObstaclePool obstaclePool;
    private List<int> occupiedLanesIndices = new();
    [SerializeField] LevelManager levelManager;

    private void Start()
    {
        lanesXPoints = roadGenerator.GetRoadLanesXPoints();
    }

    private int ChooseLane() => UnityEngine.Random.Range(0, lanesXPoints.Length);
    private float GetLaneXPoint(int laneIndex) => lanesXPoints[laneIndex];
    private int SpawnObstacle(List<int> exceptionLanes)
    {
        //Debug.Log("Creating obstacle");
        Obstacle obstacle = obstaclePool.obstaclePool.Get();
        PlaceElement(obstacle);
        return 0;
    }

    private int SpawnEnemy(List<int> exceptionLanes)
    {
        Debug.Log("creating enemy");
        return -1;
    }

    private void PlaceElement(IObstacle element)
    {
        var lane = ChooseLane();
        while (occupiedLanesIndices.Contains(lane))
        {
            lane = ChooseLane();
        }
        var obstacle = (element as MonoBehaviour);
        // FIX THIS LATER
        var randomZ = UnityEngine.Random.Range(-10,10);
        obstacle.transform.position = new Vector3(lanesXPoints[lane], 0, randomZ);
    }

    public void GenerateObstacle(int ObstacleCount, int enemyCount, float zoneStartZCoordinate, float zoneEndZCoordinate)
    {
        //Debug.Log("GENERATING OBSTACLES");
        List<int> usedLanes = new(3);
        for (int i = 0; i < ObstacleCount; i++)
        {
            usedLanes.Add(SpawnObstacle(usedLanes));
        }
        for (int i = 0; i < enemyCount; i++)
        {
            usedLanes.Add(SpawnEnemy(usedLanes));
        }

    }

    private int GetRandomLane(List<int> occupiedLanes)
    {
        return -1;
    }

    public void ResetOccupiedLanes()
    {
        occupiedLanesIndices.Clear();
    }
}
