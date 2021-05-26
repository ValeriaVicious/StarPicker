using UnityEngine;
using UnityEngine.UI;


namespace StarPickerPrototype
{
    internal sealed class HighScore : MonoBehaviour
    {
        #region Fields

        public static int Score = 1000;

        #endregion


        #region UnityMethods

        private void Awake()
        {
            if (PlayerPrefs.HasKey(Constants.HighScore))
            {
                Score = PlayerPrefs.GetInt(Constants.HighScore);
            }
            PlayerPrefs.SetInt(Constants.HighScore, Score);
        }

        private void Update()
        {
            UpdateScoreText();
        }

        #endregion


        #region Methods

        private void UpdateScoreText()
        {
            Text textObject = GetComponent<Text>();
            textObject.text = $"High Score: {Score}";

            if (Score > PlayerPrefs.GetInt(Constants.HighScore))
            {
                PlayerPrefs.SetInt(Constants.HighScore, Score);
            }
        }

        #endregion
    }
}