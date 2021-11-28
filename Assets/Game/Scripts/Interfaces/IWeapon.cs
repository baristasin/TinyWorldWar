using System.Collections;
using UnityEngine;

namespace Assets.Game.Scripts.Interfaces
{
    public interface IWeapon
    {
        GameObject GetGameobject();
        Transform GetTransform();
        void Initialize(Transform holdTransform);
        void DeactivateGun();
        void OnPlayerAimToggle(bool toggle);
        void Shoot();
    }
}