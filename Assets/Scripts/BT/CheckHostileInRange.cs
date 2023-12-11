using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BT;
using UnityEngine.AI;

public class CheckHostileInRange : BT_Node
{
    private Transform _transform;
    private NavMeshAgent _agent;
    private BT_DefendBee _DefendBee;

    public static int _enemyLayer = 1 << 6;

    public CheckHostileInRange(Transform transform, NavMeshAgent agent, BT_DefendBee btBee)
    {
        _transform = transform;
        _agent = agent;
        _DefendBee = btBee;    

    }

    public override NodeState Evaluate()
    {
        object t = GetData("target");
        if (t == null)
        {
            Collider[] colliders = Physics.OverlapSphere(_transform.position, BT_DefendBee.FOVRange, _enemyLayer);
            Debug.Log(colliders.Length);

            if (colliders.Length > 0){

                parent.SetData("target", colliders[0].transform);
                if (colliders[0].transform.parent == null)
                {
                    Debug.Log(colliders[0].transform.parent.parent);
                    nodeState = NodeState.FAILURE;
                    return nodeState;
                }
                Debug.Log(transform.position);
                nodeState = NodeState.SUCCESS;
                Debug.Log("Found target");
                return nodeState;
                
            }

            nodeState = NodeState.FAILURE;
            return nodeState;
        }
        nodeState = NodeState.SUCCESS;
        return nodeState;
    }

}

