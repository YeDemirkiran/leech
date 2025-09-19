using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public void GlitchExitGame()
    {
        // activate the glitch effect

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
