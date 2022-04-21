using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityAtoms.LDJ50Atoms;
using UnityAtoms.SceneMgmt;
using TMPro;

namespace LDJ50
{
    public class GameModeButton : MonoBehaviour
    {
        public IDecider RedDeciderValue, BlueDeciderValue;
        public string ButtonText;

        public IDeciderVariable RedDeciderVariable, BlueDeciderVariable;
        public SceneField GameScene;
        public TextMeshProUGUI ButtonTextContainer;

        void Start ()
        {
            ButtonTextContainer.text = ButtonText;
        }

        public void OnButtonClicked ()
        {
            RedDeciderVariable.Value = RedDeciderValue;
            BlueDeciderVariable.Value = BlueDeciderValue;

            SceneManager.LoadScene(GameScene);
        }
    }
}
