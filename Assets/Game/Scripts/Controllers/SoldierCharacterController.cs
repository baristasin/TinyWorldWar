using Assets.Game.Scripts.Behaviours;
using Assets.Game.Scripts.Managers;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Game.Scripts.Controllers
{
    public class SoldierCharacterController : CustomBehaviour
    {
        public CharacterHitDetectorBehaviour CharacterHitDetectorBehaviour => _characterHitDetectorBehaviour;
        public PlayerMovementBehaviour PlayerMovementBehaviour => _playerMovementBehaviour;
        public GunnerBehaviour GunnerBehaviour => _gunnerBehaviour;
        public AimBehaviour AimBehaviour => _aimBehaviour;

        [SerializeField] private PlayerMovementBehaviour _playerMovementBehaviour;
        [SerializeField] private CharacterHitDetectorBehaviour _characterHitDetectorBehaviour;
        [SerializeField] private GunnerBehaviour _gunnerBehaviour;
        [SerializeField] private AimBehaviour _aimBehaviour;

        public override void Initialize(GameManager gameManager)
        {
            base.Initialize(gameManager);

            _playerMovementBehaviour.Initialize(this);
            _characterHitDetectorBehaviour.Initialize(this);
            _gunnerBehaviour.Initialize(this);
            _aimBehaviour.Initialize(this);

            _playerMovementBehaviour.Activate();
            _characterHitDetectorBehaviour.Activate();
            _gunnerBehaviour.Activate();
            _aimBehaviour.Activate();
        }

        private void Update()
        {
            if (Input.GetMouseButton(0))
            {
                _gunnerBehaviour.ShootCurrentGun();
            }

            if (Input.GetMouseButtonDown(1))
            {
                _playerMovementBehaviour.SetFiring();
            }
        }

        public void DetectorHit(LayerMask layer)
        {
            var damage = GameManager.BattleController.GetDamageAmount(layer);
            //Health segmentine damage'i yolla.
        }
    }
}