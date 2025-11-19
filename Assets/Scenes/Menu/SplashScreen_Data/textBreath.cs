using UnityEngine;
using TMPro; // Or using UnityEngine.UI; for UI Text
using System.Collections;

public class textBreath : MonoBehaviour
{
    public float minFontSize = 30f;
    public float maxFontSize = 35f;
    public float breathingDuration = 2f; // Time for one full breath cycle (in and out)

    private TextMeshProUGUI textMeshPro; // Or Text textComponent; for UI Text

    void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>(); // Or GetComponent<Text>();
        StartCoroutine(BreathAnimation());
    }

    IEnumerator BreathAnimation()
    {
        while (true) // Loop indefinitely
        {
            // Breathe In (increase font size)
            float opacity = 0f;
            float timer = 0f;
            while (timer < breathingDuration / 2)
            {
                timer += Time.deltaTime;
                //textMeshPro.fontSize = Mathf.Lerp(minFontSize, maxFontSize, timer / (breathingDuration / 2));
                opacity = Mathf.Lerp(0.5f, 1f, timer / (breathingDuration / 2));
                textMeshPro.color = new Color(1f, 1f, 1f, opacity);
                yield return null;
            }

            // Breathe Out (decrease font size)
            timer = 0f;
            while (timer < breathingDuration / 2)
            {
                timer += Time.deltaTime;
                //textMeshPro.fontSize = Mathf.Lerp(maxFontSize, minFontSize, timer / (breathingDuration / 2));
                opacity = Mathf.Lerp(1f, 0.5f, timer / (breathingDuration / 2));
                textMeshPro.color = new Color(1f, 1f, 1f, opacity);
                yield return null;
            }
        }
    }
}