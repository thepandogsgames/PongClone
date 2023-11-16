using UnityEngine;

namespace Code.Movement
{
    public class Movement : IMovement
    {
        private Rigidbody2D _rb;
        private float _speed;
        private Vector2 _direction;
        
        public void Move(Vector2 direction)
        {
            _direction.x = direction.x;
            _direction.y = direction.y * _speed;
            _rb.velocity = _direction;
        }

        public void Config(Rigidbody2D rb, float speed)
        {
            _rb = rb;
            _speed = speed;
        }
    }
}
