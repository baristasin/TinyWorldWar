using Assets.Game.Scripts.Controllers;
using System.Collections;
using UnityEngine;

namespace Assets.Game.Scripts.BehaviourTree
{
    public class AIBehaviourTreeConnector : MonoBehaviour
    {
        public SoldierCharacterController SoldierCharacterController => _soldierCharacterController;

        private SoldierCharacterController _soldierCharacterController;

        public void Initialize(SoldierCharacterController soldierCharacterController)
        {
            _soldierCharacterController = soldierCharacterController;
        }

    }
}