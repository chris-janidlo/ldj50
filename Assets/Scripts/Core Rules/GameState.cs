using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LDJ50.CoreRules
{
    public struct GameState : IEquatable<GameState>
    {
        public const Player FIRST_PLAYER = Player.Blue;

        public Board Board;
        public Player CurrentPlayer;
        public bool IsLossState;

        public static GameState InitialGameState ()
        {
            Board board = Board.CreateBoard();

            void addPiece (Player owner, Vector2Int position)
            {
                Piece piece = new Piece
                {
                    Owner = owner,
                    Form = Form.Scientist,
                    Position = position
                };
                board.SetPiece(piece, position);
            }

            addPiece(Player.Blue, new Vector2Int(1, 0));
            addPiece(Player.Blue, new Vector2Int(0, 1));

            int redCorner = Board.SIDE_LENGTH - 1;

            addPiece(Player.Red, new Vector2Int(redCorner - 1, redCorner));
            addPiece(Player.Red, new Vector2Int(redCorner, redCorner - 1));

            return new GameState
            {
                Board = board,
                CurrentPlayer = FIRST_PLAYER
            };
        }

        public static bool operator == (GameState lhs, GameState rhs) => lhs.GetHashCode() == rhs.GetHashCode();
        public static bool operator != (GameState lhs, GameState rhs) => !(lhs == rhs);

        public override int GetHashCode () => (Board, CurrentPlayer, IsLossState).GetHashCode();

        public bool Equals (GameState other) => this == other;
        public override bool Equals (object obj) => obj is GameState other && this == other;

        public IEnumerable<GameState> LegalFutureStates ()
        {
            HashSet<GameState> seenStates = new HashSet<GameState>();
            List<Piece> pieces = Board.GetPiecesByOwner(CurrentPlayer).ToList();

            if (pieces.Count == 1)
            {
                Piece piece = pieces[0];

                foreach (var move in piece.LegalMoves(Board))
                {
                    GameState state = ApplyMove(this, piece, move, true);
                    if (seenStates.Contains(state)) continue;

                    seenStates.Add(state);
                    yield return state;
                }

                yield break;
            }

            foreach (var piece1 in pieces)
            {
                foreach (var move1 in piece1.LegalMoves(Board))
                {
                    GameState intermediateState = ApplyMove(this, piece1, move1, false);
                    foreach (var piece2 in pieces)
                    {
                        if (piece1 == piece2) continue;

                        foreach (var move2 in piece2.LegalMoves(intermediateState.Board))
                        {
                            GameState finalState = ApplyMove(intermediateState, piece2, move2, true);
                            if (seenStates.Contains(finalState)) continue;

                            seenStates.Add(finalState);
                            yield return finalState;
                        }
                    }
                }
            }
        }

        // assumes move is legal
        static GameState ApplyMove (GameState originalState, Piece oldPiece, Piece newPiece, bool changePlayer)
        {
            GameState result = originalState;
            result.Board = Board.DeepClone(originalState.Board); // since the above line results in a fast memory copy, we need to create a new Board in order to not overwrite the one in originalState

            if (result.Board.GetPiece(newPiece.Position) is Piece conflictingPiece && oldPiece.Form.GetInteraction() == PieceInteraction.Swap)
            {
                conflictingPiece.Position = oldPiece.Position;
                result.Board.SetPiece(conflictingPiece, oldPiece.Position);
            }
            else
            {
                result.Board.RemovePiece(oldPiece.Position);
            }

            result.Board.SetPiece(newPiece, newPiece.Position);

            if (changePlayer)
            {
                result.CurrentPlayer = originalState.CurrentPlayer == Player.Blue
                    ? Player.Red
                    : Player.Blue;
            }

            result.IsLossState = result.Board.IsLossForPlayer(result.CurrentPlayer);

            return result;
        }
    }
}
