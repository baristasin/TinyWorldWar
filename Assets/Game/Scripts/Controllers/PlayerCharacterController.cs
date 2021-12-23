using Assets.Game.Scripts.Behaviours;
using Assets.Game.Scripts.Managers;
using System.Collections;
using UnityEngine;

namespace Assets.Game.Scripts.Controllers
{
    public class PlayerCharacterController : SoldierCharacterController
    {
        public PlayerMovementBehaviour PlayerMovementBehaviour => _playerMovementBehaviour;
        public AimBehaviour AimBehaviour => _aimBehaviour;
        public PlayerInterfaceNotifierBehaviour PlayerInterfaceNotifierBehaviour => _playerInterfaceNotifierBehaviour;

        [SerializeField] private PlayerMovementBehaviour _playerMovementBehaviour;
        [SerializeField] private AimBehaviour _aimBehaviour;
        [SerializeField] private PlayerInterfaceNotifierBehaviour _playerInterfaceNotifierBehaviour;


        public override void Initialize(GameManager gameManager)
        {
            base.Initialize(gameManager);

            _playerMovementBehaviour.Initialize(this);
            _characterHitDetectorBehaviour.Initialize(this);
            _gunnerBehaviour.Initialize(this);
            _aimBehaviour.Initialize(this);
            _characterHealthBehaviour.Initialize(this);
            //_characterSoundBehaviour.Initialize(this);
            _playerInterfaceNotifierBehaviour.Initialize(this);

            ActivateSoldier();

        }

        public override void ActivateSoldier()
        {
            base.ActivateSoldier();

            _playerMovementBehaviour.Activate();
            _characterHitDetectorBehaviour.Activate();
            _gunnerBehaviour.Activate();
            _aimBehaviour.Activate();
            _characterHealthBehaviour.Activate();
            //_characterSoundBehaviour.Activate();
            _playerInterfaceNotifierBehaviour.Activate();

        }

        public override void DeactivateSoldier()
        {
            base.DeactivateSoldier();

            _playerMovementBehaviour.Deactivate();
            _characterHitDetectorBehaviour.Deactivate();
            _gunnerBehaviour.Deactivate();
            _aimBehaviour.Deactivate();
            _characterHealthBehaviour.Deactivate();
            //_characterSoundBehaviour.Activate();
            _playerInterfaceNotifierBehaviour.Deactivate();
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

        public override void DetectorHit(string tag)
        {
            base.DetectorHit(tag);

            _playerInterfaceNotifierBehaviour.NotifyPlayerInterface();
        }
    }
}