using UnityEditor;
using UnityEngine;
using UnityEngine.Playables;

public class GameManager : MonoBehaviour
{
    PlayableDirector director;
    DialogueManager dialogueManager;

    [SerializeField] PlayableAsset[] playables;
    [SerializeField] DialogueObject[] dialogueObjects;

    int currentStageIndex = 0;

    private void Awake()
    {
        director = GetComponent<PlayableDirector>();
        dialogueManager = FindFirstObjectByType<DialogueManager>();
    }

    private void Start()
    {
        currentStageIndex = PlayerPrefs.GetInt("Stage", 0);
        if (currentStageIndex >= playables.Length)
            currentStageIndex = 0;

        dialogueManager.CurrentDialogueObect = dialogueObjects[currentStageIndex];
        
        director.playableAsset = playables[currentStageIndex];
        director.Play();
    }

    public void GlitchExitGame()
    {
        // activate the glitch effect

        // increase the timeline
        PlayerPrefs.SetInt("Stage", currentStageIndex + 1);
        PlayerPrefs.Save();

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
