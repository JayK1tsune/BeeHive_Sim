using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkerBee : GAgent
{
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        SubGoal s1 = new SubGoal("CanHarvest", 1, true);
        goals.Add(s1, 3);

        SubGoal s2 = new SubGoal("isHarvested", 1, true);
        goals.Add(s2, 5);

        SubGoal s3 = new SubGoal("isDead", 1, true);
        goals.Add(s3, 5);
    }

}
