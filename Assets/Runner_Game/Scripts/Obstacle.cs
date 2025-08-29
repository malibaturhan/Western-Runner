using UnityEngine;

public class Obstacle : MonoBehaviour, IObstacle
{
    public void OnDespawn()
    {
        //Debug.Log("obstacle DEspawned");
    }

    public void OnSpawn()
    {
        //Debug.Log("obstacle spawned");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("player hit");
        }
    }
}
