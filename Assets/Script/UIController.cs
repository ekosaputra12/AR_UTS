using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject arCamera;
    public GameObject arContent;   // misal ImageTarget
    public CanvasGroup uiCanvas;   // biar bisa fade-out
    public float fadeDuration = 1f;

    public void StartAR()
    {
        StartCoroutine(FadeAndStart());
    }

    private System.Collections.IEnumerator FadeAndStart()
    {
        // Fade out dulu
        float t = 0;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            uiCanvas.alpha = Mathf.Lerp(1, 0, t / fadeDuration);
            yield return null;
        }
        uiCanvas.gameObject.SetActive(false);

        // Aktifkan AR system
        if (arCamera != null) arCamera.SetActive(true);
        if (arContent != null) arContent.SetActive(true);
    }
}
