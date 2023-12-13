using System;
using UnityEngine;

namespace Code.Movement
{
    public class MovementController : MonoBehaviour
    {
        [SerializeField] private float speed;

        private IMovement _movement;
        private Vector2 _direction = Vector2.zero;
        private Rigidbody2D _rb;
        private Camera _camera;

        private void Awake()
        {
            _movement = new Movement();
            _movement.Config(GetComponent<Rigidbody2D>(), speed);
            _rb = GetComponent<Rigidbody2D>();
            _camera = Camera.main;
        }

        private void Update()
        {
            ClampFinalPosition();
        }

        private void FixedUpdate()
        {
            _movement.Move(_direction);
        }

        public void SetDirection(float direction)
        {
            _direction.y = direction;
        }
        
        private void ClampFinalPosition()
        {
            var viewportPoint = _camera.WorldToViewportPoint(_rb.position);
            viewportPoint.y = Mathf.Clamp(viewportPoint.y, 0.1f, 0.9f);
            _rb.position = _camera.ViewportToWorldPoint(viewportPoint);
        }
        
    }
}
