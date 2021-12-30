using Assets.Game.Scripts.Managers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Game.Scripts.Controllers
{
    public class HospitalController : CustomBehaviour
    {
        [SerializeField] private List<Transform> _redHospitals;
        [SerializeField] private List<Transform> _blueHospitals;

        public override void Initialize(GameManager gameManager)
        {
            base.Initialize(gameManager);
        }

        public Transform GetNearestHospital(Team team)
        {
            return team == Team.Red ? _redHospitals[0] : _blueHospitals[0];
        }
    }
}