using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoController : MonoBehaviour
{
    [SerializeField]
    GameObject raw;
    
    [SerializeField]
    GameObject skipBtn;

    private void OnEnable()
    {
        Invoke("dest", 44f);
        Debug.Log("Video playing");
        
    }

    public void dest()
    {
        Destroy(this.gameObject);
        raw.SetActive(false);
        skipBtn.SetActive(false);
        Debug.Log("�����");
        SoundManager.Instance.BGMClicked();
    }
}
