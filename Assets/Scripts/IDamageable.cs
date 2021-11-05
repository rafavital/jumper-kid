using System;

public interface IDamageable
{
    public event Action OnGetDamaged;
    public void Damage(float damage);
}
