using System.Collections.Generic;

namespace BT
{
    public class BT_Sequence : BT_Node
    {
        public BT_Sequence() : base() { }
        public BT_Sequence(List<BT_Node> children) : base(children) { }

        public override NodeState Evaluate()
        {
            bool anyChildIsRunning = false;

            foreach (BT_Node node in children)
            {
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

            nodeState = anyChildIsRunning ? NodeState.RUNNING : NodeState.SUCCESS;
            return nodeState;
        }

    }

}