using System.Collections;
using UnityEngine;

namespace Assets.Game.Scripts.BehaviourTree.Nodes
{
    public class IsThereAnEnemyNearNode : Node
    {
        private AIBehaviourTreeConnector _connector;

        public IsThereAnEnemyNearNode(AIBehaviourTreeConnector connector)
        {
            _connector = connector;
        }

        public override NodeState Evaluate()
        {

            var result = _connector.SoldierCharacterController.AICharacterController.AIEnemyRadarBehaviour.IsThereAnEnemyNear
                ? NodeState.SUCCESS
                : NodeState.FAILURE;

            Debug.Log($"TreeBehaviour: IsThereAnEnemyNearNode {result}");
            return result;


        }
    }
}