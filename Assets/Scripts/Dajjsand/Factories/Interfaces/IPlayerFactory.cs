using System.Collections;
using Dajjsand.Views.Player;
using UnityEngine;

namespace Dajjsand.Factories.Interfaces
{
    public interface IPlayerFactory
    {
        public IEnumerator LoadResources();
        public Player InstantiatePlayer(Transform container);
    }
}