using System;
using UnityAtoms.BaseAtoms;
using Player;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Reference of type `Player.PlayerController`. Inherits from `AtomReference&lt;Player.PlayerController, PlayerControllerPair, PlayerControllerConstant, PlayerControllerVariable, PlayerControllerEvent, PlayerControllerPairEvent, PlayerControllerPlayerControllerFunction, PlayerControllerVariableInstancer, AtomCollection, AtomList&gt;`.
    /// </summary>
    [Serializable]
    public sealed class PlayerControllerReference : AtomReference<
        Player.PlayerController,
        PlayerControllerPair,
        PlayerControllerConstant,
        PlayerControllerVariable,
        PlayerControllerEvent,
        PlayerControllerPairEvent,
        PlayerControllerPlayerControllerFunction,
        PlayerControllerVariableInstancer>, IEquatable<PlayerControllerReference>
    {
        public PlayerControllerReference() : base() { }
        public PlayerControllerReference(Player.PlayerController value) : base(value) { }
        public bool Equals(PlayerControllerReference other) { return base.Equals(other); }
        protected override bool ValueEquals(Player.PlayerController other)
        {
            throw new NotImplementedException();
        }
    }
}
