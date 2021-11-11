using Assets.Game.Scripts.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Game.Scripts.Managers
{
    public class GameManager : MonoBehaviour
    {
        public InputController _inputController;

        private void Start()
        {
            _inputController.Initialize(this);
        }
    }
}