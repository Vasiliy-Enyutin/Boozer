using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using Player;
using UnityEngine;

namespace Enemy
{
    [RequireComponent(typeof(AIPath))]
    public class EnemyCatcher : MonoBehaviour
    {
        private const float WAIT_DURATION = 2f;
        private AIPath _aiPath;
        private EndgameInformer _endgameInformer;
        private PlayerMovement _playerMovement;

        private void Awake()
        {
            _aiPath = GetComponent<AIPath>();
        }

        private void Start()
        {
            _playerMovement = FindObjectOfType<PlayerMovement>();
            _playerMovement.OnControlsChanged += PausePathfinding;
            _endgameInformer = FindObjectOfType<EndgameInformer>();
        }

        private void Update()
        {
            if (_aiPath.reachedEndOfPath)
            {
                _endgameInformer.InvokeOnCatched();
            }
        }

        private void PausePathfinding(Dictionary<MovementDirection, ControlButton> obj)
        {
            StartCoroutine(WaitRoutine());
        }

        private IEnumerator WaitRoutine()
        {
            _aiPath.isStopped = true;
            yield return new WaitForSeconds(WAIT_DURATION);
            _aiPath.isStopped = false;
        }
    }
}
