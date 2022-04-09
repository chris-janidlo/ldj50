using System;
using LDJ50.CoreRules;

namespace UnityAtoms.LDJ50Atoms
{
    /// <summary>
    /// Event Reference of type `GameState`. Inherits from `AtomEventReference&lt;GameState, GameStateVariable, GameStateEvent, GameStateVariableInstancer, GameStateEventInstancer&gt;`.
    /// </summary>
    [Serializable]
    public sealed class GameStateEventReference : AtomEventReference<
        GameState,
        GameStateVariable,
        GameStateEvent,
        GameStateVariableInstancer,
        GameStateEventInstancer>, IGetEvent 
    { }
}
