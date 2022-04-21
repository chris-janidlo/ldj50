using System;
using UnityAtoms.BaseAtoms;
using LDJ50;

namespace UnityAtoms.LDJ50Atoms
{
    /// <summary>
    /// Reference of type `IDecider`. Inherits from `EquatableAtomReference&lt;IDecider, IDeciderPair, IDeciderConstant, IDeciderVariable, IDeciderEvent, IDeciderPairEvent, IDeciderIDeciderFunction, IDeciderVariableInstancer, AtomCollection, AtomList&gt;`.
    /// </summary>
    [Serializable]
    public sealed class IDeciderReference : EquatableAtomReference<
        IDecider,
        IDeciderPair,
        IDeciderConstant,
        IDeciderVariable,
        IDeciderEvent,
        IDeciderPairEvent,
        IDeciderIDeciderFunction,
        IDeciderVariableInstancer>, IEquatable<IDeciderReference>
    {
        public IDeciderReference() : base() { }
        public IDeciderReference(IDecider value) : base(value) { }
        public bool Equals(IDeciderReference other) { return base.Equals(other); }
    }
}
