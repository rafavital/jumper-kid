#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityAtoms.Editor;

namespace UnityAtoms.BaseAtoms.Editor
{
    /// <summary>
    /// Variable property drawer of type `Player.PlayerController`. Inherits from `AtomDrawer&lt;PlayerControllerVariable&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomPropertyDrawer(typeof(PlayerControllerVariable))]
    public class PlayerControllerVariableDrawer : VariableDrawer<PlayerControllerVariable> { }
}
#endif
