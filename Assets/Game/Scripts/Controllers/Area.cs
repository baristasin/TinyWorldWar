using System.Collections;
using UnityEngine;

namespace Assets.Game.Scripts.Controllers
{
    public class Area : MonoBehaviour
    {
        public Team Team => _team;
        public Transform AreaTransform => _areaTransform;
        public int AreaId => _areaId;

        [SerializeField] private Transform _areaTransform;
        [SerializeField] private int _areaId;

        private Team _team;

        public void SetAreaTeam(Team team)
        {
            _team = team;
        }

    }
}