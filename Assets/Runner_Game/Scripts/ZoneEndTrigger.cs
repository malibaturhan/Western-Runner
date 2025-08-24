using System;
using UnityEngine;

public class ZoneEndTrigger : MonoBehaviour
{
    private LevelManager levelManager;
    private void OnEnable()
    {
        levelManager = FindFirstObjectByType<LevelManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            levelManager.EndZone();
        }
    }
}
