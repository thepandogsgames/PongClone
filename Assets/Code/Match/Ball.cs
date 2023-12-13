using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Code.Match
{
    public class Ball : MonoBehaviour
    {
        [SerializeField] private float speed;
        private Transform _transform;
        private Rigidbody2D _rb;
        private float _height;
        private Vector3 _startPosition;
        private Vector3 _direction;
        private float _acelerationTime = 0.5f;
        
        private void Awake()
        {
            _transform = GetComponent<Transform>();
            _rb = GetComponent<Rigidbody2D>();
            _startPosition = Vector3.zero;
            Reset();
        }

        public void Reset()
        {
            _rb.velocity = Vector2.zero;
            _height = Random.Range(-4f, 4f);
            _startPosition.y = _height;
            _transform.position = _startPosition;
            SetDirection();
            StartCoroutine(StartMovement());
        }

        private void SetDirection()
        {
            _direction.x = 1f;
            _direction.y = 0.5f;
            if (Random.Range(0f, 1f) > 0.5f)
            {
                _direction *= -1;
            }
        }

        private IEnumerator StartMovement()
        {
            float currentTime = 0f;
            float progress = 0f;
            float currentSpeed = 0f;

            while (_acelerationTime > currentTime)
            {
                progress = currentTime / _acelerationTime;
                currentSpeed = Mathf.Lerp(0f, speed, progress);
                _rb.velocity = _direction * currentSpeed;
                currentTime += Time.deltaTime;
                yield return null;
            }
        }
    }
}
