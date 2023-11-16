using UnityEngine;

namespace Code.Match
{
    public class Limit : MonoBehaviour
    {
        private AudioSource _audioSource;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
            _audioSource.Stop();
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
