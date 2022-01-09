using Assets.Game.Scripts.Controllers;
using Assets.Game.Scripts.UI;
using System.Collections;
using UnityEngine;

namespace Assets.Game.Scripts.Managers
{
    public class UIManager : CustomBehaviour
    {
        public InGamePanel InGamePanel;
        public EndGamePanel endGamePanel;

        public override void Initialize(GameManager gameManager)
        {
            base.Initialize(gameManager);

            InGamePanel.Initialize(this);
        }

        public void ActivateEndGamePanel(Team team)
        {
            endGamePanel.gameObject.SetActive(true);
            endGamePanel.Activate(team);
        }

        public void DeactivateEndGamePanel()
        {
            endGamePanel.gameObject.SetActive(false);
        }

    }
}