using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    [SerializeField]
    Transform[] sky;
    [SerializeField]
    float skySpeed;
    [SerializeField]
    Transform[] cloud;
    [SerializeField]
    float cloudSpeed;
    [SerializeField]
    Transform[] mountain;
    [SerializeField]
    float mountainSpeed;
    [SerializeField]
    Transform[] ground;
    [SerializeField]
    float groundSpeed; // �ٴ��� ��ֹ� �ӵ���..

    void Update()
    {
        if (GameManager.instance.isPlaying)
        {
            BGMove();
        }
    }

    void BGMove()
    {
        for (int i = 0; i <= 1; i++)
        {
            sky[i].Translate(Vector3.right * skySpeed * Time.deltaTime * -1);
            cloud[i].Translate(Vector3.right * cloudSpeed * Time.deltaTime * -1);
            mountain[i].Translate(Vector3.right * mountainSpeed * Time.deltaTime * -1);
            ground[i].Translate(Vector3.right * groundSpeed * Time.deltaTime * -1);

            if (sky[i].localPosition.x < -1600)
                sky[i].localPosition = new Vector3(sky[i].localPosition.x + 4000, sky[i].localPosition.y, sky[i].localPosition.z);
            if (cloud[i].localPosition.x < -1600)
                cloud[i].localPosition = new Vector3(cloud[i].localPosition.x + 4000, cloud[i].localPosition.y, cloud[i].localPosition.z);
            if (mountain[i].localPosition.x < -1600)
                mountain[i].localPosition = new Vector3(mountain[i].localPosition.x + 4000, mountain[i].localPosition.y, mountain[i].localPosition.z);
            if (ground[i].localPosition.x < -1600)
                ground[i].localPosition = new Vector3(ground[i].localPosition.x + 4000, ground[i].localPosition.y, ground[i].localPosition.z);
        }


    }
}
