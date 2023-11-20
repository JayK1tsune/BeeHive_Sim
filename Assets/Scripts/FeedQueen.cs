using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedQueen : GAction
{
    public override bool PrePerform()
    {
        return true;
    }
    public override bool PostPerform()
    {
        beliefs.RemoveState("QueenNeedsHoney");
        return true;
    }
}
