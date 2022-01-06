using Assets.Game.Scripts.Controllers;
using System.Collections;
using UnityEngine;
using System.Linq;
using System.Collections.Generic;

namespace Assets.Game.Scripts.Behaviours
{
    public class AIEnemyRadarBehaviour : BaseCharacterBehaviour
    {
        public LayerMask EnemyLayerMaskValue => _layermask;
        public bool IsThereAnEnemyNear => _currentEnemyTransform != null && _currentEnemyTransform.tag != "Dead";
        public Transform CurrentEnemyTransform => _currentEnemyTransform;

        [SerializeField] private LayerMask _layermask;

        private Transform _currentEnemyTransform;


        public override void Initialize(SoldierCharacterController soldierCharacterController)
        {
            base.Initialize(soldierCharacterController);

        }

        public override void Activate()
        {
            base.Activate();

            StartCoroutine(DetectEnemiesCo());

        }

        public override void Deactivate()
        {
            base.Deactivate();
        }

        private IEnumerator DetectEnemiesCo()
        {
            while (_isActivated && _isInitialized)
            {
                Collider[] hitColliders = Physics.OverlapSphere(transform.position, Random.Range(30f,50f), _layermask);
                if (hitColliders.Length > 0)
                {
                    foreach (var col in hitColliders)
                    {
                        if (col.gameObject != null && col.gameObject.tag != "Dead")
                        {
                            _currentEnemyTransform = col.transform;
                        }
                    }
                }
                else
                {
                    _currentEnemyTransform = null;
                    _soldierCharacterController.AICharacterController.AIaimBehaviour.SetAimTarget(null);
                }

                yield return new WaitForSeconds(1f);

            }

        }
    }
}