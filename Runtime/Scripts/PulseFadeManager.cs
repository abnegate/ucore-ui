using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static UIHelpers;

public class PulseFadeManager : MonoBehaviour
{
    public float startDelaySeconds = 1f;
    public float betweenDelaySeconds = 1f;
    public float endDelaySeconds = 1f;
    public List<PulseFadeHandler> objectsToPulse;

    public UnityEvent onComplete;

    void Awake()
    {
        StartPulse();
    }

    public void StartPulse()
    {
        StartCoroutine(FadeObjects());
    }

    IEnumerator FadeObjects()
    {
        yield return new WaitForSeconds(startDelaySeconds);

        foreach (var obj in objectsToPulse) {
            var canvas = obj.container
                .GetComponentInChildren<CanvasGroup>();

            if (canvas == null) {
                continue;
            }
            yield return FadeCanvas(canvas, 1, obj.timeToFadeSeconds);
            yield return new WaitForSeconds(obj.timeToDisplaySeconds);
            yield return FadeCanvas(canvas, 0, obj.timeToFadeSeconds);
            yield return new WaitForSeconds(betweenDelaySeconds);
        }
        yield return new WaitForSeconds(endDelaySeconds);

        onComplete.Invoke();
    }
}
