using Assets.Game.Scripts.Behaviours;
using Assets.Game.Scripts.BehaviourTree;
using Assets.Game.Scripts.BehaviourTree.Nodes;
using Assets.Game.Scripts.Managers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Game.Scripts.Controllers
{
    public class AICharacterController : SoldierCharacterController
    {
        public AIMovementBehaviour AIMovementBehaviour => _aIMovementBehaviour;
        public AIAimBehaviour AIaimBehaviour => _aIAimBehaviour;
        public AIEnemyRadarBehaviour AIEnemyRadarBehaviour => _aIEnemyRadarBehaviour;

        [SerializeField] private AIMovementBehaviour _aIMovementBehaviour;
        [SerializeField] private AIAimBehaviour _aIAimBehaviour;
        [SerializeField] private AIEnemyRadarBehaviour _aIEnemyRadarBehaviour;
        [SerializeField] private AIBehaviourTreeConnector _aIBehaviourTreeConnector;

        private Selector _topNode;

        private bool _isCharacterDeactivated;

        public bool IsAggressive { get; set; }


        public override void Initialize(GameManager gameManager)
        {
            base.Initialize(gameManager);

            _aIMovementBehaviour.Initialize(this);
            _characterHitDetectorBehaviour.Initialize(this);
            _characterHealthBehaviour.Initialize(this);
            _aIAimBehaviour.Initialize(this);
            _gunnerBehaviour.Initialize(this);
            _aIEnemyRadarBehaviour.Initialize(this);
            _aIBehaviourTreeConnector.Initialize(this);
            _characterSoundBehaviour.Initialize(this);

            ActivateSoldier();
        }

        public override void DeactivateSoldier()
        {
            base.DeactivateSoldier();
            _aIMovementBehaviour.Deactivate();
            _characterHitDetectorBehaviour.Deactivate();
            _characterHealthBehaviour.Deactivate();
            _aIAimBehaviour.Deactivate();
            _gunnerBehaviour.Deactivate();
            _aIEnemyRadarBehaviour.Deactivate();
            _isCharacterDeactivated = true;
        }

        public override void ActivateSoldier()
        {
            SetBehaviourTree();

            var randNum = Random.Range(0, 11);

            IsAggressive = randNum > 7 ? true : false;

            _aIMovementBehaviour.Activate();
            _characterHitDetectorBehaviour.Activate();
            _characterHealthBehaviour.Activate();
            _aIAimBehaviour.Activate();
            _gunnerBehaviour.Activate();
            _aIEnemyRadarBehaviour.Activate();
            _characterSoundBehaviour.Activate();

            _isCharacterDeactivated = false;
        }

        private void Update()
        {
            if (!_isCharacterDeactivated)
            {
                if (_topNode != null)
                {
                    _topNode.Evaluate();

                    if (_topNode.NodeState == NodeState.FAILURE)
                    {
                        Debug.Log($"TreeBehaviour: TopNodeFailure");
                    }
                }
            }
        }

        private void SetBehaviourTree()
        {
            IsThereAnEnemyNearNode isThereAnEnemyNearNode = new IsThereAnEnemyNearNode(_aIBehaviourTreeConnector);
            ShootNode shootNode = new ShootNode(_aIBehaviourTreeConnector);
            HealthNode healthNode = new HealthNode(_aIBehaviourTreeConnector, 15f);
            GoNearestHospitalNode goNearestHospitalNode = new GoNearestHospitalNode(_aIBehaviourTreeConnector);
            HasAnyAvailableAreaNode hasAnyAvailableAreaNode = new HasAnyAvailableAreaNode(_aIBehaviourTreeConnector);
            GoToAreaNode goToAreaNode = new GoToAreaNode(_aIBehaviourTreeConnector);

            Sequence objectiveSequence = new Sequence(new List<Node> { hasAnyAvailableAreaNode, goToAreaNode });
            Sequence getHealedSequence = new Sequence(new List<Node> { healthNode, goNearestHospitalNode });
            Sequence combatSequence = new Sequence(new List<Node> { isThereAnEnemyNearNode, shootNode });

            _topNode = new Selector(new List<Node> { combatSequence, getHealedSequence, objectiveSequence });
        }
    }
}