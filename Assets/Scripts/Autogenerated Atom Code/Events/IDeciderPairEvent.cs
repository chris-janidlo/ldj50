using UnityEngine;
using LDJ50;

namespace UnityAtoms.LDJ50Atoms
{
    /// <summary>
    /// Event of type `IDeciderPair`. Inherits from `AtomEvent&lt;IDeciderPair&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-cherry")]
    [CreateAssetMenu(menuName = "Unity Atoms/Events/IDeciderPair", fileName = "IDeciderPairEvent")]
    public sealed class IDeciderPairEvent : AtomEvent<IDeciderPair> { }
}
