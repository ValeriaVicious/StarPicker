using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;


namespace StarPickerPrototype
{
    internal sealed class Loading : MonoBehaviour
    {
        #region Fields

        [SerializeField] private Text _barText;
        [SerializeField] private Image _imageLoadBar;
        private AsyncOperation _asyncOperation;
        private float _waitForSeconds = 1.0f;
        private float _progressOfPercent = 0.9f;
        private float _percent = 100.0f;

        #endregion


        #region UnityMethods

        private void Start()
        {
            StartCoroutine(LoadingTheSceneOfGame());
        }

        #endregion


        #region Methods

        private IEnumerator LoadingTheSceneOfGame()
        {
            yield return new WaitForSeconds(_waitForSeconds);
            _asyncOperation = SceneManager.LoadSceneAsync(Constants.SceneOfGame);
            while (!_asyncOperation.isDone)
            {
                float progress = _asyncOperation.progress / _progressOfPercent;
                _imageLoadBar.fillAmount = progress;
                _barText.text = "Loading... " + string.Format("{0:0}%", progress * _percent);
                yield return 0;
            }
        }

        #endregion
    }
}
