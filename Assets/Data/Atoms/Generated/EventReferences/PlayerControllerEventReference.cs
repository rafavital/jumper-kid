using System;
using Player;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Event Reference of type `Player.PlayerController`. Inherits from `AtomEventReference&lt;Player.PlayerController, PlayerControllerVariable, PlayerControllerEvent, PlayerControllerVariableInstancer, PlayerControllerEventInstancer&gt;`.
    /// </summary>
    [Serializable]
    public sealed class PlayerControllerEventReference : AtomEventReference<
        Player.PlayerController,
        PlayerControllerVariable,
        PlayerControllerEvent,
        PlayerControllerVariableInstancer,
        PlayerControllerEventInstancer>, IGetEvent 
    { }
}
