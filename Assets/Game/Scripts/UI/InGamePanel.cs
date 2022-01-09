using Assets.Game.Scripts.Controllers;
using Assets.Game.Scripts.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Game.Scripts.UI
{
    public class InGamePanel : MonoBehaviour
    {
        [SerializeField] private List<Image> _redAreaCapturedImages;
        [SerializeField] private List<Image> _blueAreaCapturedImages;

        [SerializeField] private InGamePanelPlayerInterfaceSegment _inGamePanelPlayerInterfaceSegment;

        [SerializeField] private Text _blueTeamPointsText;
        [SerializeField] private Text _redTeamPointsText;

        [SerializeField] private GameObject _playContainer;

        public UIManager UIManager { get; set; }

        public void Initialize(UIManager Manager)
        {
            UIManager = Manager;

            AreaController.OnAllAreasSent += UpdateAreaUI;
        }

        private void OnDestroy()
        {
            AreaController.OnAllAreasSent -= UpdateAreaUI;
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

        public void UpdateAreaUI(List<Area> areas)
        {
            for (int i = 0; i < areas.Count; i++)
            {
                if(areas[i].Team == Team.Red)
                {
                    _blueAreaCapturedImages[i].gameObject.SetActive(false);
                    _redAreaCapturedImages[i].gameObject.SetActive(true);
                }
                else if(areas[i].Team == Team.Blue)
                {
                    _blueAreaCapturedImages[i].gameObject.SetActive(true);
                    _redAreaCapturedImages[i].gameObject.SetActive(false);
                }
            }
        }

        public void TogglePlayContainer(bool toggle)
        {
            _playContainer.gameObject.SetActive(toggle);
        }

    }
}