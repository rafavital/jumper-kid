#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityEngine.UIElements;
using UnityAtoms.Editor;
using Player;

namespace UnityAtoms.BaseAtoms.Editor
{
    /// <summary>
    /// Event property drawer of type `PlayerControllerPair`. Inherits from `AtomEventEditor&lt;PlayerControllerPair, PlayerControllerPairEvent&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomEditor(typeof(PlayerControllerPairEvent))]
    public sealed class PlayerControllerPairEventEditor : AtomEventEditor<PlayerControllerPair, PlayerControllerPairEvent> { }
}
#endif
