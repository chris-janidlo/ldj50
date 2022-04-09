using UnityEngine;
using LDJ50.CoreRules;

namespace UnityAtoms.LDJ50Atoms
{
    /// <summary>
    /// Event of type `GameStatePair`. Inherits from `AtomEvent&lt;GameStatePair&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-cherry")]
    [CreateAssetMenu(menuName = "Unity Atoms/Events/GameStatePair", fileName = "GameStatePairEvent")]
    public sealed class GameStatePairEvent : AtomEvent<GameStatePair> { }
}
