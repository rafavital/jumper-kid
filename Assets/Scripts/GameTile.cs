using System;
using UnityEngine;

[SelectionBase]
public class GameTile : MonoBehaviour
{
    public static event Action OnTileSettle;
    private static event Action OnFreeze;
    [SerializeField] private float descentSpeed = 1f;
    private Rigidbody2D rb;
    private bool settled;
    private bool gamePaused;
    private bool freeze;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        freeze = false;
        settled = false;
        rb.velocity = Vector2.down * descentSpeed;
    }

    private void Update()
    {
        if (!freeze && Mathf.Abs(rb.velocity.y) <= 0.01f && !settled)
        {
            Settle();
        }
    }

    public void SetPosition(Vector2 position)
    {
        if (settled)
            return;

        transform.position = new Vector2((position.x / 0.5f) * 0.5f, transform.position.y);
    }

    public void HandlePause(bool value)
    {
        freeze = value;
        rb.velocity = value ? Vector2.zero : Vector2.down * descentSpeed;
        rb.isKinematic = value;
    }

    private void Settle()
    {
        rb.velocity = Vector2.zero;
        rb.isKinematic = true;
        settled = true;
        OnTileSettle?.Invoke();
    }
}
