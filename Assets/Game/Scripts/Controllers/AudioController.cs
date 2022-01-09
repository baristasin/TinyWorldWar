using Assets.Game.Scripts.Controllers;
using Assets.Game.Scripts.Managers;
using System.Collections;
using UnityEngine;

namespace Assets.Game.Scripts.Controllers
{
    public class AudioController : CustomBehaviour
    {
        public AudioClip WalkingClip => Random.Range(0, 2) == 0 ? _walkingClip1 : _walkingClip2;
        public AudioClip GetDamageClip => _getDamageClip;
        public AudioClip GetGunSwitchAudioClip => _gunSwitchAudioClip;

        public AudioClip GetJumpAudioClip => _jumpAudioClip;

        [SerializeField] private AudioSource _mainThemeAudioSource;
        [SerializeField] private AudioSource _victoryDefeatAudioSource;
        [SerializeField] private AudioClip _mainMenuTheme;

        [SerializeField] private AudioClip _walkingClip1;
        [SerializeField] private AudioClip _walkingClip2;
        [SerializeField] private AudioClip _getDamageClip;
        [SerializeField] private AudioClip _gunSwitchAudioClip;
        [SerializeField] private AudioClip _jumpAudioClip;
        [SerializeField] private AudioClip _victoryAudioClip;
        [SerializeField] private AudioClip _defeatAudioClip;

        public override void Initialize(GameManager gameManager)
        {
            base.Initialize(gameManager);

            _mainThemeAudioSource.clip = _mainMenuTheme;
            _mainThemeAudioSource.Play();
        }

        public void PlayVictory()
        {
            _victoryDefeatAudioSource.clip = _victoryAudioClip;
            _victoryDefeatAudioSource.Play();
        }

        public void PlayDefeat()
        {
            _victoryDefeatAudioSource.clip = _defeatAudioClip;
            _victoryDefeatAudioSource.Play();
        }


    }
}