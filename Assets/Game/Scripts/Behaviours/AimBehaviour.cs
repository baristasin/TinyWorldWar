using Cinemachine;
using System.Collections;
using UnityEngine;

namespace Assets.Game.Scripts.Behaviours
{
    public class AimBehaviour : BaseCharacterBehaviour
    {
        public Transform AimTransform => _aimTransform;

        [SerializeField] private Camera _tpsCamera;
        [SerializeField] private Transform _aimTransform;

        private void Update()
        {
            if(_isInitialized && _isActivated)
            {
                _aimTransform.position = _tpsCamera.transform.position + _tpsCamera.transform.forward * 40f; // 40 depends on gun range
            }
        }
    }
}