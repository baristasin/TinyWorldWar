using System.Collections;
using UnityEngine;

namespace Assets.Game.Scripts.Bullets
{
    public class ThrowableAmmo : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;

        public void ThrowAmmo(Vector3 directionForward, float force)
        {
            _rigidbody.AddForce(directionForward * force, ForceMode.VelocityChange);
        }
    }
}