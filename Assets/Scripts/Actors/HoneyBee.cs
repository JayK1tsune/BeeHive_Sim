using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoneyBee : GAgent
{

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



    void CheckQueen()
    {
        beliefs.ModifyState("QueenNeedsHoney", 0);
        Invoke("CheckQueen", Random.Range(10, 20));
    }



}
