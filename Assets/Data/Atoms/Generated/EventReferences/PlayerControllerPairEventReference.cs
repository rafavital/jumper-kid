using System;
using Player;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Event Reference of type `PlayerControllerPair`. Inherits from `AtomEventReference&lt;PlayerControllerPair, PlayerControllerVariable, PlayerControllerPairEvent, PlayerControllerVariableInstancer, PlayerControllerPairEventInstancer&gt;`.
    /// </summary>
    [Serializable]
    public sealed class PlayerControllerPairEventReference : AtomEventReference<
        PlayerControllerPair,
        PlayerControllerVariable,
        PlayerControllerPairEvent,
        PlayerControllerVariableInstancer,
        PlayerControllerPairEventInstancer>, IGetEvent 
    { }
}
