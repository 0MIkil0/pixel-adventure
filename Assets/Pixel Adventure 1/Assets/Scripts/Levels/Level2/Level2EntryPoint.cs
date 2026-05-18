using UnityEngine;

//класс меняет флаг чтобы запустить второй уровень и закрывает коллизии за игроком
namespace Pixel_Adventure_1.Assets.Scripts.Levels.Level2
{
    public class Level2EntryPoint : MonoBehaviour
    {
       [SerializeField] private Level2Goal _level2Goal;
       [SerializeField] private Level2ManagerCollision _level2ManagerCollision;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                _level2Goal.ChangeSecondLevel();
                _level2ManagerCollision.ColliderTrue();
            }
        }
    }
}
