using Assets.Game.Scripts.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Game.Scripts.UI
{
    public class InGamePanel : MonoBehaviour
    {
        [SerializeField] private InGamePanelPlayerInterfaceSegment _inGamePanelPlayerInterfaceSegment;

        [SerializeField] private Text _blueTeamPointsText;
        [SerializeField] private Text _redTeamPointsText;

        public UIManager UIManager { get; set; }

        public void Initialize(UIManager Manager)
        {
            UIManager = Manager;            
        }

        public void UpdatePlayerInterfaceSegment(PlayerInterfaceSegmentData playerInterfaceSegmentData)
        {
            _inGamePanelPlayerInterfaceSegment.UpdateView(playerInterfaceSegmentData);
        }

        public void UpdateTeamPointsUI(int blue,int red)
        {
            _blueTeamPointsText.text = blue.ToString();
            _redTeamPointsText.text = red.ToString();
        }
    }
}