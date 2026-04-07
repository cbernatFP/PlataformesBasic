using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif


public class CanvisEscena : MonoBehaviour
{
    // Start is called before the first frame update
    public void Nivell1()
    {
        SceneManager.LoadScene(1);
    }

    public void Sortir() {
        Application.Quit();

        #if UNITY_EDITOR
                EditorApplication.isPlaying = false;
        #endif
    }

}
