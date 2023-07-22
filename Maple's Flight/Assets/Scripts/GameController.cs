using UnityEngine;

public class GameController : MonoBehaviour
{
    public bool IsGameOver { set; get; } = false;
    public void GameOver()
    {
        if (IsGameOver == true) return;

        IsGameOver = true;
        BackendGameData.Instance.UserGameData.timeCount += 1;


        BackendGameData.Instance.GameDataUpdate(AfterGameOver);
    }
    public void AfterGameOver()
    {
        Utils.LoadScene(SceneNames.Lobby);
    }

    public void OnStartClicked()
    {
        Utils.LoadScene(SceneNames.Scene_SH);
    }
}
