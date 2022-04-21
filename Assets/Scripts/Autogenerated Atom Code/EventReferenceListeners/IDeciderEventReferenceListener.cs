using UnityEngine;
using LDJ50;

namespace UnityAtoms.LDJ50Atoms
{
    /// <summary>
    /// Event Reference Listener of type `IDecider`. Inherits from `AtomEventReferenceListener&lt;IDecider, IDeciderEvent, IDeciderEventReference, IDeciderUnityEvent&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-orange")]
    [AddComponentMenu("Unity Atoms/Listeners/IDecider Event Reference Listener")]
    public sealed class IDeciderEventReferenceListener : AtomEventReferenceListener<
        IDecider,
        IDeciderEvent,
        IDeciderEventReference,
        IDeciderUnityEvent>
    { }
}
