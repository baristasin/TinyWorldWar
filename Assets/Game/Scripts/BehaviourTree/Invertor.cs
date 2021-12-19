using System.Collections;
using UnityEngine;

namespace Assets.Game.Scripts.BehaviourTree
{
    public class Invertor : Node
    {
        protected Node _node;

        public Invertor(Node node)
        {
            _node = node;
        }

        public override NodeState Evaluate()
        {

            switch (_node.Evaluate())
            {
                case NodeState.RUNNING:
                    _nodeState = NodeState.RUNNING;

                    break;
                case NodeState.SUCCESS:
                    _nodeState = NodeState.FAILURE;
                    break;
                case NodeState.FAILURE:
                    _nodeState = NodeState.SUCCESS;
                    break;
                default:
                    break;
            }
            return _nodeState;
        }
    }
}