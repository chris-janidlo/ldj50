using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
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
            MoveDecided(GameState.InitialGameState());
        }

        void MoveDecided (GameState decision)
        {
            GameState = decision;

            if (GameState.IsLossState || !GameState.LegalFutureStates().Any())
            {
                Debug.Log(GameState.Board);
                Debug.Log($"{GameState.CurrentPlayer} loses");
                endGame(GameState.CurrentPlayer);
            }
            else
            {
                IDecider nextDecider = GameState.CurrentPlayer == Player.Blue
                    ? BlueDecider
                    : RedDecider;
                nextDecider.DecideMove(GameState, MoveDecided);
            }
        }

        void endGame (Player loser)
        {
            //throw new System.NotImplementedException("TODO: loss scene");
        }
    }
}
