using Assets.Game.Scripts.Bullets;
using Assets.Game.Scripts.Interfaces;
using MangoramaStudio.Scripts.Behaviours;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Game.Scripts.Throwables
{
    public abstract class Throwable : MonoBehaviour, IWeapon
    {
        [SerializeField] private CurvedIndicatorBehaviour _curvedIndicatorBehaviour;
        [SerializeField] private ThrowableAmmo _throwableBullet;
        [SerializeField] protected float _firingRate;
        [SerializeField] private int _throwableCount;

        private bool _isOnCooldown;
        private float _cooldown;

        private Transform _holdTransform;
        private bool _isInitialized;

        public event EventHandler OnWeaponShoot;
        public event EventHandler OnWeaponReload;

        private void Update()
        {
            if (_isInitialized)
            {
                if (_isOnCooldown)
                {
                    _cooldown -= Time.deltaTime;
                    if (_cooldown <= 0)
                    {
                        _isOnCooldown = false;
                    }
                }

                transform.position = _holdTransform.position;
                transform.rotation = _holdTransform.rotation;
            }
        }

        public void DeactivateGun()
        {
            _isInitialized = false;
        }

        public GameObject GetGameobject()
        {
            return gameObject;
        }

        public Transform GetTransform()
        {
            return transform;
        }

        public void Initialize(Transform holdTransform)
        {
            _isInitialized = true;
            _holdTransform = holdTransform;
        }

        public void OnPlayerAimToggle(bool toggle)
        {
            _curvedIndicatorBehaviour.gameObject.SetActive(toggle);
        }

        public void Shoot()
        {
            if(_isInitialized && !_isOnCooldown && _throwableCount > 0)
            {
                var ammo = Instantiate(_throwableBullet, transform.position, transform.rotation);
                ammo.ThrowAmmo(_curvedIndicatorBehaviour.DirectionForward, _curvedIndicatorBehaviour.DefaultForce);
                _throwableCount--;
                _cooldown = _firingRate;
                _isOnCooldown = true;
            }
        }

        public int GetMagazineTotalSize()
        {
            return _throwableCount;
        }

        public int GetCurrentAmmoInMagazine()
        {
            return 1;
        }
    }
}