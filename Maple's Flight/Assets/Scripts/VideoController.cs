using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoController : MonoBehaviour
{
    [SerializeField]
    GameObject raw;
    [SerializeField]
    SoundManager soundManager;

    private void OnEnable()
    {
        Invoke("dest", 44f);
        Debug.Log("����");
    }

    private void dest()
    {
        Destroy(this.gameObject);
        raw.SetActive(false);
        Debug.Log("�����");

        Debug.Log("SoundPlaying:" + soundManager.soundPlaying);
        soundManager.soundPlaying = true;
    }
}
