using Names;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace General
{
    public class SceneLoader : Subscriber
    {
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
