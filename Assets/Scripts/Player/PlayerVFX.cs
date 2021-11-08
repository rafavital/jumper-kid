using UnityEngine;
using DG.Tweening;

[DisallowMultipleComponent]
public class PlayerVFX : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sprite;
    private Vector3 spriteOriginalScale;
    private void Reset()
    {
        if (!sprite)
            sprite = GetComponentInChildren<SpriteRenderer>();
    }
    private void Awake()
    {
        if (!sprite)
            sprite = GetComponentInChildren<SpriteRenderer>();

        spriteOriginalScale = sprite.transform.localScale;
    }

    public void FlipSprite(float dir)
    {
        sprite.flipX = Mathf.Sign(dir) < 0;
    }

    public void Squash(float squashFactor, float duration, Ease ease = Ease.OutCubic)
    {
        sprite.transform.DOScale(new Vector3(spriteOriginalScale.x - squashFactor, spriteOriginalScale.y + squashFactor, spriteOriginalScale.z), duration / 2f)
              .From(spriteOriginalScale)
              .SetEase(ease)
              .OnComplete(() => sprite.transform.DOScale(spriteOriginalScale, duration / 2f).SetEase(ease));
    }

    public void Stretch(float stretchFactor, float duration, Ease ease = Ease.OutCubic)
    {
        sprite.transform.DOScale(new Vector3(spriteOriginalScale.x + stretchFactor, spriteOriginalScale.y - stretchFactor, spriteOriginalScale.z), duration / 2f)
              .From(spriteOriginalScale)
              .SetEase(ease)
              .OnComplete(() => sprite.transform.DOScale(spriteOriginalScale, duration / 2f).SetEase(ease));
    }
}