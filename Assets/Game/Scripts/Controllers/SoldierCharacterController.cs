using Assets.Game.Scripts.Behaviours;
using Assets.Game.Scripts.Managers;
using System;
using System.Collections;
using UnityEngine;

namespace Assets.Game.Scripts.Controllers
{
    public class SoldierCharacterController : CustomBehaviour
    {
        public CharacterHitDetectorBehaviour CharacterDetectorBehaviour => _characterDetectorBehaviour;

        [SerializeField] private CharacterHitDetectorBehaviour _characterDetectorBehaviour;

        public override void Initialize(GameManager gameManager)
        {
            base.Initialize(gameManager);
            _characterDetectorBehaviour.Initialize(this);
        }

        public void DetectorHit(LayerMask layer)
        {
            var damage = GameManager.BattleController.GetDamageAmount(layer);
            //Health segmentine damage'i yolla.
        }
    }
}