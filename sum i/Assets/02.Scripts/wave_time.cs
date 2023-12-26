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
        StartCoroutine(Move()); // Move �Լ��� Coroutine���� ȣ��
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
            Debug.Log("��Ҹ�");
            yield return new WaitForSeconds(DownWaveTime);
            this.transform.Translate(new Vector3(0, -1, 0));
            AudioManager.Inst.PlaySFX("water");
            Debug.Log("���������¼Ҹ�");

            isWave = true;
        }
    }
}

