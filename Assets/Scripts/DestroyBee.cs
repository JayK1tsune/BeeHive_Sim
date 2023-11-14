using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBee : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);    // Destroy the bee
    }
}