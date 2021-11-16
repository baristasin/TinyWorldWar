using Assets.Game.Scripts.Controllers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Game.Scripts.Managers
{
    public class GameManager : MonoBehaviour
    {
        public InputController InputController;
        public BattleController BattleController;

        [SerializeField] private SoldierCharacterController _soldierCharacterController; 
        private void Start()
        {
            InputController.Initialize(this);
            BattleController.Initialize(this);

            _soldierCharacterController.Initialize(this); // Temp
        }
    }
}