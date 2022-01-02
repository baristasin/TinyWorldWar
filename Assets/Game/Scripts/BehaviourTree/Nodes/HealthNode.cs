using Assets.Game.Scripts.Controllers;
using System.Collections;
using UnityEngine;

namespace Assets.Game.Scripts.BehaviourTree.Nodes
{
    public class HealthNode : Node
    {
        private AIBehaviourTreeConnector _connector;
        private float _lowHealthThreshold;

        private AICharacterController _aICharacterController;


        public HealthNode(AIBehaviourTreeConnector connector, float lowHealthThreshold)
        {
            _connector = connector;
            _lowHealthThreshold = lowHealthThreshold;

            _aICharacterController = _connector.SoldierCharacterController.AICharacterController;
        }

        public override NodeState Evaluate()
        {
            if (_aICharacterController.CharacterHealthBehaviour.IsGettingTreatment)
            {
                return NodeState.SUCCESS;
            }

            var result = _aICharacterController.CharacterHealthBehaviour.CurrentHealth < _lowHealthThreshold
                ? NodeState.SUCCESS
                : NodeState.FAILURE;

            return result;

        }
    }
}