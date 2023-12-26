using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class CutSceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int currentCutIndex = 0;
    public string nextSceneName;
    public GameObject[] cutScenes;
    void Start()
    {
        AudioManager.Inst.PlaySFX("DoneSong__Island_Kid");
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.anyKeyDown && currentCutIndex < cutScenes.Length)
        {
            cutScenes[currentCutIndex].SetActive(false);
            currentCutIndex++;
        }
        if (currentCutIndex == cutScenes.Length)
        {
            SceneManager.LoadScene(nextSceneName);
            AudioManager.Inst.StopAllSFX();
        }

    }
}
