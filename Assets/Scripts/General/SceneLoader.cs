using General.Constants;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace General
{
    public class SceneLoader : Subscriber
    {
        public void LoadMainMenuScene()
        {
            SceneManager.LoadScene(Names.Scenes.MAIN_MENU);
        }

        public void LoadMapScene()
        {
            SceneManager.LoadScene(Names.Scenes.MAP);
        }

        [Event(Names.LOAD_HOUSE_SCENE)]
        public void LoadHouseScene()
        {
            SceneManager.LoadScene(Names.Scenes.HOUSE);
        }

        [Event(Names.LOAD_NOTEBOOK_SCENE)]
        public void LoadNotebookScene()
        {
            SceneManager.LoadScene(Names.Scenes.NOTEBOOK);
        }

        public void QuitApplication()
        {
            Application.Quit();
        }
    }
}
