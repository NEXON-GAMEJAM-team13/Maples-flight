using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayersPrefs : MonoBehaviour
{
    int beforeData;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("beforeData"))
        {
            beforeData = PlayerPrefs.GetInt("beforeData");
        }
    }

    public void Save()
    {

    }

    public void Load()
    {

    }
}
