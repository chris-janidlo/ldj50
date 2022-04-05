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
        MCTSSearcher searcher;

        public override void DecideMove (GameState currentState, DecisionCallback callback)
        {
            if (searcher == null) searcher = new MCTSSearcher(currentState.CurrentPlayer);

            callback(searcher.Search(currentState));
        }
    }
}
