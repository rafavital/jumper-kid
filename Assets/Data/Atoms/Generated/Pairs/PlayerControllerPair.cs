using System;
using UnityEngine;
using Player;
namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// IPair of type `&lt;Player.PlayerController&gt;`. Inherits from `IPair&lt;Player.PlayerController&gt;`.
    /// </summary>
    [Serializable]
    public struct PlayerControllerPair : IPair<Player.PlayerController>
    {
        public Player.PlayerController Item1 { get => _item1; set => _item1 = value; }
        public Player.PlayerController Item2 { get => _item2; set => _item2 = value; }

        [SerializeField]
        private Player.PlayerController _item1;
        [SerializeField]
        private Player.PlayerController _item2;

        public void Deconstruct(out Player.PlayerController item1, out Player.PlayerController item2) { item1 = Item1; item2 = Item2; }
    }
}