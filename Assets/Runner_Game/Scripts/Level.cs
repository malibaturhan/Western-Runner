using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "Scriptable Objects/Level")]
public class Level : ScriptableObject
{
    public string LevelName;

    public int laneCount;

    [Header("Zones can be included this level")]
    public Zone[] zones;

    private void OnValidate()
    {
        if (laneCount % 2 == 0)
        {
            laneCount += 1;
            Debug.LogWarning($"Lane count must be odd\nADJUSTED to {laneCount}");
        }
        if (laneCount < 3)
        {
            laneCount += 3;
            Debug.LogWarning($"Lane cannot be less than 3\nADJUSTED to {laneCount}");
        }
    }

    public Zone[] SelectNewZones(int numOfZones)
    {
        var newZones = new Zone[numOfZones];
        for (int i = 0; i < numOfZones; i++)
        {
            Zone nextZone = zones[Random.Range(0, zones.Length)];
            newZones[i] = nextZone;
        }
        return newZones;
    }
}
