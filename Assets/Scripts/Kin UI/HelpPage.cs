using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LDJ50.KinUI
{
    public class HelpPage : MonoBehaviour
    {
        public GameObject ContentsParent;

        void Start ()
        {
            Close();
        }

        public void Open ()
        {
            ContentsParent.SetActive(true);
        }

        public void Close ()
        {
            ContentsParent.SetActive(false);
        }
    }
}
