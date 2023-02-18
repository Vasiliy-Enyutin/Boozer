using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(PlayerMovement))]
    public class PlayerAnimator : MonoBehaviour
    {
        [SerializeField]
        private Animator _animator;
        [SerializeField]
        private Transform _playerGFX;

        private PlayerMovement _playerMovement;
        private Vector3 _baseScale;

        private void Awake()
        {
            _baseScale = _playerGFX.localScale;
            _playerMovement = GetComponent<PlayerMovement>();
        }

        private void Update()
        {
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
                _playerGFX.localScale = new Vector3(-_baseScale.x, _baseScale.y, _baseScale.z);
                _animator.Play("Run_side");
            }
            else if (direction.x < 0)
            {
                _playerGFX.localScale = new Vector3(_baseScale.x, _baseScale.y, _baseScale.z);
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
    }
}
