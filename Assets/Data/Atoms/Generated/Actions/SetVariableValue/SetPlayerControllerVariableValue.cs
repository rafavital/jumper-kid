using UnityEngine;
using UnityAtoms.BaseAtoms;
using Player;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Set variable value Action of type `Player.PlayerController`. Inherits from `SetVariableValue&lt;Player.PlayerController, PlayerControllerPair, PlayerControllerVariable, PlayerControllerConstant, PlayerControllerReference, PlayerControllerEvent, PlayerControllerPairEvent, PlayerControllerVariableInstancer&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-purple")]
    [CreateAssetMenu(menuName = "Unity Atoms/Actions/Set Variable Value/PlayerController", fileName = "SetPlayerControllerVariableValue")]
    public sealed class SetPlayerControllerVariableValue : SetVariableValue<
        Player.PlayerController,
        PlayerControllerPair,
        PlayerControllerVariable,
        PlayerControllerConstant,
        PlayerControllerReference,
        PlayerControllerEvent,
        PlayerControllerPairEvent,
        PlayerControllerPlayerControllerFunction,
        PlayerControllerVariableInstancer>
    { }
}
