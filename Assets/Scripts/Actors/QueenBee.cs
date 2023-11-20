using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueenBee : GAgent
{
    // Start is called before the first frame update
    new void LateUpdate()
    {
        base.LateUpdate();
        if (GWorld.Instance.GetWorld().states.ToString().Contains("HoneyMade"))
        {
            this.GetComponent<Transform>().localScale = new Vector3(10f, 10f, 10f);
        }

    }
}
