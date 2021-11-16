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
        public GunnerBehaviour GunnerBehaviour => _gunnerBehaviour;

        [SerializeField] private PlayerMovementBehaviour _playerMovementBehaviour;
        [SerializeField] private CharacterHitDetectorBehaviour _characterHitDetectorBehaviour;
        [SerializeField] private GunnerBehaviour _gunnerBehaviour;

        public override void Initialize(GameManager gameManager)
        {
            base.Initialize(gameManager);
            _playerMovementBehaviour.Initialize(this);
            _characterHitDetectorBehaviour.Initialize(this);
            _gunnerBehaviour.Initialize(this);

            _playerMovementBehaviour.Activate();
            _characterHitDetectorBehaviour.Activate();
            _gunnerBehaviour.Activate();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _gunnerBehaviour.ShootCurrentGun();
            }
        }

        public void DetectorHit(LayerMask layer)
        {
            var damage = GameManager.BattleController.GetDamageAmount(layer);
            //Health segmentine damage'i yolla.
        }
    }
}