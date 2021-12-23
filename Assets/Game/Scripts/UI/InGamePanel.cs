using Assets.Game.Scripts.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Game.Scripts.UI
{
    public class InGamePanel : MonoBehaviour
    {
        [SerializeField] private InGamePanelPlayerInterfaceSegment _inGamePanelPlayerInterfaceSegment;

        public UIManager UIManager { get; set; }

        public void Initialize(UIManager Manager)
        {
            UIManager = Manager;            
        }

        public void UpdatePlayerInterfaceSegment(PlayerInterfaceSegmentData playerInterfaceSegmentData)
        {
            _inGamePanelPlayerInterfaceSegment.UpdateView(playerInterfaceSegmentData);
        }
    }
}