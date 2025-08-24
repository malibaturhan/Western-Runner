using UnityEngine;

[CreateAssetMenu(fileName = "Zone", menuName = "Scriptable Objects/Zone")]
public class Zone : ScriptableObject
{
    public string ZoneName { get; set; }
    public int BarricadeCount { get; set; }
    public int EnemyCount { get; set; }
    public GameObject[] ShortBarricades { get; set; }
    public GameObject[] LongBarricades { get; set; }

}
