using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "Scriptable Objects/Level")]
public class Level : ScriptableObject
{
    public string LevelName { get; set; }
    public int LaneCount {  get; set; }

    [Header("Zones can be included this level")]
    public Zone[] zones { get; set; }
}
