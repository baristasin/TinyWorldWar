using Assets.Game.Scripts.Managers;
using System.Collections;
using UnityEngine;

namespace Assets.Game.Scripts.Controllers
{
    public abstract class CustomBehaviour : MonoBehaviour
    {
        public GameManager GameManager { get; set; }
        public virtual void Initialize(GameManager gameManager)
        {
            GameManager = gameManager;
        }
    }
}