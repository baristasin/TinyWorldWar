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
        public SpawnController SpawnController;
        public BattleController BattleController;
        public AudioController AudioController;
        public HospitalController HospitalController;
        public AreaController AreaController;
        public UIManager UIManager;

        [SerializeField] private SoldierCharacterController _soldierCharacterController;
        [SerializeField] private List<AICharacterController> _aiCharacterControllers;

        [SerializeField] private int _teamStartingPoint;

        private int _blueTeamPoints;
        private int _redTeamPoints;

        private bool _isGameEnded;

        private void Start()
        {
            AudioController.Initialize(this);
            InputController.Initialize(this);
            SpawnController.Initialize(this);
            BattleController.Initialize(this);
            UIManager.Initialize(this);
            HospitalController.Initialize(this);
            AreaController.Initialize(this);

            //_soldierCharacterController.Initialize(this); // Temp
            //foreach (var ai in _aiCharacterControllers)
            //{
            //    ai.Initialize(this);
            //}

            _blueTeamPoints = _teamStartingPoint;
            _redTeamPoints = _teamStartingPoint;

            UIManager.InGamePanel.UpdateTeamPointsUI(_blueTeamPoints, _redTeamPoints);
        }

        private void Update()
        {
            if(_blueTeamPoints <= 0)
            {
                _blueTeamPoints = 0;
                _isGameEnded = true;
                UIManager.InGamePanel.UpdateTeamPointsUI(_blueTeamPoints, _redTeamPoints);

            }

            if (_redTeamPoints <= 0)
            {
                _redTeamPoints = 0;
                _isGameEnded = true;
                UIManager.InGamePanel.UpdateTeamPointsUI(_blueTeamPoints, _redTeamPoints);

            }
        }

        public void PlayGame()
        {
            UIManager.InGamePanel.TogglePlayContainer(false);

            _soldierCharacterController.Initialize(this); // Temp
            foreach (var ai in _aiCharacterControllers)
            {
                ai.Initialize(this);
            }
        }

        public void ExitGame()
        {
            Application.Quit();
        }

        public void SoldierSpawned(Team team)
        {
            if (_isGameEnded) return;

            if(team == Team.Blue)
            {
                _blueTeamPoints -= 1;
            }
            else
            {
                _redTeamPoints -= 1;
            }

            UIManager.InGamePanel.UpdateTeamPointsUI(_blueTeamPoints, _redTeamPoints);

        }

        public void UpdateGameState(int blueTeamAreaCount,int redTeamAreaCount)
        {
            if (_isGameEnded) return;

            _blueTeamPoints -= redTeamAreaCount;
            _redTeamPoints -= blueTeamAreaCount;

            _blueTeamPoints = Mathf.Clamp(_blueTeamPoints,0, _teamStartingPoint);
            _redTeamPoints = Mathf.Clamp(_redTeamPoints, 0, _teamStartingPoint);

            UIManager.InGamePanel.UpdateTeamPointsUI(_blueTeamPoints, _redTeamPoints);

            if (_blueTeamPoints < 0)
            {
                _isGameEnded = true;
                //Red Win
                return;
            }

            if(_redTeamPoints < 0)
            {
                _isGameEnded = true;
                //Blue Win
                return;
            }
        }
    }
}