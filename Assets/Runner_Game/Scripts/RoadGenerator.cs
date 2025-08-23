using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System;

public class RoadGenerator : MonoBehaviour
{

    [Header("Settings")]
    [SerializeField] private int roadWidth = 3;
    [SerializeField] private int roadLength = 15;
    [Tooltip("Road is build with same amount of items\n" +
        "After this position tiles backwards will be reconstructed at front")]
    [SerializeField] private int roadRefreshPosition = 15;
    [SerializeField] private float blockRoadWidth;
    [SerializeField] private float blockRoadHeight;
    [SerializeField] private List<GameObject> roadTilePrefabs;

    [Header("***Elements***")]
    private List<GameObject> roadTiles;
    [SerializeField] private Transform roadParent;
    [SerializeField] private GameObject refreshTrigger;

    [Header("***Temporary Variables***")]
    private int lastRoadTileZCoordinate; // as block

    void Start()
    {
        CenterRoad();
        roadTiles = new(roadWidth * roadLength);
        LoadRoadTiles();
        ArrangeRoadTiles();
    }



    private void CenterRoad()
    {
        var calculatedX = -(blockRoadWidth * roadWidth / 2);
        roadParent.position = new Vector3(calculatedX,
                                        transform.position.y,
                                        transform.position.z);
    }

    void Update()
    {

    }
    private void LoadRoadTiles()
    {
        var chosenTileIndex = UnityEngine.Random.Range(0, roadTilePrefabs.Count);
        Debug.Log(chosenTileIndex.ToString());
        for (int i = 0; i < roadWidth * roadLength; i++)
        {
            Debug.Log(i);
            roadTiles.Add(Instantiate(roadTilePrefabs[chosenTileIndex], roadParent));
        }
    }


    public void ArrangeRoadTiles()
    {
        int tileCount = 0;
        float xInitial = blockRoadWidth;
        for (int z = 0; z < roadLength; z++)
        {
            for (int x = 0; x < roadWidth; x++)
            {
                roadTiles[tileCount].transform.Translate(new Vector3(xInitial * x, 0, z * blockRoadHeight));
                tileCount++;
            }
        }
    }

    public float[] GetRoadLanesXCoordinates()
    {
        var initialCoor = -roadWidth / 2 * blockRoadWidth;
        float[] xCoordinates = new float[roadWidth];
        for (int x = 0; x < roadWidth; x++)
        {
            xCoordinates[x] = initialCoor + x * blockRoadWidth;
        }
        Debug.Log(xCoordinates);
        return xCoordinates;
    }

    // TURN IT IENUMERATOR LATER DUE TO PERFORMANCE ISSUES
    public void RearrangeTilesForward()
    {
        int index = 0;
        for (int z = 0; z < roadRefreshPosition; z++) 
        {
            for (int x = 0; x < roadWidth; x++) 
            {
                //roadTiles[index]
                index++;
            }
        }
    }
}
