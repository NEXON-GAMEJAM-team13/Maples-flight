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

        if (IsFieldDataEmpty(imageID, inputFieldID.text, "���̵�")) return;
        //  if (IsFieldDataEmpty(imagePW, inputFieldPW.text, "��й�ȣ")) return;

        btnLogin.interactable = false;

        StartCoroutine(nameof(LoginProcess));

        ResponseToLogin(inputFieldID.text, inputFieldPW.text);
    }

    private void ResponseToLogin(string ID, string PW)
    {
        Backend.BMember.CustomLogin(ID, PW, callback =>
        {
            StopCoroutine(nameof(LoginProcess));

            if (callback.IsSuccess()) //�α��μ���
                SetMessage($"{UserInfo.Data.nickname}�� ȯ���մϴ�.");
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

                //if (message.Contains("��й�ȣ"))
            }

        });
    }

    private IEnumerator LoginProcess()
    {
        float time = 0;

        while (true)
        {
            time += Time.deltaTime;
            SetMessage($"�α��� ���Դϴ�... {time:F1}");

            yield return null;
        }
    }

    private void Awake()
    {
        //string ID = "user001";
        //string PW = "abc";
        //string nickname = "wooyeon";

        // ȸ������
        //Backend.BMember.CustomSignUp(ID, PW);

        // �α���
        //Backend.BMember.CustomLogin(ID, PW);

        // �г��� ����
        // ���� �г���
        //Backend.BMember.CreateNickname(nickname);
        // �̹� �ִ� �г��� ����
        //Backend.BMember.UpdateNickname(nickname);
    }

}
