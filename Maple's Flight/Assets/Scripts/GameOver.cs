using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOver : MonoBehaviour
{
    [Header("=광고=")]
    [SerializeField]
    AdmobManager AdmobManager;

    [Header("=엔딩=")]
    [SerializeField]
    Image thumbnail;
    [SerializeField]
    TextMeshProUGUI titleTxt;
    [SerializeField]
    TextMeshProUGUI descTxt;
    [Header("=그 외=")]
    [SerializeField]
    GameObject retryBtn;

    private void OnEnable()
    {
        GameManager.instance.Save();

        thumbnail.sprite = GameManager.instance.EndingController.GetEndingImage(GameManager.instance.endingNow);
        titleTxt.text = GameManager.instance.EndingController.GetEndingTitleText(GameManager.instance.endingNow);
        descTxt.text = GameManager.instance.EndingController.GetEndingDescText(GameManager.instance.endingNow);

        Invoke("RetryAble", 0.5f);

        int rand = Random.Range(0, 3); // 0 1 2
        Debug.Log(rand);
        if (rand == 2) // 1/3 확률로 광고 띄우기
        {
            AdmobManager.LoadInterstitialAd();
            AdmobManager.ShowInterstitialAd();
        }
    }

    void RetryAble()
    {
        retryBtn.GetComponent<Button>().interactable = true;
    }
}
