#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityAtoms.Editor;

namespace UnityAtoms.LDJ50Atoms.Editor
{
    /// <summary>
    /// Event property drawer of type `IDecider`. Inherits from `AtomDrawer&lt;IDeciderEvent&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomPropertyDrawer(typeof(IDeciderEvent))]
    public class IDeciderEventDrawer : AtomDrawer<IDeciderEvent> { }
}
#endif
