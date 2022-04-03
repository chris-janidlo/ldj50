using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LDJ50.GameState
{
    public struct GameState
    {
        public Board Board;
        public Player CurrentPlayer;
        public bool IsLossState;

        public static GameState InitialGameState ()
        {
            Board board = Board.CreateBoard();

            Piece addPiece (Player owner, Vector2Int position)
            {
                Piece piece = new Piece
                {
                    Owner = owner,
                    Form = Form.Scientist,
                    Position = position
                };
                board.SetPiece(piece, position);
                return piece;
            }

            addPiece(Player.Human, new Vector2Int(1, 0));
            addPiece(Player.Human, new Vector2Int(0, 1));

            int aiCorner = Board.SIDE_LENGTH - 1;

            addPiece(Player.AI, new Vector2Int(aiCorner - 1, aiCorner));
            addPiece(Player.AI, new Vector2Int(aiCorner, aiCorner - 1));

            return new GameState
            {
                Board = board,
                CurrentPlayer = Player.Human
            };
        }

        public IEnumerable<GameState> LegalFutureStates ()
        {
            GameState originalState = this;
            Player player = CurrentPlayer;
            Board board = Board;

            return board.Positions
                .Cast<Piece?>()
                .Where(p => p?.Owner == player)
                .SelectMany(p => p.Value.LegalMoves(board)
                    .Select(m => ApplyMove(originalState, new Piece { Owner = player, Position = m.Item1, Form = m.Item2 }, p.Value.Form.GetInteraction(), p.Value.Position))
                );
        }

        // assumes move is legal
        static GameState ApplyMove (GameState originalState, Piece newPiece, PieceInteraction pieceInteraction, Vector2Int originalPosition)
        {
            GameState result = originalState;
            result.Board = Board.CreateBoard(); // since the above line results in a fast memory copy, we need to create a new Board in order to not overwrite the one in originalState

            result.Board.Positions = originalState.Board.Positions.Clone() as Piece?[,];

            if (result.Board.GetPiece(newPiece.Position) is Piece conflictingPiece && pieceInteraction == PieceInteraction.Swap)
            {
                conflictingPiece.Position = originalPosition;
                result.Board.SetPiece(conflictingPiece, originalPosition);
            }

            result.Board.SetPiece(newPiece, newPiece.Position);

            return result;
        }
    }
}
