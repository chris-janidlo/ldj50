using System.Linq;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using LDJ50.CoreRules;
using crass;

namespace LDJ50
{
    [CreateAssetMenu(menuName = "LDJ50/Deciders/Random", fileName = "newRandomDecider.asset")]
    public class RandomDecider : IDecider
    {
        public override bool Deciding => false;

        public override UniTask<GameState> DecideMove (GameState currentState, CancellationToken token)
        {
            var movePool = currentState.LegalFutureStates().ToList();
            return UniTask.FromResult(movePool.PickRandom()).AttachExternalCancellation(token);
        }
    }
}
