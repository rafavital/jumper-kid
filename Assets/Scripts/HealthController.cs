using System;
using UnityEngine;

public class HealthController : MonoBehaviour, IDamageable
{
    public event Action OnGetDamaged, OnDie;
    [SerializeField] private float maxHealth;
    private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void Damage(float damage)
    {
        currentHealth = Mathf.Max(0, currentHealth - damage); // clamps the health so it doesn't goes negative

        if (currentHealth < 0)
            Die();

        OnGetDamaged?.Invoke();
    }

    private void Die() => OnDie?.Invoke();
}
