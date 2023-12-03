using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoPatrolWasp : GAction
{
    public override bool PostPerform()
    {
        GWorld.Instance.GetWorld().ModifyState("IsPatroling", 1);
        
        return true;
    }

    public override bool PrePerform()
    {
        target = FindPath();
        if (target == null)
            return false;

        return true;
       
    }

    public GameObject FindPath()
    {
        //create a list of all the patrol points and then randomly select one once it get to the patrol point it will select another one
        {
            GameObject[] targets = GameObject.FindGameObjectsWithTag("Flower");
            return targets[UnityEngine.Random.Range(0, targets.Length)];    
        }
    }

}
