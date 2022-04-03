using UnityEngine;

namespace LDJ50.GameState
{
    public struct Board
    {
        public const int SIDE_LENGTH = 5;

        public Piece?[,] Positions;

        public static Board CreateBoard ()
        {
            return new Board
            {
                Positions = new Piece?[SIDE_LENGTH, SIDE_LENGTH]
            };
        }

        public static bool InBounds (Vector2Int position)
        {
            return
                position.x >= 0 && position.x < SIDE_LENGTH &&
                position.y >= 0 && position.y < SIDE_LENGTH;
        }

        public Piece? GetPiece (Vector2Int position)
        {
            return Positions[position.x, position.y];
        }

        public void SetPiece (Piece piece, Vector2Int position)
        {
            Positions[position.x, position.y] = piece;
        }
    }
}
