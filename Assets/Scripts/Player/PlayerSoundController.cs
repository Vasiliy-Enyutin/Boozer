using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(PlayerMovement))]
    [RequireComponent(typeof(AudioManager))]
    public class PlayerSoundController : MonoBehaviour
    {
        private PlayerMovement _playerMovement;
        private AudioManager _audioManager;

        private void Awake()
        {
            _playerMovement = GetComponent<PlayerMovement>();
            _audioManager = GetComponent<AudioManager>();
        }

        private void Update()
        {
            if (_playerMovement.MoveDirection.magnitude > Mathf.Epsilon)
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
