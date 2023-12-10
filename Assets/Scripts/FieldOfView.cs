using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : GAgent
{
    public float viewRadius;
    [Range(0, 360)]
    public float viewAngle;
    public GameObject[] wasp;
    public GameObject[] bee;
    public GameObject currentWasp;
    public LayerMask targetMask;
    public LayerMask obstacleMask;
    public bool canSeeBee;
    public bool canSeeWasp;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        StartCoroutine("FOVRoutine");
    }

    private IEnumerator FOVRoutine()
    {

        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while (true)
        {
            yield return wait;
            FieldOfViewCheck();
        }
    }
    private void FieldOfViewCheck()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, viewRadius, targetMask);
        if (rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 dirToTarget = (target.position - transform.position).normalized;
            if (Vector3.Angle(transform.forward, dirToTarget) < viewAngle / 2)
            {
                float distToTarget = Vector3.Distance(transform.position, target.position);
                if (!Physics.Raycast(transform.position, dirToTarget, distToTarget, obstacleMask))
                {
                    canSeeBee = true;
                    canSeeWasp = true;
                    Debug.Log("Wasp can see bee");
                }
                else
                {
                    canSeeWasp = false;
                    canSeeBee = false;
                    Debug.Log("Wasp can't see bee");
                }
            }
            else 
            {
                canSeeWasp = false;
                canSeeBee = false;
                Debug.Log("Wasp can't see bee");
            }
        }
    }  
    void Update()
    {
        wasp = GameObject.FindGameObjectsWithTag("DefenceBee");
        bee = GameObject.FindGameObjectsWithTag("Wasp");
        FindColesetWasp();
        FindClosestBee();
           
    }
    void FindColesetWasp()
    {
        float closestDistance = Mathf.Infinity;
        GameObject closestWasp = null;
        foreach (GameObject currentWasp in wasp)
        {
            float distance = Vector3.Distance(transform.position, currentWasp.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestWasp = currentWasp;
            }
        }
        currentWasp = closestWasp;
    }
    void FindClosestBee()
    {
        float closestDistance = Mathf.Infinity;
        GameObject closestBee = null;
        foreach (GameObject currentBee in bee)
        {
            float distance = Vector3.Distance(transform.position, currentBee.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestBee = currentBee;
            }
        }
        currentWasp = closestBee;
    }
}