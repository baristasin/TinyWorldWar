using Cinemachine;
using System.Collections;
using UnityEngine;

namespace Assets.Game.Scripts.Behaviours
{
    public class RobotBehaviour : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private CinemachineSmoothPath _path;
        [SerializeField] private float _speed;
        [SerializeField] private AudioListener AudioListener;

        private float _distance;

        private void Start()
        {
            _audioSource.Play();            
        }

        private void Update()
        {
            transform.position = _path.EvaluatePositionAtUnit(_distance, CinemachinePathBase.PositionUnits.Distance);
            transform.rotation = _path.EvaluateOrientationAtUnit(_distance, CinemachinePathBase.PositionUnits.Distance) * Quaternion.Euler(-90f, 0,180f);

            _distance += _speed * Time.deltaTime;

            if(_distance >= _path.PathLength)
            {
                _distance = 0;
            }

        }
    }
}