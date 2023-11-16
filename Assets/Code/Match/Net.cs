using UnityEngine;

namespace Code.Match
{
    public class Net : MonoBehaviour
    {
        private GameManager _gameManager;

        private void Awake()
        {
            _gameManager = FindObjectOfType<GameManager>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.gameObject.CompareTag("Ball")) return;
            _gameManager.AddScore(tag);
        }
    }
}
