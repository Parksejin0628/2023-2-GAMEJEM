using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class UIManager : MonoBehaviour
{

    bool SceneStart = false;
    public Image[] imageArray;
    public int currentIndex = 0;
    const int start_end = 1;
    // Start is called before the first frame update
    void Start()
    {
        SceneStart = true;

        SetActiveImage(currentIndex);
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneStart)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (currentIndex >= start_end)
                {
                    imageArray[currentIndex].gameObject.SetActive(false);
                    SceneStart = false;
                }
                else
                {
                    currentIndex++;
                    SetActiveImage(currentIndex);
                    Debug.Log(currentIndex);
                }
            }
        }
    }

    // ���� �ε����� �ش��ϴ� �̹����� Ȱ��ȭ�ϰ� �������� ��Ȱ��ȭ
    void SetActiveImage(int index)
    {
        for (int i = 0; i < imageArray.Length; i++)
        {
            if (i == index)
                imageArray[i].gameObject.SetActive(true);
            else
                imageArray[i].gameObject.SetActive(false);
        }
    }
}