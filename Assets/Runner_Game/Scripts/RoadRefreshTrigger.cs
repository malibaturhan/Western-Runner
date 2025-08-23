using UnityEngine;

public class RoadRefreshTrigger : MonoBehaviour
{
    [SerializeField] private RoadGenerator roadGenerator;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.LogWarning("Attempting to refresh road");
            roadGenerator.RearrangeTilesForward();
        }
    }
}
