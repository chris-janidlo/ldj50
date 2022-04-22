using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LDJ50.CoreRules;

namespace LDJ50.KinUI
{
    [CreateAssetMenu(menuName = "LDJ50/Game Log Generator", fileName = "newGameLogGenerator.asset")]
    public class GameLogGenerator : ScriptableObject
    {
        [Tooltip("Expects the following placeholders: {0}, which will be replaced with the piece's position, " +
            "and {1}, which will be replaced with the name of its form.")]
        public string PieceStateFormat;
        [Tooltip("Expects the following placeholders: {0}, which will be replaced with the piece's initial state, " +
            "and {1}, which will be replaced with its final state.")]
        public string PieceMoveLogFormat;

        public string GetLogEntryForAction (GameState oldState, GameState newState)
        {
            string result = $"{oldState.CurrentPlayer}:";

            foreach (Piece initialPieceState in oldState.PiecesOwnedByCurrentPlayer())
            {
                Piece finalPieceState = newState.GetPieceById(initialPieceState.ID).Value;
                result += "\n";
                result += string.Format(PieceMoveLogFormat, pieceState(initialPieceState), pieceState(finalPieceState));
            }

            return result;
        }

        string pieceState (Piece piece)
        {
            var x = (char) (piece.Position.x + 'a');
            var y = piece.Position.y.ToString();

            string position = x + y;
            string formName = piece.Form.ToString().ToLower();

            return string.Format(PieceStateFormat, position, formName);
        }
    }
}
