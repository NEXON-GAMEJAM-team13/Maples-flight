using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingController : MonoBehaviour
{
    [SerializeField]
    GameObject ingameCanvas;
    [SerializeField]
    GameObject settingBtn;

    private void Update()
    {
        settingBtn.SetActive(!ingameCanvas.activeInHierarchy);
        
    }
}
