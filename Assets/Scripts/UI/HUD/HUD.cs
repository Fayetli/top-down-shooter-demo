using UnityEngine;
using TMPro;
using TopDown.Gameplay;

namespace TopDown.UI
{
    public class HUD : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI scoreTMP;
        [SerializeField] private Character character;

        private void Start()
        {
            character.OnScoreChanged += OnUpdatedScore;
        }

        private void OnUpdatedScore(int score)
        {
            scoreTMP.text = score.ToString();
        }
    }
}