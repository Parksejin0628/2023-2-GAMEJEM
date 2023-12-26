using System.Collections;
using System.Collections.Generic;
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

        StartCoroutine(textPrint(delay));
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(textPrint(delay));
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

        // Add a delay before clearing the text
        yield return new WaitForSeconds(2f); // Adjust the delay time as needed

        targetText.text = ""; // Clear the text

        yield return new WaitForSeconds(1f);

    }

    void ApplyRandomTransform()
    {
        randomPositionOffset = new Vector3(Random.Range(-400f, 400f), Random.Range(-180f, 180f), 0f);
        randomRotationAngles = new Vector3(0f, 0f, Random.Range(-40f, 40f));

        // Apply the random offsets relative to RectTransform
        rectTransform.anchoredPosition = randomPositionOffset;

        // Use Quaternion.Euler to create a rotation quaternion from Euler angles
        rectTransform.localRotation = Quaternion.Euler(randomRotationAngles);
    }
}
