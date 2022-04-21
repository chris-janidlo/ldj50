using UnityEngine;
using LDJ50;

namespace UnityAtoms.LDJ50Atoms
{
    /// <summary>
    /// Event Instancer of type `IDecider`. Inherits from `AtomEventInstancer&lt;IDecider, IDeciderEvent&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-sign-blue")]
    [AddComponentMenu("Unity Atoms/Event Instancers/IDecider Event Instancer")]
    public class IDeciderEventInstancer : AtomEventInstancer<IDecider, IDeciderEvent> { }
}
