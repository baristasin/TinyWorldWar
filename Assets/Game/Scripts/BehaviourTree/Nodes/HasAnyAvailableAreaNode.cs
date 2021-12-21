using System.Collections;
using UnityEngine;

namespace Assets.Game.Scripts.BehaviourTree.Nodes
{
    public class HasAnyAvailableAreaNode : Node
    {
        private AIBehaviourTreeConnector _connector;

        public HasAnyAvailableAreaNode(AIBehaviourTreeConnector connector)
        {
            _connector = connector;
        }

        public override NodeState Evaluate()
        {
            Debug.Log($"TreeBehaviour: HasAnyAvailableAreaNode temporarily NodeState.SUCCESS");

            return NodeState.SUCCESS; // Temp
        }
    }
}