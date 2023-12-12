using System;
using System.Collections.Generic;
using BT;
using UnityEngine;
using UnityEngine.AI;

public class BT_DefendBee : BT_Tree
{
    public Transform[] flowers;
    public float speed = 10f;
    public static float FOVRange = 6f;
    private NavMeshAgent _agent;
    private NavMeshAgent _agentBee;
    private FieldOfView _fieldOfView; // Added FieldOfView instance
    public bool HoneyBeeUnderAttack = false;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        
    }

    protected override BT_Node SetupTree()
    {

        //BT_Node root = new BeePatrol(transform, flowers, _agent, this);
        BT_Node root = new BT_Selector(new List<BT_Node>
        {
            new BT_Sequence(new List<BT_Node>
            {
                new CheckHostileInRange(transform, _agent, this, _fieldOfView),
                new TaskGoTowardsWasp(transform, _agent, this),
            }),
            new BeePatrol(transform, flowers, _agent, this),
        });
        return root;
    }

    private void Update()
    {
        if (HoneyBeeUnderAttack == true)
        {
            _agent.SetDestination(GameObject.FindGameObjectWithTag("Wasp").transform.position);
        }
        else
        {
            _agent.SetDestination(flowers[0].position);
        }
    }


}

