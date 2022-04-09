using UnityEngine;
using LDJ50.CoreRules;

namespace UnityAtoms.LDJ50Atoms
{
    /// <summary>
    /// Event Instancer of type `GameStatePair`. Inherits from `AtomEventInstancer&lt;GameStatePair, GameStatePairEvent&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-sign-blue")]
    [AddComponentMenu("Unity Atoms/Event Instancers/GameStatePair Event Instancer")]
    public class GameStatePairEventInstancer : AtomEventInstancer<GameStatePair, GameStatePairEvent> { }
}
