using UnityEngine;
using CustomUnityEvents;


[RequireComponent(typeof(Collider2D))]
public class Hurtbox : MonoBehaviour
{
    // [SerializeField] private LayerMask checkLayer;
    public UnityHitboxEvent OnGetHurt;
    private IDamageable damageable;

    // ensures this hurtbox is a trigger
    private void Awake()
    {
        GetComponent<Collider2D>().isTrigger = true;
        damageable = GetComponentInParent<IDamageable>(); // tries to get an IDamageable component
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // if (other.gameObject.layer != checkLayer)
        // return;

        var hitbox = other.GetComponent<Hitbox>();

        if (!hitbox)
            return;

        OnGetHurt?.Invoke(hitbox);
    }

    public void Hurt(float damageAmount)
    {
        if (damageable != null)
            damageable.Damage(damageAmount);
    }
}
