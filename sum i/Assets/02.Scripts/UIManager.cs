using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;



public class UIManager : MonoBehaviour
{
    //UIManager�� �ʿ��� �⺻ ����
    static public UIManager instance;
    public GameObject player;
    private PlayerCtrl playerCtrl;


    //
    bool SceneStart = false;
    public Image[] imageArray;
    public int currentIndex = 0;
    const int start_end = 1;
    //hp�� ���õ� ����
    public GameObject[] hpEmptyObject;

    // Start is called before the first frame update

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        SceneStart = true;
        SetActiveImage(currentIndex);
        playerCtrl = player.GetComponent<PlayerCtrl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneStart)
        {
            if (Keyboard.current.spaceKey.wasPressedThisFrame)
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
        UpdateHpUI();
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

    void UpdateHpUI()
    {
        for(int i=0; i<playerCtrl.maxHp; i++)
        {
            if(playerCtrl.currentHp <= i)
            {
                hpEmptyObject[i].SetActive(true);
            }
            else
            {
                hpEmptyObject[i].SetActive(false);
            }
        }
    }
}