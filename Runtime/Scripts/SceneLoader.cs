using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UIHelpers;

public class SceneLoader : MonoBehaviour
{
    public GameObject loadingOverlay;
    public float loadingFadeTimeSeconds = 0.3f;

    private CanvasGroup canvasGroup;
    private Slider loadingSlider;

    private AsyncOperation loadOperation;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        canvasGroup = loadingOverlay
            .GetComponent<CanvasGroup>();

        loadingSlider = loadingOverlay
            .GetComponentInChildren<Slider>();
    }

    private void Update()
    {
        if (loadOperation != null
            && !loadOperation.isDone) {
            SetLoadingProgress(loadOperation.progress);
        }
    }

    public void LoadScene(string toLoad)
    {
        StartCoroutine(StartLoad(toLoad));
    }

    private IEnumerator StartLoad(string toLoad)
    {
        loadingOverlay.SetActive(true);
        yield return StartCoroutine(FadeCanvas(canvasGroup, 1, loadingFadeTimeSeconds));

        loadOperation = SceneManager.LoadSceneAsync(toLoad);
        while (!loadOperation.isDone) {
            yield return null;
        }

        yield return StartCoroutine(FadeCanvas(canvasGroup, 0, loadingFadeTimeSeconds));
        loadingOverlay.SetActive(false);

        Destroy(gameObject);
    }

    private void SetLoadingProgress(float progress)
    {
        Debug.Log($"Load progress: {progress}");
        loadingSlider.value = Mathf.Clamp01(progress / 0.9f);
    }
}