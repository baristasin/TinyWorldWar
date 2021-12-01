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

        [SerializeField] private float _aimValue;

        private void Update()
        {
            if(_isInitialized && _isActivated)
            {
                Ray ray = new Ray(_tpsCamera.transform.position, _tpsCamera.transform.forward * _aimValue);
                RaycastHit hit;
                if(Physics.Raycast(ray,out hit))
                {
                    _aimTransform.position = hit.point;
                }
                else
                {
                  _aimTransform.position = _tpsCamera.transform.position + _tpsCamera.transform.forward * _aimValue; // 40 depends on gun range
                }
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawCube(_aimTransform.transform.position, Vector3.one);
        }
    }
}