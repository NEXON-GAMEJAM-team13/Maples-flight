using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiaryController : MonoBehaviour
{
    [SerializeField]
    GameObject[] Images;
    private void OnEnable()
    {
        for (int i=0; i<11; i++)
        {
            if (GameManager.instance.isEndOpen(i))
                Images[i].transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
