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
            GameObject bee = Instantiate(beePrefab, transform.position, Quaternion.identity);
            bee.transform.parent = transform;
        }
    }
}
