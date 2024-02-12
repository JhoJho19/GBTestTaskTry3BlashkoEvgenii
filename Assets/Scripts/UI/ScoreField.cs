using TMPro;
using UnityEngine;
using Data;

namespace UI 
{
    public class ScoreField : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI UITextMeshPro;

        private void OnEnable()
        {
            UpdateCoinCounterText();
            GameProgressManager.Instance.OnIncrementScore.AddListener(UpdateCoinCounterText);
            GameProgressManager.Instance.OnDecrementScore.AddListener(UpdateCoinCounterText);
        }

        public void UpdateCoinCounterText()
        {
            UITextMeshPro.text = GameProgressManager.Instance.CoinCounter.ToString();
        }
    }

}