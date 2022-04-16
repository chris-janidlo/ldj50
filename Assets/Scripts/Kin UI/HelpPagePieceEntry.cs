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
        public Form Form;

        public Color ActiveBoardCellColor;
        public EnumMap<PieceInteraction, string> InteractionDescriptions;

        public List<Image> PieceImages;
        public TextMeshProUGUI Name;
        public List<Image> BoardCells;
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
            int sideLength = (int) Math.Sqrt(BoardCells.Count);
            Board fakeBoard = new Board(sideLength);
            Vector2Int boardCenter = new Vector2Int(sideLength / 2, sideLength / 2);

            List<Vector2Int> validPositions = Form.GetLegalBoardPositions(boardCenter, fakeBoard).ToList();

            for (int i = 0; i < BoardCells.Count; i++)
            {
                Vector2Int coordinate = new Vector2Int(i % sideLength, i / sideLength);
                if (coordinate == boardCenter) continue;

                if (validPositions.Contains(coordinate)) BoardCells[i].color = ActiveBoardCellColor;
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
