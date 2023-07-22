using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using BackEnd;


public class RegisterProfile : LoginBase
{
    [SerializeField]
    private Image imageID;
    [SerializeField]
    private TMP_InputField inputFieldID;

    [SerializeField]
    private Button btnRegister;

    [SerializeField]
    private GameObject Main;

    public void onClickRegisterAccount()
    {
        ResetUI(imageID);

        if (IsFieldDataEmpty(imageID, inputFieldID.text, "닉네임 입력...")) return;


        btnRegister.interactable = false;

        SetMessage("계정 생성중입니다...");

        CustomSignUp();

    }

    private void CustomSignUp()
    {
        Backend.BMember.CustomSignUp(inputFieldID.text, "MasterKey", callback =>
        {
            btnRegister.interactable = true;


            //계정 생성 성공
            if (callback.IsSuccess())
            {
                SetMessage($"계정생성 성공.{inputFieldID.text}님 환영합니다.");
                BackendGameData.Instance.GameDataInsert();

                gameObject.SetActive(false);
                Main.SetActive(true);
            }
            else
            {
                string message = string.Empty;
                switch (int.Parse(callback.GetStatusCode()))
                {
                    case 409:
                        message = "이미 존재하는 아이디 입니다. 다시 입력해주세요";
                        break;
                    default:
                        message = callback.GetMessage();
                        break;
                }

                if (message.Contains("ID")) { GuideForIncorrectlyEnteredData(imageID, message); }
                else { SetMessage(message); }
                Debug.LogError($"Login Failed : {callback}");

            }

        });
    }

}
