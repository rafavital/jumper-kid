using UnityEditor;
using UnityAtoms.Editor;
using Player;

namespace UnityAtoms.BaseAtoms.Editor
{
    /// <summary>
    /// Variable Inspector of type `Player.PlayerController`. Inherits from `AtomVariableEditor`
    /// </summary>
    [CustomEditor(typeof(PlayerControllerVariable))]
    public sealed class PlayerControllerVariableEditor : AtomVariableEditor<Player.PlayerController, PlayerControllerPair> { }
}
