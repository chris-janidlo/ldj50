using UnityEngine;
using UnityAtoms.BaseAtoms;
using LDJ50;

namespace UnityAtoms.LDJ50Atoms
{
    /// <summary>
    /// Adds Variable Instancer's Variable of type IDecider to a Collection or List on OnEnable and removes it on OnDestroy. 
    /// </summary>
    [AddComponentMenu("Unity Atoms/Sync Variable Instancer to Collection/Sync IDecider Variable Instancer to Collection")]
    [EditorIcon("atom-icon-delicate")]
    public class SyncIDeciderVariableInstancerToCollection : SyncVariableInstancerToCollection<IDecider, IDeciderVariable, IDeciderVariableInstancer> { }
}
