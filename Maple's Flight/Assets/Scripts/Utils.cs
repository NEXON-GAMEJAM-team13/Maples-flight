using UnityEngine.SceneManagement;

public enum SceneNames { Logo = 0, Login, Lobby, Scene_SH, }
public static class Utils
{
    // Start is called before the first frame update
    public static string GetActiveScene()
    {
        return SceneManager.GetActiveScene().name;
    }

    public static void LoadScene(string sceneName = "")
    {
        if (sceneName == "")
        {
            SceneManager.LoadScene(GetActiveScene());
        }
        else
        {
            SceneManager.LoadScene(sceneName);
        }
    }

    public static void LoadScene(SceneNames sceneName)
    {
        SceneManager.LoadScene(sceneName.ToString());
    }
}
