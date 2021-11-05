using UnityEngine;
using UnityAtoms.BaseAtoms;
using Player;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Variable Instancer of type `Player.PlayerController`. Inherits from `AtomVariableInstancer&lt;PlayerControllerVariable, PlayerControllerPair, Player.PlayerController, PlayerControllerEvent, PlayerControllerPairEvent, PlayerControllerPlayerControllerFunction&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-hotpink")]
    [AddComponentMenu("Unity Atoms/Variable Instancers/PlayerController Variable Instancer")]
    public class PlayerControllerVariableInstancer : AtomVariableInstancer<
        PlayerControllerVariable,
        PlayerControllerPair,
        Player.PlayerController,
        PlayerControllerEvent,
        PlayerControllerPairEvent,
        PlayerControllerPlayerControllerFunction>
    { }
}
