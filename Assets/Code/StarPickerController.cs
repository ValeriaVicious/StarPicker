using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace StarPickerPrototype
{
    internal sealed class StarPickerController : MonoBehaviour
    {
        #region Fields

        [SerializeField] private GameObject _packagePrefab;
        [SerializeField] private List<GameObject> _packageList;
        [SerializeField] private GameObject _gameOverMenuUI;
        [SerializeField] private int _noumberOfPackages = 3;
        [SerializeField] private float _packageBottomY = -10.0f;
        [SerializeField] private float _packageSpacingY = 2.0f;

        #endregion


        #region UnityMethods

        private void Start()
        {
            _packageList = new List<GameObject>();
            CreateThePackages();
        }

        #endregion


        #region Methods

        private void CreateThePackages()
        {
            for (int i = 0; i < _noumberOfPackages; i++)
            {
                GameObject package = Instantiate(_packagePrefab);
                Vector3 position = Vector3.zero;
                position.y = _packageBottomY + (_packageSpacingY * i);
                package.transform.position = position;
                _packageList.Add(package);
            }
        }

        private void PackageDestroyed()
        {
            int packageIndex = _packageList.Count - 1;
            GameObject packageObject = _packageList[packageIndex];
            _packageList.RemoveAt(packageIndex);

            Destroy(packageObject);

            if (_packageList.Count == 0)
            {
                Time.timeScale = 0.0f;
                _gameOverMenuUI.SetActive(true);
            }
        }

        internal void StarDestroyed()
        {
            GameObject[] starArray = GameObject.FindGameObjectsWithTag(Constants.StarTag);
            foreach (var item in starArray)
            {
                Destroy(item);
            }
            PackageDestroyed();
        }

        #endregion
    }
}
