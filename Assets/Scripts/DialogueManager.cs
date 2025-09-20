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

    public DialogueObject CurrentDialogueObect { get; set; }

    bool AnyKeyDown()
    {
        return (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space));
    }

    private void Start()
    {
        dialogueBox.SetActive(false);
    }

    public void StartCurrentDialogue()
    {
        StartDialogue(CurrentDialogueObect);
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
            if (dialogues[index].type == Dialogue.Type.Dialogue)
            {
                dialogueBox.SetActive(true);
                float charPerSecond = dialogues[index].charPerSecond > 0f ? dialogues[index].charPerSecond : globalCharPerSecond;
                yield return typeWriter.StartTypewriter(dialogues[index].dialogue, charPerSecond);
                continueText.SetActive(true);
                yield return new WaitUntil(AnyKeyDown);
                continueText.SetActive(false);
            }
            else
            {
                dialogueBox.SetActive(false);
                yield return new WaitForSeconds(dialogues[index].delay);
            }
            index++;
        }
        dialogueBox.SetActive(false);
        continueText.SetActive(false);
        onDialogueEnd?.Invoke();
    }
}
