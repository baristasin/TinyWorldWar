using Assets.Game.Scripts.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Game.Scripts.Behaviours
{
    public class CharacterHitDetectorBehaviour : BaseCharacterBehaviour
    {
        [SerializeField] private Collider _hitDetectorCollider;

        public override void Initialize(SoldierCharacterController soldierCharacterController)
        {
            base.Initialize(soldierCharacterController);

            _deactivateContainer.Add(DeactivateHitCollider);
        }

        public void DeactivateHitCollider()
        {
            _hitDetectorCollider.enabled = false;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (_isInitialized && _isActivated)
            {
                _soldierCharacterController.DetectorHit(other.gameObject.layer);
            }
        }
    }
}