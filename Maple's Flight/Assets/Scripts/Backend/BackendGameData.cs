using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using BackEnd;

public class BackendGameData : MonoBehaviour
{
    [System.Serializable]
    public class GameDataLoadEvent : UnityEvent { }
    public GameDataLoadEvent onGameDataLoadEvent = new GameDataLoadEvent();

    private static BackendGameData instance = null;
    public static BackendGameData Instance
    {
        get
        {
            if (instance == null)
                instance = new BackendGameData();
            return instance;
        }
        
    }

    private GameData gameData = new GameData();
    public GameData GameData => gameData;

    private string gameDataRowInDate = string.Empty;

    public void GameDataInsert()
    {
        gameData.Reset();
        Param param = new Param()
        {
            { "nowScore", gameData.nowScore },
            { "bestScore", gameData.bestScore }
        };

        Backend.GameData.Insert(Constants.USER_DATA_TABLE, param, callback =>
        {
            if (callback.IsSuccess())
            {
                gameDataRowInDate = callback.GetInDate();
                Debug.Log($"���� ���� ������ ���� ���� : {callback}");
            }
            else
            {
                // ����
                Debug.LogError("�������� ���� ����");
            }
        });
    }

    public void GameDataUpdate(UnityAction action=null)
    {
        if (gameData == null) return;

        Param param = new Param()
        {
            { "nowScore", gameData.nowScore },
            { "bestScore", gameData.bestScore }
        };

        if (string.IsNullOrEmpty(gameDataRowInDate))
            Debug.Log("����");
    }
}
