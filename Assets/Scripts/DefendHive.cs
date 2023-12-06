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
    bool isWaspNearby = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wasp"))
        {
            isWaspNearby = true;
            beliefs.ModifyState("HiveIsUnderAttack", 1);
            Defendbees();
            DestroyWasp(target,10f);
            Debug.Log("Wasp entered the area!");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Wasp")
        {
            isWaspNearby = false;
             Debug.Log("Wasp is dead");   
        }
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
