using Assets.Game.Scripts.Controllers;
using Assets.Game.Scripts.Managers;
using System.Collections;
using UnityEngine;

namespace Assets.Game.Scripts.Controllers
{
    public class AudioController : CustomBehaviour
    {
        public AudioClip WalkingClip => _walkingClip;
        public AudioClip GetDamageClip => _getDamageClip;
        public AudioClip GetGunSwitchAudioClip => _gunSwitchAudioClip;

        public AudioClip GetJumpAudioClip => _jumpAudioClip;

        [SerializeField] private AudioClip _walkingClip;
        [SerializeField] private AudioClip _getDamageClip;
        [SerializeField] private AudioClip _gunSwitchAudioClip;
        [SerializeField] private AudioClip _jumpAudioClip;


        public override void Initialize(GameManager gameManager)
        {
            base.Initialize(gameManager);
        }


    }
}