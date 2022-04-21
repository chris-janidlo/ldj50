using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using LDJ50.CoreRules;

namespace LDJ50
{
    public class GameOverOverlay : MonoBehaviour
    {
        public string TitleTemplate;

        public GameObject Contents;
        public TextMeshProUGUI Title;

        void Start ()
        {
            Contents.SetActive(false);
        }

        public void ShowOverlay (Player losingPlayer)
        {
            Contents.SetActive(true);
            Title.text = string.Format(TitleTemplate, losingPlayer);
        }
    }
}
