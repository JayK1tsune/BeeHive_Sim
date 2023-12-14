using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;


public class WaspDetection : GAgent
{
    GameObject[] wasps;
    NavMeshAgent agent;
    private float waspcount;
    private GameObject[] BT_DefendBee;
  

    protected override void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        base.Start();
        InvokeRepeating("FindAllWasps", 0f, 30f);

    }
    void Update()
    {
        waspcount = wasps.Length;
        if (waspcount == 0 && isWaspNearby == true)
        {
            Debug.Log("Wasp Count: " + wasps.Length);
        }
        
        
    }
    void FindAllWasps()
    {
        wasps = GameObject.FindGameObjectsWithTag("Wasp");
    }

    public bool isWaspNearby = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wasp"))
        {
            isWaspNearby = true;
            //bt_DefendBee.HoneyBeeUnderAttack = true;
            agent.SetDestination(other.transform.position);
            Debug.Log("Wasp entered the area!");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Wasp")
        {
           
            isWaspNearby = false;
            Debug.Log("Wasp is not nearby");   
        }
    }

public Transform GetNearestWaspTransform()
    {
        Transform nearestWasp = null;
        float minDistance = Mathf.Infinity;
        foreach (GameObject wasp in wasps)
        {
            float distance = Vector3.Distance(transform.position, wasp.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                nearestWasp = wasp.transform;
            }
        }
        return nearestWasp;
    }

    

}







