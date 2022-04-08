using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Cysharp.Threading.Tasks;
using LDJ50.CoreRules;

namespace LDJ50
{
    public class GameLoop : MonoBehaviour
    {
        public IDecider RedDecider, BlueDecider;

        public GameState GameState { get; private set; }

        void Start ()
        {
            MainLoop();
        }

        async void MainLoop ()
        {
            GameState = GameState.InitialGameState();

            while (!GameState.IsLossState && GameState.LegalFutureStates().Any())
            {
                IDecider nextDecider = GameState.CurrentPlayer == Player.Blue
                    ? BlueDecider
                    : RedDecider;
                GameState = await nextDecider.DecideMove(GameState);
            }

            endGame(GameState.CurrentPlayer);
        }

        void endGame (Player loser)
        {
            throw new System.NotImplementedException("TODO: loss scene");
        }
    }
}
