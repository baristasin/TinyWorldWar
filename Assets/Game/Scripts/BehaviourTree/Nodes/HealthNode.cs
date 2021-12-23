using System.Collections;
using UnityEngine;

namespace Assets.Game.Scripts.BehaviourTree.Nodes
{
    public class HealthNode : Node
    {
        private AIBehaviourTreeConnector _connector;
        private float _lowHealthThreshold;

        public HealthNode(AIBehaviourTreeConnector connector, float lowHealthThreshold)
        {
            _connector = connector;
            _lowHealthThreshold = lowHealthThreshold;
        }

        public override NodeState Evaluate()
        {
            var result = _connector.SoldierCharacterController.AICharacterController.CharacterHealthBehaviour.CurrentHealth < _lowHealthThreshold
                ? NodeState.SUCCESS
                : NodeState.FAILURE;

            return result;

        }
    }
}