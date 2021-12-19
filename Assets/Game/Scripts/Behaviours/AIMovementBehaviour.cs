using Assets.Game.Scripts.Controllers;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Game.Scripts.Behaviours
{
    public class AIMovementBehaviour : BaseCharacterBehaviour
    {
        public Vector3 TargetPosition => _targetPosition;

        [SerializeField] private NavMeshAgent _navMeshAgent;

        private Vector3 _targetPosition;

        public override void Initialize(SoldierCharacterController soldierCharacterController)
        {
            base.Initialize(soldierCharacterController);
        }
       
        public override void Activate()
        {
            base.Activate();
        }

        private void Update()
        {
            if (!_isActivated || !_isInitialized) return;

            _navMeshAgent.SetDestination(_targetPosition);
        }

        public void SetTargetPosition(Vector3 targetPosition)
        {
            targetPosition.y = transform.position.y;

            _targetPosition = targetPosition;
        }

        public override void Deactivate()
        {
            base.Deactivate();
        }
    }
}