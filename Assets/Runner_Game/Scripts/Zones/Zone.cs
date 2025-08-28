using UnityEngine;
using System;

[CreateAssetMenu(fileName = "Zone", menuName = "Scriptable Objects/Zone")]
public class Zone : ScriptableObject
{
    public string ZoneName;
    [Header("Creates a trigger at the end\nNext zone initiated")]
    public float ZoneLength;
    public int BarricadeCount;
    public int EnemyCount;
    public GameObject[] ShortBarricades;
    public GameObject[] LongBarricades;

    [Header("***Settings***")]
    private float zoneStartZPoint;
    private float zoneEndZPoint;
    private float zoneStartZCoordinate;
    private float zoneEndZCoordinate;

    public float GetZoneLength()
    {
        return ZoneLength;
    }
    public override string ToString()
    {
        return ZoneName;
    }

    public float ZoneStartZPoint {
        get { return zoneStartZPoint; }
        set
        {
            zoneStartZPoint = value;
        }
    }
    public float ZoneEndZPoint
    {
        get { return zoneEndZPoint; }
        set
        {
            zoneEndZPoint = value;
        }
    }
}
