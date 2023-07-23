using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoController : MonoBehaviour
{
    [SerializeField]
    GameObject raw;
    [SerializeField]
    SoundManager soundManager;
    [SerializeField]
    GameObject skipBtn;

    private void OnEnable()
    {
        Invoke("dest", 44f);
        Debug.Log("����");
    }

    public void dest()
    {
        Destroy(this.gameObject);
        raw.SetActive(false);
        skipBtn.SetActive(false);
        Debug.Log("�����");

        Debug.Log("SoundPlaying:" + soundManager.soundPlaying);
        soundManager.soundPlaying = true;
    }
}
