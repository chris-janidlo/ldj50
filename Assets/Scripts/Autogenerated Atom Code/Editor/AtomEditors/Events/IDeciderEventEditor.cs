#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityEngine.UIElements;
using UnityAtoms.Editor;
using LDJ50;

namespace UnityAtoms.LDJ50Atoms.Editor
{
    /// <summary>
    /// Event property drawer of type `IDecider`. Inherits from `AtomEventEditor&lt;IDecider, IDeciderEvent&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomEditor(typeof(IDeciderEvent))]
    public sealed class IDeciderEventEditor : AtomEventEditor<IDecider, IDeciderEvent> { }
}
#endif
