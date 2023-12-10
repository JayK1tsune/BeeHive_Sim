using System.Collections.Generic;

namespace BT
{
    public class BT_Selectorctor : BT_Node
    {
        public BT_Selectorctor() : base() { }
        public BT_Selectorctor(List<BT_Node> children) : base(children) { }

        public override NodeState Evaluate()
        {
            foreach (BT_Node node in children)
            {
                switch (node.Evaluate())
                {
                    case NodeState.FAILURE:
                        continue;
                    case NodeState.SUCCESS:
                        nodeState = NodeState.SUCCESS;
                        return nodeState;
                    case NodeState.RUNNING:
                        nodeState = NodeState.RUNNING;
                        return nodeState;
                    default:
                        continue;
                }
            }

            nodeState = NodeState.FAILURE;
            return nodeState;
        }

    }

}