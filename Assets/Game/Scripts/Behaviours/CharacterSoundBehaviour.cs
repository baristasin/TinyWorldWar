using Assets.Game.Scripts.Controllers;
using System.Collections;
using UnityEngine;

namespace Assets.Game.Scripts.Behaviours
{
    public class CharacterSoundBehaviour : BaseCharacterBehaviour
    {
        [SerializeField] private AudioSource _walkAudioSource;
        [SerializeField] private AudioSource _getDamageAudioSource;

        private AudioClip _walkAudioClip;
        private AudioClip _getDamageAudioClip;

        private bool _isWalking;

        public override void Activate()
        {
            base.Activate();
        }

        public override void Deactivate()
        {
            base.Deactivate();
        }

        public override void Initialize(SoldierCharacterController soldierCharacterController)
        {
            base.Initialize(soldierCharacterController);

            _walkAudioClip = soldierCharacterController.GameManager.AudioController.WalkingClip;
            _getDamageAudioClip = soldierCharacterController.GameManager.AudioController.GetDamageClip;

            _walkAudioSource.clip = _walkAudioClip;
            _getDamageAudioSource.clip =_getDamageAudioClip;

            _walkAudioSource.loop = true;

        }

        private void Update()
        {
            if(_isInitialized && _isActivated)
            {
                _walkAudioSource.enabled = _isWalking;
            }
        }

        public void SetWalkingStatus(bool status)
        {
            _isWalking = status;
        }

        public void PlayGetDamageClip()
        {
            _getDamageAudioSource.Play(); // Temp
        }

    }
}