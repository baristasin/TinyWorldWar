using System.Collections;
using UnityEngine;

namespace Assets.Game.Scripts.BehaviourTree.Nodes
{
    public class IsThereAnEnemyNearNode : Node
    {
        private AIBehaviourTreeConnector _connector;

        public override NodeState Evaluate()
        {
            return _connector.SoldierCharacterController.AICharacterController.AIEnemyRadarBehaviour.IsThereAnEnemyNear
                ? NodeState.SUCCESS
                : NodeState.FAILURE;
        }
    }
}