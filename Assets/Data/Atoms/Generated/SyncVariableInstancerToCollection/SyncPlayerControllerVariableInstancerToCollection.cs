using UnityEngine;
using UnityAtoms.BaseAtoms;
using Player;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Adds Variable Instancer's Variable of type Player.PlayerController to a Collection or List on OnEnable and removes it on OnDestroy. 
    /// </summary>
    [AddComponentMenu("Unity Atoms/Sync Variable Instancer to Collection/Sync PlayerController Variable Instancer to Collection")]
    [EditorIcon("atom-icon-delicate")]
    public class SyncPlayerControllerVariableInstancerToCollection : SyncVariableInstancerToCollection<Player.PlayerController, PlayerControllerVariable, PlayerControllerVariableInstancer> { }
}
