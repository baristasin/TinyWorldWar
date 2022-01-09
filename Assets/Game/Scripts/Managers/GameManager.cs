using Assets.Game.Scripts.Behaviours;
using Assets.Game.Scripts.Controllers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Game.Scripts.Managers
{
    public class GameManager : MonoBehaviour
    {
        public SoldierCharacterController SoldierCharacterController => _soldierCharacterController;
        public Camera MainCamera => _mainCamera;
        public Image CrossHair => _crossHair;

        public InputController InputController;
        public BattleController BattleController;
        public AudioController AudioController;
        public UIManager UIManager;

        public SpawnController SpawnController;
        public HospitalController HospitalController;
        public AreaController AreaController;

        [SerializeField] private Camera _mainCamera;
        [SerializeField] private Image _crossHair;

        [SerializeField] private SoldierCharacterController _soldierCharacterController;
        [SerializeField] private List<AICharacterController> _aiCharacterControllers;

        [SerializeField] private int _teamStartingPoint;

        private int _blueTeamPoints;
        private int _redTeamPoints;

        private int _teamStartingPointAtStart;

        private bool _isGameEnded;

        [SerializeField] private LevelBehaviour _levelBehaviourPrefab;

        private LevelBehaviour _levelBehaviour;

        private void Start()
        {
            _teamStartingPointAtStart = _teamStartingPoint;

            AudioController.Initialize(this);
            InputController.Initialize(this);
            BattleController.Initialize(this);
            UIManager.Initialize(this);

            //SpawnController.Initialize(this);
            //HospitalController.Initialize(this);
            //AreaController.Initialize(this);

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
            if (Input.GetKeyDown("q"))
            {
                _blueTeamPoints = 0;
            }

            if (Input.GetKeyDown("t"))
            {
                _redTeamPoints = 0;
            }

            if(_blueTeamPoints <= 0)
            {
                _blueTeamPoints = 0;
                RoundEnded(Team.Red);
                UIManager.InGamePanel.UpdateTeamPointsUI(_blueTeamPoints, _redTeamPoints);

            }

            if (_redTeamPoints <= 0)
            {
                _redTeamPoints = 0;
                RoundEnded(Team.Blue);
                UIManager.InGamePanel.UpdateTeamPointsUI(_blueTeamPoints, _redTeamPoints);
            }
        }

        private void RoundEnded(Team team)
        {
            if (_isGameEnded) return;
            _isGameEnded = true;
            Destroy(_levelBehaviour.gameObject);
            UIManager.ActivateEndGamePanel(team);

        }

        public void PlayGame()
        {
            _isGameEnded = false;

            _blueTeamPoints = _teamStartingPoint;
            _redTeamPoints = _teamStartingPoint;

            UIManager.InGamePanel.TogglePlayContainer(false);

            _levelBehaviour = Instantiate(_levelBehaviourPrefab);

            SpawnController = _levelBehaviour.SpawnController;
            HospitalController = _levelBehaviour.HospitalController;
            AreaController = _levelBehaviour.AreaController;

            SpawnController.Initialize(this);
            HospitalController.Initialize(this);
            AreaController.Initialize(this);

            _soldierCharacterController = _levelBehaviour.SoldierCharacterController;
            _aiCharacterControllers = _levelBehaviour.AICharacterControllers;

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