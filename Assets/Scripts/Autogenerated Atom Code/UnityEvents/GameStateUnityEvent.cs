using System;
using UnityEngine.Events;
using LDJ50.CoreRules;

namespace UnityAtoms.LDJ50Atoms
{
    /// <summary>
    /// None generic Unity Event of type `GameState`. Inherits from `UnityEvent&lt;GameState&gt;`.
    /// </summary>
    [Serializable]
    public sealed class GameStateUnityEvent : UnityEvent<GameState> { }
}
