using BT;
using UnityEngine;
using UnityEngine.AI;

public class BT_Wasp : BT_Tree
{
    public Transform[] flowers;
    public float speed = 10f;
    private NavMeshAgent _agent;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    protected override BT_Node SetupTree()
    {
        BT_Node root = new WaspPatrol(transform, flowers, _agent, this);
        return root;
    }
}

