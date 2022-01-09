﻿using Assets.Game.Scripts.Controllers;
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

        private bool _isPlayerGunner;

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

            _isPlayerGunner = soldierCharacterController.PlayerCharacterController != null ? true : false;
            
        }

        private void Update()
        {
            if (!_isActivated || !_isInitialized) return;

            if (_isPlayerGunner)
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

                #region GunSwitchLogic
                if (Input.GetKeyDown("n"))
                {
                    ChangeGun(true);
                }
                if (Input.GetKeyDown("m"))
                {
                    ChangeGun(false);
                }
                #endregion
            }

            else // AI Gunner
            {
                if (_soldierCharacterController.AICharacterController.AIaimBehaviour.IsAiming)
                {
                    _gunInitializedTransform.transform.LookAt(_soldierCharacterController.AICharacterController.AIaimBehaviour.AimTarget);
                    ShootCurrentGun();
                }
                else
                {
                    _gunInitializedTransform.transform.localEulerAngles = Vector3.zero;
                }
            }
        }

        public override void Activate()
        {
            base.Activate();

            ChangeGun(true, true);

            if (!_isPlayerGunner)
            {
                var gunRandomNumber = Random.Range(1, 11);

                var minNumberRed = 8;
                var minNumberBlue = 9;
                
                if(_soldierCharacterController.Team == Team.Blue)
                {
                    if (gunRandomNumber > minNumberBlue)
                    {
                        ChangeGun(true);
                    }
                }
                else
                {
                    if (gunRandomNumber > minNumberRed)
                    {
                        ChangeGun(true);
                    }
                }
            }
        }

        public override void Deactivate()
        {
            base.Deactivate();
        }

        public void ChangeGun(bool isNext, bool isFirst = false)
        {
            if (!_isActivated || !_isInitialized) return;

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
                if (_isPlayerGunner)
                {
                    _currentGun.OnWeaponReload -= WeaponReload;
                    _currentGun.OnWeaponShoot -= WeaponShoot;
                    _currentGun.OnPlayerAimToggle(false);
                }
                _currentGun.DeactivateGun();
                _currentGun.GetGameobject().SetActive(false);
            }

            _currentGun = isNext == true ? _weapons[nextIndex % _weapons.Count] : _weapons[previousIndex];

            if (_isPlayerGunner)
            {
                _currentGun.OnWeaponReload += WeaponReload;
                _currentGun.OnWeaponShoot += WeaponShoot;
                _soldierCharacterController.PlayerCharacterController.PlayerInterfaceNotifierBehaviour.NotifyPlayerInterface();
            }

            _soldierCharacterController.CharacterSoundBehaviour.PlayGunSwitchSound();

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
            if (!_isActivated || !_isInitialized) return;

            _currentGun.Shoot();
        }
    }
}