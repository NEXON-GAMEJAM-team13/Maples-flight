using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rigid2D;
    public float speed;
    private float defaultSpeed;

    Vector3 newVec;
    void Start()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        // rigid2D.AddForce(Vector3.up * 270);
        defaultSpeed = 5f;

        speed = defaultSpeed;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            BackendGameData.Instance.UserGameData.timeCount += 1;
            Debug.Log("1점 상승");

        }
        // if (speed > defaultSpeed)
        // {
        //     speed -= 1f * Time.deltaTime;
        // }
        // newVec = transform.position;
        // newVec.x += speed * Time.deltaTime;
        // transform.position = newVec;
        //��ġ
        //if ((Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began) || Input.GetMouseButtonDown(0))
        //{

        //}
    }

    public void UpBtn()
    {
        rigid2D.velocity = Vector3.zero;
        rigid2D.AddForce(Vector3.up * 270);
    }

    public void FastBtn()
    {
        rigid2D.velocity = Vector3.zero;
        rigid2D.AddForce(Vector3.right * 100);
    }





}
