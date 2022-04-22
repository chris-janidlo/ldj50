using System.Linq;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityAtoms.LDJ50Atoms;
using Cysharp.Threading.Tasks;
using LDJ50.CoreRules;

namespace LDJ50
{
    public class GameLoop : MonoBehaviour
    {
        public IDeciderVariable BlueDecider, RedDecider;
        public GameStatePairEvent DecisionMade;
        public GameOverOverlay GameOverOverlay;

        public GameState GameState { get; private set; }

        void Start ()
        {
            StartCoroutine(PlayOutGame(this.GetCancellationTokenOnDestroy()).ToCoroutine());
        }

        async UniTask PlayOutGame (CancellationToken token)
        {
            GameState = GameState.InitialGameState();

            while (!GameState.IsLossState && GameState.LegalFutureStates().Any())
            {
                IDecider nextDecider = GameState.CurrentPlayer == Player.Blue
                    ? BlueDecider.Value
                    : RedDecider.Value;
                GameState newState = await nextDecider.DecideMove(GameState, token);

                DecisionMade.Raise(new GameStatePair { Item1 = GameState, Item2 = newState });

                GameState = newState;
            }

            GameOverOverlay.ShowOverlay(GameState.CurrentPlayer);
        }
    }
}
