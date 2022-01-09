using Assets.Game.Scripts.Bullets;
using Assets.Game.Scripts.Interfaces;
using System;
using System.Collections;
using UnityEngine;

namespace Assets.Game.Scripts.Guns
{
    public abstract class Gun : MonoBehaviour,IWeapon
    {
        public event Action OnGunShoot;
        public event Action OnGunReload;

        public event EventHandler OnWeaponShoot;
        public event EventHandler OnWeaponReload;

        public float InitializeInterval => _initializeInterval;

        [SerializeField] protected Transform _muzzleTransform;
        [SerializeField] private float _initializeInterval;
        [SerializeField] protected Bullet _bulletPrefab;
        [SerializeField] protected float _firingRate;
        [SerializeField] protected int _magazineTotalSize;
        [SerializeField] protected float _reloadTime;
        [SerializeField] protected ParticleSystem _shootEffect;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _shootAudioClip;
        [SerializeField] private AudioClip _reloadAudioClip;

        protected bool _isInitialized;
        protected bool _isOnCooldown;
        protected float _cooldown;
        protected Transform _holdTransform;
        protected int _currentMagazineSize;

        protected bool _isReloading;

        protected bool _isFirstInitialize; // temp

        private Coroutine _reloadingRoutine;

        private void Start()
        {
            _currentMagazineSize = _magazineTotalSize;
        }

        public void Initialize(Transform holdTransform)
        {
            if (!_isFirstInitialize)
            {
                _isFirstInitialize = true;
                _currentMagazineSize = _magazineTotalSize;
            }

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

        public virtual void OnPlayerAimToggle(bool toggle)
        {

        }

        public void Shoot()
        {
            if (_isInitialized)
            {
                if (!_isOnCooldown && _currentMagazineSize > 0)
                {
                    //ShootLogic
                    _audioSource.clip = _shootAudioClip;
                    _audioSource.Play();
                    _shootEffect.Play();
                    var bullet = Instantiate(_bulletPrefab, _muzzleTransform.position, _muzzleTransform.rotation,transform); // Object Pooling
                    _isOnCooldown = true;
                    _cooldown = _firingRate;
                    _currentMagazineSize--;
                    OnWeaponShoot?.Invoke(null,null);
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
            yield return new WaitForSeconds(_reloadTime / 2f);
            _audioSource.clip = _reloadAudioClip;
            _audioSource.Play();
            yield return new WaitForSeconds(_reloadTime / 2f);
            _currentMagazineSize = _magazineTotalSize;
            _isReloading = false;
            _reloadingRoutine = null;
            OnWeaponReload?.Invoke(null, null);
        }

        public GameObject GetGameobject()
        {
            return gameObject;
        }

        public Transform GetTransform()
        {
            return transform;
        }

        public int GetMagazineTotalSize()
        {
            return _magazineTotalSize;
        }

        public int GetCurrentAmmoInMagazine()
        {
            return _currentMagazineSize;
        }
    }
}