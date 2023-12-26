using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wave_time : MonoBehaviour
{
    Rigidbody2D rigid;
    public float UpWaveTime;
    public float DownWaveTime;
    public GameObject wave;
    bool isWave = true;
    
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        StartCoroutine(Move()); // Move 함수를 Coroutine으로 호출
    }

    void Update()
    {
        if (!isWave)
        {
            StartCoroutine(Move());
        }
    }

    IEnumerator Move()
    {
        while (true)
        {
            yield return new WaitForSeconds(UpWaveTime);
            this.transform.Translate(new Vector3(0, 3, 0));
            AudioManager.Inst.PlaySFX("ship_sound");
            Debug.Log("배소리");
            yield return new WaitForSeconds(DownWaveTime);
            this.transform.Translate(new Vector3(0, -1, 0));
            AudioManager.Inst.PlaySFX("water");
            Debug.Log("물내려가는소리");

            isWave = true;
        }
    }
}

