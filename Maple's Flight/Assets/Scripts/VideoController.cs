using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoController : MonoBehaviour
{
    [SerializeField]
    GameObject raw;

    private void OnEnable()
    {
        Invoke("dest", 43f);
        Debug.Log("����");
    }

    private void dest()
    {
        Destroy(this.gameObject);
        raw.SetActive(false);
        Debug.Log("�����");
    }
}
