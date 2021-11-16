using Assets.Game.Scripts.Controllers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Game.Scripts.Behaviours
{
    public abstract class BaseCharacterBehaviour : MonoBehaviour
    {
        protected bool _isInitialized;
        protected bool _isActivated;

        protected List<Action> _activateContainer;
        protected List<Action> _deactivateContainer;

        protected SoldierCharacterController _soldierCharacterController;

        public virtual void Initialize(SoldierCharacterController soldierCharacterController)
        {
            _isInitialized = true;

            _activateContainer = new List<Action>();
            _deactivateContainer = new List<Action>();

            _soldierCharacterController = soldierCharacterController;

        }

        public virtual void Activate()
        {
            _isActivated = true;

            foreach (var action in _activateContainer)
            {
                action();
            }
        }

        public virtual void Deactivate()
        {
            _isActivated = false;

            foreach (var action in _deactivateContainer)
            {
                action();
            }
        }
    }
}