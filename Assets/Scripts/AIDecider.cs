using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LDJ50
{
    public abstract class AIDecider : IDecider
    {
        public virtual float Progress { get; protected set; }
    }
}
