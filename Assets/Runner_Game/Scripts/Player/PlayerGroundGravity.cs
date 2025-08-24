using System;
using UnityEngine;
using DG.Tweening;

public class PlayerGroundGravity : MonoBehaviour
{
    [SerializeField] private float gravity = 20f;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        ApplyGravity();
    }

    private void ApplyGravity()
    {
        if (transform.position.y > 0.05f)
        {
            transform.position += Vector3.Lerp(transform.position,Vector3.down, gravity * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            Debug.Log("hit ground and gravity is zero");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.LogWarning("kafam havada");
    }
}
