using System.Linq;
using System.Text;
using System.Collections.Generic;
using UnityEngine;

namespace LDJ50.CoreRules
{
    public struct Board
    {
        public const int SIDE_LENGTH = 5;

        public Piece?[,] Positions;
        private readonly int SideLength;

        public Board (int sideLength)
        {
            SideLength = sideLength;
            Positions = new Piece?[sideLength, sideLength];
        }

        public static Board CreateBoard ()
        {
            return new Board(SIDE_LENGTH);
        }

        public static Board DeepClone (Board other)
        {
            Board result = CreateBoard();
            for (int x = 0; x < SIDE_LENGTH; x++)
            {
                for (int y = 0; y < SIDE_LENGTH; y++)
                {
                    if (other.Positions[x, y] is Piece piece)
                    {
                        result.Positions[x, y] = piece.Clone();
                    }
                }
            }
            return result;
        }

        public bool InBounds (Vector2Int position)
        {
            return
                position.x >= 0 && position.x < SideLength &&
                position.y >= 0 && position.y < SideLength;
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

        public override string ToString ()
        {
            var result = new StringBuilder();
            for (int x = 0; x < SIDE_LENGTH; x++)
            {
                for (int y = 0; y < SIDE_LENGTH; y++)
                {
                    result.Append(Positions[x, y]?.ToChar() ?? '_');
                    result.Append(' ');
                }
                result.Append('\n');
            }
            return result.ToString();
        }

        public Piece? GetPiece (Vector2Int position)
        {
            return Positions[position.x, position.y];
        }

        public void SetPiece (Piece piece, Vector2Int position)
        {
            Positions[position.x, position.y] = piece;
        }

        public void RemovePiece (Vector2Int position)
        {
            Positions[position.x, position.y] = null;
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

        public Piece? GetPieceById (char id)
        {
            return Positions.Cast<Piece?>().FirstOrDefault(p => p?.ID == id);
        }
    }
}
