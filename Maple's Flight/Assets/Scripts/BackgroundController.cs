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
    //GameObject ground; // �ٴ��� ��ֹ� �ӵ��� => Obstacles���� ����

    void Update()
    {
        if (GameManager.instance.isPlaying)
        {
            sky.Translate(Vector3.right * skySpeed * Time.deltaTime);
        }
    }
}
