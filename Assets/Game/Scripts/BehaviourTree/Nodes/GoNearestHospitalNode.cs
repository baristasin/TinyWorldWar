using Assets.Game.Scripts.Controllers;
using System.Collections;
using UnityEngine;

namespace Assets.Game.Scripts.BehaviourTree.Nodes
{
    public class GoNearestHospitalNode : Node
    {
        private AIBehaviourTreeConnector _connector;

        private AICharacterController _aICharacterController;

        public GoNearestHospitalNode(AIBehaviourTreeConnector connector)
        {
            _connector = connector;

            _aICharacterController = _connector.SoldierCharacterController.AICharacterController;
        }

        public override NodeState Evaluate()
        {
            _connector.SoldierCharacterController.AICharacterController.AIMovementBehaviour.ToggleAIChallengedStatus(false);

            _aICharacterController.AIMovementBehaviour.
                SetTargetPosition(_connector.SoldierCharacterController.GameManager.HospitalController
                .GetNearestHospital(_connector.SoldierCharacterController.Team).transform.position);

            if (Vector3.Distance(_aICharacterController.transform.position, _connector.SoldierCharacterController.GameManager.HospitalController
                .GetNearestHospital(_connector.SoldierCharacterController.Team).transform.position) < 5f)
            {
                _aICharacterController.CharacterHealthBehaviour.UpdateHealth(1);

                if(_aICharacterController.CharacterHealthBehaviour.CurrentHealth < 75)
                {
                    _aICharacterController.CharacterHealthBehaviour.IsGettingTreatment = true;
                }
                else
                {
                    _aICharacterController.CharacterHealthBehaviour.IsGettingTreatment = false;
                }

            }


            return NodeState.RUNNING;
        }
    }
}