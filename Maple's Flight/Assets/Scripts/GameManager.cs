using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    DailyRankRegister DailyRankRegister;
    public bool isPlaying = false; // 게임하는 중인지

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

    public void SetScore(int score) // 점수 랭킹으로 넘기기
    {
        DailyRankRegister.Process(score);
    }
}
