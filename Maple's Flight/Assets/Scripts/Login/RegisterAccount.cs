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
    private Image imageNICK;
    [SerializeField]
    private TMP_InputField inputFieldNICK;

    [SerializeField]
    private Button btnRegister;

    public void onClickRegisterAccount()
    {
        ResetUI(imageID, imagePW);

        if (IsFieldDataEmpty(imageID, inputFieldID.text, "아이디")) return;
        if (IsFieldDataEmpty(imagePW, inputFieldPW.text, "비밀번호")) return;
        if (IsFieldDataEmpty(imageNICK, inputFieldNICK.text, "닉네임")) return;

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
                SetMessage($"계정 생성 성공. {inputFieldNICK.text}님 환영합니다.");

                Backend.BMember.CreateNickname(inputFieldNICK.text);
                // 계정 게임 정보 생성
                BackendGameData.Instance.GameDataInsert();
            }
            else
            {

            }
        });
    }
}
