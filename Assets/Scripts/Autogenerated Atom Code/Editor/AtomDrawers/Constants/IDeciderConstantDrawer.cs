#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityAtoms.Editor;

namespace UnityAtoms.LDJ50Atoms.Editor
{
    /// <summary>
    /// Constant property drawer of type `IDecider`. Inherits from `AtomDrawer&lt;IDeciderConstant&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomPropertyDrawer(typeof(IDeciderConstant))]
    public class IDeciderConstantDrawer : VariableDrawer<IDeciderConstant> { }
}
#endif
