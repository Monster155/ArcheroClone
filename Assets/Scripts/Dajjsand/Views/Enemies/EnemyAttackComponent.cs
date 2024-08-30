using Dajjsand.Views.Base;
using Dajjsand.Views.Guns;
using UnityEngine;

namespace Dajjsand.Views.Enemies
{
    public class EnemyAttackComponent : AutoAttackComponent
    {
        private Player.Player _player;

        public void Init(Gun gun, Player.Player player, Transform bodyCenter)
        {
            base.Init(gun, bodyCenter);
            _player = player;
        }

        protected override void Attacking()
        {
            _targetBodyCenter = _player.BodyCenter;
            base.Attacking();
        }
    }
}