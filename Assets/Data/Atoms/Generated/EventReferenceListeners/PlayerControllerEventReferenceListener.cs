using UnityEngine;
using Player;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Event Reference Listener of type `Player.PlayerController`. Inherits from `AtomEventReferenceListener&lt;Player.PlayerController, PlayerControllerEvent, PlayerControllerEventReference, PlayerControllerUnityEvent&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-orange")]
    [AddComponentMenu("Unity Atoms/Listeners/PlayerController Event Reference Listener")]
    public sealed class PlayerControllerEventReferenceListener : AtomEventReferenceListener<
        Player.PlayerController,
        PlayerControllerEvent,
        PlayerControllerEventReference,
        PlayerControllerUnityEvent>
    { }
}
