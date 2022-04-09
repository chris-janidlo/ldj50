using UnityEditor;
using UnityAtoms.Editor;
using LDJ50.CoreRules;

namespace UnityAtoms.LDJ50Atoms.Editor
{
    /// <summary>
    /// Variable Inspector of type `GameState`. Inherits from `AtomVariableEditor`
    /// </summary>
    [CustomEditor(typeof(GameStateVariable))]
    public sealed class GameStateVariableEditor : AtomVariableEditor<GameState, GameStatePair> { }
}
