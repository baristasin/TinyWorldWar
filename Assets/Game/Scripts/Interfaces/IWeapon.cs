using System.Collections;
using UnityEngine;

namespace Assets.Game.Scripts.Interfaces
{
    public enum WeaponType
    {
        Shootable,
        Throwable
    }

    public interface IWeapon
    {
        WeaponType GetWeaponType();
        GameObject GetGameobject();
        Transform GetTransform();
        void Initialize(Transform holdTransform);
        void DeactivateGun();
        void OnPlayerAimToggle(bool toggle);
        void Shoot();
    }
}