using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LDJ50.CoreRules
{
    public struct Piece
    {
        public Player Owner;

        public Form Form;

        public Vector2Int Position;

        public static bool operator == (Piece lhs, Piece rhs) =>
            lhs.Owner == rhs.Owner &&
            lhs.Form == rhs.Form &&
            lhs.Position == rhs.Position;

        public static bool operator != (Piece lhs, Piece rhs) => !(lhs == rhs);

        public override int GetHashCode () => (Owner, Form, Position).GetHashCode();

        public IEnumerable<Piece> LegalMoves (Board board)
        {
            foreach (Vector2Int legalPosition in Form.GetLegalBoardPositions(Position, board))
            {
                foreach (Form legalForm in Form.GetFormTransitions())
                {
                    yield return new Piece { Owner = Owner, Position = legalPosition, Form = legalForm };
                }
            }
        }

        public char ToChar ()
        {
            char c = Form switch
            {
                Form.Captain => 'c',
                Form.Engineer => 'e',
                Form.Pilot => 'i',
                Form.Priest => 'p',
                Form.Robot => 'r',
                Form.Scientist => 's',
                _ => throw new InvalidOperationException($"unexpected {Form.GetType().Name} value {Form}")
            };

            return Owner switch
            {
                Player.Blue => char.ToLower(c),
                Player.Red => char.ToUpper(c),
                _ => throw new InvalidOperationException($"unexpected {Owner.GetType().Name} value {Owner}")
            };
        }
    }
}
