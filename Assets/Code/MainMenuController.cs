using UnityEngine.SceneManagement;
using UnityEngine;


namespace StarPickerPrototype
{

    internal sealed class MainMenuController : MonoBehaviour
    {
        #region Methods

        public void StartButton()
        {
            SceneManager.LoadScene(Constants.SceneOfLoading);
        }

        public void AboutAuthorButton()
        {
            SceneManager.LoadScene(Constants.SceneAboutAuthor);
        }

        public void BackToMainScene()
        {
            SceneManager.LoadScene(Constants.SceneOfMainMenu);
        }

        public void ExitButton()
        {
            Application.Quit();
        }

        #endregion
    }
}