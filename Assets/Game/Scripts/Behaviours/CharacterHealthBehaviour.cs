using Assets.Game.Scripts.Controllers;
using System.Collections;
using UnityEngine;

namespace Assets.Game.Scripts.Behaviours
{
    public class CharacterHealthBehaviour : BaseCharacterBehaviour
    {
        public int CurrentHealth => _currentHealth;

        [SerializeField] private int _maxHealth;

        private int _currentHealth;

        public override void Initialize(SoldierCharacterController soldierCharacterController)
        {
            base.Initialize(soldierCharacterController);

            _currentHealth = _maxHealth;
        }

        public override void Activate()
        {
            base.Activate();
        }

        public override void Deactivate()
        {
            base.Deactivate();
        }

        public void UpdateHealth(int amount)
        {
            if(!_isInitialized || !_isActivated)
            {
                return;
            }

            _currentHealth += amount;

            if(_currentHealth < 0)
            {
                Debug.Log("PlayerDead");
            }
        }

    }
}