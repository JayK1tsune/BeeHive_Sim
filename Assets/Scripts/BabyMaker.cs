using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random=UnityEngine.Random;


public class BabyMaker
{
    private float mutationRate;
    private System.Random random;
    

    public BabyMaker(float mutationRate)
    {
        this.mutationRate = mutationRate;
        random = new System.Random();
    }
    private float CalculateFitness()
    {
        return (float)random.NextDouble();
    }
    
    private void MutateGenes(ref float fitness){
        if (random.NextDouble() < mutationRate)
        {
            fitness = (float)random.NextDouble();
        }
    }

    public bool ShouldBeeSpawn()
    {
        float currentFitness = CalculateFitness();
        MutateGenes(ref currentFitness);
        float spawnThreshold = 0.3f;
        return currentFitness > spawnThreshold;
    }


}

public class BeeManger : MonoBehaviour
{
    public GameObject beePrefab;
    public void SpawnBabyBee(GameObject beePrefab){
        beePrefab = GameObject.Find("WorkerBee");
        float mutationRate = 0.1f;
        BabyMaker babyMaker = new BabyMaker(mutationRate);
        bool SpawnBabyBee = babyMaker.ShouldBeeSpawn();
        if (SpawnBabyBee)
        {
            SpawnBee(beePrefab);
            Debug.Log("Baby Bee Spawned");
        }
        else
        {
            Debug.Log("Baby Bee Not Spawned");
        }
    }
    void SpawnBee(GameObject beePrefab)
    {
  
        Instantiate(beePrefab, this.transform.position, Quaternion.identity);
        transform.parent = transform;
        Invoke("SpawnBee", Random.Range(2, 10));
        Debug.Log("Bee Prefab is not null");
        

    }

}
