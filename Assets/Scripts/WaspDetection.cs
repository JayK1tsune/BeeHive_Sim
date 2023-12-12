using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BT;


public class WaspDetection : GAgent
{
    GameObject[] wasps;
  
    private float waspcount;
    private GameObject[] BT_DefendBee;
    BT_DefendBee bt_DefendBee;

    protected override void Start()
    {
        base.Start();
        InvokeRepeating("FindAllWasps", 0f, 30f);
        for (int i = 0; i < BT_DefendBee.Length; i++)
        {
            BT_DefendBee[i] = GameObject.FindGameObjectWithTag("DefenceBee");
        }
        bt_DefendBee = BT_DefendBee[0].GetComponent<BT_DefendBee>();
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
            //bt_DefendBee.HoneyBeeUnderAttack = true;

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







