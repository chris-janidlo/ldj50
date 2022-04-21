using System;
using UnityEngine.Events;
using LDJ50;

namespace UnityAtoms.LDJ50Atoms
{
    /// <summary>
    /// None generic Unity Event of type `IDecider`. Inherits from `UnityEvent&lt;IDecider&gt;`.
    /// </summary>
    [Serializable]
    public sealed class IDeciderUnityEvent : UnityEvent<IDecider> { }
}
