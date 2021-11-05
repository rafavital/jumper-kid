using System.Collections;
using UnityEngine;
using UnityAtoms.BaseAtoms;

namespace Player
{
    public enum PlayerStates
    {
        IDLE,
        RUNNING,
        AIRBORNE,
        HURT,
        DEAD
    }

    [SelectionBaseAttribute]
    [DisallowMultipleComponent]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float knockback = 25f;
        [SerializeField] private float stunDuration;
        [Header("Data")]
        [SerializeField] private LevelInfo gameInfo;
        [SerializeField] private VoidBaseEventReference onGameOverEvent;
        [SerializeField] private BoolEventReference onPauseGame;

        //TODO: improve this by making a Finite State Machine for the player
        private PlayerStates currentState;
        private PlayerMovement playerMovement;
        private PlayerAnimationController animationController;
        private PlayerInput playerInput;
        private PlayerVFX playerVFX;
        private HealthController healthController;

        private Coroutine stunCoroutine;


        #region UNITY CALLS
        private void OnEnable()
        {
            if (gameInfo.currentPlayer != this)
                Destroy(this);


            PlayerInput.OnChangeHorizontalAxis += HandlePlayerFlip;
            PlayerMovement.OnPlayerCrushed += HandleDeath;
            PlayerMovement.OnStartFalling += HandleStartFalling;
        }
        private void OnDisable()
        {
            PlayerInput.OnChangeHorizontalAxis -= HandlePlayerFlip;
            PlayerMovement.OnPlayerCrushed -= HandleDeath;
            PlayerMovement.OnStartFalling -= HandleStartFalling;
        }

        private void Awake()
        {
            if (gameInfo.currentPlayer == null)
                gameInfo.currentPlayer = this;

            playerInput = GetComponent<PlayerInput>();
            playerMovement = GetComponent<PlayerMovement>();
            animationController = GetComponent<PlayerAnimationController>();
            playerVFX = GetComponent<PlayerVFX>();
            healthController = GetComponent<HealthController>();


            currentState = PlayerStates.IDLE;
        }

        private void Update()
        {
            switch (currentState)
            {
                case PlayerStates.IDLE:
                    if (playerInput.HorizontalAxis != 0)
                        ChangeState(PlayerStates.RUNNING);
                    else if (playerInput.JumpDown)
                        Jump();

                    break;
                case PlayerStates.RUNNING:
                    RunningBehaviour();

                    break;
                case PlayerStates.AIRBORNE:
                    if (playerMovement.GetVelocity().y <= 0 && playerMovement.IsGrounded)
                    {
                        if (playerInput.HorizontalAxis == 0)
                            ChangeState(PlayerStates.IDLE);
                        else
                            ChangeState(PlayerStates.RUNNING);
                    }
                    playerMovement.ApplyGravity(playerInput.JumpHeld);

                    break;
            }

        }

        private void FixedUpdate()
        {
            if (IsInState(PlayerStates.RUNNING) || IsInState(PlayerStates.AIRBORNE))
            {
                playerMovement.Move(playerInput.HorizontalAxis, playerInput.JumpHeld);
            }
        }

        #endregion

        #region PUBLIC METHODS
        ///<summary>
        /// Method that deals with the player's hurtbox getting hit
        ///</summary>
        public void GetHurt(Hitbox hitbox)
        {
            var movingDir = Mathf.Sign(playerMovement.GetVelocity().x);
            ChangeState(PlayerStates.HURT);
            playerMovement.ZeroVelocity();

            Vector2 knockbackDir = new Vector2(-movingDir, 1.25f); // makes the player knockback backwards and upwards
            playerMovement.AddForce(knockbackDir * knockback, ForceMode2D.Impulse);

            if (stunCoroutine != null)
                StopCoroutine(stunCoroutine);
            stunCoroutine = StartCoroutine(StunTimer());
        }

        ///<summary>
        /// Method that handles the player's death
        ///</summary>
        public void HandleDeath()
        {
            onPauseGame.Event.Raise(true);
            ChangeState(PlayerStates.DEAD);
        }
        #endregion

        #region PRIVATE METHODS
        private void RunningBehaviour()
        {
            if (playerInput.JumpDown && playerMovement.IsGrounded)
            {
                Jump();
            }
            else if (playerInput.HorizontalAxis == 0)
            {
                ChangeState(PlayerStates.IDLE);
            }
        }

        /// <summary> 
        ///Changes the current state to the new given state
        /// </summary>
        private void ChangeState(PlayerStates newState)
        {
            if (currentState == newState)
                return;

            ExitState();
            currentState = newState;
            EnterState();
        }

        // this helps to concentrate all checks of the player state in one place, making it easier to maintain later
        private bool IsInState(PlayerStates state) => currentState == state;

        /// <summary> Deals with the initialization of the given state </summary>
        private void EnterState()
        {
            switch (currentState)
            {
                case PlayerStates.IDLE:
                    playerMovement.ZeroVelocity();
                    animationController.PlayAnimation(PlayerAnimationController.animIdle);

                    break;
                case PlayerStates.AIRBORNE:
                    animationController.PlayAnimation(PlayerAnimationController.animJump);
                    playerMovement.Jump();

                    break;
                case PlayerStates.RUNNING:
                    animationController.PlayAnimation(PlayerAnimationController.animRun);

                    break;
                case PlayerStates.DEAD:
                    animationController.PlayAnimation(PlayerAnimationController.animDeath)
                                        .OnComplete(() => onGameOverEvent.Event.Raise());

                    break;
            }
        }

        /// <summary> Deals with the cleanup of the current state </summary>
        private void ExitState()
        {
        }

        private void HandlePlayerFlip(float dir)
        {
            if (dir == 0 || IsInState(PlayerStates.DEAD))
                return;

            playerVFX.FlipSprite(dir);
        }

        private void HandleStartFalling()
        {
            if (IsInState(PlayerStates.AIRBORNE))
                animationController.PlayAnimationTransition(new AnimationObject(PlayerAnimationController.animJumpTransition), new AnimationObject(PlayerAnimationController.animFalling));
        }

        private void Jump()
        {
            animationController.PlayAnimationTransition(new AnimationObject(PlayerAnimationController.animBeginJump),
                                                        new AnimationObject(PlayerAnimationController.animJump));
            ChangeState(PlayerStates.AIRBORNE);
        }

        private IEnumerator StunTimer()
        {
            yield return new WaitForSeconds(stunDuration);
            ChangeState(PlayerStates.IDLE);
        }
        #endregion


    }

}