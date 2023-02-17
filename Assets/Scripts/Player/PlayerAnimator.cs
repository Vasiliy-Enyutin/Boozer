using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(PlayerMovement))]
    public class PlayerAnimator : MonoBehaviour
    {
        [SerializeField]
        private Animator _animator;

        private PlayerMovement _playerMovement;

        private void Awake()
        {
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
                if (transform.localScale.x > 0)
                {
                    FlipX();
                }
                _animator.Play("Run_side");
            }
            else if (direction.x < 0)
            {
                if (transform.localScale.x < 0)
                {
                    FlipX();
                }
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

        private void FlipX()
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
    }
}
