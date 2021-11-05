using System;
using UnityEngine.Events;
using Player;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// None generic Unity Event of type `Player.PlayerController`. Inherits from `UnityEvent&lt;Player.PlayerController&gt;`.
    /// </summary>
    [Serializable]
    public sealed class PlayerControllerUnityEvent : UnityEvent<Player.PlayerController> { }
}
