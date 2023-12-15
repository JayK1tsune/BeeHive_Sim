using System.Collections.Generic;
using BehaviorTree;
using UnityEngine.AI;

public class WaspBT : BTTree
{
    public UnityEngine.Transform[] waypoints;

    
    public static float speed = 5f;
    public static float fovRange = 6f;
    public static float attackRange = 1f;
    public static NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
    }

    protected override BTNode SetupTree()
    {
        //Create the tree structure here most important actions are at the top of the "Tree"
        BTNode root = new Selector(new List<BTNode>
        {
            new Sequence(new List<BTNode>
            {
                new CheckEnemyInAttackRange(transform),
                new TaskAttack(transform),
            }),
            new Sequence(new List<BTNode>
            {
                new CheckEnemyInFOVRange(transform),
                new TaskGoToTarget(transform),
            }),
            new TaskPatrol(transform, waypoints),
        });

        return root;
    }
}
