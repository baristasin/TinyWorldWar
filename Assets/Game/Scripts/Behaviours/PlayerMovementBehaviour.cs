using Assets.Game.Scripts.Controllers;
using Cinemachine;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Game.Scripts.Behaviours
{
    public class PlayerMovementBehaviour : BaseCharacterBehaviour
    {
        public bool IsWalking => _isWalking && _isGrounded;
        public bool IsAiming => _isAiming;

        public Transform CameraTransform;

        public Image Crosshair;

        [SerializeField] private CharacterController _characterController;

        [SerializeField] private float _speed;

        [SerializeField] private Transform _groundCheck;

        [SerializeField] private LayerMask _groundMask;

        [SerializeField] private float _jumpHeight;

        [SerializeField] private CinemachineFreeLook _cinemachineFreeLookCam;

        private float _defaultFowValue = 50f;
        private float _aimFowValue = 25;

        private float _fowValue = 40f;

        private float _groundDistance = 0.4f;
        private float _turnSmoothTime = 0.4f;
        private float _turnSmoothVelocity;
        private bool _isGrounded;
        private bool _isAiming;
        private Vector3 _fallVelocity;

        private bool _isWalking;

        [Button]
        public void SetFiring()
        {
            if (!_isInitialized || !_isActivated) return;

            _isAiming = !_isAiming;
            Crosshair.gameObject.SetActive(_isAiming);
        }

        public override void Initialize(SoldierCharacterController soldierCharacterController)
        {
            base.Initialize(soldierCharacterController);

            _cinemachineFreeLookCam.enabled = true;
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
                _isWalking = true;

                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + CameraTransform.eulerAngles.y;

                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _turnSmoothVelocity, _turnSmoothTime);

                if (!_isAiming)
                {
                    transform.rotation = Quaternion.Euler(0, angle, 0);
                }

                Vector3 moveDirection = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
                _characterController.Move(moveDirection.normalized * _speed * Time.deltaTime);
            }
            else
            {
                _isWalking = false;
            }

            _cinemachineFreeLookCam.m_Lens.FieldOfView = _fowValue;

            if (_isAiming)
            {
                _fowValue = Mathf.Lerp(_fowValue, _aimFowValue, Time.deltaTime * 5f);

                float targetAngle = CameraTransform.eulerAngles.y;

                float angle = targetAngle;

                transform.rotation = Quaternion.Euler(0, angle, 0);
            }
            else
            {
                _fowValue = Mathf.Lerp(_fowValue, _defaultFowValue, Time.deltaTime * 5f);
            }

            if (Input.GetButtonDown("Jump") && _isGrounded)
            {
                _fallVelocity.y = Mathf.Sqrt(_jumpHeight * Physics.gravity.y / 4.2f * Physics.gravity.y);
                _soldierCharacterController.CharacterSoundBehaviour.PlayJumpClip();
            }


            _fallVelocity.y += Physics.gravity.y * Time.deltaTime;

            _characterController.Move(_fallVelocity * Time.deltaTime);
        }
    }
}