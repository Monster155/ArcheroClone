using System;
using Dajjsand.Controllers.Interfaces;
using Dajjsand.Factories.Interfaces;
using Dajjsand.Utils;
using Dajjsand.Views.Guns.Base;
using Dajjsand.Views.HealthBars;
using Dajjsand.Views.Player;
using UnityEngine;
using Zenject;

namespace Dajjsand.Controllers
{
    public class PlayerController : IPlayerController
    {
        public event Action PlayerDead;

        private IPlayerFactory _playerFactory;
        private IGunFactory _gunFactory;
        private IPlayerController _playerControllerImplementation;

        public Player Player { get; private set; }

        [Inject]
        private void Construct(IPlayerFactory playerFactory, IGunFactory gunFactory)
        {
            _playerFactory = playerFactory;
            _gunFactory = gunFactory;
        }

        public void Init(HealthBarsController hpBarController, Transform spawnPoint)
        {
            Gun gun = _gunFactory.InstantiateGun(GlobalValues.SelectedGun, null);

            Player = _playerFactory.InstantiatePlayer(null);
            Player.transform.position = spawnPoint.position;
            Player.Init(hpBarController, gun);
            Player.Dead += Player_OnDead;
            StopPlayer();
        }

        public void Start()
        {
            Player.gameObject.SetActive(true);
        }

        public void StopPlayer()
        {
            Player.gameObject.SetActive(false);
        }

        private void Player_OnDead()
        {
            StopPlayer();
            PlayerDead?.Invoke();
        }
    }
}