using Assets.Game.Scripts.Managers;
using Assets.Game.Scripts.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Game.Scripts.Controllers
{
    public class SpawnController : CustomBehaviour
    {
        public List<CustomTimer> _timerList;

        [SerializeField] private Transform _blueTeamSpawnTransform;
        [SerializeField] private Transform _redTeamSpawnTransform;

        public override void Initialize(GameManager gameManager)
        {
            base.Initialize(gameManager);
            _timerList = new List<CustomTimer>();
        }

        public void GetIntoSpawnList(SoldierCharacterController soldierCharacterController)
        {
            soldierCharacterController.DeactivateSoldier();
            soldierCharacterController.gameObject.SetActive(false);
            CustomTimer timer = new CustomTimer(10f, soldierCharacterController);
            timer.OnTimeEnded += SpawnSoldier;

            _timerList.Add(timer);
        }

        private void Update()
        {
            if (_timerList.Count > 0)
            {
                foreach (var timer in _timerList)
                {
                    if(timer != null)
                    {

                    timer.Tick(Time.deltaTime);
                    }
                }
            }
        }

        private void SpawnSoldier(CustomTimer timer, SoldierCharacterController soldier)
        {
            soldier.transform.position = soldier.Team == Team.Blue ? _blueTeamSpawnTransform.transform.position : _redTeamSpawnTransform.position;
            soldier.transform.rotation = soldier.Team == Team.Blue ? _blueTeamSpawnTransform.transform.rotation : _redTeamSpawnTransform.rotation;

            soldier.gameObject.SetActive(true);

            soldier.Initialize(GameManager);
            timer.Dispose();

            GameManager.SoldierSpawned(soldier.Team);
        }
    }
}