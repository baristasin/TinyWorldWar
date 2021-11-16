using Assets.Game.Scripts.Controllers;
using Assets.Game.Scripts.Guns;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Assets.Game.Scripts.Behaviours
{
    public class GunnerBehaviour : BaseCharacterBehaviour
    {
        [SerializeField] private List<Gun> _guns;
        [SerializeField] private Transform _gunSpawnTransform;
        [SerializeField] private Transform _gunInitializedTransform;

        private Gun _currentGun;

        public override void Initialize(SoldierCharacterController soldierCharacterController)
        {
            base.Initialize(soldierCharacterController);

            foreach (var gun in _guns)
            {
                gun.gameObject.SetActive(false);
            }

            _currentGun = _guns[0];
        }

        private void Update()
        {
            if (_soldierCharacterController.PlayerMovementBehaviour.IsAiming)
            {
                _gunInitializedTransform.transform.LookAt(_soldierCharacterController.AimBehaviour.AimTransform);
            }
            else
            {
                _gunInitializedTransform.transform.localEulerAngles = Vector3.zero;
            }
        }

        public override void Activate()
        {
            base.Activate();

            _currentGun.transform.position = _gunSpawnTransform.transform.position;
            _currentGun.transform.rotation = _gunSpawnTransform.transform.rotation;

            _currentGun.transform.position = _gunInitializedTransform.transform.position; // Temporary no delay
            _currentGun.transform.rotation = _gunInitializedTransform.transform.rotation;

            _currentGun.gameObject.SetActive(true);

            _currentGun.Initialize(_gunInitializedTransform);
        }

        public void ShootCurrentGun()
        {
            _currentGun.Shoot();
        }
    }
}