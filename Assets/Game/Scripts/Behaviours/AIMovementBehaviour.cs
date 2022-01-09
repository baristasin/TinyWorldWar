﻿using Assets.Game.Scripts.Controllers;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Game.Scripts.Behaviours
{
    public class AIMovementBehaviour : BaseCharacterBehaviour
    {
        public bool IsAIChallenged => _isAIChallenged;

        public Vector3 TargetPosition => _targetPosition;

        [SerializeField] private NavMeshAgent _navMeshAgent;
        [SerializeField] private Animator _aiAnimator;

        private Vector3 _targetPosition;

        private Vector3 _dodgeMovementPosition;

        private bool _isAIChallenged;

        private Coroutine _dodgeMovementRoutine;

        public override void Initialize(SoldierCharacterController soldierCharacterController)
        {
            base.Initialize(soldierCharacterController);

            _navMeshAgent.speed = Random.Range(3.5f, 5f);
        }

        public override void Activate()
        {
            base.Activate();
        }

        private void Update()
        {
            if (!_isActivated || !_isInitialized) return;

            _navMeshAgent.updateRotation = !_soldierCharacterController.AICharacterController.AIaimBehaviour.IsAiming;

            if (!_isAIChallenged && Vector3.Distance(transform.position, _targetPosition) > 1.5f)
            {
                _aiAnimator.SetBool("isWalking", true);
                _aiAnimator.SetBool("isIdle", false);                
            }

            else
            {
                _aiAnimator.SetBool("isWalking", false);
                _aiAnimator.SetBool("isIdle", true);
            }

            if (_soldierCharacterController.AICharacterController.AIaimBehaviour.IsAiming)
            {
                transform.LookAt(_soldierCharacterController.AICharacterController.AIaimBehaviour.AimTarget);
            }

            if (!_isAIChallenged || !_soldierCharacterController.AICharacterController.AIaimBehaviour.CanSeeEnemy)
            {
                _navMeshAgent.SetDestination(_targetPosition);
            }

            else
            {
                _navMeshAgent.SetDestination(_dodgeMovementPosition);
            }
        }

        private IEnumerator DodgeMovementCo()
        {
            while (true)
            {
                _dodgeMovementPosition = new Vector3(Random.Range(transform.position.x - 2f, transform.position.x + 2f)
                    , transform.position.y
                    , Random.Range(transform.position.z - 2f, transform.position.z + 2f));

                yield return new WaitForSeconds(1.5f);
            }
        }

        public void SetTargetPosition(Vector3 targetPosition)
        {
            targetPosition.y = transform.position.y;

            _targetPosition = targetPosition;
        }

        public void ToggleAIChallengedStatus(bool toggle)
        {
            _isAIChallenged = toggle;

            if (toggle)
            {
                if (_dodgeMovementRoutine == null)
                {
                    _dodgeMovementRoutine = StartCoroutine(DodgeMovementCo());
                }
            }

            else
            {
                if (_dodgeMovementRoutine != null)
                {
                    StopCoroutine(_dodgeMovementRoutine);
                    _dodgeMovementRoutine = null;
                }
            }
        }

        public override void Deactivate()
        {
            base.Deactivate();
        }
    }
}