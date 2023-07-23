using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BackEnd;


public class GameManager : MonoBehaviour
{
    [SerializeField]
    DailyRankRegister DailyRankRegister;
    public EndingController EndingController;
    [SerializeField]
    bool[] isOpenedEnding = { false, false, false, false, false, false, false, false, false, false };

    public bool isPlaying = false; // �����ϴ� ������
    public int nowEnding;

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

    public void Ending(int endNum)
    {
        isOpenedEnding[endNum] = true;
        nowEnding = endNum;
    }

    public void SetRank(int score)
    {
        DailyRankRegister.Process(score);
    }

    public void SetNowScore(int score)
    {
        DailyRankRegister.GameData.nowScore = score;
    }

    public int GetNowScore()
    {
        return DailyRankRegister.GameData.nowScore;
    }

    public int SetBestScore(int score)
    {
        if (score > DailyRankRegister.GameData.bestScore)
            DailyRankRegister.GameData.bestScore = score;
        return DailyRankRegister.GameData.bestScore;
    }
}
