using UnityEngine;
using LDJ50;

namespace UnityAtoms.LDJ50Atoms
{
    /// <summary>
    /// Variable of type `IDecider`. Inherits from `EquatableAtomVariable&lt;IDecider, IDeciderPair, IDeciderEvent, IDeciderPairEvent, IDeciderIDeciderFunction&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-lush")]
    [CreateAssetMenu(menuName = "Unity Atoms/Variables/IDecider", fileName = "IDeciderVariable")]
    public sealed class IDeciderVariable : EquatableAtomVariable<IDecider, IDeciderPair, IDeciderEvent, IDeciderPairEvent, IDeciderIDeciderFunction> { }
}
