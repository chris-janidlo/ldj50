using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LDJ50
{
    public abstract class IInitializableSO : ScriptableObject
    {
        public abstract void Initialize ();
    }
}
