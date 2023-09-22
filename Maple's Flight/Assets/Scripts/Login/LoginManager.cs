using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BackEnd;

public class LoginManager : MonoBehaviour
{
    void Awake(){
        string ID="user321";
        string PW="321";
        
        try{CustomSignUp(ID, PW);}catch{}
        ResponseToLogin(ID, PW);

    }
    // Start is called before the first frame update
   
    public void CustomSignUp(string userID, string userPW)
	{
		Backend.BMember.CustomSignUp(userID, userPW, callback =>
		{
			// "계정 생성" 버튼 상호작용 활성화
			

			// 계정 생성 성공
			if ( callback.IsSuccess() )
			{
				// E-mail 정보 업데이트
				Backend.BMember.UpdateCustomEmail($"{userID}@snsd.com", callback =>
				{
					if ( callback.IsSuccess() )
					{
						Debug.Log($"계정 생성 성공. {userID}님 환영합니다.");
						BackendGameData.Instance.GameDataInsert();
						// Lobby 씬으로 이동
						// Utils.LoadScene(SceneNames.Lobby);
					}
				});
			}
			// 계정 생성 실패
			else
			{
				string message = string.Empty;

				switch ( int.Parse(callback.GetStatusCode()) )
				{
					case 409:	// 중복된 customId 가 존재하는 경우
						message = "이미 존재하는 아이디입니다.";
						break;
					case 403:	// 차단당한 디바이스일 경우
						message = callback.GetMessage();
						break;
					case 401:	// 프로젝트 상태가 '점검'일 경우
					case 400:	// 디바이스 정보가 null일 경우
					default:
						message = callback.GetMessage();
						break;
				}

				if ( message.Contains("아이디") )
				{
					Debug.Log(message);
				}
				else
				{
					Debug.Log(message);
				}
			}
		});
	}
    public void ResponseToLogin(string ID, string PW)
	{
		// 서버에 로그인 요청
		Backend.BMember.CustomLogin(ID, PW, callback =>
		{
			StopCoroutine(nameof(LoginProcess));

			// 로그인 성공
			if ( callback.IsSuccess() )
			{
				Debug.Log($"{ID}님 환영합니다.");

				// Lobby 씬으로 이동
				Utils.LoadScene(SceneNames.Lobby);
			}
			// 로그인 실패
			else
			{
				// 로그인에 실패했을 때는 다시 로그인을 해야하기 때문에 "로그인" 버튼 상호작용 활성화
				// btnLogin.interactable = true;

				string message = string.Empty;

				switch ( int.Parse(callback.GetStatusCode()) )
				{
					case 401:	// 존재하지 않는 아이디, 잘못된 비밀번호
						message = callback.GetMessage().Contains("customId") ? "존재하지 않는 아이디입니다." : "잘못된 비밀번호 입니다.";
						break;
					case 403:	// 유저 or 디바이스 차단
						message = callback.GetMessage().Contains("user") ? "차단당한 유저입니다." : "차단당한 디바이스입니다.";
						break;
					case 410:	// 탈퇴 진행중
						message = "탈퇴가 진행중인 유저입니다.";
						break;
					default:
						message = callback.GetMessage();
						break;
				}

				// StatusCode 401에서 "잘못된 비밀번호 입니다." 일 때
				if ( message.Contains("비밀번호") )
				{
                    Debug.Log(message);
				}
				else
				{
				Debug.Log(message);
				}
                
			}
		});
	}

    private IEnumerator LoginProcess()
	{
		float time = 0;

		while ( true )
		{
			time += Time.deltaTime;

			Debug.Log($"로그인 중입니다... {time:F1}");

			yield return null;
		}
	}
}
