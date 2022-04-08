using System.Threading;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Cysharp.Threading.Tasks;
using LDJ50.CoreRules;
using LDJ50.MCTS;

namespace LDJ50
{
    [CreateAssetMenu(menuName = "LDJ50/Deciders/MCTS", fileName = "newMctsDecider.asset")]
    public class MCTSDecider : IDecider
    {
        public MCTSParameters SearchParameters;

        MCTSSearcher searcher;

        public override async UniTask<GameState> DecideMove (GameState currentState, CancellationToken token)
        {
            if (searcher == null) searcher = new MCTSSearcher(currentState.CurrentPlayer, SearchParameters);

            return await Task.Run(() => searcher.Search(currentState), cancellationToken: token);
        }
    }
}
