using UnityEngine;

public class Enemy : MonoBehaviour, IObstacle
{
    public void OnDespawn()
    {
        Debug.Log("enemy DEspawned");
    }

    public void OnSpawn()
    {
        Debug.Log("enemy spawned");
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
