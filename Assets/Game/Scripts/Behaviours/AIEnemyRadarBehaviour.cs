using Assets.Game.Scripts.Controllers;
using System.Collections;
using UnityEngine;
using System.Linq;
using System.Collections.Generic;

namespace Assets.Game.Scripts.Behaviours
{
    public class AIEnemyRadarBehaviour : BaseCharacterBehaviour
    {
        public bool IsThereAnEnemyNear => _currentEnemyTransform != null && _currentEnemyTransform.tag != "Dead";
        public Transform CurrentEnemyTransform => _currentEnemyTransform;

        private Transform _currentEnemyTransform;

        private int _layermask = 1 << 25;

        public override void Initialize(SoldierCharacterController soldierCharacterController)
        {
            base.Initialize(soldierCharacterController);
        }

        private IEnumerator DetectEnemiesCo()
        {
            while (_isActivated && _isInitialized)
            {

                Collider[] hitColliders = Physics.OverlapSphere(transform.position, 20f, _layermask);
                if (hitColliders.Length > 0 && hitColliders[0] != null)
                {
                    _currentEnemyTransform = hitColliders[0].transform;
                }
                else
                {
                    _currentEnemyTransform = null;
                }

                yield return new WaitForSeconds(1f);

            }

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


    }
}