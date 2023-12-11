using System.Collections.Generic;

namespace BT
{
    public class BT_Sequence : BT_Node
    {
        public BT_Sequence() : base() { }
        public BT_Sequence(List<BT_Node> children) : base(children) { }
        // The sequence node will return success only when all children return success.
        public override NodeState Evaluate()
        {
            bool anyChildIsRunning = false;

            foreach (BT_Node node in children)
            {
                // Evaluate the child node and store the result in a local variable
                switch (node.Evaluate())
                {
                    case NodeState.FAILURE:
                        nodeState = NodeState.FAILURE;
                        return nodeState;
                    case NodeState.SUCCESS:
                        continue;
                    case NodeState.RUNNING:
                        anyChildIsRunning = true;
                        continue;
                    default:
                        nodeState = NodeState.SUCCESS;
                        return nodeState;
                }
            }
            // If we get here, then all children either succeeded or are still running
            nodeState = anyChildIsRunning ? NodeState.RUNNING : NodeState.SUCCESS;
            return nodeState;
        }

    }

}