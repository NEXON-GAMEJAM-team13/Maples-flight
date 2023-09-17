using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOver : MonoBehaviour
{
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

        Invoke("RetryAble", 1f);
    }

    void RetryAble()
    {
        retryBtn.GetComponent<Button>().interactable = true;
    }
}
