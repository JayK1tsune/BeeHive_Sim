using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WorldState
{
    public string key; // name of the world state
    public int value;
}

public class WorldStates 
{
    public Dictionary<string, int> states;

    public WorldStates()
    {
        states = new Dictionary<string, int>();
    }

    public bool HasState(string key)
    {
        return states.ContainsKey(key); // returns true if the key is in the dictionary
    }

    void AddState(string key, int value)
    {
        states.Add(key, value); // adds a new key and value to the dictionary
    }

    public void ModifyState(string key, int value)
    {
        if (states.ContainsKey(key))
        {
            states[key] += value; // modifies the value of the key
            if (states[key] <= 0)
            {
                RemoveState(key); // removes the key if the value is less than or equal to 0
            }
        }
        else
        {
            states.Add(key, value); // adds a new key and value to the dictionary
        }
    }

    public void RemoveState(string key)
    {
        if (states.ContainsKey(key))
        {
            states.Remove(key); // removes the key from the dictionary
        }
    }

    public void SetState(string key, int value)
    {
        if (states.ContainsKey(key))
        {
            states[key] = value; // sets the value of the key
        }
        else
        {
            states.Add(key, value); // adds a new key and value to the dictionary
        }
    }
    public Dictionary<string, int> GetStates()
    {
        return states; // returns the dictionary
    }

}
