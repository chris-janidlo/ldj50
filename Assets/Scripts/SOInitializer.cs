using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LDJ50
{
    public class SOInitializer : MonoBehaviour
    {
        public List<IInitializableSO> InitializableSOs;

        void Start ()
        {
            foreach (IInitializableSO so in InitializableSOs)
            {
                so.Initialize();
            }
        }
    }
}
