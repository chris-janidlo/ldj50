using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityAtoms.LDJ50Atoms;
using LDJ50.CoreRules;

namespace LDJ50.KinUI
{
    public class Cell : MonoBehaviour
    {
        public Vector2Int Coordinates;

        public Image PieceImage;
        public Button Button;

        public CellMapper Mapper;
        public PieceSpriteGenerator PieceSpriteGenerator;

        Piece? currentPiece => currentState.Board.GetPiece(Coordinates);
        GameState currentState;

        void Start ()
        {
            Mapper.RegisterCell(Coordinates, this);
        }

        public void OnPlayerDecisionNeeded (GameState gameState)
        {
            currentState = gameState;
            updateImage();

            Button.interactable = currentPiece?.Owner == gameState.CurrentPlayer;
        }

        public void OnPlayerDecisionMade (GameState gameState)
        {
            currentState = gameState;
            Button.interactable = false;
            updateImage();
        }

        public void OnClick ()
        {
            throw new System.NotImplementedException();
        }

        void updateImage ()
        {
            (PieceImage.sprite, PieceImage.color) = PieceSpriteGenerator.GetSprite(currentPiece);
        }
    }
}
