using UnityEngine;
using System.Security.Cryptography;

namespace Pixel_Adventure_1.Assets.Scripts.Enemy
{
    public class EnemyAi : MonoBehaviour
    {
        private static readonly int IsMoving = Animator.StringToHash("isMoving");
        private Rigidbody2D _rb;
        private Vector2 _movement = new Vector2(1, 0);
        private Animator _animator;
        private Transform _transform;
        private float _movementSpeed = 1f;
        private bool _isRight = true;
        private bool _isJumping = false;
        private bool _isDashing = false;
        private float normalGraviti = 1;
        [SerializeField] private LayerMask groundLayer;
        [SerializeField] private LayerMask wallLayer;
        [SerializeField] private LayerMask enemyLayer;
        [SerializeField] private Transform groundCheckPoint;

        void Start()
        {
            _transform = GetComponent<Transform>();
            _animator = GetComponent<Animator>();
            _rb = GetComponent<Rigidbody2D>();
            _rb.gravityScale = normalGraviti;
        }

        void FixedUpdate()
        {
            if (!_isDashing)
            {
                Run();
            }

            if (_isRight && _isJumping == false)
            {
                RaycastDown(0.1f, 0.3f);
                RaycastWall(Vector2.right, 0.1f);
            }
            else if (!_isRight && _isJumping == false)
            {
                RaycastDown(-0.1f, 0.3f);
                RaycastWall(Vector2.left, 0.1f);
            }

        }

        void RaycastDown(float distanceRay, float rayLength)
        {
            Vector2 rayDownOrigin = new Vector2(groundCheckPoint.position.x + distanceRay, groundCheckPoint.position.y);
            RaycastHit2D hitDown = Physics2D.Raycast(rayDownOrigin, Vector2.down, rayLength, groundLayer);

            if (hitDown.collider == null && _isJumping == false)
            {
                Rotate();
            }
        }

        void RaycastWall(Vector2 direction, float rayLength)
        {
            Vector2 rayWallOrigin = new Vector2(groundCheckPoint.position.x, groundCheckPoint.position.y);
            Vector2 rayEnemyOrigin = new Vector2(groundCheckPoint.position.x + 0.1f, groundCheckPoint.position.y);
            RaycastHit2D hitWall = Physics2D.Raycast(rayWallOrigin, direction, rayLength, wallLayer);
            RaycastHit2D hitBox = Physics2D.Raycast(rayWallOrigin, direction , 0.4f, groundLayer);
            RaycastHit2D hitEnemy = Physics2D.Raycast(rayEnemyOrigin, direction, 0.04f ,enemyLayer);
            
            if (hitWall.collider != null && _isJumping == false)
            {
                Rotate();
            }
            else if (hitBox.collider != null && hitBox.collider.gameObject.CompareTag("Box") && _isJumping == false)
            {
                Jump();
                Invoke(nameof(DashCallInvoke), 0.29f);
            }
            
            else if(hitEnemy.collider != null && _isJumping == false)
            {
                int randNum = RandomNumberGenerator.GetInt32(4);
                if (randNum == 1 || randNum== 2)
                {
                    Rotate();
                }
                else if (randNum == 3)
                {
                    Jump();
                    Invoke(nameof(DashCallInvoke), 0.29f);
                }
            }
        }
        
        void Jump()
        {
            _rb.AddForce(Vector2.up * 3f, ForceMode2D.Impulse);
            _isJumping = true;
            Invoke(nameof(isJumpingFalse), 1f);
        }

        void DashCallInvoke()
        {
            if (_isRight)
            {
                Dash(1);
            }
            else if (!_isRight)
            {
                Dash(-1);
            }
        }

        void isJumpingFalse()
        {
            _isJumping = false;
        }

        void isDashingFalse()
        {
            _isDashing = false;
            _rb.gravityScale = normalGraviti;
        }

        void Dash(int x)
        {
            _isDashing = true;
            _rb.gravityScale = 0;
            _rb.AddForce(new Vector2(x, 0) * 2f, ForceMode2D.Impulse);
            Invoke(nameof(isDashingFalse), 0.25f);
        }

        void Run()
        {
            _animator.SetBool(IsMoving, true);
            _rb.linearVelocity = new Vector2(_movementSpeed * _movement.x, _rb.linearVelocity.y);
        }

        void Rotate()
        {
            _isRight = !_isRight;
            _movement.x *= -1;
            transform.Rotate(0, 180, 0);
        }
    }
}