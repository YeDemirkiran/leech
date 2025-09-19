using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class DialogueManager : MonoBehaviour
{
    Dialogue[] dialogues;
    [SerializeField] DialogueTypewriter typeWriter;
    [SerializeField] GameObject dialogueBox;
    [SerializeField] GameObject continueText;
    [SerializeField] float globalCharPerSecond;

    [SerializeField] UnityEvent onDialogueEnd;

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
            float charPerSecond = dialogues[index].charPerSecond > 0f ? dialogues[index].charPerSecond : globalCharPerSecond;
            yield return typeWriter.StartTypewriter(dialogues[index].dialogue, charPerSecond);
            continueText.SetActive(true);
            yield return new WaitUntil(AnyKeyDown);
            continueText.SetActive(false);
            index++;
        }
        dialogueBox.SetActive(false);
        continueText.SetActive(false);
        onDialogueEnd?.Invoke();
    }
}
