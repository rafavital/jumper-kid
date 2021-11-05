using UnityEngine;
using System;
using Player;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Variable of type `Player.PlayerController`. Inherits from `AtomVariable&lt;Player.PlayerController, PlayerControllerPair, PlayerControllerEvent, PlayerControllerPairEvent, PlayerControllerPlayerControllerFunction&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-lush")]
    [CreateAssetMenu(menuName = "Unity Atoms/Variables/PlayerController", fileName = "PlayerControllerVariable")]
    public sealed class PlayerControllerVariable : AtomVariable<Player.PlayerController, PlayerControllerPair, PlayerControllerEvent, PlayerControllerPairEvent, PlayerControllerPlayerControllerFunction>
    {
        protected override bool ValueEquals(Player.PlayerController other)
        {
            throw new NotImplementedException();
        }
    }
}
