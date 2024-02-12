using UnityEngine;
using UnityEngine.Events;

namespace Gameplay 
{
    public class CoinBehavior : MonoBehaviour
    {
        [SerializeField] AudioSource soundOfTakenCoin;
        public Animator CoinAnimator;
        public UnityEvent OnCoinTaken;
        public UnityEvent OnCoinReset;
        private bool _isCoinTaken;

        private void Start()
        {
            DeathZoneLogic deathZone = FindObjectOfType<DeathZoneLogic>();
            if (deathZone != null)
            {
                deathZone.OnDeathZone.AddListener(Restart);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!_isCoinTaken && other.gameObject.layer == LayerMask.NameToLayer("Ball"))
            {
                CoinAnimator.SetTrigger("CoinTaked");
                soundOfTakenCoin.Play();
                OnCoinTaken.Invoke();
                _isCoinTaken = true;
            }
        }

        private void Restart()
        {
            if (_isCoinTaken) 
            {
                OnCoinReset.Invoke();
                CoinAnimator.SetTrigger("Restart");
                _isCoinTaken = false;
            }
        }
    }
}