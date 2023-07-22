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
    float stageTime;  //현재 경과 시간
    [SerializeField]
    float desTime;    //목표시간
    [SerializeField]
    float nextTime;

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
        GameManager.instance.isGameOver = false;
        StartCoroutine("Timer");
    }

    void Update()
    {
        if (!GameManager.instance.isGameOver)
        {
            time_txt.text = ((int)(stageTime / 10)).ToString();
            MakeObstacles();
        }
    }

    public void GameOver()
    {
        StopAllCoroutines();
        GameManager.instance.SetScore((int)(stageTime / 10));
        gameOverPanel.SetActive(true);
        Debug.Log("게임오버~");
        gameObject.SetActive(false);

        nowScore_txt.text = ((int)(stageTime / 10)).ToString();
        bestScore_txt.text = ((int)(stageTime / 10)).ToString();
    }

    void MakeObstacles()
    {
        if (Time.timeScale == 0)
            return;

        if (stageTime > nextTime)
        {
            nextTime = stageTime + 5f;
            int obsIdx = Random.Range(0, obstacle.Length);
            obstacles[idx] = Instantiate(obstacle[obsIdx], Vector3.zero, Quaternion.identity);
            obstacles[idx].transform.SetParent(obsParent);
            obstacles[idx].transform.localScale = Vector3.one;
            // 스테이지 별로 다른 난이도
            //if (GameManager.instance.CurrentStage == 1)
            obstacles[idx].transform.localPosition = new Vector3(840f, Random.Range(-600f, -400f), 0f);
            
            if (++idx == 5) idx = 0;
        }

        for (int i=0; i<5; i++)
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
