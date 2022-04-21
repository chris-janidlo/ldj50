using UnityEngine;
using UnityAtoms.BaseAtoms;
using LDJ50;

namespace UnityAtoms.LDJ50Atoms
{
    /// <summary>
    /// Variable Instancer of type `IDecider`. Inherits from `AtomVariableInstancer&lt;IDeciderVariable, IDeciderPair, IDecider, IDeciderEvent, IDeciderPairEvent, IDeciderIDeciderFunction&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-hotpink")]
    [AddComponentMenu("Unity Atoms/Variable Instancers/IDecider Variable Instancer")]
    public class IDeciderVariableInstancer : AtomVariableInstancer<
        IDeciderVariable,
        IDeciderPair,
        IDecider,
        IDeciderEvent,
        IDeciderPairEvent,
        IDeciderIDeciderFunction>
    { }
}
