using UnityEngine;
using System.Collections;

public static class UIHelpers
{
    public static IEnumerator FadeCanvas(
        CanvasGroup canvasGroup,
        float targetValue,
        float duration)
    {
        float startValue = canvasGroup.alpha;
        float time = 0;

        while (time < duration) {
            canvasGroup.alpha = Mathf.Lerp(
                startValue,
                targetValue,
                time / duration);

            time += Time.deltaTime;
            yield return null;
        }
        canvasGroup.alpha = targetValue;
    }
}
