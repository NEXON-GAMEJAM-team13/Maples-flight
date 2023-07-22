using UnityEngine;
using UnityEngine.UI;
using TMPro;
using BackEnd;

public class RegisterAccount : LoginBase
{

    //ID
    [SerializeField]
    private Image imageID;  //필드색상변경
    [SerializeField]
    private TMP_InputField inputFieldID;  //텍스트정보 추출


    //PW
    [SerializeField]
    private Image imagePW;
    [SerializeField]
    private TMP_InputField inputFieldPW;


    //ConfirmPW
    [SerializeField]
    private Image imageConfirmPW;
    [SerializeField]
    private TMP_InputField inputFieldConfirmPW;

    //Email
    [SerializeField]
    private Image imageEmail;
    [SerializeField]
    private TMP_InputField inputFieldEmail;

    [SerializeField]
    private Button btnRegisterAccount;//계정생성버튼(상호작용 가능/불가능)


    public void OnClickRegisterAccount()
    {
        //매개변수를 입력한 InputField UI의 색상과 Message내용 초기화
        ResetUI(imageID, imagePW, imageConfirmPW, imageEmail);

        //필드값이 비어있는지 체크
        if (IsFieldDataEmpty(imageID, inputFieldID.text, "ID")) return;
        if (IsFieldDataEmpty(imagePW, inputFieldPW.text, "PW")) return;
        if (IsFieldDataEmpty(imageConfirmPW, inputFieldConfirmPW.text, "Confirm PW")) return;
        if (IsFieldDataEmpty(imageEmail, inputFieldEmail.text, "Email")) return;

        //PW와 Confirm PW가 다른경우
        if (!inputFieldConfirmPW.text.Equals(inputFieldPW.text))
        {
            GuideForIncorrectlyEnteredData(imageConfirmPW, "비밀번호가 일치하지 않습니다");
            return;
        }
        if (!inputFieldEmail.text.Contains("@"))
        {
            GuideForIncorrectlyEnteredData(imageEmail, "메일 형식이 잘못되었습니다");
            return;
        }
        //계정생성 버튼 비활성화
        btnRegisterAccount.interactable = false;
        SetMessage("계정 생성중입니다...");

        //뒤끝 서버 계정 생성 시도
        CustomSignUp();

    }
    private void CustomSignUp()
    {
        Backend.BMember.CustomSignUp(inputFieldID.text, inputFieldPW.text, callback =>
        {
            //계정생성버튼 상호작용 활성화
            btnRegisterAccount.interactable = true;

            if (callback.IsSuccess())
            {
                //계정 생성 성공

                //Email 정보 업데이트
                Backend.BMember.UpdateCustomEmail(inputFieldEmail.text, callback =>
                {
                    if (callback.IsSuccess())
                    {
                        SetMessage($"계정 생성 성공. {inputFieldID.text}님 환영합니다");


                        //계정생성 성공시 해당 계정에 게임정보 생성
                        BackendGameData.Instance.GameDataInsert();
                        //Lobby로 이동
                        Utils.LoadScene(SceneNames.Lobby);
                    }
                });
            }
            else
            {
                //계정 생성 실패
                string message = string.Empty;

                switch (int.Parse(callback.GetStatusCode()))
                {
                    case 409:
                        //중복된 커스텀 아이디가 존재하는 경우
                        message = "이미 존재하는 아이디입니다.";
                        break;
                    case 403:   //차단당한 경우
                    case 401:   //프로젝트가 점검중인 경우
                    case 400:   // 디바이스 정보가 Null인 경우
                    default:
                        message = callback.GetMessage();
                        break;
                }
                if (message.Contains("ID"))
                {
                    GuideForIncorrectlyEnteredData(imageID, message);
                }
                else
                {
                    SetMessage(message);
                }


            }
        });
    }
}
