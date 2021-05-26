using UnityEngine;
using UnityEngine.UI;


namespace StarPickerPrototype
{
    internal sealed class Package : MonoBehaviour
    {
        #region Fields

        [SerializeField] private int _numberOfScore;
        private Text _scoreText;
        private AudioSource _soundOfStars;

        #endregion


        #region UnityMethods

        private void Start()
        {
            Text score = FindObjectOfType<Text>();
            _scoreText = score.GetComponent<Text>();
            _scoreText.text = "0";
            _soundOfStars = GetComponent<AudioSource>();
        }

        private void Update()
        {
            ControlThePackage();
        }

        private void OnCollisionEnter(Collision collision)
        {
            GameObject colliderOfStar = collision.gameObject;

            if (colliderOfStar.CompareTag(Constants.StarTag))
            {
                Destroy(colliderOfStar);
                _soundOfStars.Play();

                int score = int.Parse(_scoreText.text);
                score += _numberOfScore;
                _scoreText.text = score.ToString();

                if (score > HighScore.Score)
                {
                    HighScore.Score = score;
                }
            }
        }

        #endregion


        #region Methods

        private void ControlThePackage()
        {
            Vector3 mousePositionTwoD = Input.mousePosition;
            mousePositionTwoD.z = -Camera.main.transform.position.z;
            Vector3 mousePositionThreeD = Camera.main.ScreenToWorldPoint(mousePositionTwoD);

            Vector3 position = transform.position;
            position.x = mousePositionThreeD.x;
            transform.position = position;
        }

        #endregion
    }
}
