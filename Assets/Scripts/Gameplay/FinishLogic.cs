using UnityEngine;
using System.Collections;
using Data;
using NonMonobech;

namespace Gameplay 
{
    public class FinishLogic : MonoBehaviour
    {
        [SerializeField] private ParticleSystem[] particleSystemFirework;
        [SerializeField] AudioSource audioSource;
        private NextSceneLoader _nextSceneLoader;

        private void Start()
        {
            _nextSceneLoader = new NextSceneLoader();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Ball"))
            {
                BallController ballController = other.GetComponent<BallController>();
                if (ballController != null)
                {
                    foreach (var particle in particleSystemFirework)
                    {
                        particle.Play();
                    }
                    audioSource.Play();

                    ballController.enabled = false;
                    StartCoroutine(WaitAndLoad(2f));
                }
            }
        }

        IEnumerator WaitAndLoad(float time)
        {
            yield return new WaitForSeconds(time);
            _nextSceneLoader.LoadNextScene();
        }
    }
}

