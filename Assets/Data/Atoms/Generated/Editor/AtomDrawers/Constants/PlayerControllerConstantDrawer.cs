#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityAtoms.Editor;

namespace UnityAtoms.BaseAtoms.Editor
{
    /// <summary>
    /// Constant property drawer of type `Player.PlayerController`. Inherits from `AtomDrawer&lt;PlayerControllerConstant&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomPropertyDrawer(typeof(PlayerControllerConstant))]
    public class PlayerControllerConstantDrawer : VariableDrawer<PlayerControllerConstant> { }
}
#endif
