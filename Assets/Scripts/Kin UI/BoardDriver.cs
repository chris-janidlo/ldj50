using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityAtoms.LDJ50Atoms;
using LDJ50.CoreRules;

namespace LDJ50.KinUI
{
    public class BoardDriver : MonoBehaviour
    {
        [Flags]
        enum ButtonType
        {
            None                    = 0,

            Reset                   = 1 << 0,
            Confirm                 = 1 << 1,
            NonGrid                 = Reset | Confirm,

            MoveablePiece           = 1 << 2,
            PieceMovementTarget     = 1 << 3,
            PieceTransformation     = 1 << 4,
            AllGrid                 = MoveablePiece | PieceMovementTarget | PieceTransformation,

            All                     = NonGrid | AllGrid
        }

        public List<Cell> Cells;

        public Button ResetButton, ConfirmButton;
        public FormPopup FormButtons;

        public GameStateEvent PlayerDecisionMade;

        Dictionary<Vector2Int, Cell> positionMap;
        GameState masterState, workingState;

        Vector2Int currentlyMoving, currentTarget;
        List<string> pieceIdsMoved;

        void Awake ()
        {
            positionMap = new Dictionary<Vector2Int, Cell>();
            pieceIdsMoved = new List<string>();

            foreach (var cell in Cells)
            {
                if (positionMap.TryGetValue(cell.Coordinates, out Cell existingCell))
                {
                    throw new InvalidOperationException($"cannot add Cell {cell.name} to {name} because there is already a Cell ({existingCell.name}) at position {cell.Coordinates}");
                }

                positionMap[cell.Coordinates] = cell;
            }

            ResetButton.onClick.AddListener(OnResetButtonClicked);
            FormButtons.RegisterCallback(pieceTransformationCallback);
            resetButtons(ButtonType.NonGrid);
        }

        public void OnPlayerDecisionNeeded (GameState gameState)
        {
            workingState = masterState = gameState;
            pieceIdsMoved.Clear();

            resetButtons();
            setupMoveablePieces();

            drawBoard(masterState);
        }

        public void OnResetButtonClicked ()
        {
            workingState = masterState;
            pieceIdsMoved.Clear();

            resetButtons();
            setupMoveablePieces();

            drawBoard(masterState);
        }

        public void OnConfirmButtonClicked ()
        {
            masterState = workingState;
            masterState.FlipPlayer();

            resetButtons();

            PlayerDecisionMade.Raise(masterState);
        }

        void resetButtons (ButtonType types = ButtonType.All)
        {
            if (types.HasFlag(ButtonType.Reset)) ResetButton.interactable = false;
            if (types.HasFlag(ButtonType.Confirm)) ConfirmButton.interactable = false;

            foreach (Cell cell in Cells)
            {
                if (types.HasFlag(ButtonType.MoveablePiece) && cell.GetClickCallback() == moveablePieceClickCallback ||
                    types.HasFlag(ButtonType.PieceMovementTarget) && cell.GetClickCallback() == pieceMovementTargetClickCallback)
                {
                    cell.RegisterClickCallback(null);
                }
            }

            if (types.HasFlag(ButtonType.PieceTransformation)) FormButtons.TearDownPopup();
        }

        void setupMoveablePieces (Vector2Int? exceptPosition = null)
        {
            foreach (Piece playerPiece in workingState.PiecesOwnedByCurrentPlayer())
            {
                if (playerPiece.Position == exceptPosition || pieceIdsMoved.Contains(playerPiece.ID)) continue;

                positionMap[playerPiece.Position].RegisterClickCallback(moveablePieceClickCallback);
            }
        }

        void drawBoard (GameState state)
        {
            Cells.ForEach(c => c.UpdateImage(state));
        }

        void moveablePieceClickCallback (Cell cell)
        {
            resetButtons(ButtonType.AllGrid);
            setupMoveablePieces(exceptPosition: cell.Coordinates);

            foreach (Vector2Int position in workingState.LegalPositionsForPieceAt(cell.Coordinates))
            {
                positionMap[position].RegisterClickCallback(pieceMovementTargetClickCallback);
            }

            currentlyMoving = cell.Coordinates;
        }

        void pieceMovementTargetClickCallback (Cell cell)
        {
            resetButtons(ButtonType.AllGrid);
            setupMoveablePieces();

            FormButtons.SetUpPopup(cell, workingState.LegalFormTransitionsForPieceAt(currentlyMoving));

            currentTarget = cell.Coordinates;
        }

        void pieceTransformationCallback (Form form)
        {
            resetButtons(ButtonType.AllGrid);

            Piece pieceMoved = workingState.Board.GetPiece(currentlyMoving).Value;
            Piece resultingPiece = new Piece(pieceMoved.ID, pieceMoved.Owner, form, currentTarget);

            workingState = GameState.ApplyMove(workingState, pieceMoved, resultingPiece, false);
            ResetButton.interactable = true;

            pieceIdsMoved.Add(pieceMoved.ID);
            setupMoveablePieces();

            if (pieceIdsMoved.Count == workingState.PiecesOwnedByCurrentPlayer().Count())
            {
                ConfirmButton.interactable = true;
            }

            drawBoard(workingState);
        }
    }
}
