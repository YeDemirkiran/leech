using System.Collections;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    [TextArea]
    public string dialogue;
    public float charPerSecond;
}

public class DialogueManager : MonoBehaviour
{
    [SerializeField] DialogueTypewriter typeWriter;
    [SerializeField] GameObject continueText;
    [SerializeField] Dialogue[] dialogues;

    void Start()
    {
        continueText.SetActive(false);
        StartCoroutine(DialogueRoutine());
    }

    bool AnyKeyDown()
    {
        return Input.anyKeyDown;
    }

    IEnumerator DialogueRoutine()
    {
        int index = 0;

        while (index < dialogues.Length)
        {
            yield return typeWriter.StartTypewriter(dialogues[index].dialogue, dialogues[index].charPerSecond);
            continueText.SetActive(true);
            yield return new WaitUntil(AnyKeyDown);
            continueText.SetActive(false);
            index++;
        }
    }
}
