using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LDJ50.CoreRules;

namespace LDJ50
{
    public class GameLoop : MonoBehaviour
    {
        public IDecider RedDecider, BlueDecider;

        public GameState GameState { get; private set; }

        void Start ()
        {
            DecisionMade(GameState.InitialGameState());
        }

        public void DecisionMade (GameState decision)
        {
            GameState = decision;

            if (decision.IsLossState || !decision.LegalFutureStates().Any())
            {
                endGame(GameState.CurrentPlayer);
            }
            else
            {
                IDecider nextDecider = decision.CurrentPlayer == Player.Blue
                    ? BlueDecider
                    : RedDecider;
                nextDecider.DecideMove(GameState, DecisionMade);
            }
        }

        void endGame (Player loser)
        {
            throw new System.NotImplementedException("TODO: loss scene");
        }
    }
}
