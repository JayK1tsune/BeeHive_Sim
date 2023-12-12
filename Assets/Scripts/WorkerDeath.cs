using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkerDeath : GAction
{
    public override bool PrePerform()
    {
        return true;
    }
    public override bool PostPerform()
    {
        GameObject.Destroy(this.gameObject,1);
        GWorld.Instance.GetWorld().ModifyState("FlowersAvailable", 1);
        return true;
    }
}
