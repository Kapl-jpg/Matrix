using Names;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace General
{
    public class SceneLoader : Subscriber
    {
        public void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void LoadMainScene()
        {
            SceneManager.LoadScene(Constants.SceneNames.MAIN_MENU);
        }

        public void LoadMapScene()
        {
            SceneManager.LoadScene(Constants.SceneNames.MAP);
        }

        public void LoadHomeScene()
        {
            SceneManager.LoadScene(Constants.SceneNames.HOME);
        }

        [Event(EventNames.LoadNotebook)]
        private void LoadNotebookScene()
        {
            SceneManager.LoadScene(Constants.SceneNames.NOTEBOOK);
        }

        public void QuitApplication()
        {
            Application.Quit();
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
}
