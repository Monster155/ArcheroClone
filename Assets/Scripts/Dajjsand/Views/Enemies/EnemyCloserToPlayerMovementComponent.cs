using Dajjsand.Views.Enemies.Base;
using UnityEngine;

namespace Dajjsand.Views.Enemies
{
    public class EnemyCloserToPlayerMovementComponent : EnemyMovementComponent
    {
        protected override void Move()
        {
            _agent.destination = _target.transform.position;

            if (_agent.velocity.magnitude > 0)
                _rotatingPart.rotation = Quaternion.Euler(
                    0,
                    Quaternion.LookRotation(_agent.velocity).eulerAngles.y,
                    0);
        }
    }
}