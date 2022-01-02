using Assets.Game.Scripts.Controllers;
using System.Collections;
using UnityEngine;

namespace Assets.Game.Scripts.BehaviourTree.Nodes
{
    public class GoToAreaNode : Node
    {
        private AIBehaviourTreeConnector _connector;

        private AICharacterController _aICharacterController;

        public GoToAreaNode(AIBehaviourTreeConnector connector)
        {
            _connector = connector;

            _aICharacterController = _connector.SoldierCharacterController.AICharacterController;

        }

        public override NodeState Evaluate()
        {
            _aICharacterController.AIMovementBehaviour.ToggleAIChallengedStatus(false);

            _aICharacterController.AIMovementBehaviour.
            SetTargetPosition(_connector.SoldierCharacterController.GameManager.AreaController.
            GetNextArea(_connector.SoldierCharacterController.Team, _aICharacterController.IsAggressive).AreaTransform.position);


            return NodeState.RUNNING;
        }
    }
}