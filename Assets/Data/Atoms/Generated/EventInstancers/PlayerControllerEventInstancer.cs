using UnityEngine;
using Player;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Event Instancer of type `Player.PlayerController`. Inherits from `AtomEventInstancer&lt;Player.PlayerController, PlayerControllerEvent&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-sign-blue")]
    [AddComponentMenu("Unity Atoms/Event Instancers/PlayerController Event Instancer")]
    public class PlayerControllerEventInstancer : AtomEventInstancer<Player.PlayerController, PlayerControllerEvent> { }
}
