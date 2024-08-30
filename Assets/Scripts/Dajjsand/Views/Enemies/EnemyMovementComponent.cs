using UnityEngine;
using UnityEngine.AI;

namespace Dajjsand.Views.Enemies
{
    public class EnemyMovementComponent : MonoBehaviour
    {
        [SerializeField] private Transform _rotatingPart;
        [SerializeField] private NavMeshAgent _agent;

        private Player.Player _target;

        public bool CanMove { get; set; }

        public void Init(Player.Player player)
        {
            _target = player;
        }

        private void Update()
        {
            if (!CanMove)
            {
                _agent.destination = _agent.transform.position;
                return;
            }

            _agent.destination = _target.transform.position;

            if (_agent.velocity.magnitude > 0)
                _rotatingPart.rotation = Quaternion.Euler(
                    0,
                    Quaternion.LookRotation(_agent.velocity).eulerAngles.y,
                    0);
        }
    }
}