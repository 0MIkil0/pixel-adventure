using Pixel_Adventure_1.Assets.Scripts.Player;
using UnityEngine;

namespace Pixel_Adventure_1.Assets.Scripts
{
    public class PlayerMovement2D : MonoBehaviour
    {
        private static readonly int IsRunning = Animator.StringToHash("isRunning");
        private static readonly int IsJumping = Animator.StringToHash("isJumping");
        private Rigidbody2D _rb;
        public static float Speed = 2;
        private const float JumpForce = 5;
        private Vector2 _movement;
        private bool _isGrounded;
        private bool _isRight;
        private int _jumpCount;
        private const int MaxJumpCount = 1;
        [SerializeField] private float groundCheckRadius = 0.01f;
        [SerializeField]  private Transform groundCheckPoint; 
        [SerializeField]  private LayerMask groundLayer;   
        private Animator _animator;
        private Dash _dash;
        public ParticleSystem doubleJumpParticles;//разобрать с Ильей
        
        void Start()
        { 
            //СОХРАНЕНИЕ
            if (PlayerPrefs.HasKey("SaveX"))
            {
                float x = PlayerPrefs.GetFloat("SaveX");
                float y = PlayerPrefs.GetFloat("SaveY");
                float z = PlayerPrefs.GetFloat("SaveZ");
        
                transform.position = new Vector3(x, y, z);
        
                Debug.Log("Загружена позиция: " + transform.position);
            }
            _animator = GetComponent<Animator>();
            _rb = GetComponent<Rigidbody2D>();   
            _dash = GetComponent<Dash>();
            _animator.SetBool(IsJumping,false);
        }
        void Update()
        {
            //получение направления от -1 до 1 
            float moveX = Input.GetAxisRaw("Horizontal"); 
            //запись направления
            _movement = new Vector2(moveX, 0);
            //если нажали пробел и перс стоит на земле
            if (Input.GetKeyDown(KeyCode.Space) && _isGrounded )
            {
                _jumpCount = 1;
                Jump();
            }
            if (Input.GetKeyDown(KeyCode.Space) &&  _jumpCount < MaxJumpCount && !_isGrounded)
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
        void FixedUpdate()
        {
            _isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius,  groundLayer);
            
            if (_isGrounded)
            {
                _animator.SetBool(IsJumping,false);
                _jumpCount = 0;
            }
            ApplyMovement();
            
        }
 
        void ApplyMovement()
        {
            if (_dash.IsDashing == true)
            {
                return;
            }
            _rb.linearVelocity = new Vector2(Speed * _movement.x, _rb.linearVelocity.y);
        }
        //прыжок
        void Jump()
        {
            _animator.SetBool(IsJumping,true);
            //применяем силу к физ объекту на сцене по y, фикс значение тип применения силы
            _rb.AddForce(new Vector2(0, 1) * JumpForce, ForceMode2D.Impulse);
        }
        void OnDrawGizmos()
        {
            if (groundCheckPoint != null)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawWireSphere(groundCheckPoint.position, groundCheckRadius);
            }
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
    