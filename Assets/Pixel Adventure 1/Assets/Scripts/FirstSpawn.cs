//скрипт для того, чтобы отключать коллизию на перегородке между первым и вторым уровнем
using UnityEngine;

public class FirstSpawn : MonoBehaviour
{
    public GameObject leftCollision;
    public GameObject rightCollision;
    private BoxCollider2D _rightCollider;
    private BoxCollider2D _leftCollider;

    void Start()
    {
        _rightCollider = rightCollision.GetComponent<BoxCollider2D>();
        _leftCollider = leftCollision.GetComponent<BoxCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _rightCollider.enabled = false;
            _leftCollider.enabled = false;
        }
    }
}
