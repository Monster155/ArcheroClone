using System;
using Dajjsand.Services.InputServices.Interfaces;
using Dajjsand.Views.Base;
using Dajjsand.Views.Guns;
using Dajjsand.Views.Guns.Base;
using Dajjsand.Views.HealthBars;
using UnityEngine;
using Zenject;

namespace Dajjsand.Views.Player
{
    public class Player : MonoBehaviour
    {
        public event Action Dead;

        [SerializeField] private PlayerMovementComponent _movement;
        [SerializeField] private PlayerAttackComponent _attack;
        [SerializeField] private BaseHealthComponent _health;
        [SerializeField] private Transform _bodyCenter;
        [field: SerializeField] public int ContactDamage { get; set; }

        private IInputService _inputService;

        public Transform BodyCenter => _bodyCenter;


        [Inject]
        private void Construct(IInputService inputService)
        {
            _inputService = inputService;
        }

        public void Init(HealthBarsController healthBarsController, Gun gun)
        {
            _attack.Init(gun, _bodyCenter);
            _movement.Init(_inputService);
            _health.Init(healthBarsController);
            
            _health.OnDead += Health_OnDead;
        }

        private void Update()
        {
            Vector3 moveDirection = new Vector3(_inputService.Horizontal, 0, _inputService.Vertical);
            bool isMoving = moveDirection.magnitude > 0;

            _attack.CanAttack = !isMoving;
            _movement.CanMove = isMoving;
        }
        
        private void Health_OnDead()
        {
            Dead?.Invoke();
        }
    }
}