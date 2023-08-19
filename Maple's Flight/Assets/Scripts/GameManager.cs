using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BackEnd;


public class GameManager : MonoBehaviour
{
    [SerializeField]
    DailyRankRegister DailyRankRegister;
    public EndingController EndingController;

    public bool isPlaying = false; // 게임중인지
    public bool isDiary = false; // 도감 보는 중인지
    public static int endingCnt = 11;
    public int scoreNow;
    public int endingNow;

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


    public void SetEnding(int endNum)
    {
        if (!DailyRankRegister.GameData.isOpenedEnding[endNum])
            DailyRankRegister.GameData.isOpenedEnding[endNum] = true;
        endingNow = endNum;
    }

    public bool ShowEnding(int endNum)
    {
        if (DailyRankRegister.GameData.isOpenedEnding[endNum])
        {
            endingNow = endNum;
            return true;
        }
        return false;
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

    public bool isEndOpen(int val)
    {
        return DailyRankRegister.GameData.isOpenedEnding[val];
    }
}
