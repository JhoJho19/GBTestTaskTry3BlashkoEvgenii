using UnityEngine;
using UnityEngine.Events;
using Gameplay;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

namespace Data
{
    public class GameProgressManager : MonoBehaviour
    {
        public static GameProgressManager Instance { get; private set; }
        public UnityEvent OnIncrementScore;
        public UnityEvent OnDecrementScore;

        public int LvlCount { get; set; }
        public int CoinCounter { get; set; }


        private void Awake()
        {
            LvlCount = 1;
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            CoinBehavior coinBehavior = FindObjectOfType<CoinBehavior>();
            if (coinBehavior != null)
            {
                coinBehavior.OnCoinTaken.AddListener(IncrementScore);
                coinBehavior.OnCoinReset.AddListener(DecrementScore);
            }
        }

        private void IncrementScore()
        {
            CoinCounter++;
            OnIncrementScore.Invoke();
        }

        private void DecrementScore()
        {
            CoinCounter--;
            OnDecrementScore.Invoke();
        }
    }
}
