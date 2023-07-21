using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BackEnd;

public class BackendManager : MonoBehaviour
{
    private void Awake()
    {
        // Update 메소드의 Backend.AsyncPoll(); 호출 위해 파괴 ㄴㄴ
        DontDestroyOnLoad(gameObject);
        BackendSetUp();
    }

    private void Update()
    {
        // 서버의 비동기 메소드 호출을 위해 작성
        if (Backend.IsInitialized)
            Backend.AsyncPoll();
    }

    void BackendSetUp()
    {
        var bro = Backend.Initialize(true); // 뒤끝 초기화

        // 뒤끝 초기화에 대한 응답값
        if (bro.IsSuccess())
        {
            Debug.Log("초기화 성공 : " + bro); // 성공일 경우 statusCode 204 Success
        }
        else
        {
            Debug.LogError("초기화 실패 : " + bro); // 실패일 경우 statusCode 400대 에러 발생 
        }
    }
}
