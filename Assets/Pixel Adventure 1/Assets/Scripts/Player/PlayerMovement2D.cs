using UnityEngine;

namespace Pixel_Adventure_1.Assets.Scripts.Player
{
    public class PlayerMovement2D : MonoBehaviour
    {
        public ParticleSystem DoubleJumpParticles; //разобрать с Ильей

        [SerializeField] private float _groundCheckRadius = 0.01f;
        [SerializeField] private Transform _groundCheckPoint;
        [SerializeField] private LayerMask _groundLayer;

        private static readonly int IsRunning = Animator.StringToHash("isRunning");
        private static readonly int IsJumping = Animator.StringToHash("isJumping");
        private static readonly float Speed = 2;
        private Rigidbody2D _rb;
        private Vector2 _movement;
        private Animator _animator;
        private PlayerDash _playerDash;
        private const float JumpForce = 5;
        private const int MaxJumpCount = 1;
        private bool _isGrounded;
        private bool _isRight;
        private int _jumpCount;

        private void Start()
        {
            _animator = GetComponent<Animator>();
            _rb = GetComponent<Rigidbody2D>();
            _playerDash = GetComponent<PlayerDash>();
            _animator.SetBool(IsJumping, false);
        }

        private void Update()
        {
            //получение направления от -1 до 1 
            float moveX = Input.GetAxisRaw("Horizontal");
            //запись направления
            _movement = new Vector2(moveX, 0);
            //если нажали пробел и перс стоит на земле
            if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
            {
                _jumpCount = 1;
                Jump();
            }

            if (Input.GetKeyDown(KeyCode.Space) && _jumpCount < MaxJumpCount && !_isGrounded)
            {
                _rb.linearVelocity = new Vector2(_rb.linearVelocity.x, 0);
                _jumpCount = 2;
                Jump();

            }

            //анимация
            if (moveX == 1 || moveX == -1)
            {
                _animator.SetBool(IsRunning, true);
            }
            else
            {
                _animator.SetBool(IsRunning, false);
            }

            //аним поворота
            //isRight по дефолту false поэтому если после спавна нажимаем лево
            //условие выполняется
            if (moveX < 0 && !_isRight)
            {
                Flip();
            }
            else if (moveX > 0 && _isRight)
            {
                Flip();
            }
        }

        private void FixedUpdate()
        {
            _isGrounded = Physics2D.OverlapCircle(_groundCheckPoint.position, _groundCheckRadius, _groundLayer);

            if (_isGrounded)
            {
                _animator.SetBool(IsJumping, false);
                _jumpCount = 0;
            }

            ApplyMovement();

        }

        private void OnDrawGizmos()
        {
            if (_groundCheckPoint != null)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawWireSphere(_groundCheckPoint.position, _groundCheckRadius);
            }
        }

        private void ApplyMovement()
        {
            if (_playerDash.IsDashing == true)
            {
                return;
            }

            _rb.linearVelocity = new Vector2(Speed * _movement.x, _rb.linearVelocity.y);
        }

        //прыжок
        private void Jump()
        {
            _animator.SetBool(IsJumping, true);
            //применяем силу к физ объекту на сцене по y, фикс значение тип применения силы
            _rb.AddForce(new Vector2(0, 1) * JumpForce, ForceMode2D.Impulse);
        }


        private void Flip()
        {
            _isRight = !_isRight;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }
}
    
