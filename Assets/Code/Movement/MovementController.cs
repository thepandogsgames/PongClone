using UnityEngine;

namespace Code.Movement
{
    public class MovementController : MonoBehaviour
    {
        [SerializeField] private float speed;

        private IMovement _movement;
        private Vector2 _direction = Vector2.zero;

        private void Awake()
        {
            _movement = new Movement();
            _movement.Config(GetComponent<Rigidbody2D>(), speed);
        }

        private void FixedUpdate()
        {
            _movement.Move(_direction);
        }

        public void SetDirection(float direction)
        {
            _direction.y = direction;
        }
    }
}
