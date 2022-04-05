using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LDJ50.CoreRules;

namespace LDJ50.MCTS
{
    public class MCTSNode
    {
        const float EXPLORATION_CONSTANT = 2;

        public GameState GameState { get; protected set; }

        public float TotalScore { get; protected set; }
        public int Visits { get; protected set; }

        public bool IsLeaf => children.Count == 0;

        public IReadOnlyList<MCTSNode> Children => children.AsReadOnly();

        protected List<MCTSNode> children;
        protected MCTSNode parent;

        public MCTSNode (GameState state)
        {
            GameState = state;
            children = new List<MCTSNode>();
        }

        public MCTSNode ExplorationCandidate ()
        {
            MCTSNode currentCandiate = children.First();
            float maxExplorationValue = currentCandiate.explorationValue();

            foreach (var child in children.Skip(1))
            {
                float candidateUcb1 = child.explorationValue();
                if (candidateUcb1 > maxExplorationValue)
                {
                    currentCandiate = child;
                    maxExplorationValue = candidateUcb1;
                }
            }

            return currentCandiate;
        }

        public MCTSNode BestChild ()
        {
            MCTSNode bestChild = children.First();
            float maxVisits = bestChild.Visits;

            foreach (var child in children.Skip(1))
            {
                if (child.Visits > maxVisits)
                {
                    bestChild = child;
                    maxVisits = child.Visits;
                }
            }

            return bestChild;
        }

        public void Expand ()
        {
            foreach (GameState state in GameState.LegalFutureStates())
            {
                addChild(new MCTSNode(state));
            }
        }

        public void BackPropagate (float score)
        {
            TotalScore += score;
            Visits++;
            parent?.BackPropagate(score);
        }

        public void Detach ()
        {
            parent = null;
        }

        void addChild (MCTSNode child)
        {
            child.parent = this;
            children.Add(child);
        }

        // UCT formula
        float explorationValue ()
        {
            if (Visits == 0) return float.PositiveInfinity;
            return TotalScore / Visits // prefer nodes with higher score
                + EXPLORATION_CONSTANT * Mathf.Sqrt(Mathf.Log(parent.Visits) / Visits); // but also look at nodes that have been under-explored
        }
    }
}
