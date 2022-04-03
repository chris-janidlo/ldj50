using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LDJ50.GameState
{
    public static class FormExtensions
    {
        private static readonly Vector2Int[] cardinalDirections = new Vector2Int[4]
        {
            Vector2Int.up, Vector2Int.right, Vector2Int.down, Vector2Int.left
        };

        private static readonly Vector2Int[] diagonalDirections = new Vector2Int[4]
        {
            new Vector2Int(1, 1), new Vector2Int(1, -1), new Vector2Int(-1, -1), new Vector2Int(-1, 1)
        };

        private static readonly Vector2Int[] allDirections = new Vector2Int[8]
        {
            Vector2Int.up, Vector2Int.right, Vector2Int.down, Vector2Int.left,
            new Vector2Int(1, 1), new Vector2Int(1, -1), new Vector2Int(-1, -1), new Vector2Int(-1, 1)
        };

        private static readonly Dictionary<Form, IEnumerable<Form>> transitionMap = new Dictionary<Form, IEnumerable<Form>>
        {
            [Form.Captain] = new List<Form>
            {
                Form.Scientist
            },
            [Form.Engineer] = new List<Form>
            {
                Form.Pilot,
                Form.Priest
            },
            [Form.Pilot] = new List<Form>
            {
                Form.Engineer,
                Form.Priest,
                Form.Captain
            },
            [Form.Priest] = new List<Form>
            {
                Form.Robot,
                Form.Engineer
            },
            [Form.Robot] = new List<Form>
            {
                Form.Engineer,
                Form.Priest,
                Form.Captain
            },
            [Form.Scientist] = new List<Form>
            {
                Form.Engineer,
                Form.Priest
            },
        };

        public static IEnumerable<Vector2Int> GetLegalBoardPositions (this Form form, Vector2Int currentPosition, Board board)
        {
            return form switch
            {
                Form.Captain => movement(currentPosition, board, 5, allDirections, PieceInteraction.Capture),
                Form.Engineer => movement(currentPosition, board, 2, diagonalDirections, PieceInteraction.Swap),
                Form.Pilot => movement(currentPosition, board, 2, diagonalDirections, PieceInteraction.Capture),
                Form.Priest => movement(currentPosition, board, 3, cardinalDirections, PieceInteraction.Swap),
                Form.Robot => movement(currentPosition, board, 2, cardinalDirections, PieceInteraction.Capture),
                Form.Scientist => movement(currentPosition, board, 1, allDirections, PieceInteraction.None),
                _ => throw new System.ArgumentException($"unexpected {form.GetType().Name} value {form}"),
            };
        }

        public static IEnumerable<Form> GetFormTransitions (this Form form)
        {
            return transitionMap[form];
        }

        public static PieceInteraction GetInteraction (this Form form)
        {
            return form switch
            {
                Form.Captain => PieceInteraction.Capture,
                Form.Engineer => PieceInteraction.Swap,
                Form.Pilot => PieceInteraction.Capture,
                Form.Priest => PieceInteraction.Swap,
                Form.Robot => PieceInteraction.Capture,
                Form.Scientist => PieceInteraction.None,
                _ => throw new System.ArgumentException($"unexpected {form.GetType().Name} value {form}"),
            };
        }

        private static IEnumerable<Vector2Int> movement (Vector2Int currentPosition, Board board, int range, Vector2Int[] directions, PieceInteraction PieceInteraction)
        {
            for (int r = 1; r <= range; r++)
            {
                foreach (Vector2Int dir in directions)
                {
                    Vector2Int candidatePosition = currentPosition + dir * r;
                    if (!Board.InBounds(candidatePosition)) break;

                    Piece? pieceAtTarget = board.GetPiece(candidatePosition);

                    if (pieceAtTarget == null)
                    {
                        yield return candidatePosition;
                        continue; // don't need to worry about PieceInteractions if there isn't a piece there. keep searching in this direction
                    }

                    Player thisOwner = board.GetPiece(currentPosition).Value.Owner;

                    if (PieceInteraction != PieceInteraction.None && pieceAtTarget.Value.Owner != thisOwner) yield return candidatePosition;

                    break; // no piece can jump over other pieces
                }
            }
        }
    }
}
