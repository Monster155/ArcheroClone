using System.Collections;
using Dajjsand.Views.Enemies;
using UnityEngine;

namespace Dajjsand.Factories.Interfaces
{
    public interface IEnemyFactory
    {
        public IEnumerator LoadResources();
        public Enemy InstantiateEnemy(Transform container);
    }
}