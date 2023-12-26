using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wave_time : MonoBehaviour
{
    private GameObject cameraObject;
    Rigidbody2D rigid;
    public float UpWaveTime;
    public float DownWaveTime;
    public float UpWaveLength;
    public float DownWaveLength;
    public GameObject wave;
    public int waveTurn = 0;
    public int maxWaveTurn = 7;
    
    // Start is called before the first frame update
    void Start()
    {
        cameraObject = GameObject.Find("Main Camera");
        rigid = GetComponent<Rigidbody2D>();
        StartCoroutine(Move()); // Move 함수를 Coroutine으로 호출
    }

    void Update()
    {
        transform.position = new Vector3(cameraObject.transform.position.x, transform.position.y, transform.position.z);
    }

    IEnumerator Move()
    {
        while (true)
        {
            yield return new WaitForSeconds(UpWaveTime);
            if (waveTurn == maxWaveTurn)
            {
                UpWaveLength = 99;
            }
            this.transform.Translate(new Vector3(0, UpWaveLength, 0));
            AudioManager.Inst.PlaySFX("ship_sound");
            Debug.Log("배소리");
            yield return new WaitForSeconds(DownWaveTime);
            this.transform.Translate(new Vector3(0, DownWaveLength, 0));
            AudioManager.Inst.PlaySFX("water");
            Debug.Log("물내려가는소리");

            waveTurn++;
        }
    }
}

