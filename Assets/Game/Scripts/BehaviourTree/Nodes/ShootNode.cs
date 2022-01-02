using Assets.Game.Scripts.Controllers;
using System.Collections;
using UnityEngine;

namespace Assets.Game.Scripts.BehaviourTree.Nodes
{
    public class ShootNode : Node
    {
        private AIBehaviourTreeConnector _connector;

        private AICharacterController _aICharacterController;


        public ShootNode(AIBehaviourTreeConnector connector)
        {
            _connector = connector;

            _aICharacterController = _connector.SoldierCharacterController.AICharacterController;

        }

        public override NodeState Evaluate()
        {
            _aICharacterController.AIMovementBehaviour.ToggleAIChallengedStatus(true);


            _aICharacterController.AIaimBehaviour.
                SetAimTarget(_aICharacterController.AIEnemyRadarBehaviour.CurrentEnemyTransform);



            return NodeState.RUNNING;
        }
    }
}