using Assets.Game.Scripts.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Game.Scripts.Controllers
{
    public class HospitalController : CustomBehaviour
    {
        public List<Transform> HospitalTransforms => _hospitalTransforms;

        [SerializeField] private List<Transform> _hospitalTransforms;

        public override void Initialize(GameManager gameManager)
        {
            base.Initialize(gameManager);
        }
    }
}