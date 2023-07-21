using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rigid2D;
    
    void Start()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        rigid2D.AddForce(Vector3.up * 270);
    }

    void Update()
    {
        //ÅÍÄ¡
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
