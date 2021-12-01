using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Game.Scripts.UI
{
    public class PlayerInterfaceSegmentData
    {
        public Sprite PlayerAvatar;
        public int PlayerCurrentHealth;
        public int PlayerMaxHealth;
        public int PlayerAmmoInMagazine;
        public int PlayerAmmoTotal;
    }

    public class InGamePanelPlayerInterfaceSegment : MonoBehaviour
    {
        [SerializeField] private Image _playerAvatarImage;
        [SerializeField] private Text _playerCurrentHealthText;
        [SerializeField] private Text _playerMaxHealthText;
        [SerializeField] private Text _playerAmmoInMagazine;
        [SerializeField] private Text _playerAmmoTotal;

        public void UpdateView(PlayerInterfaceSegmentData playerInterfaceSegmentData)
        {
            //_playerAvatarImage.sprite = playerInterfaceSegmentData.PlayerAvatar;
            //_playerCurrentHealthText.text = playerInterfaceSegmentData.PlayerCurrentHealth.ToString();
            //_playerMaxHealthText.text = playerInterfaceSegmentData.PlayerMaxHealth.ToString();
            _playerAmmoInMagazine.text = playerInterfaceSegmentData.PlayerAmmoInMagazine.ToString();
            _playerAmmoTotal.text = playerInterfaceSegmentData.PlayerAmmoTotal.ToString();
        }
    }
}