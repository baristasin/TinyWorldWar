﻿using System.Collections;
using UnityEngine;

namespace Assets.Game.Scripts.BehaviourTree.Nodes
{
    public class GoNearestHospitalNode : Node
    {
        private AIBehaviourTreeConnector _connector;

        public GoNearestHospitalNode(AIBehaviourTreeConnector connector)
        {
            _connector = connector;
        }

        public override NodeState Evaluate()
        {
            _connector.SoldierCharacterController.AICharacterController.AIMovementBehaviour.ToggleAIChallengedStatus(false);

            _connector.SoldierCharacterController.AICharacterController.AIMovementBehaviour.
                SetTargetPosition(_connector.SoldierCharacterController.GameManager.HospitalController.HospitalTransforms[0].position);

            Debug.Log($"TreeBehaviour: GoNearestHospitalNode Temporarily NodeState.RUNNING");

            return NodeState.RUNNING;
        }
    }
}