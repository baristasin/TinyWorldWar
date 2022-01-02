using Assets.Game.Scripts.Controllers;
using System.Collections;
using UnityEngine;

namespace Assets.Game.Scripts.BehaviourTree.Nodes
{
    public class IsThereAnEnemyNearNode : Node
    {
        private AIBehaviourTreeConnector _connector;

        private AICharacterController _aICharacterController;


        public IsThereAnEnemyNearNode(AIBehaviourTreeConnector connector)
        {
            _connector = connector;

            _aICharacterController = _connector.SoldierCharacterController.AICharacterController;

        }

        public override NodeState Evaluate()
        {

            var result = _aICharacterController.AIEnemyRadarBehaviour.IsThereAnEnemyNear
                ? NodeState.SUCCESS
                : NodeState.FAILURE;

            return result;


        }
    }
}