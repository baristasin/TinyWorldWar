using Assets.Game.Scripts.Managers;
using System.Collections;
using UnityEngine;

namespace Assets.Game.Scripts.Controllers
{
    public abstract class Controller : MonoBehaviour
    {
        protected GameManager GameManager;
        public virtual void Initialize(GameManager gameManager)
        {
            GameManager = gameManager;
        }
    }
}