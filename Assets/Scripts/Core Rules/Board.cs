using System.Collections.Generic;
using UnityEngine;

namespace LDJ50.CoreRules
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

        public override int GetHashCode ()
        {
            unchecked
            {
                if (Positions == null)
                {
                    return 0;
                }
                int hash = 17;
                foreach (Piece? element in Positions)
                {
                    hash = hash * 31 + element.GetHashCode();
                }
                return hash;
            }
        }

        public Piece? GetPiece (Vector2Int position)
        {
            return Positions[position.x, position.y];
        }

        public void SetPiece (Piece piece, Vector2Int position)
        {
            Positions[position.x, position.y] = piece;
        }

        public IEnumerable<Piece> GetPiecesByOwner (Player owner)
        {
            foreach (Piece? piece in Positions)
            {
                if (piece?.Owner == owner) yield return piece.Value;
            }
        }

        public bool IsLossForPlayer (Player player)
        {
            foreach (Piece? piece in Positions)
            {
                if (piece?.Owner == player) return false;
            }
            return true;
        }
    }
}
