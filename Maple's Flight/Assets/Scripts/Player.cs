using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rigid2D;
    [SerializeField]
    float resetSpeed = 0.5f;
    
    void Start()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        rigid2D.AddForce(Vector3.right * 50);
    }

    void Update()
    {
        if (transform.localPosition.x > - 330f)
        {
            transform.Translate(Vector3.right * resetSpeed * -1 * Time.deltaTime);
        }
        //ÅÍÄ¡
        //if ((Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began) || Input.GetMouseButtonDown(0))
        //{
            
        //}
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
}
