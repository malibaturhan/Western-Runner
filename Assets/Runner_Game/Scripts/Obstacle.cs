using UnityEngine;

public class Obstacle : MonoBehaviour, IObstacle
{
    public void OnDespawn()
    {
        Debug.Log("obstacle DEspawned");
    }

    public void OnSpawn()
    {
        Debug.Log("obstacle spawned");
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
