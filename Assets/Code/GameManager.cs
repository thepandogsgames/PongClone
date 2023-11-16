using Code.Match;
using Code.Scriptable_Objects;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code
{
    public class GameManager : MonoBehaviour
    {
        [Header("Data")]
        [SerializeField] private GameData gameData;
        [Header("Positions")]
        [SerializeField] private Transform pos1;
        [SerializeField] private Transform pos2;
        [Header("UI")]
        [SerializeField] private TextMeshProUGUI scoreText1;
        [SerializeField] private TextMeshProUGUI scoreText2;
        [SerializeField] private GameObject endMenu;
        [SerializeField] private TextMeshProUGUI endText;
        [Space] 
        [SerializeField] private Ball ball;
        private GameObject _player1;
        private GameObject _player2;

        private int _score1;
        private int _score2;

        private AudioSource _audioSource;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
            LoadData();
            LoadGame();
            _audioSource.Stop();
        }

        private void LoadData()
        {
            if (gameData.IsMultiplayer)
            {
                _player1 = gameData.Player1;
                _player2 = gameData.Player2;
            }
            else
            {
                _player1 = gameData.Player;
                _player2 = gameData.Enemy;
            }
        }

        private void LoadGame()
        {
            Instantiate(_player1, pos1);
            Instantiate(_player2, pos2);
        }

        private bool MaxScoreReached(int score)
        {
            return score == 5;
        }

        private void EndGame(string playerName)
        {
            Time.timeScale = 0f;
            endMenu.SetActive(true);
            endText.text = playerName + " win!";
        }

        public void AddScore(string goTag)
        {
            _audioSource.PlayOneShot(_audioSource.clip);
            if (goTag.Equals("Net1"))
            {
                _score2++;
                scoreText2.text = _score2.ToString();
                if (MaxScoreReached(_score2))
                {
                    EndGame("Player2");
                }
            }
            else
            {
                _score1++;
                scoreText1.text = _score1.ToString();
                if (MaxScoreReached(_score1))
                {
                    EndGame("Player1");
                }
            }
            ball.Reset();
        }

        public void RestartGame()
        {
            Time.timeScale = 1f;
            LoadScene("GameScene");
        }

        public void ExitGame()
        {
            Time.timeScale = 1f;
            LoadScene("MainMenu");
        }


        private void LoadScene(string scene)
        {
            SceneManager.LoadScene(scene);
        }
    }
}
