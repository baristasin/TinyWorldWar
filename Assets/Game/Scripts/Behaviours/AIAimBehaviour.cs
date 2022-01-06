using Assets.Game.Scripts.Controllers;
using Sirenix.OdinInspector;
using System.Collections;
using UnityEngine;

namespace Assets.Game.Scripts.Behaviours
{
    public class AIAimBehaviour : BaseCharacterBehaviour
    {
        public bool IsAiming => _isAiming;
        public Transform AimTarget => _aimTarget;

        public bool CanSeeEnemy => _canSeeEnemy;

        [SerializeField] private Transform _aimingTransform;

        private Transform _aimTarget;

        private bool _isAiming;

        private bool _canSeeEnemy;

        public override void Initialize(SoldierCharacterController soldierCharacterController)
        {
            base.Initialize(soldierCharacterController);
        }

        private void Update()
        {
            if (!_isActivated || !_isInitialized) return;

            if (_aimTarget && IsEligibleForShooting())
            {
                _isAiming = true;
            }
            else
            {
                _isAiming = false;
            }
        }

        public bool IsEligibleForShooting()
        {
            //Fire ray and detect obstacles between  

            if (_aimTarget)
            {
                RaycastHit hit;
                Debug.DrawRay(_aimingTransform.position, (_aimTarget.position - _aimingTransform.transform.position).normalized * 20f, Color.red);
                if (Physics.Raycast(_aimingTransform.position, (_aimTarget.position - _aimingTransform.transform.position).normalized, out hit, 50f))
                {
                    _canSeeEnemy = true;
                    if (hit.transform.gameObject.tag != "Dead" && 1 << hit.transform.gameObject.layer == _soldierCharacterController.AICharacterController.AIEnemyRadarBehaviour.EnemyLayerMaskValue)
                    {
                        return true;
                    }
                }

                else
                {
                    _canSeeEnemy = false;
                    return false;
                }

            }

            return false;
        }

        public override void Activate()
        {
            base.Activate();
        }

        public override void Deactivate()
        {
            base.Deactivate();
        }

        [Button]
        public void SetAimTarget(Transform aimTarget)
        {
            _aimTarget = aimTarget;
        }
    }
}