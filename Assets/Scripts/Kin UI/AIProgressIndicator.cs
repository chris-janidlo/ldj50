using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace LDJ50.KinUI
{
    public class AIProgressIndicator : MonoBehaviour
    {
        public string BaseText, RepeatingText;
        public int MaxRepetitions;

        public TextMeshProUGUI TextContainer;
        public AIDecider AIDecider;

        void Update ()
        {
            TextContainer.text = AIDecider.Deciding
                ? BaseText + Repeat(RepeatingText, (int) (MaxRepetitions * AIDecider.Progress))
                : "";
        }

        // https://stackoverflow.com/a/720915/5931898
        string Repeat (string value, int count)
        {
            return new StringBuilder(value.Length * count).Insert(0, value, count).ToString();
        }
    }
}
