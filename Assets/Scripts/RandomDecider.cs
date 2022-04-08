using System.Linq;
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
        public override UniTask<GameState> DecideMove (GameState currentState)
        {
            var movePool = currentState.LegalFutureStates().ToList();
            return UniTask.FromResult(movePool.PickRandom());
        }
    }
}
