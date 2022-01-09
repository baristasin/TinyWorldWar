using Assets.Game.Scripts.Controllers;
using Assets.Game.Scripts.Managers;
using System.Collections;
using UnityEngine;

namespace Assets.Game.Scripts.UI
{
    public class EndGamePanel : MonoBehaviour
    {

        [SerializeField] private GameObject _playerWinContainer;
        [SerializeField] private GameObject _playerLoseContainer;

        private UIManager UIManager;

        public void Initialize(UIManager Manager)
        {
            UIManager = Manager;            
        }

        public void Activate(Team team)
        {
            _playerWinContainer.SetActive(false);
            _playerLoseContainer.SetActive(false);

            if(team == Team.Blue)
            {
                _playerWinContainer.SetActive(true);
            }
            else
            {
                _playerLoseContainer.SetActive(true);
            }

        }
    }
}