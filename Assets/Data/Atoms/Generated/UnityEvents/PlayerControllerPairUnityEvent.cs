using System;
using UnityEngine.Events;
using Player;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// None generic Unity Event of type `PlayerControllerPair`. Inherits from `UnityEvent&lt;PlayerControllerPair&gt;`.
    /// </summary>
    [Serializable]
    public sealed class PlayerControllerPairUnityEvent : UnityEvent<PlayerControllerPair> { }
}
