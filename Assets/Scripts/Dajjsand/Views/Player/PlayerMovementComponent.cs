using System;
using Dajjsand.Services.InputServices.Interfaces;
using UnityEngine;
using Zenject;

namespace Dajjsand.Views.Player
{
    public class PlayerMovementComponent : MonoBehaviour
    {
        [SerializeField] private float _speed = 10f;
        [SerializeField] private Transform _rotatingPart;
        [SerializeField] private Rigidbody _movingPart;

        private IInputService _inputService;

        public bool CanMove { get; set; }

        public void Init(IInputService inputService)
        {
            _inputService = inputService;
        }

        private void FixedUpdate()
        {
            if (!CanMove)
            {
                _movingPart.velocity = Vector3.zero;
                return;
            }

            Vector3 moveDirection = new Vector3(_inputService.Horizontal, 0, _inputService.Vertical).normalized;

            if (moveDirection.magnitude > 0)
                _rotatingPart.rotation = Quaternion.Euler(
                    0,
                    Quaternion.LookRotation(moveDirection).eulerAngles.y,
                    0);

            _movingPart.velocity = moveDirection * _speed;
        }
    }
}