using UnityEngine;

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

}
