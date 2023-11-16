using Code.Input;
using Code.Movement;
using UnityEngine;

namespace Code
{
    public class Player : MonoBehaviour, IInput
    {
        private MovementController _movementController;
        private AudioSource _audioSource;

        private void Awake()
        {
            _movementController = GetComponent<MovementController>();
            _audioSource = GetComponent<AudioSource>();
            _audioSource.Stop();
        }

        public void MovementDirectionPressed(float direction)
        {
            _movementController.SetDirection(direction);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Ball"))
            {
                _audioSource.PlayOneShot(_audioSource.clip);
            }
        }
    }
}
