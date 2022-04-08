using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using LDJ50.CoreRules;

namespace LDJ50
{
    public abstract class IDecider : ScriptableObject
    {
        public abstract UniTask<GameState> DecideMove (GameState currentState, CancellationToken token);
    }
}
