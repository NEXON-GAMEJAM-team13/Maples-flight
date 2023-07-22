using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    DailyRankRegister DailyRankRegister;
    public bool isGameOver = true;

    public static GameManager instance = null;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
            Destroy(gameObject);
    }

    //private GameData gameData = new GameData();
    //public GameData GameData => gameData;

    public void SetScore(int score)
    {
        //GameData.nowScore = score;
        //if (score > GameData.bestScore)
        //    GameData.bestScore = score;
        DailyRankRegister.Process(score);
    }
    /*
    public void PlusScore()
    {
        GameData.nowScore += 10;
        GameData.bestScore += 10;
        BackendGameData.Instance.GameDataUpdate();
    }*/
}
