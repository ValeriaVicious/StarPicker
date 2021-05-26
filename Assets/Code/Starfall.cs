using UnityEngine;


namespace StarPickerPrototype
{
    internal sealed class Starfall : MonoBehaviour
    {
        #region Fields

        [SerializeField] private GameObject _starPrefab;
        [SerializeField] private float _speed = 10.0f;
        [SerializeField] private float _leftAndRightEdge = 10.0f;
        [SerializeField] private float _chanceToChangeDirections = 0.1f;
        [SerializeField] private float _secondsBetweenStarDrops = 1.0f;
        [SerializeField] private float _secondsWhenToDropTheStars = 2.0f;

        private float _changeDirection = -1.0f;

        #endregion


        #region UnityMethods

        private void Start()
        {
            Invoke(nameof(DropStar), _secondsWhenToDropTheStars);
        }

        private void Update()
        {
            MoveTheStarfall();
        }

        private void FixedUpdate()
        {
            RandomChangeDirection();
        }

        #endregion


        #region Methods

        private void MoveTheStarfall()
        {
            Vector3 position = transform.position;
            position.x += _speed * Time.deltaTime;
            transform.position = position;

            if (position.x < -_leftAndRightEdge)
            {
                _speed = Mathf.Abs(_speed);
            }
            else if (position.x > _leftAndRightEdge)
            {
                _speed = -Mathf.Abs(_speed);
            }
        }

        private void RandomChangeDirection()
        {
            if (Random.value < _chanceToChangeDirections)
            {
                _speed *= _changeDirection;
            }
        }

        private void DropStar()
        {
            GameObject star = Instantiate(_starPrefab);
            star.transform.position = transform.position;
            Invoke(nameof(DropStar), _secondsBetweenStarDrops);
        }

        #endregion
    }
}
