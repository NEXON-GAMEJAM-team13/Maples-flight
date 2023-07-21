using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Utils : MonoBehaviour
{
    public enum SceneNames { Logo=0, Login, }

    public static string GetActiveScene()
    {
        return SceneManager.GetActiveScene().name;
    }

    public static void LoadScene(string sceneName="")
    {
        if (sceneName == "")
            SceneManager.LoadScene(GetActiveScene());
        else
            SceneManager.LoadScene(sceneName);
    }
    
    public static void LoadScene(SceneNames sceneName)
    {
        SceneManager.LoadScene(sceneName.ToString());
    }
}
