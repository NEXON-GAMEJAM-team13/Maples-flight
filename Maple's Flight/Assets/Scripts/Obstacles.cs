using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Obstacles : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI time_txt;
    [SerializeField]
    GameObject gameOverPanel;
    [SerializeField]
    TextMeshProUGUI nowScore_txt;
    [SerializeField]
    TextMeshProUGUI bestScore_txt;

    [SerializeField]
    float stageTime;  // 현재 시간
    [SerializeField]
    float obsCycle = 5f; // 다음 장애물 생성 주기
    [SerializeField]
    float nextTime; // 다음 장애물 등장 시간
    //[SerializeField]
    //float desTime;    //목표 시간

    [SerializeField]
    GameObject[] obstacle;
    [SerializeField]
    GameObject[] obstacles = new GameObject[5];
    [SerializeField]
    Transform obsParent;
    [SerializeField] 
    int idx;
    [SerializeField] 
    float speed;

    public void GameStart()
    {
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
        obsParent.gameObject.SetActive(false);

        GameManager.instance.SetScore((int)(stageTime / 10));
        gameOverPanel.SetActive(true);
        
        nowScore_txt.text = ((int)(stageTime / 10)).ToString();
        bestScore_txt.text = ((int)(stageTime / 10)).ToString();
    }

    void MakeObstacles()
    {
        if (Time.timeScale == 0)
            return;

        if (stageTime > nextTime)
        {
            nextTime = stageTime + obsCycle;
            int obsIdx = Random.Range(0, obstacle.Length);
            obstacles[idx] = Instantiate(obstacle[obsIdx], Vector3.zero, Quaternion.identity);
            obstacles[idx].transform.SetParent(obsParent);
            obstacles[idx].transform.localScale = Vector3.one;
            // 스테이지 별로 다른 난이도
            //if (GameManager.instance.CurrentStage == 1)
            obstacles[idx].transform.localPosition = new Vector3(840f, Random.Range(-600f, -400f), 0f);
            
            if (++idx == 5) idx = 0;
        }

        for (int i = 0; i < 5; i++)
        {
            if (obstacles[i])
            {
                obstacles[i].transform.Translate(-0.3f * speed * Time.deltaTime, 0, 0);
                if (obstacles[i].transform.localPosition.x < -700f)
                {
                    Destroy(obstacles[i]);
                }
            }
        }
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(0.1f);
        stageTime++;
        StartCoroutine(Timer());
    }
}
