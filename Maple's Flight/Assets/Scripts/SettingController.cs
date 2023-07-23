using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingController : MonoBehaviour
{
    [SerializeField]
    GameObject ingameCanvas;
    [SerializeField]
    GameObject video;
    [SerializeField]
    GameObject settingBtn;

    private void Update()
    {
        if (ingameCanvas.activeInHierarchy || (video && video.activeInHierarchy))
            settingBtn.SetActive(false);
        else
            settingBtn.SetActive(true);

    }
}
