using UnityEngine;
using BackEnd;

public class DailyRankRegister : MonoBehaviour
{

    public void Process(int newScore)
    {
        UpdateMyRankData(newScore);

    }

    private void UpdateMyRankData(int newScore)
    {
        string rowInDate = string.Empty;
        Backend.GameData.GetMyData(Constants.USER_DATA_TABLE, new Where(), callback =>
        {
            if (!callback.IsSuccess())
            {
                Debug.LogError($"데이터 조회중 문제가 발생했습니다.: {callback}");

            }
            Debug.Log($"데이터 조회에 성공했습니다 : {callback}");
            if (callback.FlattenRows().Count > 0)
            {
                rowInDate = callback.FlattenRows()[0]["inDate"].ToString();
            }
            else
            {
                Debug.LogError("데이터가 존재하지 않습니다");
                return;

            }

            Param param = new Param(){
                {"timeCount", newScore}
            };
            Backend.URank.User.UpdateUserScore(Constants.DAILY_RANK_UUID, Constants.USER_DATA_TABLE, rowInDate, param, callback =>
           {
               if (callback.IsSuccess())
               {
                   Debug.Log($"랭킹등록에 성공했습니다 : {callback}");
               }
               else
               {
                   Debug.Log($"랭킹 등록에 실패했습니다 : {callback}");
               }


           });
        });
    }
}
