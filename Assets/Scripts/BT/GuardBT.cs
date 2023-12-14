using System.Collections.Generic;
using BehaviorTree;

public class GuardBT : BTTree
{
    public UnityEngine.Transform[] waypoints;

    public static float speed = 2f;
    public static float fovRange = 6f;
    public static float attackRange = 1f;

    protected override BTNode SetupTree()
    {
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
