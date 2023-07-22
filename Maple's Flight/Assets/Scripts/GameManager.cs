using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BackEnd;


public class GameManager : MonoBehaviour
{
    [SerializeField]
    DailyRankRegister DailyRankRegister;
    public bool isPlaying = false; // �����ϴ� ������

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

    public void SetScore(int score) // ���� ��ŷ���� �ѱ��
    {
        DailyRankRegister.Process(score);

    }
}
