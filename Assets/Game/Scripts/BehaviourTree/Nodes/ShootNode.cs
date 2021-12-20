using System.Collections;
using UnityEngine;

namespace Assets.Game.Scripts.BehaviourTree.Nodes
{
    public class ShootNode : Node
    {
        private AIBehaviourTreeConnector _connector;

        public override NodeState Evaluate()
        {
            _connector.SoldierCharacterController.AICharacterController.AIaimBehaviour.
                SetAimTarget(_connector.SoldierCharacterController.AICharacterController.AIEnemyRadarBehaviour.CurrentEnemyTransform);

            return NodeState.RUNNING;
        }
    }
}