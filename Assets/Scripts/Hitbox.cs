using CustomUnityEvents;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    [SerializeField] private float damageAmount = 0f;
    public UnityHurtboxEvent OnHit;

    // ensures this hitbox is a trigger
    private void Awake() => GetComponent<Collider2D>().isTrigger = true;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // if (other.gameObject.layer != checkLayer)
        // return;

        var hurtbox = other.GetComponent<Hurtbox>();

        if (!hurtbox)
            return;

        hurtbox.Hurt(damageAmount);
        OnHit?.Invoke(hurtbox);
    }
}