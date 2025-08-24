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

    public void SetZoneStartZCoordinate(float _zoneStartZCoordinate)
    {
        zoneStartZCoordinate = _zoneStartZCoordinate;
    }
    public void SetZoneEndZCoordinate(float _zoneEndZCoordinate)
    {
        if (_zoneEndZCoordinate > zoneStartZCoordinate)
        {
            zoneEndZCoordinate = _zoneEndZCoordinate;
        }
        else
        {
            throw new ArgumentOutOfRangeException("End coordinate cannot be closer than start");
        }
    }
}
