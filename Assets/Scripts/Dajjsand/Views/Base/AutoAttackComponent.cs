using System;
using Dajjsand.Views.Guns;
using Dajjsand.Views.Guns.Base;
using UnityEngine;

namespace Dajjsand.Views.Base
{
    public class AutoAttackComponent : MonoBehaviour
    {
        [SerializeField] private Transform _gunContainer;
        [SerializeField] private Transform _rotatingPart;

        protected Gun _gun;
        protected Transform _targetBodyCenter;
        protected Transform _bodyCenter;

        public bool CanAttack { get; set; }
        public float AttackRange => _gun.AttackRange;


        public void Init(Gun gun, Transform bodyCenter)
        {
            _gun = gun;
            _bodyCenter = bodyCenter;
            _gun.transform.parent = _gunContainer;
            _gun.transform.localPosition = Vector3.zero;
            _gun.transform.localRotation = Quaternion.identity;
        }

        private void Update()
        {
            if (!CanAttack)
                return;

            Attacking();
        }

        protected virtual void Attacking()
        {
            if (_targetBodyCenter == null)
                return;

            Vector3 viewDirection = _targetBodyCenter.position - _bodyCenter.position;
            if (viewDirection.magnitude > 0)
                _rotatingPart.rotation = Quaternion.Euler(
                    0,
                    Quaternion.LookRotation(viewDirection).eulerAngles.y,
                    0);

            _gun.Shoot();
        }
    }
}