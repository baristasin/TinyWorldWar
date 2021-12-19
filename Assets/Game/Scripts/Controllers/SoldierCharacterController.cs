﻿using Assets.Game.Scripts.Behaviours;
using Assets.Game.Scripts.Managers;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Game.Scripts.Controllers
{
    public class SoldierCharacterController : CustomBehaviour
    {
        public AICharacterController AICharacterController => _aICharacterController;
        public PlayerCharacterController PlayerCharacterController => _playerCharacterController;

        public CharacterHitDetectorBehaviour CharacterHitDetectorBehaviour => _characterHitDetectorBehaviour;
        public CharacterSoundBehaviour CharacterSoundBehaviour => _characterSoundBehaviour;
        public CharacterHealthBehaviour CharacterHealthBehaviour => _characterHealthBehaviour;

        [SerializeField] private PlayerCharacterController _playerCharacterController;
        [SerializeField] private AICharacterController _aICharacterController;

        [SerializeField] protected CharacterHitDetectorBehaviour _characterHitDetectorBehaviour;
        [SerializeField] protected CharacterSoundBehaviour _characterSoundBehaviour;
        [SerializeField] protected CharacterHealthBehaviour _characterHealthBehaviour;

        public override void Initialize(GameManager gameManager)
        {
            base.Initialize(gameManager);            
        }

        public virtual void DetectorHit(LayerMask layer)
        {
            var damage = GameManager.BattleController.GetDamageAmount(layer);
            _characterHealthBehaviour.UpdateHealth(-damage);
        }
    }
}