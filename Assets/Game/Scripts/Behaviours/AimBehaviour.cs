using Assets.Game.Scripts.Interfaces;
using Cinemachine;
using System.Collections;
using UnityEngine;

namespace Assets.Game.Scripts.Behaviours
{
    public class AimBehaviour : BaseCharacterBehaviour
    {
        public Transform AimTransform => _aimTransform;

        [SerializeField] private Camera _tpsCamera;
        [SerializeField] private CinemachineFreeLook _cinemachineFreeLook;
        [SerializeField] private Transform _aimTransform;

        [SerializeField] private float _testAimValue;

        private void Update()
        {
            if(_isInitialized && _isActivated)
            {
                Ray ray = new Ray(_tpsCamera.transform.position, _tpsCamera.transform.forward * _testAimValue);
                RaycastHit hit;
                if(_soldierCharacterController.GunnerBehaviour.CurrentGun.GetWeaponType() != WeaponType.Throwable && Physics.Raycast(ray,out hit))
                {
                    _aimTransform.position = hit.point;
                }
                else
                {
                  _aimTransform.position = _tpsCamera.transform.position + _tpsCamera.transform.forward * _testAimValue; // 40 depends on gun range
                }

                _cinemachineFreeLook.m_Lens.FieldOfView = 30f;
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawCube(_aimTransform.transform.position, Vector3.one);
        }
    }
}