using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Game.Scripts.Behaviours
{
    public class PlayerMovementBehaviour : BaseCharacterBehaviour
    {
        public bool IsAiming => _isAiming;

        [SerializeField] private CharacterController _characterController;

        [SerializeField] private float _speed;

        [SerializeField] private Transform _cameraTransfom;

        [SerializeField] private Transform _groundCheck;

        [SerializeField] private LayerMask _groundMask;

        [SerializeField] private float _jumpHeight;

        [SerializeField] private Image _crosshair;

        private float _groundDistance = 0.4f;
        private float _turnSmoothTime = 0.1f;
        private float _turnSmoothVelocity;
        private bool _isGrounded;
        private bool _isAiming;
        private Vector3 _fallVelocity;

        [Button]
        public void SetFiring()
        {
            _isAiming = !_isAiming;
            _crosshair.gameObject.SetActive(_isAiming);
        }

        private void Update()
        {
            if (!_isInitialized || !_isActivated) return;

            _isGrounded = Physics.CheckSphere(_groundCheck.position, _groundDistance, _groundMask);

            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");

            if (_isGrounded && _fallVelocity.y < 0)
            {
                _fallVelocity.y = Physics.gravity.y / 4.2f;
            }

            Vector3 direction = new Vector3(horizontal, 0, vertical * 2f).normalized;

            if (direction.magnitude >= 0.1f)
            {
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + _cameraTransfom.eulerAngles.y;

                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _turnSmoothVelocity, _turnSmoothTime);

                transform.rotation = Quaternion.Euler(0, angle, 0);

                Vector3 moveDirection = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
                _characterController.Move(moveDirection.normalized * _speed * Time.deltaTime);
            }

            if (_isAiming)
            {
                float targetAngle = _cameraTransfom.eulerAngles.y;

                float angle = targetAngle;

                transform.rotation = Quaternion.Euler(0, angle, 0);
            }

            if (Input.GetButtonDown("Jump") && _isGrounded)
            {
                _fallVelocity.y = Mathf.Sqrt(_jumpHeight * Physics.gravity.y / 4.2f * Physics.gravity.y);
            }


            _fallVelocity.y += Physics.gravity.y * Time.deltaTime;

            _characterController.Move(_fallVelocity * Time.deltaTime);
        }
    }
}