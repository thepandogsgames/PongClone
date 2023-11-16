using Code.Scriptable_Objects;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code
{
    public class MenuManager : MonoBehaviour
    {
        [SerializeField] private GameData gameData;
        
        public void SinglePlayerSelected()
        {
            gameData.IsMultiplayer = false;
            LoadScene();
        }
        
        public void MultiPlayerSelected()
        {
            gameData.IsMultiplayer = true;
            LoadScene();
        }

        private void LoadScene()
        {
            SceneManager.LoadScene("GameScene");
        }
    }
}
