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
        [SerializeField] private List<Area> _allAreas;

        [SerializeField] private List<Area> _areasFromBlueSide;
        [SerializeField] private List<Area> _areasFromRedSide;

        [SerializeField] private List<Area> _areaFromCriticalArea;


        public override void Initialize(GameManager gameManager)
        {
            base.Initialize(gameManager);
            StartCoroutine(SendAreaDataCo());
        }

        private IEnumerator SendAreaDataCo()
        {
            while (true)
            {
                yield return new WaitForSeconds(1f);

                int blueTeamAreas = 0;
                int redTeamAreas = 0;

                blueTeamAreas = _allAreas.FindAll(x => x.Team == Team.Blue).Count;
                redTeamAreas = _allAreas.FindAll(x => x.Team == Team.Red).Count;

                Debug.Log($"BlueAreas: {blueTeamAreas}");
                Debug.Log($"RedAreas: {redTeamAreas}");

                GameManager.UpdateGameState(blueTeamAreas, redTeamAreas);
            }

        }

        public Area GetNextArea(Team team, bool isAggressiveBehaviour)
        {
            if (isAggressiveBehaviour && _areaFromCriticalArea.Find(x => x.Team != team) is Area area)
            {
                return area;
            }

            if (team == Team.Blue && _areasFromBlueSide.First(x => x.Team == Team.Neutral || x.Team == Team.Red) != null)
            {
                return _areasFromBlueSide.First(x => x.Team == Team.Neutral || x.Team == Team.Red);
            }

            else if(team == Team.Red && _areasFromRedSide.First(x => x.Team == Team.Neutral || x.Team == Team.Blue) != null)
            {
                return _areasFromRedSide.First(x => x.Team == Team.Neutral || x.Team == Team.Blue);
            }

            else
            {
                if(team == Team.Red)
                {
                    return _areasFromRedSide[2];
                }

                if (team == Team.Blue)
                {
                    return _areasFromBlueSide[2];
                }

                return null;
            }
        }
    }
}