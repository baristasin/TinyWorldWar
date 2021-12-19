using Assets.Game.Scripts.Controllers;
using Assets.Game.Scripts.Guns;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Assets.Game.Scripts.Interfaces;
using Assets.Game.Scripts.Throwables;

namespace Assets.Game.Scripts.Behaviours
{
    public class GunnerBehaviour : BaseCharacterBehaviour
    {
        public IWeapon CurrentGun => _currentGun;

        [SerializeField] private List<Gun> _guns;
        [SerializeField] private List<Throwable> _throwables;
        [SerializeField] private Transform _gunSpawnTransform;
        [SerializeField] private Transform _gunInitializedTransform;

        private List<IWeapon> _weapons;

        private IWeapon _currentGun;

        public override void Initialize(SoldierCharacterController soldierCharacterController)
        {

            _weapons = new List<IWeapon>();

            foreach (var weapon in _guns)
            {
                _weapons.Add(weapon.GetComponent<IWeapon>());
            }

            foreach (var weapon in _throwables)
            {
                _weapons.Add(weapon.GetComponent<IWeapon>());
            }

            base.Initialize(soldierCharacterController);

            foreach (var gun in _guns)
            {
                gun.GetGameobject().SetActive(false);
            }

            _currentGun = _weapons[0];
        }

        private void Update()
        {
            if (_soldierCharacterController.PlayerCharacterController.PlayerMovementBehaviour.IsAiming)
            {
                _gunInitializedTransform.transform.LookAt(_soldierCharacterController.PlayerCharacterController.AimBehaviour.AimTransform);
                _currentGun.OnPlayerAimToggle(true);
            }
            else
            {
                _gunInitializedTransform.transform.localEulerAngles = Vector3.zero;
                _currentGun.OnPlayerAimToggle(false);
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

            ChangeGun(true,true);
        }

        public void ChangeGun(bool isNext, bool isFirst = false)
        {
            int nextIndex = 0;
            int previousIndex = 0;

            if (!isFirst)
            {
                int currentIndex = 0;
                for (int i = 0; i < _weapons.Count; i++)
                {
                    if (_weapons[i] == _currentGun)
                    {
                        currentIndex = i;
                        break;
                    }
                }

                nextIndex = currentIndex + 1 % _weapons.Count;
                previousIndex = currentIndex - 1 % _weapons.Count;

                if (previousIndex < 0)
                {
                    previousIndex += _weapons.Count;
                }
            }

            if (_currentGun.GetGameobject())
            {
                _currentGun.OnWeaponReload -= WeaponReload;
                _currentGun.OnWeaponShoot -= WeaponShoot;
                _currentGun.OnPlayerAimToggle(false);
                _currentGun.DeactivateGun();
                _currentGun.GetGameobject().SetActive(false);
            }

            _currentGun = isNext == true ? _weapons[nextIndex % _weapons.Count] : _weapons[previousIndex];

            _currentGun.OnWeaponReload += WeaponReload;
            _currentGun.OnWeaponShoot += WeaponShoot;

            _soldierCharacterController.PlayerCharacterController.PlayerInterfaceNotifierBehaviour.NotifyPlayerInterface();

            ActivateGun(_currentGun);
        }

        private void WeaponShoot(object sender, System.EventArgs e)
        {
            _soldierCharacterController.PlayerCharacterController.PlayerInterfaceNotifierBehaviour.NotifyPlayerInterface();
        }

        private void WeaponReload(object sender, System.EventArgs e)
        {
            _soldierCharacterController.PlayerCharacterController.PlayerInterfaceNotifierBehaviour.NotifyPlayerInterface();
        }

        private void ActivateGun(IWeapon gun)
        {            
            gun.GetTransform().position = _gunSpawnTransform.transform.position;
            gun.GetTransform().rotation = _gunSpawnTransform.transform.rotation;

            gun.GetTransform().position = _gunInitializedTransform.transform.position; // Temporary no delay
            gun.GetTransform().rotation = _gunInitializedTransform.transform.rotation;

            gun.GetGameobject().SetActive(true);
            gun.Initialize(_gunInitializedTransform);            
        }

        public void ShootCurrentGun()
        {
            _currentGun.Shoot();
        }
    }
}