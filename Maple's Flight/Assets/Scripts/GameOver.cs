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
    [SerializeField]
    GameObject newScore;
    [SerializeField]
    GameObject newEnd;

    private void OnEnable()
    {
        thumbnail.sprite = GameManager.instance.EndingController.GetEndingImage(GameManager.instance.endingNow);
        titleTxt.text = GameManager.instance.EndingController.GetEndingTitleText(GameManager.instance.endingNow);
        descTxt.text = GameManager.instance.EndingController.GetEndingDescText(GameManager.instance.endingNow);

        Invoke("RetryAble", 1f);

        CheckNew();

        GameManager.instance.Save();
    }

    void RetryAble()
    {
        retryBtn.GetComponent<Button>().interactable = true;
    }

    void CheckNew()
    {
        if (GameManager.instance.isNewScore)
            newScore.SetActive(true);
        if (GameManager.instance.isNewEnd)
            newEnd.SetActive(true);

        Debug.Log(GameManager.instance.isNewScore);
        Debug.Log(GameManager.instance.isNewEnd);
    }
}
