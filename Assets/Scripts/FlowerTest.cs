using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerTest : GAction
{
    public override bool PrePerform()
    {
        target = GWorld.Instance.RemoveFlowers(); // get the flower from the world
        //Debug.Log("FlowerTest: PrePerform: target = " + target);
        if (target == null)
            return false;
        inventory.AddItem(target);
        GWorld.Instance.GetWorld().ModifyState("FlowersAvailable", -1);
        Debug.Log("FlowerTest: PrePerform: target = " + target);
        return true;
    }
    public override bool PostPerform()
    {
        GWorld.Instance.AddFlowers(target); // add the flower back to the world
        inventory.RemoveItem(target); // remove the flower from the inventory
        GWorld.Instance.GetWorld().ModifyState("FlowersAvailable", 1); // update the world state
        //Debug.Log("FlowerTest: PostPerform: target = " + target);
        return true;
    }
}
