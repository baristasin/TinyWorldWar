using Cinemachine;
using System.Collections;
using UnityEngine;

namespace Assets.Game.Scripts.Behaviours
{
    public class AimBehaviour : BaseCharacterBehaviour
    {
        public Transform AimTransform => _aimTransform;

        public Camera TpsCamera;

        [SerializeField] private Transform _aimTransform;

        [SerializeField] private float _aimValue;

        private void Update()
        {
            if(_isInitialized && _isActivated)
            {
                Ray ray = new Ray(TpsCamera.transform.position, TpsCamera.transform.forward * _aimValue);
                RaycastHit hit;
                if(Physics.Raycast(ray,out hit))
                {
                    _aimTransform.position = hit.point;
                }
                else
                {
                  _aimTransform.position = TpsCamera.transform.position + TpsCamera.transform.forward * _aimValue; // 40 depends on gun range
                }
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawCube(_aimTransform.transform.position, Vector3.one);
        }
    }
}