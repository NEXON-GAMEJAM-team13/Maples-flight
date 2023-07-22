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

        if (IsFieldDataEmpty(imageID, inputFieldID.text, "���̵�")) return;
        if (IsFieldDataEmpty(imagePW, inputFieldPW.text, "��й�ȣ")) return;
        if (IsFieldDataEmpty(imageNICK, inputFieldNICK.text, "�г���")) return;

        btnRegister.interactable = false;
        SetMessage("���� �������Դϴ�.");

        CustomSignUp();
    }

    private void CustomSignUp()
    {

        Backend.BMember.CustomSignUp(inputFieldID.text, inputFieldPW.text, callback =>
        {
            btnRegister.interactable = true;

            // ������������
            if (callback.IsSuccess())
            {
                SetMessage($"���� ���� ����. {inputFieldNICK.text}�� ȯ���մϴ�.");

                Backend.BMember.CreateNickname(inputFieldNICK.text);
                // ���� ���� ���� ����
                BackendGameData.Instance.GameDataInsert();
            }
            else
            {

            }
        });
    }
}
