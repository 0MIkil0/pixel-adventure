using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Pixel_Adventure_1.Assets.Scripts.Player
{
    public class PlayerDash : MonoBehaviour
    {
        public ParticleSystem DashParticles;
        public Image DashImage;
        public bool IsDashing { get; private set; }
        
        [SerializeField] private float _dashForce = 6f;
        private Rigidbody2D _rb;
        private float _originalGravity;

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            _originalGravity = _rb.gravityScale;
        }

        void Update()
        {

            //dash
            if (Input.GetKeyDown(KeyCode.LeftShift) && transform.localScale.x > 0)
            {
                DashFunc(1);

            }

            if (Input.GetKeyDown(KeyCode.LeftShift) && transform.localScale.x < 0)
            {
                DashFunc(-1);
            }
        }

        private void DashFunc(int x)
        {
            _rb.AddForce(new Vector2(x, 0) * _dashForce, ForceMode2D.Impulse);
            _rb.gravityScale = 0;
            IsDashing = true;
            Invoke(nameof(StopDashing), 0.2f);
            LockDash();
            DashParticles.Play();
        }

        private void StopDashing()
        {
            _rb.gravityScale = _originalGravity;
            IsDashing = false;
        }

        private IEnumerator FillImageSmooth(float duration)
        {
            float time = 0; // сколько уже прошло времени
            while (DashImage.fillAmount < 1)
            {
                time += Time.deltaTime;
                DashImage.fillAmount = time / duration;
                yield return null;
            }

            GetComponent<PlayerDash>().enabled = true;
        }

        private void LockDash()
        {
            DashImage.fillAmount = 0;
            StartCoroutine(FillImageSmooth(5)); // заполнить до 1 за 5 секунд
            GetComponent<PlayerDash>().enabled = false;
        }
    }
}