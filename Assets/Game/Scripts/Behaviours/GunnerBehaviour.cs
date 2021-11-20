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

            if (Input.GetKeyDown("n"))
            {
                ChangeGun(true);
            }
            if (Input.GetKeyDown("m"))
            {
                ChangeGun(false);
            }
        }        

        public override void Activate()
        {
            base.Activate();

            ActivateGun(_currentGun);
        }

        public void ChangeGun(bool isNext)
        {
            int currentIndex = 0;
            for (int i = 0; i < _guns.Count; i++)
            {
                if(_guns[i] == _currentGun)
                {
                    currentIndex = i;
                    break;
                }
            }

            var nextIndex = currentIndex + 1 % _guns.Count;
            var previousIndex = currentIndex - 1 % _guns.Count;

            if (previousIndex < 0)
            {
                previousIndex += _guns.Count;
            }

            if (_currentGun)
            {
                _currentGun.gameObject.SetActive(false);
            }

            _currentGun = isNext == true ? _guns[nextIndex % _guns.Count] : _guns[previousIndex];

            ActivateGun(_currentGun);
        }

        private void ActivateGun(Gun gun)
        {
            gun.transform.position = _gunSpawnTransform.transform.position;
            gun.transform.rotation = _gunSpawnTransform.transform.rotation;

            gun.transform.position = _gunInitializedTransform.transform.position; // Temporary no delay
            gun.transform.rotation = _gunInitializedTransform.transform.rotation;

            gun.gameObject.SetActive(true);
            gun.Initialize(_gunInitializedTransform);
        }

        public void ShootCurrentGun()
        {
            _currentGun.Shoot();
        }
    }
}