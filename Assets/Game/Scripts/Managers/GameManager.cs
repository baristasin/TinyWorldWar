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
        public HospitalController HospitalController;
        public UIManager UIManager;

        [SerializeField] private SoldierCharacterController _soldierCharacterController;
        [SerializeField] private List<AICharacterController> _aiCharacterControllers;
        private void Start()
        {
            AudioController.Initialize(this);
            InputController.Initialize(this);
            BattleController.Initialize(this);
            UIManager.Initialize(this);
            HospitalController.Initialize(this);

            _soldierCharacterController.Initialize(this); // Temp
            foreach (var ai in _aiCharacterControllers)
            {
                ai.Initialize(this);
            }
        }
    }
}