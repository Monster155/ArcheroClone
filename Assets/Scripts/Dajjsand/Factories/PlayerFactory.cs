using System.Collections;
using Dajjsand.Factories.Interfaces;
using Dajjsand.Views.Player;
using UnityEngine;
using Zenject;

namespace Dajjsand.Factories
{
    public class PlayerFactory : IPlayerFactory
    {
        private DiContainer _diContainer;
        private Player _playerPrefab;

        public PlayerFactory(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }

        public IEnumerator LoadResources()
        {
            yield return _playerPrefab = Resources.Load<Player>("Views/Players/Player");
        }

        public Player InstantiatePlayer(Transform container)
        {
            Player player = _diContainer.InstantiatePrefabForComponent<Player>(_playerPrefab.gameObject, container);
            return player;
        }
    }
}