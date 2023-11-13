using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoIntoFlowerField : GAction
{
    public override bool PrePerform()
    {
        return true;
    }
    public override bool PostPerform()
    {
        GWorld.Instance.GetWorld().ModifyState("BeeWaiting", 1);
        GWorld.Instance.AddWorkerBees(this.gameObject);
        beliefs.ModifyState("AtFlowerField", 1);
        return true;
    }
}
