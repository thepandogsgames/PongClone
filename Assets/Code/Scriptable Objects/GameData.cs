using UnityEngine;

namespace Code.Scriptable_Objects
{
    [CreateAssetMenu(fileName = "GameData", menuName = "Data/GameData")]
    public class GameData : ScriptableObject
    {
        [Header("Single Game")] 
        [SerializeField] private GameObject player;
        [SerializeField] private GameObject enemy;
        [Header("Multi Game")] 
        [SerializeField] private GameObject player1;
        [SerializeField] private GameObject player2;

        private bool _isMultiplayer = true;

        public GameObject Player => player;

        public GameObject Enemy => enemy;

        public GameObject Player1 => player1;

        public GameObject Player2 => player2;
        
        public bool IsMultiplayer
        {
            get => _isMultiplayer;
            set => _isMultiplayer = value;
        }
    }
}
