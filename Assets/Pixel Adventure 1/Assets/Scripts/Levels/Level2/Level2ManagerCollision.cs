using Pixel_Adventure_1.Assets.Scripts.Levels.Level1;
using UnityEngine;

namespace Pixel_Adventure_1.Assets.Scripts.Levels.Level2
{
    public class Level2ManagerCollision : MonoBehaviour
    {
        public GameObject LeftCollision;
        public GameObject RightCollision;

        private BoxCollider2D _rightCollider;
        private BoxCollider2D _leftCollider;

        private void Start()
        {
            _rightCollider = RightCollision.GetComponent<BoxCollider2D>();
            _leftCollider = LeftCollision.GetComponent<BoxCollider2D>();
            Invoke(nameof(ColliderTrue), 0.2f);

            Level1Event.OnFirstLevelCompleted += OpenSecondLevel;
        }

        //закрыть проход при заходе на второй уровень
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                _leftCollider.enabled = true;
                _rightCollider.enabled = true;
            }
        }

        public void ColliderTrue()
        {
            _rightCollider.enabled = true;
            _leftCollider.enabled = true;
        }

        private void OpenSecondLevel()
        {
            _rightCollider.enabled = false;
            _leftCollider.enabled = false;
            OnDestroy();
        }

        private void OnDestroy()
        {
            Level1Event.OnFirstLevelCompleted -= OpenSecondLevel;
        }
    }
}
