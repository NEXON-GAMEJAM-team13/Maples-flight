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

    void OnEnable() 
    {
        // 위치 초기화, 힘 주기
        transform.localPosition = new Vector3(-498, 1252, transform.localPosition.z);
        rigid2D.AddForce(Vector3.right * 50);
    }

    void Update()
    {
        // 조절
        if (transform.localPosition.x > -330f)
        {
            transform.Translate(Vector3.right * resetSpeed * -1 * Time.deltaTime);
        }

        // 아웃
        if (transform.localPosition.y > 1400f || transform.localPosition.x > 650f)
        {
            GameManager.instance.SetEnding(0);
            GameOver();
        }

        if (transform.localPosition.y < -700f)
        {
            int score = GameManager.instance.scoreNow;

            if (score <= 15)
                GameManager.instance.SetEnding(7);
            else if (score <= 30)
                GameManager.instance.SetEnding(8);
            else if (score <= 45)
                GameManager.instance.SetEnding(9);
            else if (score <= 60)
                GameManager.instance.SetEnding(10);
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
        if (collision.CompareTag("Tree"))
        {
            GameManager.instance.SetEnding(2);
            GameOver();
        }
        else if (collision.CompareTag("Stone"))
        {
            GameManager.instance.SetEnding(3);
            GameOver();
        }
        else if (collision.CompareTag("Branch"))
        {
            GameManager.instance.SetEnding(1);
            GameOver();
        }
        else if (collision.CompareTag("rabbit"))
        {
            GameManager.instance.SetEnding(6);
            GameOver();
        }
        else if (collision.CompareTag("bird"))
        {
            GameManager.instance.SetEnding(4);
            GameOver();
        }
        else if (collision.CompareTag("squirrel"))
        {
            GameManager.instance.SetEnding(5);
            GameOver();
        }
        else
            Debug.Log("뭐에 부딫힘?");
    }
}
