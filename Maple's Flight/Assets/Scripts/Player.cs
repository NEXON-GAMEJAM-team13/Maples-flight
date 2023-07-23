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

    void OnEnable() // ��ũ��Ʈ Ȱ��ȭ�� ������ ����
    {
        transform.localPosition = new Vector3(-498, 1252, transform.localPosition.z); // ��ġ �ʱ�ȭ
        rigid2D.AddForce(Vector3.right * 50);

    }

    void Update()
    {
        if (transform.localPosition.y > 1400f)
        {
            GameManager.instance.Ending(0);
            GameOver();
        }

        if (transform.localPosition.y < -700f)
        {
            if (GameManager.instance.GetNowScore() <= 15)
                GameManager.instance.Ending(7);
            else if (GameManager.instance.GetNowScore() <= 30)
                GameManager.instance.Ending(8);
            else if (GameManager.instance.GetNowScore() <= 45)
                GameManager.instance.Ending(9);
            else if (GameManager.instance.GetNowScore() <= 60)
                GameManager.instance.Ending(10);
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
            GameManager.instance.Ending(2);
            GameOver();
        }
        else if (collision.CompareTag("Stone"))
        {
            GameManager.instance.Ending(3);
            GameOver();
        }
        else if (collision.CompareTag("Branch"))
        {
            GameManager.instance.Ending(1);
            GameOver();
        }
        else if (collision.CompareTag("rabbit"))
        {
            GameManager.instance.Ending(6);
            GameOver();
        }
        else if (collision.CompareTag("bird"))
        {
            GameManager.instance.Ending(4);
            GameOver();
        }
        else if (collision.CompareTag("squirrel"))
        {
            GameManager.instance.Ending(5);
            GameOver();
        }
        else
            Debug.Log("뭐에 부딫힘?");
    }





}
