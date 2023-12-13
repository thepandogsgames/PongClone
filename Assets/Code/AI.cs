using Code.Input;
using UnityEngine;

namespace Code
{
    [RequireComponent(typeof(IInput))]
    public class AI : MonoBehaviour
    {
        private IInput _inputActor;
        private float _direction;
        private Transform _ballTransform;
        private Rigidbody2D _ballRb;
        
        private void Awake()
        {
            _ballTransform = GameObject.FindGameObjectWithTag("Ball").GetComponent<Transform>();
            _ballRb = GameObject.FindGameObjectWithTag("Ball").GetComponent<Rigidbody2D>();
            _inputActor = GetComponent<IInput>();
        }

        private void FixedUpdate()
        {
            CalculateBallPosition();
            _inputActor.MovementDirectionPressed(_direction);
        }

        private void CalculateBallPosition()
        {
            if (_ballRb.velocity.x < 0f)
            {
                _direction = 0f;
                return;
            }
            if (_ballTransform.position.y > transform.position.y)
            {
                _direction = 0.35f;
            }
            else if(_ballTransform.position.y < transform.position.y)
            {
                _direction = -0.35f;
            }
            else
            {
                _direction = 0f;
            }
        }
    }
}
