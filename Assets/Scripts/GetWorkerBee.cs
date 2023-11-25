using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetWorkerBee : GAction
{
    GameObject resource;
    public override bool PrePerform()
    {
        target = GWorld.Instance.RemoveWorkerBees();
        if(target == null){
            return false;
        }
        resource = GWorld.Instance.RemoveHives();
        if(resource != null){
            inventory.AddItem(resource);
        }
        else { //If we have no hives then we can release the Bee as we have no need for the worker.
            GWorld.Instance.AddWorkerBees(target);
            target = null;
            return false;
        }

        GWorld.Instance.GetWorld().ModifyState("HivesAvailable", -1); // -1 because we are removing a hive
        return true;
    }
    public override bool PostPerform()
    {
        GWorld.Instance.GetWorld().ModifyState("BeeWaiting", -1);
        if(target){
            target.GetComponent<GAgent>().inventory.AddItem(resource); // Add the hive to the worker bee's inventory
        }
        return true;
    }
}
