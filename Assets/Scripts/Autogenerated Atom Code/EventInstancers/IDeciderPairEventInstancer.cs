using UnityEngine;
using LDJ50;

namespace UnityAtoms.LDJ50Atoms
{
    /// <summary>
    /// Event Instancer of type `IDeciderPair`. Inherits from `AtomEventInstancer&lt;IDeciderPair, IDeciderPairEvent&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-sign-blue")]
    [AddComponentMenu("Unity Atoms/Event Instancers/IDeciderPair Event Instancer")]
    public class IDeciderPairEventInstancer : AtomEventInstancer<IDeciderPair, IDeciderPairEvent> { }
}
