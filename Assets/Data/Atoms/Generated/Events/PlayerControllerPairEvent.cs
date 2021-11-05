using UnityEngine;
using Player;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Event of type `PlayerControllerPair`. Inherits from `AtomEvent&lt;PlayerControllerPair&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-cherry")]
    [CreateAssetMenu(menuName = "Unity Atoms/Events/PlayerControllerPair", fileName = "PlayerControllerPairEvent")]
    public sealed class PlayerControllerPairEvent : AtomEvent<PlayerControllerPair>
    {
    }
}
