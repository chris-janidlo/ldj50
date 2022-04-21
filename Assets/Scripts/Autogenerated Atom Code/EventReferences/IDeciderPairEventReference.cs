using System;
using LDJ50;

namespace UnityAtoms.LDJ50Atoms
{
    /// <summary>
    /// Event Reference of type `IDeciderPair`. Inherits from `AtomEventReference&lt;IDeciderPair, IDeciderVariable, IDeciderPairEvent, IDeciderVariableInstancer, IDeciderPairEventInstancer&gt;`.
    /// </summary>
    [Serializable]
    public sealed class IDeciderPairEventReference : AtomEventReference<
        IDeciderPair,
        IDeciderVariable,
        IDeciderPairEvent,
        IDeciderVariableInstancer,
        IDeciderPairEventInstancer>, IGetEvent 
    { }
}
