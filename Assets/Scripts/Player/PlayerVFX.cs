using UnityEngine;

[DisallowMultipleComponent]
public class PlayerVFX : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sprite;
    private void Reset()
    {
        if (!sprite)
            sprite = GetComponentInChildren<SpriteRenderer>();
    }
    private void Awake()
    {
        if (!sprite)
            sprite = GetComponentInChildren<SpriteRenderer>();
    }

    public void FlipSprite(float dir)
    {
        sprite.flipX = Mathf.Sign(dir) < 0;
    }
}