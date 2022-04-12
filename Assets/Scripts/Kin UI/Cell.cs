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
        public delegate void ClickCallback (Cell cell);

        public Vector2Int Coordinates;

        public Image PieceImage;
        public Button Button;
        public PieceSpriteGenerator PieceSpriteGenerator;

        ClickCallback currentCallback;

        public void RegisterClickCallback (ClickCallback callback)
        {
            currentCallback = callback;
            Button.interactable = currentCallback != null;
        }

        public ClickCallback GetClickCallback () => currentCallback;

        public void OnClick ()
        {
            currentCallback?.Invoke(this);
        }

        public void UpdateImage (GameState state)
        {
            (PieceImage.sprite, PieceImage.color) = PieceSpriteGenerator.GetSprite(state.Board.GetPiece(Coordinates));
        }
    }
}
