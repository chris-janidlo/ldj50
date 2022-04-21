using UnityEditor;
using UnityAtoms.Editor;
using LDJ50;

namespace UnityAtoms.LDJ50Atoms.Editor
{
    /// <summary>
    /// Variable Inspector of type `IDecider`. Inherits from `AtomVariableEditor`
    /// </summary>
    [CustomEditor(typeof(IDeciderVariable))]
    public sealed class IDeciderVariableEditor : AtomVariableEditor<IDecider, IDeciderPair> { }
}
