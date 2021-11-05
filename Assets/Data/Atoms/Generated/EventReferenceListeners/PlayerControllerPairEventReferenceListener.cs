using UnityEngine;
using Player;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Event Reference Listener of type `PlayerControllerPair`. Inherits from `AtomEventReferenceListener&lt;PlayerControllerPair, PlayerControllerPairEvent, PlayerControllerPairEventReference, PlayerControllerPairUnityEvent&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-orange")]
    [AddComponentMenu("Unity Atoms/Listeners/PlayerControllerPair Event Reference Listener")]
    public sealed class PlayerControllerPairEventReferenceListener : AtomEventReferenceListener<
        PlayerControllerPair,
        PlayerControllerPairEvent,
        PlayerControllerPairEventReference,
        PlayerControllerPairUnityEvent>
    { }
}
