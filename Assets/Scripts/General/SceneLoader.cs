using Names;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace General
{
    public class SceneLoader : Subscriber
    {
        public void LoadMainMenuScene()
        {
            SceneManager.LoadScene(Constants.SceneNames.MAIN_MENU);
        }

        public void LoadMapScene()
        {
            SceneManager.LoadScene(Constants.SceneNames.MAP);
        }

        [Event(EventNames.LoadHouseScene)]
        public void LoadHouseScene()
        {
            SceneManager.LoadScene(Constants.SceneNames.HOME);
        }

        [Event(EventNames.LoadNotebookScene)]
        public void LoadNotebookScene()
        {
            SceneManager.LoadScene(Constants.SceneNames.NOTEBOOK);
        }

        public void QuitApplication()
        {
            Application.Quit();
        }
    }
}
