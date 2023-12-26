using System.Collections;
using TMPro;
using UnityEngine;

public class TextUI : MonoBehaviour
{
    private string text;
    public TMP_Text targetText;
    private float delay = 0.125f;
    public Vector3 randomPositionOffset;
    public Vector3 randomRotationAngles;

    public RectTransform rectTransform;

    void Start()
    {
        ApplyRandomTransform();
        text = targetText.text.ToString();
        targetText.text = " ";

        rectTransform = GetComponent<RectTransform>();

        StartCoroutine(RandomTextPrint());
    }

    void Update()
    {

    }

    IEnumerator RandomTextPrint()
    {
        while (true)
        {
            yield return StartCoroutine(textPrint(delay));

            // Generate a random delay for the next iteration
            float randomDelay = Random.Range(1f, 3f);
            yield return new WaitForSeconds(randomDelay);
        }
    }

    IEnumerator textPrint(float d)
    {
        ApplyRandomTransform();
        int count = 0;

        while (count != text.Length)
        {
            if (count < text.Length)
            {
                targetText.text += text[count].ToString();
                count++;
            }

            yield return new WaitForSeconds(delay);
        }

        yield return new WaitForSeconds(2f);

        targetText.text = "";

        yield return new WaitForSeconds(1f);
    }

    void ApplyRandomTransform()
    {
        randomPositionOffset = new Vector3(Random.Range(-850f, -850f), Random.Range(-480f, 480f), 0f);
        randomRotationAngles = new Vector3(0f, 0f, Random.Range(-40f, 40f));

        rectTransform.anchoredPosition = randomPositionOffset;
        rectTransform.localRotation = Quaternion.Euler(randomRotationAngles);
    }
}
