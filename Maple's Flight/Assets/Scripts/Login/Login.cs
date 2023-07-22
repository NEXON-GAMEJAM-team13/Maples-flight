using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using BackEnd;

public class Login : LoginBase
{
    [SerializeField]
    private Image imageID;
    [SerializeField]
    private TMP_InputField inputFieldID;
    [SerializeField]
    private Image imagePW;
    [SerializeField]
    private TMP_InputField inputFieldPW;

    [SerializeField]
    private Button btnLogin;

    public void OnclickLogin()
    {
        ResetUI(imageID, imagePW);

        if (IsFieldDataEmpty(imageID, inputFieldID.text, "아이디")) return;
        if (IsFieldDataEmpty(imagePW, inputFieldPW.text, "비밀번호")) return;

        btnLogin.interactable = false;

        StartCoroutine(nameof(LoginProcess));

        ResponseToLogin(inputFieldID.text, inputFieldPW.text);
    }

    private void ResponseToLogin(string ID, string PW)
    {
        Backend.BMember.CustomLogin(ID, PW, callback =>
        {
            StopCoroutine(nameof(LoginProcess));

            if (callback.IsSuccess()) //로그인성공
                SetMessage($"{UserInfo.Data.nickname}님 환영합니다.");
            else
            {
                btnLogin.interactable = true;
                string message = string.Empty;

                switch (int.Parse(callback.GetStatusCode()))
                {
                    case 401:
                        break;
                    case 403:
                        break;
                    case 410:
                        break;
                    default:
                        break;
                }

                //if (message.Contains("비밀번호"))
            }

        });
    }

    private IEnumerator LoginProcess()
    {
        float time = 0;

        while (true)
        {
            time += Time.deltaTime;
            SetMessage($"로그인 중입니다... {time:F1}");

            yield return null;
        }
    }

    private void Awake()
    {
        //string ID = "user001";
        //string PW = "abc";
        //string nickname = "wooyeon";

        // 회원가입
        //Backend.BMember.CustomSignUp(ID, PW);

        // 로그인
        //Backend.BMember.CustomLogin(ID, PW);

        // 닉네임 설정
        // 최초 닉네임
        //Backend.BMember.CreateNickname(nickname);
        // 이미 있는 닉네임 수정
        //Backend.BMember.UpdateNickname(nickname);
    }
    
}
