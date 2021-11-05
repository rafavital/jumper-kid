#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityAtoms.Editor;

namespace UnityAtoms.BaseAtoms.Editor
{
    /// <summary>
    /// Value List property drawer of type `Player.PlayerController`. Inherits from `AtomDrawer&lt;PlayerControllerValueList&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomPropertyDrawer(typeof(PlayerControllerValueList))]
    public class PlayerControllerValueListDrawer : AtomDrawer<PlayerControllerValueList> { }
}
#endif
