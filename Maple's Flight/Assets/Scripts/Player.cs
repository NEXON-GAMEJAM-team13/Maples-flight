using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rigid2D;
    [SerializeField]
    float resetSpeed = 0.5f;
    [SerializeField]
    Obstacles Obstacles;
    
    void Awake()
    {
        rigid2D = GetComponent<Rigidbody2D>();
    }

    void OnEnable() // 스크립트 활성화될 때마다 실행
    {
        transform.localPosition = new Vector3(-498, 1252, transform.localPosition.z); // 위치 초기화
        rigid2D.AddForce(Vector3.right * 50);
    }

    void Update()
    {
        if (transform.localPosition.x > - 330f)
        {
            transform.Translate(Vector3.right * resetSpeed * -1 * Time.deltaTime);
        }

        if (transform.localPosition.y < -1240f)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        GameManager.instance.isPlaying = false;
        Obstacles.GameOver();
        gameObject.SetActive(false);
    }

    public void UpBtn()
    {
        rigid2D.velocity = Vector3.zero;
        rigid2D.AddForce(Vector3.up * 200);
    }

    public void FastBtn()
    {
        rigid2D.velocity = Vector3.zero;
        rigid2D.AddForce(Vector3.right * 80);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            Debug.Log("장애물 충돌~");
            GameOver();
        }
    }
}
