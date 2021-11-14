using Assets.Game.Scripts.Bullets;
using System.Collections;
using UnityEngine;

namespace Assets.Game.Scripts.Guns
{
    public abstract class Gun : MonoBehaviour
    {
        [SerializeField] protected Transform _muzzleTransform;
        [SerializeField] protected Bullet _bulletPrefab;
        [SerializeField] protected float _firingRate;

        protected bool _isInitialized;
        protected bool _isOnCooldown;
        protected float _cooldown;

        public void Initialize()
        {
            _isInitialized = true;
        }

        private void Update()
        {
            if (_isOnCooldown)
            {
                _cooldown -= Time.deltaTime;
                if(_cooldown <= 0)
                {
                    _isOnCooldown = false;
                }
            }
        }

        public void Shoot()
        {
            if (_isInitialized && !_isOnCooldown)
            {
                //ShootLogic
                var bullet = Instantiate(_bulletPrefab, _muzzleTransform.position, _muzzleTransform.rotation); // Object Pooling
                _isOnCooldown = true;
                _cooldown = _firingRate;
            }
        }
    }
}