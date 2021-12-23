using System.Collections;
using UnityEngine;

namespace Assets.Game.Scripts.BehaviourTree.Nodes
{
    public class GoToAreaNode : Node
    {
        private AIBehaviourTreeConnector _connector;

        public GoToAreaNode(AIBehaviourTreeConnector connector)
        {
            _connector = connector;
        }

        public override NodeState Evaluate()
        {
            _connector.SoldierCharacterController.AICharacterController.AIMovementBehaviour.ToggleAIChallengedStatus(false);

            _connector.SoldierCharacterController.AICharacterController.AIMovementBehaviour.
            SetTargetPosition(_connector.SoldierCharacterController.GameManager.AreaController.
            GetNextArea(_connector.SoldierCharacterController.Team).AreaTransform.position);


            return NodeState.RUNNING;
        }
    }
}