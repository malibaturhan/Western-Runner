using NUnit.Framework;
using UnityEngine;
using System.Collections;
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
    [SerializeField] private int triggerOffset = 10;
    [SerializeField] private float blockRoadWidth;
    [SerializeField] private float blockRoadHeight;
    [SerializeField] private List<GameObject> roadTilePrefabs;

    [Header("***Elements***")]
    private Queue<GameObject> roadTiles;
    [SerializeField] private Transform roadParent;
    [SerializeField] private GameObject refreshTrigger;

    [Header("***Temporary Variables***")]
    private int lastRoadTileZCoordinate = 0; // as block
    

    void Start()
    {
        roadTiles = new Queue<GameObject>();
        CenterRoad();
        LoadRoadTiles();
        ArrangeRoadTiles();
        RelocateRefreshTrigger();
    }



    private void CenterRoad()
    {
        var calculatedX = -(blockRoadWidth * roadWidth / 2);
        roadParent.position = new Vector3(calculatedX,
                                        transform.position.y,
                                        transform.position.z);
    }

    private void LoadRoadTiles()
    {
        var chosenTileIndex = UnityEngine.Random.Range(0, roadTilePrefabs.Count);
        for (int i = 0; i < roadWidth * roadLength; i++)
        {
            var tile = Instantiate(roadTilePrefabs[chosenTileIndex], roadParent);
            tile.gameObject.tag = "Ground";
            roadTiles.Enqueue(tile);
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
                GameObject tile = roadTiles.Dequeue();
                tile.transform.localPosition = new Vector3(xInitial * x, 0, z * blockRoadHeight);
                roadTiles.Enqueue(tile);
                tileCount++;
            }
            lastRoadTileZCoordinate = roadLength - triggerOffset;
        }
        
    }

    private void RelocateRefreshTrigger()
    {
        Vector3 newPosition = new Vector3(refreshTrigger.transform.position.x,
                                          refreshTrigger.transform.position.y,
                                          lastRoadTileZCoordinate - (roadLength - roadRefreshPosition) + triggerOffset);
        refreshTrigger.transform.position = newPosition;
    }

    public void RefreshRoad()
    {
        StartCoroutine(RearrangeTilesForwardCoroutine());
    }

    private IEnumerator RearrangeTilesForwardCoroutine()
    {
        for (int z = 0; z < roadRefreshPosition; z++)
        {
            for (int x = 0; x < roadWidth; x++)
            {
                GameObject tile = roadTiles.Dequeue();
                Vector3 newPos = new Vector3(tile.transform.position.x,
                                             tile.transform.position.y,
                                             lastRoadTileZCoordinate * blockRoadHeight
                                             );
                tile.transform.position = newPos;
                roadTiles.Enqueue(tile) ;
            }
            lastRoadTileZCoordinate++;
            yield return null;
        }
        RelocateRefreshTrigger();
    }

    public float[] GetRoadLanesXCoordinates()
    {
        var initialCoor = -roadWidth / 2 * blockRoadWidth;
        float[] xCoordinates = new float[roadWidth];
        for (int x = 0; x < roadWidth; x++)
        {
            xCoordinates[x] = initialCoor + x * blockRoadWidth;
        }
        return xCoordinates;
    }

}
