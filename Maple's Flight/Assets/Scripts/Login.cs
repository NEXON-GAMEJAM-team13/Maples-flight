using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using BackEnd;


public class Login : LoginBase
{
    [SerializeField]
    private Image imageID; //ID필드 색상 변경
    [SerializeField]
    private TMP_InputField inputFieldID; // ID필드 텍스트 정보 추출

    [SerializeField]
    private Image imagePW; //필드색상 변경

    [SerializeField]
    private TMP_InputField inputFieldPW; //PW필드 텍스트 정보 추출


    [SerializeField]
    private Button btnLogin; //로그인 버튼(상호작용 기능/툴기능)


    public void OnClickLogin()
    {
        //매개변수로 입력한 InputField UI의 색상과 Message내용 초기화
        ResetUI(imageID, imagePW);

        //필드값이 비어있는지 체크
        if (IsFieldDataEmpty(imageID, inputFieldID.text, "ID")) return;
        if (IsFieldDataEmpty(imagePW, inputFieldPW.text, "PW")) return;

        //로그인 버튼을 연타하지 못하도록 상호작용 비활성화
        btnLogin.interactable = false;


        //서버에 로그인을 요청하는 동안 화면에 출력하는 내용 업데이트
        //ex) 로그인 관련 텍스트출력, 톱니바퀴 아이콘 회전 등
        StartCoroutine(nameof(LoginProcess));

        ResponseToLogin(inputFieldID.text, inputFieldPW.text);
    }

    private void ResponseToLogin(string ID, string PW)
    {
        //서버에 로그인 요청
        Backend.BMember.CustomLogin(ID, PW, callback =>
        {

            StopCoroutine(nameof(LoginProcess));

            //로그인 성공
            if (callback.IsSuccess())
            {
                SetMessage($"{inputFieldID.text}님 환영합니다");
                //Lobby씬으로 이동
                Utils.LoadScene(SceneNames.Lobby);
            }
            else
            {
                //로그인 실패시

                //로그인 상호작용 버튼 다시 활성화
                btnLogin.interactable = true;

                string message = string.Empty;

                switch (int.Parse(callback.GetStatusCode()))
                {
                    case 401:
                        message = callback.GetMessage().Contains("customId") ? "존재하지 않는 아이디입니다." : "잘못된 비밀번호 입니다";
                        break;

                    case 403:
                        message = callback.GetMessage().Contains("user") ? "차단당한 유저입니다" : "차단당한 디바이스입니다";
                        break;

                    case 410:
                        message = "탈퇴 진행중인 아이디입니다";
                        break;

                    default:
                        message = callback.GetMessage();
                        break;

                }

                if (message.Contains("비밀번호"))
                {
                    GuideForIncorrectlyEnteredData(imagePW, message);
                }
                else
                {
                    GuideForIncorrectlyEnteredData(imageID, message);

                }
            }
        }
        );
    }


    //로그인 시도 후 서버로부터 전달받은 message를 기반으로 로직 처리
    private IEnumerator LoginProcess()
    {
        float time = 0;
        while (true)
        {
            time += Time.deltaTime;
            SetMessage($"로그인 중입니다...{time:F1}");

            yield return null;

        }
    }
}
