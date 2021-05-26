using UnityEngine;


namespace StarPickerPrototype
{
    internal sealed class Star : MonoBehaviour
    {
        #region Fields

        private const float _bottomY = -20.0f;

        #endregion


        #region UnityMethods

        private void Update()
        {
            CheckTheBottom();
        }

        #endregion


        #region Methods

        private void CheckTheBottom()
        {
            if (transform.position.y < _bottomY)
            {
                Destroy(gameObject);
                StarPickerController starPickerController = Camera.main.GetComponent<StarPickerController>();
                starPickerController.StarDestroyed();
            }
        }

        #endregion
    }
}
