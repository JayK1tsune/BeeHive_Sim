using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class GWorld
{
    private static readonly GWorld instance = new GWorld();
    private static WorldStates world;
    private static Queue<GameObject> workerBees;
    private static Queue<GameObject> hives;
    private static Queue<GameObject> flowers;

    static GWorld()
    {
        world = new WorldStates();
        workerBees = new Queue<GameObject>();
        hives = new Queue<GameObject>();
        flowers = new Queue<GameObject>();

        GameObject[] _hives = GameObject.FindGameObjectsWithTag("Hives");
        foreach (GameObject h in _hives)
        {
            hives.Enqueue(h);
        }
        if (_hives.Length > 0)
        {
            world.ModifyState("HivesAvailable", _hives.Length);
        }

        GameObject[] flow = GameObject.FindGameObjectsWithTag("Flower");
        foreach (GameObject f in flow)
        {
            flowers.Enqueue(f);
        }
        if (flow.Length > 0)
        {
            world.ModifyState("FlowersAvailable", flow.Length);
        }
    }

    private GWorld()
    {
    }
    public void AddFlowers(GameObject f){
        flowers.Enqueue(f);
    }
    public GameObject RemoveFlowers(){
        if(flowers.Count == 0){
            return null;
        }
        return flowers.Dequeue();
    }
    public void AddHives(GameObject h){
        hives.Enqueue(h);
    }
    public GameObject RemoveHives(){
        if(hives.Count == 0){
            return null;
        }
        return hives.Dequeue();
    }
    public void AddWorkerBees(GameObject b){
        workerBees.Enqueue(b);
    }
    public GameObject RemoveWorkerBees(){
        if(workerBees.Count == 0){
            return null;
        }
        return workerBees.Dequeue();
    }

    public static GWorld Instance
    {
        get
        {
            return instance;
        }
    }
    public WorldStates GetWorld()
    {
        return world;
    }
}
