using Assets.Game.Scripts.Controllers;
using System;
using System.Collections;
using UnityEngine;

namespace Assets.Game.Scripts.Utilities
{
    public class CustomTimer : IDisposable
    {
        public event Action<CustomTimer, SoldierCharacterController> OnTimeEnded;
        public float TimeAmount;
        public SoldierCharacterController Soldier;

        private bool _isEnded;

        public CustomTimer(float timeAmount,SoldierCharacterController soldier)
        {
            Soldier = soldier;
            TimeAmount = timeAmount;
        }

        public void Tick(float tickAmount)
        {
            if (_isEnded) return;

            TimeAmount -= tickAmount;

            if (TimeAmount < 0)
            {
                OnTimeEnded?.Invoke(this,Soldier);
                _isEnded = true;
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}