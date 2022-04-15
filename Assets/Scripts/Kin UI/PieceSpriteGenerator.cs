using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LDJ50.CoreRules;
using crass;

namespace LDJ50.KinUI
{
    [CreateAssetMenu(menuName = "LDJ50/Kin Sprite Generator", fileName = "newSpriteGenerator.asset")]
    public class PieceSpriteGenerator : ScriptableObject
    {
        public EnumMap<Form, Sprite> FormSprites;
        public EnumMap<Player, Color> PlayerColors;

        public (Sprite, Color) GetSprite (Piece? potentialPiece)
        {
            return potentialPiece is Piece piece
                ? (FormSprites[piece.Form], PlayerColors[piece.Owner])
                : (null, Color.clear);
        }

        public Sprite GetGraphic (Form form)
        {
            return FormSprites[form];
        }
    }
}
