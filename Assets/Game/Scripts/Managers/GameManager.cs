using Assets.Game.Scripts.Controllers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Game.Scripts.Managers
{
    public class GameManager : MonoBehaviour
    {
        public SoldierCharacterController SoldierCharacterController => _soldierCharacterController;

        public InputController InputController;
        public BattleController BattleController;
        public AudioController AudioController;
        public UIManager UIManager;

        [SerializeField] private SoldierCharacterController _soldierCharacterController;
        [SerializeField] private AICharacterController _aiCharacterController;
        private void Start()
        {
            AudioController.Initialize(this);
            InputController.Initialize(this);
            BattleController.Initialize(this);
            UIManager.Initialize(this);

            _soldierCharacterController.Initialize(this); // Temp
            _aiCharacterController.Initialize(this);
        }
    }
}