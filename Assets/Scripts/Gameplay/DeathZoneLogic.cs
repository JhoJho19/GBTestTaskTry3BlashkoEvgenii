using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Gameplay
{
    public class DeathZoneLogic : MonoBehaviour
    {
        public UnityEvent OnDeathZone;
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Ball"))
            {
                other.gameObject.transform.position = new Vector3(0, 0.65f, -10);
                OnDeathZone.Invoke();
            }
        }
    }
}
