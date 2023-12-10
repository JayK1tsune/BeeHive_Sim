using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaspDetection : GAgent
{
    GameObject[] wasps;

    private float waspcount;


    protected override void Start()
    {
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

    bool isWaspNearby = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wasp"))
        {
            isWaspNearby = true;
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
    

}







