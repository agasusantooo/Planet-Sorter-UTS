using UnityEngine;

public class PauseBlink : MonoBehaviour
{
    public float blinkSpeed = 1f;
    private CanvasGroup canvasGroup;

    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    void Update()
    {
        if (canvasGroup != null && Time.timeScale == 0f)
        {
            float alpha = Mathf.PingPong(Time.unscaledTime * blinkSpeed, 1f);
            canvasGroup.alpha = alpha;
        }
        else if (canvasGroup != null)
        {
            canvasGroup.alpha = 1f;
        }
    }
}
