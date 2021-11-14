using Assets.Game.Scripts.Bullets;
using Assets.Game.Scripts.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Game.Scripts.Controllers
{
    public class BattleController : CustomBehaviour
    {
        [SerializeField] private List<Bullet> _bulletTypes;

        public int GetDamageAmount(LayerMask layer)
        {
            foreach (var bulletType in _bulletTypes)
            {
                if(bulletType.LayerMask == layer)
                {
                    return bulletType.Damage;
                }
            }

            Debug.Log($"Error: Damager with {layer} layer is not initialized");
            return 0;
        }
    }
}