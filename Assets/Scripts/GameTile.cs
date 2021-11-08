using System;
using System.Linq;
using UnityEngine;
using DG.Tweening;
using Random = UnityEngine.Random;

[SelectionBase]
public class GameTile : MonoBehaviour
{
    public static event Action OnTileSettle;
    private static event Action OnFreeze;

    [SerializeField] private LevelInfo gameInfo;
    [SerializeField] private float descentSpeed = 1f;

    private Rigidbody2D rb;
    private bool settled;
    private bool freeze;
    private bool startedMoving;
    private float myWidth;
    private int blocksThatFinishedAnimating;
    private int blocksToAnimate;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        freeze = false;
        settled = false;
        startedMoving = false;

        ImpedeSelfCollision();

        CalculateMyWidth();
        ScaleBlocks();
    }

    private void Update()
    {
        if (startedMoving && !freeze && !settled && Mathf.Abs(rb.velocity.y) <= 0.01f)
        {
            Settle();
        }
    }

    public void SetPosition(Vector2 position)
    {
        if (settled)
            return;

        var newX = Mathf.Round(position.x / 0.25f) * 0.25f;
        var clampX = gameInfo.mainCamera.transform.position.x + gameInfo.sceneBounds.x - myWidth;
        newX = Mathf.Clamp(newX, -clampX, clampX);
        transform.position = new Vector2(newX, transform.position.y);
    }

    public void HandlePause(bool value)
    {
        freeze = value;
        rb.velocity = value ? Vector2.zero : Vector2.down * descentSpeed;
        rb.isKinematic = value;
    }

    private void StartMoving()
    {
        rb.isKinematic = false;
        rb.velocity = Vector2.down * descentSpeed;

        startedMoving = true;
    }

    private void Settle()
    {
        rb.velocity = Vector2.zero;
        rb.isKinematic = true;
        settled = true;
        OnTileSettle?.Invoke();
    }

    // Calculates the current tile's width based on it's children colliders
    private void CalculateMyWidth()
    {
        float leftMostX = 0;
        float rightMostX = 0;

        foreach (Collider2D colliders in GetComponentsInChildren<Collider2D>())
        {
            var rightBoundX = colliders.bounds.max.x;
            var leftBoundX = colliders.bounds.min.x;
            leftMostX = rightBoundX > rightMostX ? rightBoundX : leftMostX;
            rightMostX = leftBoundX < leftMostX ? leftBoundX : leftMostX;
        }

        myWidth = Mathf.Max(Mathf.Abs(leftMostX), Mathf.Abs(rightMostX));
    }

    private void ScaleBlocks()
    {
        var blocks = transform.GetComponentsInChildren<Transform>().Where(t => t != transform).ToArray();
        blocksToAnimate = blocks.Length;
        // foreach (var t in blocks)
        // {
        //     print(t.name);
        // }

        for (int i = 0; i < blocks.Length; i++)
        {
            var b = blocks[i];
            var originalScale = b.localScale;
            b.DOScale(originalScale, Random.Range(0.1f, 0.5f))
             .From(Vector3.zero)
             .SetEase(Ease.InOutElastic)
             .OnComplete(TryFinishAnimation);
        }
    }

    private void TryFinishAnimation()
    {
        blocksThatFinishedAnimating++;

        if (blocksThatFinishedAnimating >= blocksToAnimate)
            StartMoving();
    }

    private void ImpedeSelfCollision()
    {
        var colliders = GetComponentsInChildren<Collider2D>();

        foreach (var col1 in colliders)
        {
            foreach (var col2 in colliders)
            {
                Physics2D.IgnoreCollision(col1, col2);
            }
        }
    }
}
