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
            AddForce();
        }

        private void AddForce()
        {
            _direction.x = 1f;
            _direction.y = 0.5f;
            if (Random.Range(0f, 1f) > 0.5f)
            {
                _direction *= -1;
            }
            _rb.AddForce(_direction * speed, ForceMode2D.Impulse);
        }
    }
}
