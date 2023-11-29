using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BabyBeeSpawn : MonoBehaviour
{
    public GameObject beePrefab;

    public void onCollisionEnter(Collision other)
    {
        Debug.Log("Collision");
        if (other.gameObject.tag == "HoneyBee")
        {
            Invoke("SpawnBee", 1);
        }
    }
    void SpawnBee()
    {
        GameObject bee = Instantiate(beePrefab, this.transform.position, Quaternion.identity);
        bee.transform.parent = transform;
        Invoke("SpawnBee", Random.Range(2, 10));
    }
    
}
