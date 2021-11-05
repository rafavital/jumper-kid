using UnityEngine;
using System;
using UnityAtoms.BaseAtoms;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Player
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovement : MonoBehaviour
    {
        public static event Action OnPlayerCrushed, OnStartFalling;
        [SerializeField] private LevelInfo levelInfo;
        [SerializeField] private FloatVariable traveledDistance;


        [Header("General Move Parameters")]
        [SerializeField] private float moveSpeed;
        [SerializeField] private float airMoveSpeed;

        [Header("Jump Parameters")]
        [SerializeField] private float jumpHeight;
        [SerializeField] private float lowJumpGravity = 2.5f;
        [SerializeField] private float highJumpGravity = 2f;
        [SerializeField] private float jumpDistance;

        [Header("Checks")]
        [SerializeField] private Transform feetPos;
        [SerializeField] private Transform headPos;
        [SerializeField] private LayerMask groundLayer;
        [SerializeField] private Vector2 groundCheckSize;
        [SerializeField] private LayerMask wallLayer;
        [SerializeField] private int wallCheckResolution;
        [SerializeField] private float wallCheckDistance;
        [SerializeField] private LayerMask tileLayer;


        private Rigidbody2D rb;

        private float jumpVelocity;
        private float jumpGravity;
        private float lastYVelocity;

        public bool IsGrounded { get => isGrounded; private set => isGrounded = value; }
        private bool isGrounded;

        #region UNITY CALLS
#if UNITY_EDITOR
        private void OnDrawGizmosSelected()
        {

            if (feetPos)
                Gizmos.DrawWireCube(feetPos.position, new Vector3(groundCheckSize.x, groundCheckSize.y, 0));

            if (headPos && feetPos)
            {
                float step = (headPos.position.y - feetPos.position.y) / (float)wallCheckResolution;

                for (int i = 0; i <= wallCheckResolution; i++)
                {
                    var pos = feetPos.position + Vector3.up * step * i;
                    Debug.DrawLine(pos, pos + Vector3.right * wallCheckDistance, Color.red);
                    Debug.DrawLine(pos, pos + Vector3.left * wallCheckDistance, Color.red);
                }
            }

            // int jumpArcResolution = 3;

            // for (int i = 0; i < jumpArcResolution; i++)
            // {
            //     if (i == 0)
            //         continue;
            //     var pAX = (i - 1) * moveSpeed;
            //     var pBX = i * moveSpeed;
            //     // Vector2 pA = new Vector2(pAX, (-4 * jumpHeight * moveSpeed * pAX * pAX) + (2 * jumpHeight));
            //     // Vector2 pB = new Vector2(pBX, (-4 * jumpHeight * moveSpeed * Mathf.Pow(pBX, 2)) + (2 * jumpHeight));
            //     Vector2 pA = new Vector2(pAX, -moveSpeed * Mathf.Pow((pAX - (pAX / 2)), 2) + jumpHeight);
            //     Vector2 pB = new Vector2(pBX, -moveSpeed * Mathf.Pow((pBX - (pBX / 2)), 2) + jumpHeight);
            //     Handles.DrawAAPolyLine(new Vector3[] { (Vector2)transform.position + pA, (Vector2)transform.position + pB });
            // }

        }
#endif
        private void Reset() => rb = GetComponent<Rigidbody2D>();
        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();

            jumpVelocity = 2 * jumpHeight * moveSpeed / jumpDistance;
            jumpGravity = -2 * jumpHeight * (moveSpeed * moveSpeed) / (jumpDistance * jumpDistance);
        }

        private void Start()
        {
            traveledDistance.Value = 0;
        }

        private void FixedUpdate()
        {
            GroundCheck();
        }

        private void Update()
        {
            // wrap around the screen
            if (transform.position.x - transform.localScale.x / 2 > levelInfo.mainCamera.transform.position.x + levelInfo.sceneBounds.x)
                transform.position = new Vector2(levelInfo.mainCamera.transform.position.x - levelInfo.sceneBounds.x, transform.position.y);
            else if (transform.position.x + transform.localScale.x / 2 < levelInfo.mainCamera.transform.position.x - levelInfo.sceneBounds.x)
                transform.position = new Vector2(levelInfo.mainCamera.transform.position.x + levelInfo.sceneBounds.x, transform.position.y);

            // updates the traveled distance
            var distance = transform.position.y - 1.75f; //FIXME: remove hardcoded value
            traveledDistance.Value = Mathf.Max(distance, traveledDistance.Value);

            if (lastYVelocity > 0 && rb.velocity.y <= 0)
                OnStartFalling?.Invoke();
        }

        private void LateUpdate()
        {
            lastYVelocity = rb.velocity.y;
        }



        #endregion

        #region PUBLIC METHODS
        public void Move(float direction, bool jumpHeld)
        {
            var movement = new Vector2(direction * (IsGrounded ? moveSpeed : airMoveSpeed), rb.velocity.y);

            if (CheckWall(direction))
                movement.x = 0;

            rb.velocity = movement;
        }

        public void Jump()
        {
            var yVel = Mathf.Sqrt(2f * jumpHeight * Mathf.Abs(Physics2D.gravity.y * lowJumpGravity));
            rb.velocity = new Vector2(rb.velocity.x, yVel);
        }

        public void ApplyGravity(bool jumpHeld) => rb.gravityScale = jumpHeld ? highJumpGravity : lowJumpGravity;

        public void ZeroVelocity() => rb.velocity = Vector2.zero;

        public Vector2 GetVelocity() => rb.velocity;

        public void AddForce(Vector2 force, ForceMode2D mode) => rb.AddForce(force, mode);
        #endregion

        #region PRIVATE METHODS
        private bool GroundCheck() => IsGrounded = Physics2D.OverlapBox(feetPos.position, groundCheckSize, 0, groundLayer);

        private bool CheckWall(float dir)
        {
            var distance = headPos.position.y - feetPos.position.y;
            float step = distance / (float)wallCheckResolution;

            for (int i = 0; i <= wallCheckResolution; i++)
            {
                Vector2 rayPos = (Vector2)feetPos.position + Vector2.up * step * i;

                var hit = Physics2D.Raycast(rayPos, dir * Vector2.right, wallCheckDistance, wallLayer);

                if (hit)
                {
                    if (Mathf.Abs(hit.normal.y) > 0.01f || (dir > 0 && hit.normal.x > 0.01f || dir < 0 && hit.normal.x < 0.01f))
                    {
                        continue;
                    }
                    else
                        return true;
                }
            }

            return false;
        }
        #endregion

        private void OnCollisionEnter2D(Collision2D other)
        {
            bool tileIsAbove = other.transform.position.y - (other.collider.bounds.size.y / 2) > headPos.position.y;
            if (other.gameObject.IsInLayerMask(tileLayer) && tileIsAbove && IsGrounded)
            {
                // even though the project supports a data oriented event system, this is such a specfic call that it doesn't need a data event
                OnPlayerCrushed?.Invoke();
            }
        }
    }

}