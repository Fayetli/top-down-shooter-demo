using UnityEngine;
using System;
using TopDown.Gameplay.FireSystem;
using UnityEngine.SceneManagement;

namespace TopDown.Gameplay
{
    public class Character : MonoBehaviour
    {
        [SerializeField] private FireController fireController;
        public int Score { get; private set; }

        public Action<int> OnScoreChanged;

        private void Start()
        {
            fireController.Init(IncreaseScore);
        }

        private void IncreaseScore()
        {
            Score++;
            OnScoreChanged?.Invoke(Score);
            print("Score: " + Score);
        }

        public void OnDamaged()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}