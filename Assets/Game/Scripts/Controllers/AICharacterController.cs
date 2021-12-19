using Assets.Game.Scripts.Behaviours;
using Assets.Game.Scripts.Managers;
using Sirenix.OdinInspector;
using System.Collections;
using UnityEngine;

namespace Assets.Game.Scripts.Controllers
{
    public class AICharacterController : SoldierCharacterController
    {
        public AIMovementBehaviour AIMovementBehaviour => _aIMovementBehaviour;

        [SerializeField] private AIMovementBehaviour _aIMovementBehaviour;

        public override void Initialize(GameManager gameManager)
        {
            base.Initialize(gameManager);

            _aIMovementBehaviour.Initialize(this);
            _characterHitDetectorBehaviour.Initialize(this);
            _characterHealthBehaviour.Initialize(this);
            //_characterSoundBehaviour.Initialize(this);

            _aIMovementBehaviour.Activate();
            _characterHitDetectorBehaviour.Activate();
            _characterHealthBehaviour.Activate();
            //_characterSoundBehaviour.Activate();
        }

        [Button]
        public void SetDestTest(Transform testTransform)
        {
            _aIMovementBehaviour.SetTargetPosition(testTransform.position);
        }
    }
}