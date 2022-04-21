using System;
using LDJ50;

namespace UnityAtoms.LDJ50Atoms
{
    /// <summary>
    /// Event Reference of type `IDecider`. Inherits from `AtomEventReference&lt;IDecider, IDeciderVariable, IDeciderEvent, IDeciderVariableInstancer, IDeciderEventInstancer&gt;`.
    /// </summary>
    [Serializable]
    public sealed class IDeciderEventReference : AtomEventReference<
        IDecider,
        IDeciderVariable,
        IDeciderEvent,
        IDeciderVariableInstancer,
        IDeciderEventInstancer>, IGetEvent 
    { }
}
