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
        public AIAimBehaviour AIaimBehaviour => _aIAimBehaviour;

        [SerializeField] private AIMovementBehaviour _aIMovementBehaviour;
        [SerializeField] private AIAimBehaviour _aIAimBehaviour;
        

        public override void Initialize(GameManager gameManager)
        {
            base.Initialize(gameManager);

            _aIMovementBehaviour.Initialize(this);
            _characterHitDetectorBehaviour.Initialize(this);
            _characterHealthBehaviour.Initialize(this);
            _aIAimBehaviour.Initialize(this);
            _gunnerBehaviour.Initialize(this);
            //_characterSoundBehaviour.Initialize(this);

            _aIMovementBehaviour.Activate();
            _characterHitDetectorBehaviour.Activate();
            _characterHealthBehaviour.Activate();
            _aIAimBehaviour.Activate();
            _gunnerBehaviour.Activate();
            //_characterSoundBehaviour.Activate();
        }

        [Button]
        public void SetDestTest(Transform testTransform)
        {
            _aIMovementBehaviour.SetTargetPosition(testTransform.position);
        }
    }
}