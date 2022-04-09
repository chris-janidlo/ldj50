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
        public GameStateEvent PlayerDecisionNeeded, PlayerDecisionMade;

        // TODO: use cancellation token
        public override UniTask<GameState> DecideMove (GameState currentState, CancellationToken token)
        {
            PlayerDecisionNeeded.Raise(currentState);

            UniTaskCompletionSource<GameState> tcs = new UniTaskCompletionSource<GameState>();

            void decisionCallback (GameState decision)
            {
                tcs.TrySetResult(decision);
                PlayerDecisionMade.Unregister(decisionCallback);
            }
            PlayerDecisionMade.Register(decisionCallback);

            return tcs.Task;
        }
    }
}
