#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityEngine.UIElements;
using UnityAtoms.Editor;
using LDJ50.CoreRules;

namespace UnityAtoms.LDJ50Atoms.Editor
{
    /// <summary>
    /// Event property drawer of type `GameState`. Inherits from `AtomEventEditor&lt;GameState, GameStateEvent&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomEditor(typeof(GameStateEvent))]
    public sealed class GameStateEventEditor : AtomEventEditor<GameState, GameStateEvent> { }
}
#endif
