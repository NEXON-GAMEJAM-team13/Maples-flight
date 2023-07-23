using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleButton : MonoBehaviour
{
    public Sprite on;
    public Sprite off;

    [SerializeField]
    bool[] soundActive;
    [SerializeField]
    Button[] btn = new Button[2];
    [SerializeField]
    Image[] statusImage;

    void Awake()
    {
        for (int i = 0; i < 2; i++)
        {
            soundActive[i] = true;
            statusImage[i].sprite = on;
        }
    }

    public void SoundBtnClk(int val) //0 1
    {
        if (SoundManager.Instance.toggleActive[val])
        {
            btn[val].transform.localPosition = new Vector3(90, btn[val].transform.localPosition.y, btn[val].transform.localPosition.z);
            // soundActive[val] = false;
            SoundManager.Instance.toggleActive[val] = false;

            statusImage[val].sprite = off;




        }
        else
        {
            Debug.Log("BGMOFF");
            btn[val].transform.localPosition = new Vector3(190, btn[val].transform.localPosition.y, btn[val].transform.localPosition.z);
            // soundActive[val] = true;
            SoundManager.Instance.toggleActive[val] = true;
            statusImage[val].sprite = on;

            //volume ㅈㅗㅈㅓㄹㅎㅏㄴㅡㄴ ㅁㅔㅅㅗㄷㅡ ㅅㅏㅂㅇㅣㅂ
        }
    }

}
