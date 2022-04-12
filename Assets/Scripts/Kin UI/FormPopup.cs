using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LDJ50.CoreRules;
using crass;

namespace LDJ50.KinUI
{
    public class FormPopup : MonoBehaviour
    {
        public delegate void ClickCallback (Form form);

        public Transform ParentTransform;
        [Tooltip("Assumes that there aren't any extra GameObjects between buttons and the layout group that controls the button layout")]
        public EnumMap<Form, Button> FormButtons;

        public void RegisterCallback (ClickCallback callback)
        {
            foreach (Form form in EnumUtil.AllValues<Form>())
            {
                FormButtons[form].onClick.AddListener(() => callback(form));
            }

            TearDownPopup();
        }

        public void SetUpPopup (Cell cell, IEnumerable<Form> forms)
        {
            ParentTransform.gameObject.SetActive(true);
            ParentTransform.position = cell.transform.position;

            foreach (Form form in EnumUtil.AllValues<Form>())
            {
                FormButtons[form].gameObject.SetActive(forms.Contains(form));
            }
        }

        public void TearDownPopup ()
        {
            ParentTransform.gameObject.SetActive(false);
        }
    }
}
