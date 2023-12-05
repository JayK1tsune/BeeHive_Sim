using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceQueue{
    public Queue<GameObject> que = new Queue<GameObject>();
    public string tag;
    public string modstate;

    // constructor for the resource queue
    public ResourceQueue(string t, string m, WorldStates w){
        tag = t;
        modstate = m;
        if (tag != ""){
            GameObject[] resources = GameObject.FindGameObjectsWithTag(tag);
            foreach (GameObject r in resources){
                que.Enqueue(r);
            }
        }
        if(modstate != ""){
            w.ModifyState(modstate, que.Count); // modify the state of the world
        }
    }
    // Constructor for the Add and remove functions
    public void AddResource(GameObject r){
        que.Enqueue(r);
    }
    public GameObject RemoveResource(){
        if(que.Count == 0){
            return null;
        }
        return que.Dequeue();
    }

}
public sealed class GWorld
{
    private static readonly GWorld instance = new GWorld();
    private static WorldStates world;
    private static ResourceQueue workerBees;
    private static ResourceQueue hives;
    private static ResourceQueue flowers;
    private static Dictionary<string, ResourceQueue> resources = new Dictionary<string, ResourceQueue>(); // dictionary of all the resources

    static GWorld()
    {
        world = new WorldStates();
        workerBees = new ResourceQueue("","",world);
        resources.Add("workerbees",workerBees);
        hives = new ResourceQueue("Hives","HivesAvailable",world);
        resources.Add("hives",hives);
        flowers = new ResourceQueue("Flower","FlowersAvailable",world);
        resources.Add("flowers",flowers);
    }
    public ResourceQueue GetQueue(string tag){
        return resources[tag];
    }

    private GWorld()
    {
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
