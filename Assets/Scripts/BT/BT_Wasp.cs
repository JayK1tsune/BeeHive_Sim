using UnityEngine;
using UnityEngine.AI;
using System.Linq;
using BT;

public class BT_Wasp : BT_Tree
{
    public Transform[] flowers;
    private NavMeshAgent _agent;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        GameObject[] flowerObjects = GameObject.FindGameObjectsWithTag("Flower");
        
        // Store transforms in the flowers array
        flowers = flowerObjects.Select(obj => obj.transform).ToArray();

        // Shuffle the flowers array
        Shuffle(flowers);

        // Assign the first flower to the current agent
        if (flowers.Length > 0)
        {
            _agent.SetDestination(flowers[0].position);
        }
    }

    // Fisher-Yates shuffle algorithm for shuffling the flowers array in place. otherwise 
    //the wasp will always go to the same flower
    private void Shuffle<T>(T[] array)
    {
        System.Random random = new System.Random();
        int n = array.Length;
        for (int i = 0; i < n; i++)
        {
            int r = i + random.Next(n - i);
            T temp = array[r];
            array[r] = array[i];
            array[i] = temp;
        }
    }

    protected override BT_Node SetupTree()
    {
        BT_Node root = new WaspPatrol(transform, flowers, _agent, this);
        return root;
    }
}


