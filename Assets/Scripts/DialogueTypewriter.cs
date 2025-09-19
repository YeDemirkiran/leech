using System.Collections;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class DialogueTypewriter : MonoBehaviour
{
    string dialogueText;
    float charPerSecond;
    TMP_Text text;

    void Awake()
    {
        text = GetComponent<TMP_Text>();
    }

    public IEnumerator StartTypewriter(string text, float charPerSecond)
    {
        dialogueText = text;
        this.charPerSecond = charPerSecond;
        this.text.text = "";
        StopAllCoroutines();
        yield return StartCoroutine(TypewriteIE());
    }

    IEnumerator TypewriteIE()
    {
        float timer = 0f;
        int index = 0;

        while (index < dialogueText.Length)
        {
            if (timer > 1f / charPerSecond)
            {
                text.text += dialogueText[index];
                index++;
                timer = 0f;
            }
            else
            {
                timer += Time.deltaTime;
            }
            yield return null;
        }
    }
}
