using UnityEngine;
using Player;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Event Instancer of type `PlayerControllerPair`. Inherits from `AtomEventInstancer&lt;PlayerControllerPair, PlayerControllerPairEvent&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-sign-blue")]
    [AddComponentMenu("Unity Atoms/Event Instancers/PlayerControllerPair Event Instancer")]
    public class PlayerControllerPairEventInstancer : AtomEventInstancer<PlayerControllerPair, PlayerControllerPairEvent> { }
}
