using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LDJ50.CoreRules;
using TMPro;
using crass;

namespace LDJ50.KinUI
{
    public class HelpPagePieceEntry : MonoBehaviour
    {
        [Serializable]
        public class Cell
        {
            public Vector2Int Coordinates;
            public Image Image;
        }

        public Form Form;

        public Color ActiveBoardCellColor;
        public EnumMap<PieceInteraction, string> InteractionDescriptions;

        public List<Image> PieceImages;
        public TextMeshProUGUI Name;
        public List<Cell> BoardCells;
        public EnumMap<Form, Image> FormTransformationImages;
        public TextMeshProUGUI CellInteractionText;

        public PieceSpriteGenerator PieceSpriteGenerator;

        void Start ()
        {
            drawSummary();
            drawMovement();
            drawTransformations();
            drawInteraction();
        }

        void drawSummary ()
        {
            foreach (var image in PieceImages)
            {
                image.sprite = PieceSpriteGenerator.GetGraphic(Form);
            }

            Name.text = Form.ToString();
        }

        void drawMovement ()
        {
            Board blankBoard = Board.CreateBoard();
            Vector2Int boardCenter = new Vector2Int(2, 2);

            var cellsByPosition = BoardCells.ToDictionary(c => c.Coordinates, c => c.Image);

            foreach (var position in Form.GetLegalBoardPositions(boardCenter, blankBoard))
            {
                if (position == boardCenter) continue;
                cellsByPosition[position].color = ActiveBoardCellColor;
            }
        }

        void drawTransformations ()
        {
            var formTransformations = Form.GetFormTransitions().ToList();

            foreach (var form in EnumUtil.AllValues<Form>())
            {
                FormTransformationImages[form].gameObject.SetActive(formTransformations.Contains(form));
            }
        }

        void drawInteraction ()
        {
            CellInteractionText.text = InteractionDescriptions[Form.GetInteraction()];
        }
    }
}
