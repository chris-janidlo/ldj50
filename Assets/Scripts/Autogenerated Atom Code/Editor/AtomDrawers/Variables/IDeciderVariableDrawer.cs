#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityAtoms.Editor;

namespace UnityAtoms.LDJ50Atoms.Editor
{
    /// <summary>
    /// Variable property drawer of type `IDecider`. Inherits from `AtomDrawer&lt;IDeciderVariable&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomPropertyDrawer(typeof(IDeciderVariable))]
    public class IDeciderVariableDrawer : VariableDrawer<IDeciderVariable> { }
}
#endif
