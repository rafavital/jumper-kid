#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityEngine.UIElements;
using UnityAtoms.Editor;
using Player;

namespace UnityAtoms.BaseAtoms.Editor
{
    /// <summary>
    /// Event property drawer of type `Player.PlayerController`. Inherits from `AtomEventEditor&lt;Player.PlayerController, PlayerControllerEvent&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomEditor(typeof(PlayerControllerEvent))]
    public sealed class PlayerControllerEventEditor : AtomEventEditor<Player.PlayerController, PlayerControllerEvent> { }
}
#endif
