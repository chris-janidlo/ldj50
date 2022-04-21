#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityEngine.UIElements;
using UnityAtoms.Editor;
using LDJ50;

namespace UnityAtoms.LDJ50Atoms.Editor
{
    /// <summary>
    /// Event property drawer of type `IDeciderPair`. Inherits from `AtomEventEditor&lt;IDeciderPair, IDeciderPairEvent&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomEditor(typeof(IDeciderPairEvent))]
    public sealed class IDeciderPairEventEditor : AtomEventEditor<IDeciderPair, IDeciderPairEvent> { }
}
#endif
