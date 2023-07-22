using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoScenario : MonoBehaviour
{
    [SerializeField]
    private Progress progress;

    [SerializeField]
    private SceneNames nextScene;

    private void Awake()
    {
        SystemSetUp();
    }

    private void SystemSetUp()
    {
        Application.runInBackground = true;

        //해상도 설정
        int width = Screen.width;
        int height = (int)(Screen.width * 20f / 9f);
        Screen.SetResolution(width, height, true);

        //화면이 꺼지지 않도록 설정
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        //로딩 애니메이션 시작, 재생 완료시 OnAfterProgress()메소드 실행
        progress.Play(OnAfterProgress);
    }
    private void OnAfterProgress()
    {
        Utils.LoadScene(nextScene);
    }
}
