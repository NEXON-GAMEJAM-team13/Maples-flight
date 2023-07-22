using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    [SerializeField]
    Transform sky;
    [SerializeField]
    float skySpeed;
    [SerializeField]
    Transform cloud;
    [SerializeField]
    float cloudSpeed;
    [SerializeField]
    Transform mountain;
    [SerializeField]
    float mountainSpeed;
    //[SerializeField]
    //GameObject ground; // 바닥은 장애물 속도로 => Obstacles에서 관리

    void Update()
    {
        if (GameManager.instance.isPlaying)
        {
            sky.Translate(Vector3.right * skySpeed * Time.deltaTime);
        }
    }
}
