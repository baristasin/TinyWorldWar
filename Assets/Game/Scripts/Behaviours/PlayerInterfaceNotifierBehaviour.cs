using Assets.Game.Scripts.Controllers;
using Assets.Game.Scripts.UI;
using System.Collections;
using UnityEngine;

namespace Assets.Game.Scripts.Behaviours
{
    public class PlayerInterfaceNotifierBehaviour : BaseCharacterBehaviour
    {
        private PlayerInterfaceSegmentData _playerInterfaceSegmentData;
        public override void Initialize(SoldierCharacterController soldierCharacterController)
        {
            base.Initialize(soldierCharacterController);

            _playerInterfaceSegmentData = new PlayerInterfaceSegmentData();
        }

        public override void Activate()
        {
            base.Activate();
            var gunnerBehaviour = _soldierCharacterController.GunnerBehaviour;

            _playerInterfaceSegmentData.PlayerAmmoTotal = gunnerBehaviour.CurrentGun.GetMagazineTotalSize();
            _playerInterfaceSegmentData.PlayerAmmoInMagazine = gunnerBehaviour.CurrentGun.GetCurrentAmmoInMagazine();

            _soldierCharacterController.GameManager.UIManager.InGamePanel.UpdatePlayerInterfaceSegment(_playerInterfaceSegmentData);
        }

        public void NotifyPlayerInterface()
        {
            var gunnerBehaviour = _soldierCharacterController.GunnerBehaviour;

            _playerInterfaceSegmentData.PlayerAmmoTotal = gunnerBehaviour.CurrentGun.GetMagazineTotalSize();
            _playerInterfaceSegmentData.PlayerAmmoInMagazine = gunnerBehaviour.CurrentGun.GetCurrentAmmoInMagazine();

            _soldierCharacterController.GameManager.UIManager.InGamePanel.UpdatePlayerInterfaceSegment(_playerInterfaceSegmentData);
        }

        public override void Deactivate()
        {
            base.Deactivate();
        }
    }
}