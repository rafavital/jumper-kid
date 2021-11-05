using UnityEngine;

namespace Player
{
    [DisallowMultipleComponent]
    public class PlayerAnimationController : BaseAnimationManager
    {
        // this avoids having to hard code animation names throughout the codebase
        public static readonly string animJump = "PlayerJump";
        public static readonly string animIdle = "PlayerIdle";
        public static readonly string animRun = "PlayerRun";
        public static readonly string animHurt = "PlayerHurt";
        public static readonly string animDeath = "PlayerDeath";
        public static readonly string animBeginJump = "PlayerBeginJump";
        public static readonly string animJumpTransition = "PlayerJumpTransition";
        public static readonly string animFalling = "PlayerFalling";
    }
}
