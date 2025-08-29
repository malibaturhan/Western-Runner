using UnityEngine;

public class PlayerPoolDespawner : MonoBehaviour
{
    [SerializeField] private ObstaclePool obstaclePool;

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            obstaclePool.obstaclePool.Release(other.gameObject.GetComponent<Obstacle>());
        }
        if (other.gameObject.CompareTag("Enemy"))
        {

        }
    }
}
