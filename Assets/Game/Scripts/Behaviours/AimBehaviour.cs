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
            _aimTransform.position = _tpsCamera.transform.position + _tpsCamera.transform.forward * 40f;

            Debug.DrawRay(_tpsCamera.transform.position, _tpsCamera.transform.forward * 10f ,Color.blue);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(_aimTransform.position, 1f);
        }
    }
}