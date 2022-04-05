using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using LDJ50.CoreRules;
using crass;

namespace LDJ50.MCTS
{
    public class MCTSSearcher
    {
        public Player Player { get; private set; }

        MCTSNode previousChoice;
        Random random;

        public MCTSSearcher (Player player)
        {
            Player = player;
            random = new Random();
        }

        public GameState Search (GameState startingState)
        {
            MCTSNode root = previousChoice?.Children.FirstOrDefault(c => c.GameState == startingState) // TODO: is this accurate?
                ?? new MCTSNode(startingState);
            root.Detach();

            foreach (var _ in Enumerable.Range(0, 1))
            {
                MCTSNode leaf = traverse(root); // selection and expansion
                float score = rollout(leaf); // rollout
                leaf.BackPropagate(score); // back propagation
            }

            previousChoice = root.BestChild();
            return previousChoice.GameState;
        }

        MCTSNode traverse (MCTSNode root)
        {
            MCTSNode node = root;
            while (!node.IsLeaf) node = node.ExplorationCandidate();

            if (node.Visits == 0) return node;

            node.Expand();
            return node.Children.First(); // technically all children will have the highest possible exploration score of infinity due to never having been explored, so skip the calculation and just grab the first one
        }

        float rollout (MCTSNode node)
        {
            GameState state = node.GameState;
            while (!state.IsLossState) state = rolloutPolicy(state.LegalFutureStates());

            return state.CurrentPlayer == Player
                ? -1
                : 1;
        }

        GameState rolloutPolicy (IEnumerable<GameState> options)
        {
            return options.ElementAt(random.Next(options.Count()));
        }
    }
}
