using UnityEngine;
using BackEnd;
using UnityEngine.Events;

public class BackendGameData
{
    [System.Serializable]
    public class GameDataLoadEvent : UnityEngine.Events.UnityEvent { }
    public GameDataLoadEvent onGameDataLoadEvent = new GameDataLoadEvent();

    private static BackendGameData instance = null;
    public static BackendGameData Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new BackendGameData();
            }

            return instance;
        }
    }

    private UserGameData userGameData = new UserGameData();
    public UserGameData UserGameData => userGameData;

    private string gameDataRowInDate = string.Empty;

    public void GameDataInsert()
    {
        userGameData.Reset();

        Param param = new Param(){
            {"timeCount", userGameData.timeCount}
        };

        Backend.GameData.Insert("USER_DATA", param, callback =>
        {

            if (callback.IsSuccess())
            {
                gameDataRowInDate = callback.GetInDate();

                Debug.Log($"개인정보 데이터 삽입에 성공했습니다:{callback}");
            }
            else
            {
                Debug.LogError($"개인정보 데이터 삽입에 실패했습니다:{callback}");
            }
            //실패했을 때 
        });
    }

    public void GameDataLoad()
    {
        Backend.GameData.GetMyData("USER_DATA", new Where(), callback =>
        {
            //로딩 성공
            if (callback.IsSuccess())
            {
                Debug.Log($"게임정보 로딩에 성공:{callback}");

                try
                {
                    LitJson.JsonData gameDataJson = callback.FlattenRows();
                    if (gameDataJson.Count <= 0)
                    {
                        Debug.LogWarning("데이터가 존재하지 않습니다");

                    }
                    else
                    {
                        //불러온 게임 정보의 고유값
                        gameDataRowInDate = gameDataJson[0]["inDate"].ToString();

                        userGameData.timeCount = float.Parse(gameDataJson[0]["timeCount"].ToString());

                        //불러온 게임정보를 UserGameData변수에 저장
                        userGameData.timeCount = float.Parse(gameDataJson[0]["timeCount"].ToString());

                        onGameDataLoadEvent?.Invoke();

                    }
                }
                catch (System.Exception e)
                {
                    userGameData.Reset();
                    Debug.LogError(e);
                }
            }
            else
            {
                Debug.LogError($"게임정보 데이터 불러오기에 실패:{callback}");

            }


        });


    }

    public void GameDataUpdate(UnityAction action = null)
    {
        if (userGameData == null)
        {
            Debug.LogError("서버에서 다운받거나 새로 삽입한 데이터가 존재하지 않습니다");
            return;

        }

        Param param = new Param(){
            {"timeCount",userGameData.timeCount}
        };

        if (string.IsNullOrEmpty(gameDataRowInDate))
        {
            Debug.LogError("user의 Indate정보가 없어 실패");

        }
        else
        {
            Debug.Log($"{gameDataRowInDate}의 게임정보 데이터 수정을 요청");

            Backend.GameData.UpdateV2("USER_DATA", gameDataRowInDate, Backend.UserInDate, param, callback =>
            {
                if (callback.IsSuccess())
                {
                    Debug.Log($"게임정보 수정 성공");
                    action?.Invoke();
                }
                else
                {
                    Debug.LogError($"게임정보 데이터 수정 실패 ");
                }
            });
        }
    }

}