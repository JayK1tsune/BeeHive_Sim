using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeBeeToHive : GAction
{
    public override bool PrePerform()
    {
        target = inventory.FindItemWithTag("Hives");
        
        if(target == null){
            return false;
        }
        return true;
    }
    public override bool PostPerform()
    {
        GWorld.Instance.GetWorld().ModifyState("HoneyMade", 1);
        GWorld.Instance.AddHives(target);
        inventory.RemoveItem(target);
        GWorld.Instance.GetWorld().ModifyState("HivesAvailable", 1);
        return true;
    }

}
