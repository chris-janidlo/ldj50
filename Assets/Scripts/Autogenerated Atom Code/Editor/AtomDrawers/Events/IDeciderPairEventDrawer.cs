#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityAtoms.Editor;

namespace UnityAtoms.LDJ50Atoms.Editor
{
    /// <summary>
    /// Event property drawer of type `IDeciderPair`. Inherits from `AtomDrawer&lt;IDeciderPairEvent&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomPropertyDrawer(typeof(IDeciderPairEvent))]
    public class IDeciderPairEventDrawer : AtomDrawer<IDeciderPairEvent> { }
}
#endif
