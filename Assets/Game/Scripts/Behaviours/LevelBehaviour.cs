using Assets.Game.Scripts.Controllers;
using Assets.Game.Scripts.Managers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Game.Scripts.Behaviours
{
    public class LevelBehaviour : MonoBehaviour
    {
        public SpawnController SpawnController;
        public HospitalController HospitalController;
        public AreaController AreaController;

        public List<AICharacterController> AICharacterControllers;
        public SoldierCharacterController SoldierCharacterController;


    }
}