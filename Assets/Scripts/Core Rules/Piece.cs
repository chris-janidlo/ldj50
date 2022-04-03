using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LDJ50.GameState
{
    public struct Piece
    {
        public Player Owner;

        public Form Form;

        public Vector2Int Position;

        public IEnumerable<(Vector2Int, Form)> LegalMoves (Board board)
        {
            foreach (Vector2Int legalPosition in Form.GetLegalBoardPositions(Position, board))
            {
                foreach (Form legalForm in Form.GetFormTransitions())
                {
                    yield return (legalPosition, legalForm);
                }
            }
        }
    }
}
