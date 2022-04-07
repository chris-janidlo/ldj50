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
            MCTSNode root = previousChoice?.ChildWithState(startingState) ?? new MCTSNode(startingState);
            root.Detach();
            root.Expand(); // always need at least one level expanded from the root

            foreach (var _ in Enumerable.Range(0, 10))
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

            // terminal nodes are essentially rollouts that are decided instantly. https://ai.stackexchange.com/a/6993/53886 has ideas for improvements here
            if (node.Visits == 0 || node.IsTerminalState) return node;

            node.Expand();
            // technically all children will have the highest possible exploration score of infinity due to never having been explored, so skip the calculation and just grab the first one
            return node.Children.First();
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
