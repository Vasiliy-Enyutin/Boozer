using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(PlayerMovement))]
    public class PlayerAnimator : MonoBehaviour
    {
        [SerializeField]
        private Animator _animator;
        [SerializeField]
        private SpriteRenderer _playerSprite;

        private const float DRINK_DURATION = 2f;
        private PlayerMovement _playerMovement;
        private bool _isDrinking = false;

        private void Awake()
        {
            _playerMovement = GetComponent<PlayerMovement>();
            _playerMovement.OnControlsChanged += PlayDrinkAnimation;
        }

        private void Update()
        {
            if (_isDrinking == true)
            {
                return;
            }
            UpdateAnimation();
        }

        private void UpdateAnimation()
        {
            Vector2 direction = _playerMovement.MoveDirection;
            if (direction.magnitude <= Mathf.Epsilon)
            {
                _animator.Play("Idle");
            }
            else if (direction.x > 0)
            {
                _playerSprite.flipX = true;
                _animator.Play("Run_side");
            }
            else if (direction.x < 0)
            {
                _playerSprite.flipX = false;
                _animator.Play("Run_side");
            }
            else if (direction.y > 0)
            {
                _animator.Play("Run_up");
            }
            else if (direction.y < 0)
            {
                _animator.Play("Run_down");
            }
        }

        private void PlayDrinkAnimation(Dictionary<MovementDirection, ControlButton> controlButtons)
        {
            // TODO анимация питья вместо idle
            _animator.Play("Idle");
            StartCoroutine(WaitForDrinkAnimation());
        }

        private IEnumerator WaitForDrinkAnimation()
        {
            _isDrinking = true;
            yield return new WaitForSeconds(DRINK_DURATION);
            _isDrinking = false;
        }
    }
}
