using Assets.Game.Scripts.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

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
        [SerializeField] private List<Area> _areasFromBlueSide;
        [SerializeField] private List<Area> _areasFromRedSide;

        [SerializeField] private List<Area> _areaFromCriticalArea;


        public override void Initialize(GameManager gameManager)
        {
            base.Initialize(gameManager);
        }

        public Area GetNextArea(Team team, bool isAggressiveBehaviour)
        {
            if (isAggressiveBehaviour && _areaFromCriticalArea.Find(x => x.Team != team) is Area area)
            {
                return area;
            }

            if(team == Team.Blue)
            {
                return _areasFromBlueSide.First(x => x.Team == Team.Neutral || x.Team == Team.Red);
            }

            else
            {
                return _areasFromRedSide.First(x => x.Team == Team.Neutral || x.Team == Team.Blue);
            }
        }
    }
}