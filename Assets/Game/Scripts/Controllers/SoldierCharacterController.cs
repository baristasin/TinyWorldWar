using Assets.Game.Scripts.Behaviours;
using Assets.Game.Scripts.Managers;
using System;
using System.Collections;
using UnityEngine;

namespace Assets.Game.Scripts.Controllers
{
    public class SoldierCharacterController : CustomBehaviour
    {
        public CharacterHitDetectorBehaviour CharacterHitDetectorBehaviour => _characterHitDetectorBehaviour;
        public PlayerMovementBehaviour PlayerMovementBehaviour => _playerMovementBehaviour;

        [SerializeField] private PlayerMovementBehaviour _playerMovementBehaviour;
        [SerializeField] private CharacterHitDetectorBehaviour _characterHitDetectorBehaviour;        

        public override void Initialize(GameManager gameManager)
        {
            base.Initialize(gameManager);
            _playerMovementBehaviour.Initialize(this);
            _characterHitDetectorBehaviour.Initialize(this);

            _playerMovementBehaviour.Activate();
            _characterHitDetectorBehaviour.Activate();
        }

        public void DetectorHit(LayerMask layer)
        {
            var damage = GameManager.BattleController.GetDamageAmount(layer);
            //Health segmentine damage'i yolla.
        }
    }
}