using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using BackEnd;

public class BackendGameData : MonoBehaviour
{
    [System.Serializable]
    public class GameDataLoadEvent : UnityEvent { }
    public GameDataLoadEvent onGameDataLoadEvent = new GameDataLoadEvent();

    private static BackendGameData instance = null;
    public static BackendGameData Instance
    {
        get
        {
            if (instance == null)
                instance = new BackendGameData();
            return instance;
        }
        
    }

    private GameData gameData = new GameData();
    public GameData GameData => gameData;

    private string gameDataRowInDate = string.Empty;

    public void GameDataInsert()
    {
        gameData.Reset();
        Param param = new Param()
        {
            { "nowScore", gameData.nowScore },
            { "bestScore", gameData.bestScore }
        };

        Backend.GameData.Insert(Constants.USER_DATA_TABLE, param, callback =>
        {
            if (callback.IsSuccess())
            {
                gameDataRowInDate = callback.GetInDate();
                Debug.Log($"게임 정보 데이터 삽입 성공 : {callback}");
            }
            else
            {
                // 실패
                Debug.LogError(callback.GetMessage());
            }
        });
    }

    public void GameDataUpdate(UnityAction action=null)
    {
        if (gameData == null) return;

        Param param = new Param()
        {
            { "nowScore", gameData.nowScore },
            { "bestScore", gameData.bestScore }
        };

        if (string.IsNullOrEmpty(gameDataRowInDate))
            Debug.Log("에러");
    }


//뒤끝콘솔 테이블에서 유저 정보를 불러올 때 호출
    public void GameDataLoad(){
        Backend.GameData.GetMyData(Constants.USER_DATA_TABLE, new Where(), callback =>{

            //게임 정보 불러오기에 성공했을 때
            if(callback.IsSuccess()){
                Debug.Log($"게임데이터 불러오기 성공 :{callback}");

                try{
                    LitJson.JsonData gameDataJson = callback.FlattenRows();
                    
                    if(gameDataJson.Count<=0){
                        Debug.LogWarning("데이터 없음");
                    }
                    else{
                        //불러온 게임 정보의 고유값
                        gameDataRowInDate = gameDataJson[0]["inDate"].ToString();
                        
                        onGameDataLoadEvent?.Invoke();
                    }
                }
                catch(System.Exception e){
                    gameData.Reset();
                    Debug.LogError(e);
                }
            
            }
            else{
                Debug.LogError($"게임정보 데이터 불러오기에 실패 : {callback}");
            }
        });

    }
}
