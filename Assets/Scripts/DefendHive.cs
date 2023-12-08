using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DefendHive : GAction
{
    public override bool PrePerform()
    {
        target = GWorld.Instance.GetQueue("wasps").RemoveResource();
        if (target == null)
        {
            return false;
        }
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.speed = 10;
        return true;
    }
    public override bool PostPerform()
    {
        beliefs.RemoveState("HiveIsUnderAttack");
        agent.speed = 5;
        return true;
    }

    public void DestroyWasp(GameObject wasp, float delay)
    { 
        wasp = target;
        Destroy(target,delay);
    }

    void Defendbees()
    {
        beliefs.ModifyState("HiveIsUnderAttack", 0);
        Invoke("Defendbees", 0);
    }
    void UpdateWaspPosition()
    {
        target = GWorld.Instance.GetQueue("wasps").RemoveResource();
    }
    void Update()
    {
        UpdateWaspPosition();
    }

}
