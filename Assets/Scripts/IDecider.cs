using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using LDJ50.CoreRules;

namespace LDJ50
{
    public abstract class IDecider : ScriptableObject, IEquatable<IDecider>
    {
        public virtual bool Deciding { get; protected set;  }

        public abstract UniTask<GameState> DecideMove (GameState currentState, CancellationToken token);

        public bool Equals (IDecider other)
        {
            return base.Equals(other);
        }
    }
}
