using System;
using UnityAtoms.BaseAtoms;
using LDJ50.CoreRules;

namespace UnityAtoms.LDJ50Atoms
{
    /// <summary>
    /// Reference of type `GameState`. Inherits from `EquatableAtomReference&lt;GameState, GameStatePair, GameStateConstant, GameStateVariable, GameStateEvent, GameStatePairEvent, GameStateGameStateFunction, GameStateVariableInstancer, AtomCollection, AtomList&gt;`.
    /// </summary>
    [Serializable]
    public sealed class GameStateReference : EquatableAtomReference<
        GameState,
        GameStatePair,
        GameStateConstant,
        GameStateVariable,
        GameStateEvent,
        GameStatePairEvent,
        GameStateGameStateFunction,
        GameStateVariableInstancer>, IEquatable<GameStateReference>
    {
        public GameStateReference() : base() { }
        public GameStateReference(GameState value) : base(value) { }
        public bool Equals(GameStateReference other) { return base.Equals(other); }
    }
}
