using UnityEngine;
using LDJ50;

namespace UnityAtoms.LDJ50Atoms
{
    /// <summary>
    /// Event of type `IDecider`. Inherits from `AtomEvent&lt;IDecider&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-cherry")]
    [CreateAssetMenu(menuName = "Unity Atoms/Events/IDecider", fileName = "IDeciderEvent")]
    public sealed class IDeciderEvent : AtomEvent<IDecider> { }
}
