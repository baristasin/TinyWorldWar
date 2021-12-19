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

        private bool _isDead;

        private Coroutine _healthRegenRoutine;

        public override void Initialize(SoldierCharacterController soldierCharacterController)
        {
            base.Initialize(soldierCharacterController);

            _currentHealth = _maxHealth;

            _healthRegenRoutine = StartCoroutine(HealthRegenCo());
        }

        private IEnumerator HealthRegenCo()
        {
            while (_isActivated && _isInitialized && !_isDead)
            {
                yield return new WaitForSeconds(.5f);
                _currentHealth += 1;
                Mathf.Clamp(_currentHealth, 0, 100);
            }
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
            if (!_isInitialized || !_isActivated)
            {
                return;
            }

            _currentHealth += amount;

            if (_currentHealth < 0)
            {
                _isDead = true;
                Debug.Log("PlayerDead");
            }
        }

    }
}