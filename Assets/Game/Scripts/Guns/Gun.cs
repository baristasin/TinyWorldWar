using Assets.Game.Scripts.Bullets;
using System.Collections;
using UnityEngine;

namespace Assets.Game.Scripts.Guns
{
    public abstract class Gun : MonoBehaviour
    {
        public float InitializeInterval => _initializeInterval;

        [SerializeField] protected Transform _muzzleTransform;
        [SerializeField] private float _initializeInterval;
        [SerializeField] protected Bullet _bulletPrefab;
        [SerializeField] protected float _firingRate;
        [SerializeField] protected int _magazineTotalSize;
        [SerializeField] protected float _reloadTime;

        protected bool _isInitialized;
        protected bool _isOnCooldown;
        protected float _cooldown;
        protected Transform _holdTransform;
        protected int _currentMagazineSize;

        protected bool _isReloading;

        private Coroutine _reloadingRoutine;

        private void Start()
        {
            _currentMagazineSize = _magazineTotalSize;
        }

        public void Initialize(Transform holdTransform)
        {
            StartCoroutine(InitializeCo());
            _holdTransform = holdTransform;
            Debug.Log("Gun initializing");
        }

        public void DeactivateGun()
        {
            _isInitialized = false;
            _isReloading = false;
            if(_reloadingRoutine != null)
            {
                StopCoroutine(_reloadingRoutine);
                _reloadingRoutine = null;
            }
        }

        private IEnumerator InitializeCo()
        {
            yield return new WaitForSeconds(_initializeInterval);
            _isInitialized = true;
        }

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

                if (_currentMagazineSize <= 0)
                {
                    Reload();
                }
            }
        }

        public void Shoot()
        {
            if (_isInitialized)
            {
                if (!_isOnCooldown && _currentMagazineSize > 0)
                {
                    //ShootLogic
                    var bullet = Instantiate(_bulletPrefab, _muzzleTransform.position, _muzzleTransform.rotation); // Object Pooling
                    _isOnCooldown = true;
                    _cooldown = _firingRate;
                    _currentMagazineSize--;
                }
            }
        }

        public void Reload()
        {
            if (!_isReloading && _reloadingRoutine == null)
            {
                _isReloading = true;
                _reloadingRoutine = StartCoroutine(ReloadCo());
            }
        }

        private IEnumerator ReloadCo()
        {
            yield return new WaitForSeconds(_reloadTime);
            _currentMagazineSize = _magazineTotalSize;
            _isReloading = false;
            _reloadingRoutine = null;
        }
    }
}