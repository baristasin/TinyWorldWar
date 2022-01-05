using System.Collections;
using UnityEngine;

namespace Assets.Game.Scripts.Bullets
{
    public class Bullet : MonoBehaviour
    {
        public bool IsFiringFromPlayersGun { get; set; }
        public string Tag => _tag;
        public int Damage => _damage;

        [SerializeField] private string _tag;
        [SerializeField] private int _damage;
        [SerializeField] private float _bulletSpeed;

        private void Update()
        {
            transform.position += transform.forward * _bulletSpeed * Time.deltaTime;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!IsFiringFromPlayersGun) return;

            if(other.gameObject.layer == LayerMask.GetMask("RedTeam"))
            {

            }
        }
    }
}