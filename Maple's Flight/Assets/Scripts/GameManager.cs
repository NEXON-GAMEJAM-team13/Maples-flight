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
    public bool isNewScore;
    public bool isNewEnd;
    [Header("=저장 여부=")]
    [SerializeField]
    bool isSaveMode;

    public static GameManager instance = null;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
            Destroy(gameObject);

        Load();
    }

    public void SetRank(int score)
    {
        DailyRankRegister.Process(score);
    }

    #region 엔딩 관련
    public void SetEnding(int endNum) // 게임 오버 시 엔딩 번호 설정
    {
        if (!DailyRankRegister.GameData.isOpenedEnding[endNum])
        {
            DailyRankRegister.GameData.isOpenedEnding[endNum] = true;
            isNewEnd = true;
        }
        else
            isNewEnd = false;
        endingNow = endNum;
    }

    public bool ShowEnding(int endNum) // 엔딩 불러오기
    {
        if (DailyRankRegister.GameData.isOpenedEnding[endNum])
        {
            endingNow = endNum;
            return true;
        }
        return false;
    }

    public void SetEndingOpen(int idx, bool isOpen) // 엔딩 해금 설정
    {
        DailyRankRegister.GameData.isOpenedEnding[idx] = isOpen;
    }

    public bool isEndOpen(int val) // 엔딩 해금 여부 확인
    {
        return DailyRankRegister.GameData.isOpenedEnding[val];
    }
    #endregion

    #region 점수 관련
    public void SetNowScore(int score)
    {
        DailyRankRegister.GameData.nowScore = score;
    }

    public int GetNowScore()
    {
        return DailyRankRegister.GameData.nowScore;
    }

    public void SetBestScore(int score)
    {
        if (score > DailyRankRegister.GameData.bestScore)
        {
            DailyRankRegister.GameData.bestScore = score;
            isNewScore = true;
        }
        else
            isNewScore = false;
    }

    public int GetBestScore()
    {
        return DailyRankRegister.GameData.bestScore;
    }
    #endregion

    public void Save()
    {
        Debug.Log("저장 시도");
        if (isSaveMode)
        {
            Debug.Log("저장 중");
            // 최고 점수 갱신, 새 엔딩 해금 때 저장
            PlayerPrefs.SetInt("BestScore", DailyRankRegister.GameData.bestScore);
            // 코드 지지..
            PlayerPrefs.SetInt("Ending_0", DailyRankRegister.GameData.isOpenedEnding[0] == true ? 1 : 0);
            PlayerPrefs.SetInt("Ending_1", DailyRankRegister.GameData.isOpenedEnding[1] == true ? 1 : 0);
            PlayerPrefs.SetInt("Ending_2", DailyRankRegister.GameData.isOpenedEnding[2] == true ? 1 : 0);
            PlayerPrefs.SetInt("Ending_3", DailyRankRegister.GameData.isOpenedEnding[3] == true ? 1 : 0);
            PlayerPrefs.SetInt("Ending_4", DailyRankRegister.GameData.isOpenedEnding[4] == true ? 1 : 0);
            PlayerPrefs.SetInt("Ending_5", DailyRankRegister.GameData.isOpenedEnding[5] == true ? 1 : 0);
            PlayerPrefs.SetInt("Ending_6", DailyRankRegister.GameData.isOpenedEnding[6] == true ? 1 : 0);
            PlayerPrefs.SetInt("Ending_7", DailyRankRegister.GameData.isOpenedEnding[7] == true ? 1 : 0);
            PlayerPrefs.SetInt("Ending_8", DailyRankRegister.GameData.isOpenedEnding[8] == true ? 1 : 0);
            PlayerPrefs.SetInt("Ending_9", DailyRankRegister.GameData.isOpenedEnding[9] == true ? 1 : 0);
            PlayerPrefs.SetInt("Ending_10", DailyRankRegister.GameData.isOpenedEnding[10] == true ? 1 : 0);
        }
    }

    public void Load()
    {
        Debug.Log("로드 시도");
        if (isSaveMode && PlayerPrefs.HasKey("BestScore"))
        {
            Debug.Log("로드 중");
            SetBestScore(PlayerPrefs.GetInt("BestScore"));
            SetEndingOpen(0, PlayerPrefs.GetInt("Ending_0") == 1 ? true : false);
            SetEndingOpen(1, PlayerPrefs.GetInt("Ending_1") == 1 ? true : false);
            SetEndingOpen(2, PlayerPrefs.GetInt("Ending_2") == 1 ? true : false);
            SetEndingOpen(3, PlayerPrefs.GetInt("Ending_3") == 1 ? true : false);
            SetEndingOpen(4, PlayerPrefs.GetInt("Ending_4") == 1 ? true : false);
            SetEndingOpen(5, PlayerPrefs.GetInt("Ending_5") == 1 ? true : false);
            SetEndingOpen(6, PlayerPrefs.GetInt("Ending_6") == 1 ? true : false);
            SetEndingOpen(7, PlayerPrefs.GetInt("Ending_7") == 1 ? true : false);
            SetEndingOpen(8, PlayerPrefs.GetInt("Ending_8") == 1 ? true : false);
            SetEndingOpen(9, PlayerPrefs.GetInt("Ending_9") == 1 ? true : false);
            SetEndingOpen(10, PlayerPrefs.GetInt("Ending_10") == 1 ? true : false);
        }
    }
}
