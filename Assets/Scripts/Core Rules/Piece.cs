using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LDJ50.CoreRules
{
    public struct Piece
    {
        public string ID;
        public Player Owner;

        public Form Form;
        public Vector2Int Position;

        public static bool operator == (Piece lhs, Piece rhs) =>
            lhs.Owner == rhs.Owner &&
            lhs.Form == rhs.Form &&
            lhs.Position == rhs.Position;

        public static bool operator != (Piece lhs, Piece rhs) => !(lhs == rhs);

        public override int GetHashCode () => (Owner, Form, Position).GetHashCode(); // deliberately exclude ID from the hashcode computation because we use the hashcode to calculate value equality, and we want to treat two pieces that are identical except for their ID as equal when comparing board layouts

        public Piece (string id, Player owner, Form form, Vector2Int position)
        {
            ID = id;
            Owner = owner;
            Form = form;
            Position = position;
        }

        public IEnumerable<Piece> LegalMoves (Board board)
        {
            foreach (Vector2Int legalPosition in Form.GetLegalBoardPositions(Position, board))
            {
                foreach (Form legalForm in Form.GetFormTransitions())
                {
                    yield return new Piece(ID, Owner, legalForm, legalPosition);
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

        public Piece Clone ()
        {
            return new Piece(ID, Owner, Form, Position);
        }
    }
}
