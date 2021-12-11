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

        [SerializeField] private AudioClip _walkingClip;
        [SerializeField] private AudioClip _getDamageClip;

        public override void Initialize(GameManager gameManager)
        {
            base.Initialize(gameManager);
        }


    }
}