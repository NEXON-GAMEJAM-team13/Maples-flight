using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiaryController : MonoBehaviour
{
    [SerializeField]
    GameObject diary;
    [SerializeField]
    GameObject page;
    [SerializeField]
    GameObject log;

    [SerializeField]
    RectTransform ScrollContent;
    [SerializeField]
    GameObject[] Images;

    private void OnEnable()
    {
        // 엔딩 해금된 것만 켜기
        for (int i = 0; i < GameManager.endingCnt; i++)
        {
            if (GameManager.instance.isEndOpen(i))
                Images[i].transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    public void SetScrollViewPos()
    {
        ScrollContent.anchoredPosition = new Vector3(0, -932.2019f, 0);
    }

    public void ShowEndingPage(int idx)
    {
        if (GameManager.instance.ShowEnding(idx))
        {
            GameManager.instance.isDiary = true;
            diary.SetActive(false);
            page.SetActive(true);
        }
    }

    public void ExitEndingPage()
    {
        GameManager.instance.isDiary = false;
        diary.SetActive(true);
        page.SetActive(false);
    }
}
