using UnityEngine;
using Player;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Constant of type `Player.PlayerController`. Inherits from `AtomBaseVariable&lt;Player.PlayerController&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-teal")]
    [CreateAssetMenu(menuName = "Unity Atoms/Constants/PlayerController", fileName = "PlayerControllerConstant")]
    public sealed class PlayerControllerConstant : AtomBaseVariable<Player.PlayerController> { }
}
