using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TapTutorial : MonoBehaviour
{
    public RawImage image;
    private float targetAlpha;
    private float FadeRate = 0.1f;

    // Start is called before the first frame update
    void Update()
    {
        StartCoroutine(AlphaChanger());
    }

    IEnumerator AlphaChanger()
    {
        yield return new WaitForSecondsRealtime(3);

        targetAlpha = 1.0f;
        Color curColor = image.color;
        while (Mathf.Abs(curColor.a - targetAlpha) > 0.0001f)
        {
            curColor.a = Mathf.Lerp(curColor.a, targetAlpha, FadeRate * Time.deltaTime);
            image.color = curColor;
            yield return null;
        }
    }
}
