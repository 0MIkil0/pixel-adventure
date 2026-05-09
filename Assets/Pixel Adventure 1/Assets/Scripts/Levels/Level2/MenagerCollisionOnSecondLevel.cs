using System;
using JetBrains.Annotations;
using UnityEngine;

namespace Pixel_Adventure_1.Assets.Scripts.Levels.Level2
{
    public class MenagerCollisionOnSecondLevel : MonoBehaviour
    {
        public GameObject leftCollision;
        public GameObject rightCollision;
         
        private BoxCollider2D _rightCollider;
        private BoxCollider2D _leftCollider;
        
        void Start()
        {
                _rightCollider = rightCollision.GetComponent<BoxCollider2D>();
                _leftCollider = leftCollision.GetComponent<BoxCollider2D>();
                Invoke(nameof(ColliderTrue), 0.2f);
            
            EventOfLevel.OnFirstLevelCompleted += OpenSecondLevel;
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
    
        void OpenSecondLevel()
        {
            _rightCollider.enabled = false;
            _leftCollider.enabled = false;
            OnDestroy();
        }
        private void OnDestroy()
        {
            EventOfLevel.OnFirstLevelCompleted -= OpenSecondLevel;
        }
    }
}
