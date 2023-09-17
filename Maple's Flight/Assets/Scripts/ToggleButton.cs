using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleButton : MonoBehaviour
{
    [SerializeField]
    bool[] soundActive;

    [SerializeField]
    GameObject[] toggle = new GameObject[2];

    [SerializeField]
    Image[] statusImage;
    [SerializeField]
    Sprite on;
    [SerializeField]
    Sprite off;

    void Awake()
    {
        for (int i = 0; i < 2; i++)
        {
            soundActive[i] = true;
            statusImage[i].sprite = on;
        }
    }

    public void SoundBtnClk(int val) // 0: BGM, 1:SFX
    {
        float togglePos = 0;

        if (soundActive[val]) // 켜져있다면
        {
            soundActive[val] = false; // 끄기
            togglePos = 99.32f; // 토글 위치 지정
            statusImage[val].sprite = off;

            // 볼륨 조절 메소드 삽입 필요
        }
        else
        {
            soundActive[val] = true;
            togglePos = 189.7f;
            statusImage[val].sprite = on;

            // 볼륨 조절 메소드 삽입 필요
        }

        // 동그라미 위치 이동
        toggle[val].transform.localPosition = new Vector3(togglePos, toggle[val].transform.localPosition.y, toggle[val].transform.localPosition.z);
    }
}
