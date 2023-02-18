using Pathfinding;
using UnityEngine;

namespace Enemy
{
    [RequireComponent(typeof(AIPath))]
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField]
        private Animator _animator;
        [SerializeField]
        private Transform _enemyGFX;
        
        private AIPath _aiPath;
        private Vector3 _baseScale;

        private void Awake()
        {
            _baseScale = _enemyGFX.localScale;
            _aiPath = GetComponent<AIPath>();
        }

        private void Update()
        {
            UpdateAnimation();
        }

        private void UpdateAnimation()
        {
            if (_aiPath.velocity.magnitude <= Mathf.Epsilon)
            {
                _animator.Play("Idle");
            }
            else if (Mathf.Abs(_aiPath.velocity.x) > Mathf.Abs(_aiPath.velocity.y))
            {
                if (_aiPath.velocity.x > 0)
                {
                    _enemyGFX.localScale = new Vector3(-_baseScale.x, _baseScale.y, _baseScale.z);
                    _animator.Play("Run_side");
                }
                else if (_aiPath.velocity.x < 0)
                {
                    _enemyGFX.localScale = new Vector3(_baseScale.x, _baseScale.y, _baseScale.z);
                    _animator.Play("Run_side");
                }
            }
            else if (Mathf.Abs(_aiPath.velocity.x) < Mathf.Abs(_aiPath.velocity.y))
            {
                if (_aiPath.velocity.y > 0)
                {
                    _animator.Play("Run_up");
                }
                else if (_aiPath.velocity.y < 0)
                {
                    _animator.Play("Run_down");
                }
            }
        }
    }
}
