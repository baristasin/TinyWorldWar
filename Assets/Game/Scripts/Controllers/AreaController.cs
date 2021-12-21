using Assets.Game.Scripts.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Game.Scripts.Controllers
{
    public enum Team
    {
        Neutral,
        Red,
        Blue
    }

    public class AreaController : CustomBehaviour
    {
        public List<Area> AreaTransforms => _areas;

        [SerializeField] private List<Area> _areas;

        public override void Initialize(GameManager gameManager)
        {
            base.Initialize(gameManager);
        }

        public Area GetNextArea(Team team)
        {
            return _areas[0];
        }
    }
}