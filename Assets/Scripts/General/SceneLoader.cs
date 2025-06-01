using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Load(SceneType sceneType)
    {
        SceneManager.LoadScene(SceneName(sceneType));
    }

    private string SceneName(SceneType sceneType)
    {
        switch (sceneType)
        {
            case SceneType.MainMenu:
                return Constants.SceneNames.MAIN_MENU;
            case SceneType.Map:
                return Constants.SceneNames.MAP;
            case SceneType.Home:
                return Constants.SceneNames.HOME;
            case SceneType.Notebook:
                return Constants.SceneNames.NOTEBOOK;
        }
        return string.Empty;
    }
}
