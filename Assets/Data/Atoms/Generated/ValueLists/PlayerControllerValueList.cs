using UnityEngine;
using Player;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Value List of type `Player.PlayerController`. Inherits from `AtomValueList&lt;Player.PlayerController, PlayerControllerEvent&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-piglet")]
    [CreateAssetMenu(menuName = "Unity Atoms/Value Lists/PlayerController", fileName = "PlayerControllerValueList")]
    public sealed class PlayerControllerValueList : AtomValueList<Player.PlayerController, PlayerControllerEvent> { }
}
