using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    //public GameObject PauseUI;
    //public AudioSource click;

    private bool paused = false;

    public void Pause() // �Ͻ�����
    {
        paused = true;
        GameManager.instance.isPlaying = false;
    }

    public void Resume() // �簳
    {
        paused = false;
        GameManager.instance.isPlaying = true;
    }

    public void StopGame() // ���� ������
    {
        paused = false;
    }

    void Start()
    {
        //PauseUI.SetActive(false);
    }

    void Update()
    {
        if (paused)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
}
