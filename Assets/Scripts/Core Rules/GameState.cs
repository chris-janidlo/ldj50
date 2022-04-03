using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LDJ50.CoreRules
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

        public override int GetHashCode () => (Board, CurrentPlayer, IsLossState).GetHashCode();

        public IEnumerable<GameState> LegalFutureStates ()
        {
            HashSet<GameState> seenStates = new HashSet<GameState>();
            IEnumerable<Piece> pieces = Board.GetPiecesByOwner(CurrentPlayer);

            foreach (var piece1 in pieces)
            {
                foreach (var move1 in piece1.LegalMoves(Board))
                {
                    GameState intermediateState = ApplyMove(this, piece1, move1);
                    foreach (var piece2 in pieces)
                    {
                        if (piece1 == piece2) continue;

                        foreach (var move2 in piece2.LegalMoves(intermediateState.Board))
                        {
                            GameState finalState = ApplyMove(intermediateState, piece2, move2);
                            if (seenStates.Contains(finalState)) continue;

                            seenStates.Add(finalState);
                            yield return finalState;
                        }
                    }
                }
            }
        }

        // assumes move is legal
        static GameState ApplyMove (GameState originalState, Piece oldPiece, Piece newPiece)
        {
            GameState result = originalState;
            result.Board = Board.CreateBoard(); // since the above line results in a fast memory copy, we need to create a new Board in order to not overwrite the one in originalState

            result.Board.Positions = originalState.Board.Positions.Clone() as Piece?[,];

            if (result.Board.GetPiece(newPiece.Position) is Piece conflictingPiece && oldPiece.Form.GetInteraction() == PieceInteraction.Swap)
            {
                conflictingPiece.Position = oldPiece.Position;
                result.Board.SetPiece(conflictingPiece, oldPiece.Position);
            }

            result.Board.SetPiece(newPiece, newPiece.Position);

            result.CurrentPlayer = originalState.CurrentPlayer == Player.AI
                ? Player.Human
                : Player.AI;
            result.IsLossState = result.Board.IsLossForPlayer(result.CurrentPlayer);

            return result;
        }
    }
}
