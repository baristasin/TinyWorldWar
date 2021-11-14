using System.Collections;
using UnityEngine;

namespace Assets.Game.Scripts.Bullets
{
    public class Bullet : MonoBehaviour
    {
        public LayerMask LayerMask => _layerMask;
        public int Damage => _damage;

        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private int _damage;        
    }
}