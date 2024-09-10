using UnityEngine;
using UnityEngine.Pool;

namespace Dajjsand.Views.HealthBars
{
    public class HealthBarsController : MonoBehaviour
    {
        [SerializeField] private Transform _barsContainer;
        [SerializeField] private HealthBar _healthBar;

        private ObjectPool<HealthBar> _barsPool;

        public void Init()
        {
            _barsPool = new ObjectPool<HealthBar>(
                () => Instantiate(_healthBar, _barsContainer),
                healthBar => healthBar.gameObject.SetActive(true),
                healthBar => healthBar.gameObject.SetActive(false),
                healthBar => Destroy(healthBar.gameObject));
        }

        public HealthBar GetHealthBar() => _barsPool.Get();
        public void ReleaseHealthBar(HealthBar healthBar) => _barsPool.Release(healthBar);
    }
}