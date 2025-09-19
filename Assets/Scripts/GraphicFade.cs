using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Graphic))]
public class GraphicFade : MonoBehaviour
{
    Graphic graphic;

     enum FadeMode { FadeIn, FadeOut };

    void Awake()
    {
        graphic = GetComponent<Graphic>();
    }

    public void FadeIn(float time)
    {
        StopAllCoroutines();
        StartCoroutine(FadeIE(time, FadeMode.FadeIn));
    }

    public void FadeOut(float time)
    {
        StopAllCoroutines();
        StartCoroutine(FadeIE(time, FadeMode.FadeOut));
    }

    IEnumerator FadeIE(float time, FadeMode mode)
    {
        Color startColor = graphic.color;
        Color targetColor = startColor;

        if (mode == FadeMode.FadeIn)
            targetColor.a = 0f;
        else if (mode == FadeMode.FadeOut)
            targetColor.a = 1f;

        float timer = 0f;

        while (timer <= 1f)
        {
            timer += Time.deltaTime / time;
            graphic.color = Color.Lerp(startColor, targetColor, timer);
            yield return null;
        }
    }
}
