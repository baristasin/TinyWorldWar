using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Game.Scripts.Behaviours
{
    public class CurvedIndicatorBehaviour : MonoBehaviour
    {
        public Vector3 DirectionForward => _direction.forward.normalized;
        public float DefaultForce => _defaultForce;

        [SerializeField] private List<GameObject> _indicators;
        [SerializeField] private Transform _direction;
        [SerializeField] private float _defaultForce;

        private void Start()
        {
            StartCoroutine(IndicatorToggleCo());
        }

        private void Update()
        {
            for (int i = 0; i < _indicators.Count; i++)
            {
                _indicators[i].transform.position = GetIndicatorPositions(_direction.transform, _direction.forward, _defaultForce, i * 0.1f);
            }
        }

        public Vector3 GetIndicatorPositions(Transform shooterObject, Vector3 direction, float shootForce, float time)
        {
            Vector3 currentPos = shooterObject.transform.position + (direction.normalized * shootForce * time) + .5f * Physics.gravity * (time * time);
            return currentPos;
        }

        private IEnumerator IndicatorToggleCo()
        {
            while (true)
            {
                for (int i = _indicators.Count - 1; i >= 0; i--)
                {
                    yield return new WaitForSeconds(.03f);
                    _indicators[i].gameObject.SetActive(!_indicators[i].gameObject.activeSelf);
                }

                for (int i = 0; i < _indicators.Count; i++)
                {
                    yield return new WaitForSeconds(.03f);
                    _indicators[i].gameObject.SetActive(!_indicators[i].gameObject.activeSelf);
                }
            }
        }
    }
}