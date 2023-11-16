using UnityEngine;
using UnityEngine.InputSystem;

namespace Code.Input
{
    [RequireComponent(typeof(IInput))]
    public class InputListener : MonoBehaviour
    {
        private IInput _inputActor;
        private float _direction;
        
        private void Awake()
        {
            _inputActor = GetComponent<IInput>();
        }

        public void MovementButtonPressed(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                _direction = context.ReadValue<Vector2>().y;
                _inputActor.MovementDirectionPressed(_direction);
            }

            if (context.canceled)
            {
                _direction = 0f;
                _inputActor.MovementDirectionPressed(_direction);
            }
        }
    }
}
