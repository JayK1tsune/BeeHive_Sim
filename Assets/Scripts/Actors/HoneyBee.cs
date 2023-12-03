using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoneyBee : GAgent
{
    BabyMaker babyMaker = new BabyMaker(0.1f); // 10% mutation rate
    BeeManger beeManager = new BeeManger();
    public GameObject beePrefab;
    new void Start()
    {
        base.Start();
        SubGoal s1 = new SubGoal("HarvestHoney", 1, false);
        goals.Add(s1, 3);

        SubGoal s2 = new SubGoal("FedQueen", 1, false); 
        goals.Add(s2, 1);
                
        SubGoal s3 = new SubGoal("DefendQueen", 1, false);
        goals.Add(s3, 5);

        Invoke("CheckQueen", Random.Range(10, 20));
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
            beeManager.SpawnBabyBee(beePrefab);
            isWaspNearby = false;
             Debug.Log("Wasp is not nearby");   
        }
    }

    void CheckQueen()
    {
        beliefs.ModifyState("QueenNeedsHoney", 0);
        Invoke("CheckQueen", Random.Range(10, 20));
    }

    void DefendQueen()
    {
        beliefs.ModifyState("QueenIsUnderAttack", 0);
        Invoke("DefendQueen", 0);
    }

}
