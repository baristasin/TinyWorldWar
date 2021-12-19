using System.Collections;
using UnityEngine;

namespace Assets.Game.Scripts.BehaviourTree.Nodes
{
    public class HealthNode : Node
    {
        private AIBehaviourTreeConnector _connector;
        private float _lowHealthThreshold;

        public override NodeState Evaluate()
        {
            return _connector.SoldierCharacterController.AICharacterController.CharacterHealthBehaviour.CurrentHealth < _lowHealthThreshold 
                ? NodeState.SUCCESS 
                : NodeState.FAILURE;
        }
    }
}