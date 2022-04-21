using UnityEngine;
using LDJ50;

namespace UnityAtoms.LDJ50Atoms
{
    /// <summary>
    /// Value List of type `IDecider`. Inherits from `AtomValueList&lt;IDecider, IDeciderEvent&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-piglet")]
    [CreateAssetMenu(menuName = "Unity Atoms/Value Lists/IDecider", fileName = "IDeciderValueList")]
    public sealed class IDeciderValueList : AtomValueList<IDecider, IDeciderEvent> { }
}
