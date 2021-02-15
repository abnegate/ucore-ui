using System.Collections;
using UnityEngine;
using static UIHelpers;

public class FadeAndDestroy : MonoBehaviour
{
    public float timeToFadeSeconds;

    public void FadeAndDestroyUI()
    {
        StartCoroutine(FadeAndDestroyObject());
    }

    public IEnumerator FadeAndDestroyObject()
    {
        var canvas = GetComponentInChildren<CanvasGroup>();
        if (canvas == null) {
            Destroy(gameObject);
            yield break;
        }
        yield return FadeCanvas(canvas, 0, timeToFadeSeconds);

        Destroy(gameObject);
    }
}
