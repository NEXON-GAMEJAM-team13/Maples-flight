using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOver : MonoBehaviour
{
    [SerializeField]
    Image thumbnail;
    [SerializeField]
    TextMeshProUGUI titleTxt;
    [SerializeField]
    TextMeshProUGUI descTxt;
    [SerializeField]
    GameObject retryBtn;
    

    private void OnEnable()
    {
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
