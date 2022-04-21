using UnityEngine;
using UnityAtoms.BaseAtoms;
using LDJ50;

namespace UnityAtoms.LDJ50Atoms
{
    /// <summary>
    /// Set variable value Action of type `IDecider`. Inherits from `SetVariableValue&lt;IDecider, IDeciderPair, IDeciderVariable, IDeciderConstant, IDeciderReference, IDeciderEvent, IDeciderPairEvent, IDeciderVariableInstancer&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-purple")]
    [CreateAssetMenu(menuName = "Unity Atoms/Actions/Set Variable Value/IDecider", fileName = "SetIDeciderVariableValue")]
    public sealed class SetIDeciderVariableValue : SetVariableValue<
        IDecider,
        IDeciderPair,
        IDeciderVariable,
        IDeciderConstant,
        IDeciderReference,
        IDeciderEvent,
        IDeciderPairEvent,
        IDeciderIDeciderFunction,
        IDeciderVariableInstancer>
    { }
}
