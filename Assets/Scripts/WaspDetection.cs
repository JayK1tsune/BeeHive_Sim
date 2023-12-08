using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaspDetection : GAgent
{
    GameObject[] wasps;
    public GameObject beePrefab;
    private float waspcount;


    protected override void Start()
    {
        base.Start();
        InvokeRepeating("FindAllWasps", 0f, 30f);
    }
    void Update()
    {
        waspcount = wasps.Length;
        if (waspcount == 0 && isWaspNearby == true)
        {
            Debug.Log("Wasp Count: " + wasps.Length);
        }
        
        
    }
    void FindAllWasps()
    {
        wasps = GameObject.FindGameObjectsWithTag("Wasp");
    }

    bool isWaspNearby = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wasp"))
        {
            isWaspNearby = true;
            Debug.Log("Wasp entered the area!");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Wasp")
        {
            SpawnBabyBee(beePrefab);
            isWaspNearby = false;
            Debug.Log("Wasp is not nearby");   
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
        transform.parent = transform;
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




