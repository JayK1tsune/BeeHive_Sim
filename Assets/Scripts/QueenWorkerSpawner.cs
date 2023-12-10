using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueenWorkerSpawner : GAgent
{
    public GameObject beePrefab;
   
    protected override void Start()
    {
        base.Start();
     
    }
    void Update()
    {
       
    
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HoneyBee"))
        {
            
            Debug.Log("HonneyBee here for the Queen!");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "HoneyBee")
        {
            SpawnBabyBee(beePrefab);
            
            Debug.Log("HonneyBee left the queen");   
        }
    }
    public void SpawnBabyBee(GameObject beePrefab){
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
        //transform.parent = transform;
        //Invoke("SpawnBee", Random.Range(2, 10)); 
    }
}

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
