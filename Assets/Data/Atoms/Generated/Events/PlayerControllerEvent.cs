using UnityEngine;
using Player;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Event of type `Player.PlayerController`. Inherits from `AtomEvent&lt;Player.PlayerController&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-cherry")]
    [CreateAssetMenu(menuName = "Unity Atoms/Events/PlayerController", fileName = "PlayerControllerEvent")]
    public sealed class PlayerControllerEvent : AtomEvent<Player.PlayerController>
    {
    }
}
