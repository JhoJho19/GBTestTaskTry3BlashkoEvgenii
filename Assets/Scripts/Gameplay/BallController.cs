using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Gameplay
{
    public class BallController : MonoBehaviour
    {
        [SerializeField] private Rigidbody ballRigidbody;
        [SerializeField] private float moveSpeed;
        [SerializeField] private float jumpForce;
        [SerializeField] AudioSource jumpSound;
        private bool _isMoving;
        private bool _isOnGround;
        private float _moveHorizontal;
        private float _moveVertical;

        public UnityEvent OnMovementStart;

        private void Update()
        {
            _moveHorizontal = Input.GetAxis("Horizontal");
            _moveVertical = Input.GetAxis("Vertical");

            if (!_isMoving && (_moveHorizontal != 0 || _moveVertical != 0))
            {
                _isMoving = true;
                OnMovementStart.Invoke();
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
        }

        private void FixedUpdate()
        {
            _isOnGround = Physics.Raycast(transform.position, Vector3.down, 0.5f);

            Vector3 movement = new Vector3(_moveHorizontal, 0.0f, _moveVertical);
            ballRigidbody.AddForce(movement * moveSpeed);
        }

        private void Jump()
        {
            if (_isOnGround)
            {
                jumpSound.Play();

                ballRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }
    }
}
