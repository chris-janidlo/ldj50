#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityAtoms.Editor;

namespace UnityAtoms.LDJ50Atoms.Editor
{
    /// <summary>
    /// Value List property drawer of type `IDecider`. Inherits from `AtomDrawer&lt;IDeciderValueList&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomPropertyDrawer(typeof(IDeciderValueList))]
    public class IDeciderValueListDrawer : AtomDrawer<IDeciderValueList> { }
}
#endif
