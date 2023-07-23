using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Obstacles : MonoBehaviour
{
    [Header("=점수=")]
    [SerializeField]
    TextMeshProUGUI time_txt;
    [SerializeField]
    TextMeshProUGUI nowScore_txt;
    [SerializeField]
    TextMeshProUGUI bestScore_txt;
    [SerializeField]
    GameObject gameOverPanel;

    [Header("=시간=")]
    [SerializeField]
    float stageTime;  // 현재 시간
    [SerializeField]
    float obsCycle; // 다음 장애물 생성 주기
    [SerializeField]
    float nextTime; // 다음 장애물 등장 시간

    [Header("=동물 친구들=")]
    [SerializeField]
    GameObject[] animalPref;
    [SerializeField]
    GameObject animals;
    [SerializeField]
    Transform aniParent;

    [Header("=상하단 장애물=")]
    [SerializeField]
    GameObject[] obstaclePref;
    [SerializeField]
    GameObject[] obstacles = new GameObject[5];
    [SerializeField]
    Transform obsParent;
    [SerializeField] 
    int idx;
    [SerializeField] 
    float speed;

    [SerializeField]
    Image btn;

    public void GameStart()
    {
        for (int i = 0; i < 3; i++)
            gameOverPanel.transform.parent.GetChild(i).gameObject.SetActive(true);

        GameManager.instance.isPlaying = true;
        stageTime = 0;
        nextTime = 0;
        StartCoroutine("Timer");
    }

    void Update()
    {
        if (GameManager.instance.isPlaying)
        {
            time_txt.text = ((int)(stageTime / 10)).ToString();
            MakeObstacles();
        }
    }

    public void GameOver()
    {
        StopAllCoroutines();
        Debug.Log("게임오버~");

        for (int i = 0; i < obsParent.childCount; i++)
        {
            Destroy(obsParent.GetChild(i).gameObject);
        }
        if (animals)
            Destroy(animals.gameObject);

        obsParent.gameObject.SetActive(false);
        gameOverPanel.SetActive(true);

        for (int i=0; i<3; i++)
            gameOverPanel.transform.parent.GetChild(i).gameObject.SetActive(false);

        int score = (int)(stageTime / 10);
        GameManager.instance.SetRank(score);
        nowScore_txt.text = score.ToString();
        GameManager.instance.SetNowScore(score);
        bestScore_txt.text = GameManager.instance.SetBestScore(score).ToString();
    }

    void MakeObstacles()
    {
        if (Time.timeScale == 0)
            return;

        if (stageTime > nextTime)
        {
            nextTime = stageTime + obsCycle;
            int obsIdx = Random.Range(0, obstaclePref.Length); // 0, obstaclePref.Length
            obstacles[idx] = Instantiate(obstaclePref[obsIdx], Vector3.zero, Quaternion.identity);
            obstacles[idx].transform.SetParent(obsParent);
            obstacles[idx].transform.localScale = new Vector3(0.8f, 0.8f, 0f);
            obstacles[idx].transform.localPosition = new Vector3(840f, GetYPos(obsIdx), 0f);

            
            if (obsIdx == 0 && !animals) // 0번 장애물일 때 토끼 등장 확률 유
            {
                //int upIdx = Random.Range(0, animalPref.Length);
                //animalPref[upIdx]
                animals = Instantiate(animalPref[0], Vector3.zero, Quaternion.identity);
                animals.transform.SetParent(aniParent);
                animals.transform.localScale = new Vector3(100f, 100f, 0f);
                animals.transform.localPosition = new Vector3(821, 53, -1);
            }
            else if (obsIdx == 1 && !animals) // 1번 장애물일 때 새 등장 확률 유
            {
                animals = Instantiate(animalPref[1], Vector3.zero, Quaternion.identity);
                animals.transform.SetParent(aniParent);
                animals.transform.localScale = new Vector3(100f, 100f, 0f);
                animals.transform.localPosition = new Vector3(945, -150, -1);
            }
            else if (obsIdx == 4 && !animals) // 4번 장애물일 때 다람쥐 등장 확률 유
            {
                animals = Instantiate(animalPref[2], Vector3.zero, Quaternion.identity);
                animals.transform.SetParent(aniParent);
                animals.transform.localScale = new Vector3(100f, 100f, 0f);
                animals.transform.localPosition = new Vector3(940, -100, -1);
            }

            if (++idx == 5) idx = 0;
        }

        for (int i = 0; i < 5; i++)
        {
            if (obstacles[i])
            {
                obstacles[i].transform.Translate(-0.3f * speed * Time.deltaTime, 0, 0);
                if (obstacles[i].transform.localPosition.x < -2400f)
                {
                    Destroy(obstacles[i]);
                }
            }
        }

        if (animals)
        {
            animals.transform.Translate(-0.3f * speed * Time.deltaTime, 0, 0);
            if (animals.transform.localPosition.x < -2000f)
            {
                Destroy(animals);
            }
        }
        
    }

    int GetYPos(int obsIdx)
    {
        int diff = 10;
        switch (obsIdx)
        {
            // 나무
            case 0:
                return -371 + diff;
            case 1:
                return -461 + diff;
            case 2:
                return -301 + diff;
            // 돌
            case 3:
                return -410 + diff;
            case 4:
                return -471 + diff;
            case 5:
                return -558 + diff;
            // 나뭇가지
            case 6:
                return 1249 - diff * 2;
            case 7:
                return 1128 - diff * 4;
            default:
                return 0;
        }
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(0.1f);
        stageTime++;
        StartCoroutine(Timer());
    }

    void MoveBtn()
    {
        btn.GetComponent<RectTransform>().transform.localPosition = new Vector3(btn.GetComponent<RectTransform>().transform.localPosition.x + 10, btn.GetComponent<RectTransform>().transform.localPosition.y, btn.GetComponent<RectTransform>().transform.localPosition.z);
    }
}
