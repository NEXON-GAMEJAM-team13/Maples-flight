using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using BackEnd;

public class RegisterAccount : LoginBase
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
    private Button btnRegister;

    public void onClickRegisterAccount()
    {
        ResetUI(imageID, imagePW);

        if (IsFieldDataEmpty(imageID, inputFieldID.text, "아이디")) return;
        if (IsFieldDataEmpty(imagePW, inputFieldPW.text, "비밀번호")) return;

        btnRegister.interactable = false;
        SetMessage("계정 생성중입니다.");

        CustomSignUp();
    }

    private void CustomSignUp()
    {
        Backend.BMember.CustomSignUp(inputFieldID.text, inputFieldPW.text, callback =>
        {
            btnRegister.interactable = true;

            // 계정생성성공
            if (callback.IsSuccess())
            {
                SetMessage($"계정 생성 성공. {inputFieldID.text}님 환영합니다.");
            }
            else
            {

            }
        });
    }
}
