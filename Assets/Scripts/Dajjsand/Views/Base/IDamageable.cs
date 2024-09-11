namespace Dajjsand.Views.Base
{
    public interface IDamageable
    {
        void ApplyDamage(int damage);
        void ApplyPeriodicDamage(int periodicDamage, int repeatsCount, float damageOnceTimer);
    }
}