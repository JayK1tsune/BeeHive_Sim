using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeSpawner : MonoBehaviour
{
    public GameObject beePrefab;
    public int numBees = 10;

    private void Awake()
    {
        for (int i = 0; i < numBees; i++)
        {
            GameObject bee = Instantiate(beePrefab, this.transform.position, Quaternion.identity);
        }
        Invoke("SpawnBee", 5);
    }

    void SpawnBee()
    {
        GameObject bee = Instantiate(beePrefab, this.transform.position, Quaternion.identity);
        bee.transform.parent = transform;
        Invoke("SpawnBee", Random.Range(2, 10));
    }
}
