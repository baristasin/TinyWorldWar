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
        public UIManager UIManager;

        [SerializeField] private SoldierCharacterController _soldierCharacterController; 
        private void Start()
        {
            _soldierCharacterController.Initialize(this); // Temp

            InputController.Initialize(this);
            BattleController.Initialize(this);
            UIManager.Initialize(this);

        }
    }
}