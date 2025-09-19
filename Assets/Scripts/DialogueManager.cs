using System.Collections;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    Dialogue[] dialogues;
    [SerializeField] DialogueTypewriter typeWriter;
    [SerializeField] GameObject dialogueBox;
    [SerializeField] GameObject continueText;

    bool AnyKeyDown()
    {
        return Input.anyKeyDown;
    }

    private void Start()
    {
        dialogueBox.SetActive(false);
    }

    public void StartDialogue(DialogueObject dialogueObject)
    {
        dialogues = dialogueObject.dialogues;
        dialogueBox.SetActive(true);
        continueText.SetActive(false);
        StartCoroutine(DialogueRoutine());
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
        dialogueBox.SetActive(false);
        continueText.SetActive(false);
    }
}
