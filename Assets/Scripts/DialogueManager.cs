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
    [SerializeField] Dialogue[] dialogues;

    void Start()
    {
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
            yield return new WaitUntil(AnyKeyDown);
            index++;
        }
    }
}
