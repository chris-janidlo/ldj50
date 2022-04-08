using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using LDJ50.CoreRules;
using UnityEngine;
using LDJ50.MCTS;

namespace LDJ50
{
    [CreateAssetMenu(menuName = "LDJ50/Deciders/MCTS", fileName = "newMctsDecider.asset")]
    public class MCTSDecider : IDecider
    {
        public MCTSParameters SearchParameters;

        MCTSSearcher searcher;

        public override void DecideMove (GameState currentState, DecisionCallback callback)
        {
            if (searcher == null) searcher = new MCTSSearcher(currentState.CurrentPlayer, SearchParameters);

            callback(searcher.Search(currentState));
        }
    }
}
