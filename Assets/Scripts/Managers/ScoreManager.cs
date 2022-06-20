using System.Globalization;
using Characters;
using TMPro;
using UnityEngine;

namespace Managers
{
    public class ScoreManager : MonoBehaviour
    {
        [Header("Comp")]
        [SerializeField]
        private TextMeshProUGUI scoreTextCount;

        // Private vars
        private float _score;

        private void OnEnable()
        {
            Ghost.OnGhostDeathScore += UpdateScore;
        }

        private void OnDisable()
        {
            Ghost.OnGhostDeathScore -= UpdateScore;
        }

        private void UpdateScore(float score)
        {
            _score += score;
            scoreTextCount.SetText(_score.ToString(CultureInfo.InvariantCulture));
        }
    }
}