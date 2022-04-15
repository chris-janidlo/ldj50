using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using UnityAtoms.LDJ50Atoms;
using LDJ50.CoreRules;

namespace LDJ50
{
    [CreateAssetMenu(menuName = "LDJ50/Deciders/Player", fileName = "newPlayerDecider.asset")]
    public class PlayerDecider : IDecider
    {
        public GameStateEvent PlayerDecisionNeeded;

        UniTaskCompletionSource<GameState> currentTcs;

        // TODO: use cancellation token
        public override UniTask<GameState> DecideMove (GameState currentState, CancellationToken token)
        {
            PlayerDecisionNeeded.Raise(currentState);

            currentTcs = new UniTaskCompletionSource<GameState>();
            return currentTcs.Task;
        }

        public void PlayerDecisionMade (GameState decision)
        {
            currentTcs.TrySetResult(decision);
        }
    }
}
