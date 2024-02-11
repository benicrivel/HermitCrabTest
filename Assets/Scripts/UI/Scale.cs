using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scale : MonoBehaviour
{
    [SerializeField]
    private RectTransform rectTransform;
    [SerializeField]
    private float duration = 2f;
    [SerializeField]
    private float maxSize = 5f;
    [SerializeField]
    private float minSize = 0.1f;
    // Start is called before the first frame update
    private void Start()
    {
        // Start the animation coroutine
        StartCoroutine(ScaleAnimationCoroutine());
    }

    private IEnumerator ScaleAnimationCoroutine()
    {
        while (true)
        {
            // Scale from 0.1x0.1 to 5x5
            yield return ScaleRectTransform(Vector3.one * minSize, Vector3.one * maxSize, duration);
            // Scale from 5x5 to 0.1x0.1
            yield return ScaleRectTransform(Vector3.one * maxSize, Vector3.one * minSize, duration);
        }
    }

    private IEnumerator ScaleRectTransform(Vector3 startScale, Vector3 targetScale, float duration)
    {
        float timeElapsed = 0f;

        while (timeElapsed < duration)
        {
            timeElapsed += Time.deltaTime;
            float t = Mathf.Clamp01(timeElapsed / duration);
            rectTransform.localScale = Vector3.Lerp(startScale, targetScale, t);
            yield return null;
        }

        // Ensure final scale is set exactly to target scale
        rectTransform.localScale = targetScale;
    }
}
