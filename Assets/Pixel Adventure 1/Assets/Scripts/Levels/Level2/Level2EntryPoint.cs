using UnityEngine;
using UnityEngine.Serialization;

//класс меняет флаг чтобы запустить второй уровень и закрывает коллизии за игроком
namespace Pixel_Adventure_1.Assets.Scripts.Levels.Level2
{
    public class Level2EntryPoint : MonoBehaviour
    {
        [FormerlySerializedAs("_level2Goal")] [SerializeField] private Level2Goal level2Goal;
        [SerializeField] private MenagerCollisionOnSecondLevel menagerCollisionOnSecondLevel;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player") &&level2Goal != null) 
            {
                level2Goal.ChangeSecondLevel();
                menagerCollisionOnSecondLevel.ColliderTrue();
            }
        }
    }
}
