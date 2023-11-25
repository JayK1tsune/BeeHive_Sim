using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoneyBee : GAgent
{
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        SubGoal s1 = new SubGoal("HarvestHoney", 1, false);
        goals.Add(s1, 3);

        SubGoal s2 = new SubGoal("FedQueen", 1, false); 
        goals.Add(s2, 5);

        Invoke("CheckQueen", Random.Range(10, 20));
    }   

    void CheckQueen()
    {
        beliefs.ModifyState("QueenNeedsHoney", 1);
        Invoke("ResetQueen", Random.Range(10, 20));
    }

}
