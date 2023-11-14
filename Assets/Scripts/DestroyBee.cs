using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBee : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "WorkerBee") {
            Destroy(collision.gameObject);
        }
    }
}