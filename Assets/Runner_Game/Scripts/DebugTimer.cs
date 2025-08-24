using UnityEngine;

public class DebugTimer : MonoBehaviour
{
    [Range(0.5f, 13f)]
    [SerializeField] private float targetTimeScale = 1f;
    void Start()
    {
        Time.timeScale = targetTimeScale;
    }

}
