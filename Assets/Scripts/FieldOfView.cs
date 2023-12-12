using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class FieldOfView : GAgent
{
    public float viewRadius;
    [Range(0, 360)]
    public float viewAngle;
    public LayerMask targetMask;
    public LayerMask obstacleMask;
    public bool canSeeBee;
    public bool canSeeWasp;
    public GameObject currentWasp;
    public GameObject currentBee;
    public GameObject[] wasp;
    public GameObject[] bee;

    private NavMeshAgent agent;

    protected override void Start()
    {
        base.Start();
        StartCoroutine("FOVRoutine");
        agent = GetComponent<NavMeshAgent>();
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

    public void FieldOfViewCheck()
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
                    if (target.CompareTag("Wasp"))
                    {
                        canSeeWasp = true;
                        canSeeBee = false;
                        agent.SetDestination(target.position);
                    }
                    else if (target.CompareTag("DefenceBee"))
                    {
                        canSeeBee = true;
                        canSeeWasp = false;
                        agent.SetDestination(target.position);
                    }
                }
                else
                {
                    canSeeWasp = false;
                    canSeeBee = false;
                }
            }
            else
            {
                canSeeWasp = false;
                canSeeBee = false;
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
