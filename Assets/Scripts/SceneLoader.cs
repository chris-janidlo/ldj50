using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityAtoms.SceneMgmt;

namespace LDJ50
{
    public class SceneLoader : MonoBehaviour
    {
        public SceneField Scene;

        public void LoadScene ()
        {
            SceneManager.LoadScene(Scene);
        }
    }
}
