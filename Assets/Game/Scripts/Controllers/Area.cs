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
        [SerializeField] private LayerMask _blueTeamLayermask;
        [SerializeField] private LayerMask _redTeamLayermask;

        [SerializeField] private MeshRenderer _areaFlagRenderer;

        public int _blueTeamMemberCount;
        public int _redTeamMemberCount;
        public int _totalCapturePoints;
        public Team _team;

        private void Start()
        {
            StartCoroutine(DetectCaptureSoldiersCo());
            _team = Team.Neutral;
        }

        public void SetAreaTeam(Team team)
        {
            _team = team;
        }

        private void Update()
        {
            _totalCapturePoints = Mathf.Clamp(_totalCapturePoints, -95, 95);

            if(_totalCapturePoints > 90)
            {
                _team = Team.Blue;
                _areaFlagRenderer.material.color = Color.green;
            }
            else if(_totalCapturePoints < -90)
            {
                _team = Team.Red;
                _areaFlagRenderer.material.color = Color.yellow;
            }
        }

        private IEnumerator DetectCaptureSoldiersCo()
        {
            while (true)
            {
                Collider[] hitCollidersBlueTeam = Physics.OverlapSphere(transform.position, 15f/*Random.Range(20f,35f)*/, _blueTeamLayermask);

                _blueTeamMemberCount = hitCollidersBlueTeam.Length;

                Collider[] hitCollidersRedTeam = Physics.OverlapSphere(transform.position, 15f/*Random.Range(20f,35f)*/, _redTeamLayermask);

                _redTeamMemberCount = hitCollidersRedTeam.Length;

                _totalCapturePoints = _totalCapturePoints + _blueTeamMemberCount - _redTeamMemberCount;

                yield return new WaitForSeconds(1f);
            }
        }
    }
}