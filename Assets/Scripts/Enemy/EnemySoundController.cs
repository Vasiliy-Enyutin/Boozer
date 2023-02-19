using Pathfinding;
using UnityEngine;

namespace Enemy
{
    public class EnemySoundController : MonoBehaviour
    {
        private AIPath _aiPath;
        private AudioManager _audioManager;

        private void Awake()
        {
            _aiPath = GetComponent<AIPath>();
            _audioManager = GetComponent<AudioManager>();

        }

        private void Update()
        {
            if (_aiPath.velocity.magnitude > Mathf.Epsilon)
            {
                _audioManager.Play("Footsteps");
            }
            else
            {
                _audioManager.Stop("Footsteps");
            }
        }
    }
}
