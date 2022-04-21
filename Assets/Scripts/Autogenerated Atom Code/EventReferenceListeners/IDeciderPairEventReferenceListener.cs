using UnityEngine;
using LDJ50;

namespace UnityAtoms.LDJ50Atoms
{
    /// <summary>
    /// Event Reference Listener of type `IDeciderPair`. Inherits from `AtomEventReferenceListener&lt;IDeciderPair, IDeciderPairEvent, IDeciderPairEventReference, IDeciderPairUnityEvent&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-orange")]
    [AddComponentMenu("Unity Atoms/Listeners/IDeciderPair Event Reference Listener")]
    public sealed class IDeciderPairEventReferenceListener : AtomEventReferenceListener<
        IDeciderPair,
        IDeciderPairEvent,
        IDeciderPairEventReference,
        IDeciderPairUnityEvent>
    { }
}
