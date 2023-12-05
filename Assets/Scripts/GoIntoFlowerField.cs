using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoIntoFlowerField : GAction
{
    GameObject resource;
    public override bool PrePerform()
    {
        target = GWorld.Instance.GetQueue("flowers").RemoveResource(); //  RemoveFlowers();       
        return true;
    }
    public override bool PostPerform()
    {
        
        GWorld.Instance.GetWorld().ModifyState("BeeWaiting", 1);
        GWorld.Instance.GetQueue("workerbees").AddResource(this.gameObject);//  AddWorkerBees(this.gameObject);
        beliefs.ModifyState("AtFlowerField", 1);
        GWorld.Instance.GetWorld().ModifyState("FlowersAvailable", -1);
        return true;
    }
}
