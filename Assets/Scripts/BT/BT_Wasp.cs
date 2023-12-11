using BT;
using UnityEngine;
using UnityEngine.AI;

public class BT_Wasp : BT_Tree
{
    public Transform[] flowers;
    // this speed gets passed to the NavMeshAgent but is now unused due to using the NavMeshAgent's speed instead
    //public float speed = 10f;
    private NavMeshAgent _agent;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }
    
    protected override BT_Node SetupTree()
    {
        // Create the root node and add children to it in the constructor call
        BT_Node root = new WaspPatrol(transform, flowers, _agent, this);
        return root;
    }
}

