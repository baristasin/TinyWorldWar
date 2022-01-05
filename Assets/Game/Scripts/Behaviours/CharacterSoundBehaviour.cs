using Assets.Game.Scripts.Controllers;
using System;
using System.Collections;
using UnityEngine;

namespace Assets.Game.Scripts.Behaviours
{
    public class CharacterSoundBehaviour : BaseCharacterBehaviour
    {
        [SerializeField] private AudioSource _walkAudioSource;
        [SerializeField] private AudioSource _getDamageAudioSource;
        [SerializeField] private AudioSource _gunSwitchAudioSource;
        [SerializeField] private AudioSource _jumpAudioSource;

        private AudioClip _walkAudioClip;
        private AudioClip _jumpAudioClip;
        private AudioClip _getDamageAudioClip;
        private AudioClip _gunSwitchAudioClip;

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
            _gunSwitchAudioClip = soldierCharacterController.GameManager.AudioController.GetGunSwitchAudioClip;
            _jumpAudioClip = soldierCharacterController.GameManager.AudioController.GetJumpAudioClip;

            _walkAudioSource.clip = _walkAudioClip;
            _getDamageAudioSource.clip =_getDamageAudioClip;
            _gunSwitchAudioSource.clip = _gunSwitchAudioClip;
            _jumpAudioSource.clip = _jumpAudioClip;

            _walkAudioSource.loop = true;

        }

        private void Update()
        {
            if(_isInitialized && _isActivated)
            {
                //_walkAudioSource.enabled = _isWalking;
            }

            else
            {
                //_walkAudioSource.enabled = false;
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

        public void PlayGunSwitchSound()
        {
            _gunSwitchAudioSource.Play();
        }

        public void PlayJumpClip()
        {
            _jumpAudioSource.Play();
        }
    }
}