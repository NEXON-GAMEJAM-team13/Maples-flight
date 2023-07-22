using UnityEngine;
using BackEnd;

public class BackendManager : MonoBehaviour
{
    private void Awake()//뒤끝서버 초기화
    {
        //Update()메소드의 Backend.AsyncPoll();호출을 위해 오브젝트를 파괴하지 않는다
        DontDestroyOnLoad(gameObject);
        //뒤끝서버 초기화
        BackendSetup();
    }

    private void Update()
    {
        if (Backend.IsInitialized)
        {
            Backend.AsyncPoll();
        }
    }

    private void BackendSetup()
    {
        var bro = Backend.Initialize(true);

        if (bro.IsSuccess())
        {
            //초기화 성공
            Debug.Log($"초기화성공:{bro}");
        }
        else
        {
            //초기화 실패시 400번대 에러 
            Debug.LogError($"초기화실패:{bro}");
        }
    }
}
